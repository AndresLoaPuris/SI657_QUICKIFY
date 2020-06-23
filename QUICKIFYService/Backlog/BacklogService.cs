using QUICKIFYRepository;
using QUICKIFYRepository.Backlog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUICKIFYService.Backlog
{
	public class BacklogService
	{

		private BacklogRepository backlogRepository = new BacklogRepository();

		public IEnumerable<HistoriaUsuario> getUserStories(string proyectName)
		{
			return backlogRepository.getUserStories(proyectName).OrderBy(s => s.Sprint);
		}


		public string getUserStoryTitle(int id)
		{
			return backlogRepository.getUserStoryTitle(id);
		}

		public IEnumerable<Tarea> getTasksByIdOfAUserStory(int id)
		{
			return backlogRepository.getTasksByIdOfAUserStory(id);
		}

		public void deleteUserStory(int? id)
		{
			backlogRepository.deleteUserStory(id);
		}

		public void deleteTask(int? id)
		{
			backlogRepository.deleteTask(id);
		}

		public HistoriaUsuario getUserStoryById(int? id)
		{
			return backlogRepository.getUserStoryById(id);
		}

		public void editUserStory(HistoriaUsuario historiaUsuario)
		{
			backlogRepository.editUserStory(historiaUsuario);
		}

		public void addUserStory(HistoriaUsuario historiaUsuario)
		{
			backlogRepository.addUserStory(historiaUsuario);
		}

		public void editTask(Tarea tarea)
		{
			backlogRepository.editTask(tarea);
		}

		public void addTask(Tarea tarea)
		{
			backlogRepository.addTask(tarea);
		}

		public Tarea getTaskById(int? id)
		{
			return backlogRepository.getTaskById(id);
		}

		public int getIdProyectByName(string proyectName)
		{
			return backlogRepository.getIdProyectByName(proyectName);
		}
	}
}
