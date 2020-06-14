using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUICKIFYRepository.Auth
{
	public class AuthRepository
	{
		private SI657_Entities db = SI657_Entities.getInstance();

		public Usuario getUser(string Email) {

			
			return db.Usuario.Where(s => s.Email == Email).FirstOrDefault<Usuario>();
		}

		public bool getAccess(string Email, string Password) {

			return db.Usuario.Any(x => x.Email == Email && x.Password == Password);
		}

		public void addUser(Usuario usuario) {

			db.Usuario.Add(usuario);
			db.SaveChanges();
		}

	}
}
