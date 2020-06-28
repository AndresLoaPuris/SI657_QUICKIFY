using QUICKIFYRepository;
using QUICKIFYRepository.Proyect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUICKIFYService.Proyect
{
	public class ProyectService
	{

		ProyectRepository proyectRepository = new ProyectRepository();

		public IEnumerable<Proyects> getProjectsByEmailFromTheUser(string emailUser)
		{
			return proyectRepository.getProjectsByEmailFromTheUser(emailUser);
		}

		public void getDispose()
		{
			proyectRepository.getDispose();
		}

		public string getNameUSer(string email)
		{
			return proyectRepository.getNameUSer(email);
		}

		public IEnumerable<Users> getUsers(string email)
		{
			return proyectRepository.getUsers(email);
		}

		public IEnumerable<Role> getRole()
		{
			return proyectRepository.getRole();
		}

		public void addProyect(string nameProyect, Users[] users)
		{
			proyectRepository.addProyect(nameProyect, users);
		}

	}
}
