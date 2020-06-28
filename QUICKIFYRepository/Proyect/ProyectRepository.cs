using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUICKIFYRepository.Proyect
{
	public class ProyectRepository
	{
		private SI657_Entities db = new SI657_Entities();

		public IEnumerable<Proyects> getProjectsByEmailFromTheUser(string emailUser)
		{
            int id = db.Users.Where(s => s.Email == emailUser).FirstOrDefault<Users>().Id;
			return db.Database.SqlQuery<Proyects>("SELECT p.Id , p.Name , p.isDelete FROM Team e JOIN Proyects p ON e.Proyect_Id = p.Id WHERE p.isDelete = 0 and e.User_Id = @Id ", new SqlParameter("Id", id)).ToList();

		}

        public IEnumerable<Users> getUsers(string email)
        {
            return db.Users.Where(s => s.Email != email);
        }

        public void getDispose()
        {
            db.Dispose();
        }

        public IEnumerable<Role> getRole()
        {
            return db.Role.Where(s => s.Id != 1);
        }

        public string getNameUSer(string email)
        {
            return db.Users.Where(s => s.Email == email).FirstOrDefault().Name;
        }

        public void addProyect(string nameProyect, Users[] users)
		{
            Proyects proyect = new Proyects();
            proyect.Name = nameProyect;
            proyect.isDelete = 0;
            db.Proyects.Add(proyect);
            db.SaveChanges();

            int lastProyect = db.Proyects.Max(p => p.Id);

            foreach (var item in users)
            {

                Team equipo = new Team();
                equipo.Proyect_Id = lastProyect;
                equipo.User_Id = db.Users.Where(s => s.Name == item.Name).FirstOrDefault<Users>().Id;
                equipo.Role_Id = db.Role.Where(s => s.Name == item.Password).FirstOrDefault<Role>().Id;
                db.Team.Add(equipo);
                db.SaveChanges();
            }

            db.SaveChanges();
        }
	}
}
