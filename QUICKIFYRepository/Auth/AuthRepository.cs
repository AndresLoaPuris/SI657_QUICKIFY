using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUICKIFYRepository.Auth
{
	public class AuthRepository
	{

		private SI657_Entities db = new SI657_Entities();

		public bool getAccess(AuthUser authUser) {
			return db.Users.Any(x => x.Email == authUser.Email && x.Password == authUser.Password);
		}

		public bool getUserExists(Users authUser)
		{
			return db.Users.Any(x => x.Email == authUser.Email || x.Name == authUser.Name);
		}
		public string getNameUser(AuthUser authUser) {
			return db.Users.Where(s => s.Email == authUser.Email).FirstOrDefault<Users>().Name;
		}

		public void signUp(Users users) {
			db.Users.Add(users);
			db.SaveChanges();
		}

		public void getDispose() {
			db.Dispose();
		}

	}
}
