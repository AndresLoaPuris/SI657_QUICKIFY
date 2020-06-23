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
		private ProyectRepository proyectRepository = new ProyectRepository();

		public void addProyect(string nombre) {
			proyectRepository.addProyect(nombre);
		}

		public IEnumerable<Proyecto> getProyects(string email)
		{
			return proyectRepository.getProyects(email);
		}


		public int lastProyect() {
			return proyectRepository.lastProyect();
		}

		public void addTeam(int lastProyect, string lider, Usuario[] usuarios) {
			proyectRepository.addTeam(lastProyect, lider, usuarios);
		}

	}
}
