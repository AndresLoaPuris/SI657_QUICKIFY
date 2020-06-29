using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QUICKIFYRepository;
using QUICKIFYService.Task;

namespace WebApp_QUICKIFY.Tests.Task
{
	[TestClass]
	public class TaskTest
	{
		[TestMethod]
		public void TasksByNameProyect_NameIsEmpty()
		{
			TasksService tasksService = new TasksService();
			Proyects proyect = new Proyects() { Name = "" };
			var result = tasksService.getTasksByNameProyect(proyect.Name, "andresloa@gamil.com");
			Assert.IsNull(result);
		}
	}
}
