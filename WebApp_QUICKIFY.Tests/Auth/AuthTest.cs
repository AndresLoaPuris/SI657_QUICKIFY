
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QUICKIFYRepository;
using QUICKIFYRepository.Auth;
using QUICKIFYService.Auth;

namespace WebApp_QUICKIFY.Tests.Auth
{
	[TestClass]
	public class AuthTest
	{

		[TestMethod]
		public void Access_EmailIsEmpty_PasswordIsEmpty()
		{
			AuthService authService = new AuthService();
			AuthUser authUser = new AuthUser() { Email = "" , Password = "12345" };
			var result = authService.getAccess(authUser);
			Assert.IsFalse(result);
		}


		[TestMethod]
		public void UserExists_NameIsEmpty_EmailIsEmpty()
		{
			AuthService authService = new AuthService();
			Users authUser = new Users() { Name = "" , Email = "donaltrup@gmail.com" };
			var result = authService.getUserExists(authUser);
			Assert.IsFalse(result);
		}

	}
}
