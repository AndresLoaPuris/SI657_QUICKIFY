using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QUICKIFYRepository;
using QUICKIFYService.Board;

namespace WebApp_QUICKIFY.Tests.Board
{
	[TestClass]
	public class BoardTest
	{
		[TestMethod]
		public void UserStoriesByNameProyect_NameIsEmpty()
		{
			BoardService authService = new BoardService();
			Proyects proyect = new Proyects() { Name = "" };
			var result = authService.getUserStoriesByNameProyect(proyect.Name);
			Assert.IsNull(result);
		}
	}
}
