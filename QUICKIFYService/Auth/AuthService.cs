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
			return authRepository.getAccess(authUser);
		}

		public bool getUserExists(Users authUser)
		{
			return authRepository.getUserExists(authUser);
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
