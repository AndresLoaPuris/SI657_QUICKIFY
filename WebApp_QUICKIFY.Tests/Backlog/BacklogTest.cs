using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QUICKIFYRepository;
using QUICKIFYService.Backlog;

namespace WebApp_QUICKIFY.Tests.Backlog
{
	[TestClass]
	public class BacklogTest
	{
		[TestMethod]
		public void IdByProjectName_NameIsEmpty()
		{
			BacklogService authService = new BacklogService();
			Proyects proyect = new Proyects() { Name = "" };
			var result = authService.getIdByProjectName(proyect.Name);
			Assert.AreEqual(-1, result);
		}

		[TestMethod]
		public void TeamUsersByProjectName_NameIsEmpty()
		{
			BacklogService authService = new BacklogService();
			Proyects proyect = new Proyects() { Name = "" };
			var result = authService.getTeamUsersByProjectName(proyect.Name);
			Assert.IsNull(result);
		}


		[TestMethod]
		public void UserStoriesByProjectName_NameIsEmpty()
		{
			BacklogService authService = new BacklogService();
			Proyects proyect = new Proyects() { Name = "" };
			var result = authService.getUserStoriesByProjectName(proyect.Name);
			Assert.IsNull(result);
		}

	}
}
