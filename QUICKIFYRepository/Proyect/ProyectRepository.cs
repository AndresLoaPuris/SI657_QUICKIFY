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
		public SI657_Entities db = SI657_Entities.getInstance();

		public IEnumerable<Proyecto> getProyects(string email)
		{
			int id = db.Usuario.Where(s => s.Email == email).FirstOrDefault<Usuario>().Id;
			return db.Database.SqlQuery<Proyecto>("SELECT p.Id , p.Nombre , p.isDelete FROM Equipo e JOIN Proyecto p ON e.Proyecto_Id = p.Id WHERE p.isDelete = 0 and e.Usuario_Id = @Id ", new SqlParameter("Id", id)).ToList();
		}

		public void addProyect(string nombre) {
			Proyecto proyecto = new Proyecto();
			proyecto.Nombre = nombre;
			proyecto.isDelete = 0;
			db.Proyecto.Add(proyecto);
			db.SaveChanges();
		}

		public int lastProyect() { 
			return db.Proyecto.Max(p => p.Id);
		}

		public void addTeam(int lastProyect, string lider, Usuario[] usuarios) {
			Equipo tempequipo = new Equipo();
			tempequipo.Proyecto_Id = lastProyect;
			Usuario tempLider = SI657_Entities.getInstance().Usuario.Where(s => s.Nombre == lider).FirstOrDefault<Usuario>();
			tempequipo.Usuario_Id = tempLider.Id;
			tempequipo.isAdmin = 1;
			SI657_Entities.getInstance().Equipo.Add(tempequipo);

			foreach (var item in usuarios)
			{

				Equipo equipo = new Equipo();
				equipo.Proyecto_Id = lastProyect;
				Usuario temp = SI657_Entities.getInstance().Usuario.Where(s => s.Nombre == item.Nombre).FirstOrDefault<Usuario>();
				equipo.Usuario_Id = temp.Id;
				equipo.isAdmin = 0;
				SI657_Entities.getInstance().Equipo.Add(equipo);
				SI657_Entities.getInstance().SaveChanges();
			}

			SI657_Entities.getInstance().SaveChanges();
		}
	}
}
