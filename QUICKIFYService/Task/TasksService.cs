using QUICKIFYRepository;
using QUICKIFYRepository.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUICKIFYService.Task
{
	public class TasksService
	{

		TasksRepository tasksRepository = new TasksRepository();

		public IEnumerable<UserStories> getTasksByNameProyect(string nameProyect, string email)
		{
			if (nameProyect != string.Empty && email != string.Empty)
			{
				return tasksRepository.getTasksByNameProyect(nameProyect, email);
			}
			else
			{
				Console.WriteLine("Error: El campo Nombre no puede ser vacio");
				return null;
			}
				
		}

		public void getDispose()
		{
			tasksRepository.getDispose();
		}

		public string getTitleUserStoryById(int id)
		{
			return tasksRepository.getTitleUserStoryById(id);
		}

		public Tasks getUserStoryById(int? id)
		{
			return tasksRepository.getUserStoryById(id);
		}

		public void addTask(Tasks tasks)
		{
			tasksRepository.addTask(tasks);
		}

		public void deleteTask(int? id)
		{
			tasksRepository.deleteTask(id);
		}

		public void editTask(Tasks tasks)
		{
			tasksRepository.editTask(tasks);
		}

		public IEnumerable<Tasks> getTasksByNameProyectAndIdUserStory(string nameProyect, int userStory_Id)
		{
			return tasksRepository.getTasksByNameProyectAndIdUserStory(nameProyect, userStory_Id);
		}

		public void finishTask(int? id, int? UserStory_id)
		{
			tasksRepository.finishTask(id, UserStory_id);
		}

		public void restoreTask(int? id, int? UserStory_id)
		{ 
			tasksRepository.restoreTask(id, UserStory_id);
		}
	}
}
