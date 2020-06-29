using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QUICKIFYRepository;
using QUICKIFYService.Proyect;

namespace WebApp_QUICKIFY.Tests.Proyect
{
	[TestClass]
	public class ProyectTest
	{
		[TestMethod]
		public void Users_EmailIsEmpty()
		{
			ProyectService proyectService = new ProyectService();
			Users users = new Users() { Email = "" };
			var result = proyectService.getUsers(users.Email);
			Assert.IsNull(result);
		}

		[TestMethod]
		public void ProjectsByEmailFromTheUser_EmailIsEmpty()
		{
			ProyectService proyectService = new ProyectService();
			Users users = new Users() { Email = "" };
			var result = proyectService.getProjectsByEmailFromTheUser(users.Email);
			Assert.IsNull(result);
		}
	}
}
