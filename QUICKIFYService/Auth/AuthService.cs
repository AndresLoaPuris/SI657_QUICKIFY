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

		public Usuario getUser(string Email) 
		{
			return authRepository.getUser(Email);
		}

		public bool getAccess(string Email, string Password)
		{
			return authRepository.getAccess(Email, Password);
		}

		public void addUser(Usuario usuario)
		{
			authRepository.addUser(usuario);
		}

	}
}
