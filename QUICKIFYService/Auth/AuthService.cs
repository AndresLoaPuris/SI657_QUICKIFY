using QUICKIFYRepository;
using QUICKIFYRepository.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUICKIFYService.Auth
{
	public class AuthService
	{
		private AuthRepository authRepository = new AuthRepository();
		public bool getAccess(AuthUser authUser)
		{
			if (authUser.Email != string.Empty && authUser.Password != string.Empty)
			{
				return authRepository.getAccess(authUser);
			}
			else if (authUser.Email == string.Empty)
			{
				Console.WriteLine("Error: El campo Email no puede ser vacio");
				return false;

			}
			else if (authUser.Password == string.Empty) {
				Console.WriteLine("Error: El campo Password no puede ser vacio");
				return false;
			}
			return false;
		}

		public bool getUserExists(Users authUser)
		{
			if (authUser.Email != string.Empty && authUser.Name != string.Empty) {
				return authRepository.getUserExists(authUser);
			}
			else if (authUser.Email == string.Empty)
			{
				Console.WriteLine("Error: El campo Email no puede ser vacio");
				return false;

			}
			else if (authUser.Name == string.Empty)
			{
				Console.WriteLine("Error: El campo Nombre no puede ser vacio");
				return false;

			}

			return false;
		}
		public string getNameUser(AuthUser authUser)
		{
			return authRepository.getNameUser(authUser);
		}

		public void signUp(Users users)
		{
			authRepository.signUp(users);
		}

		public void getDispose()
		{
			authRepository.getDispose();
		}

	}
}
