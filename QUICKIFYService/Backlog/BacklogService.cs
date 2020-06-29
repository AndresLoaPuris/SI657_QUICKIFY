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
		BacklogRepository backlogRepository = new BacklogRepository();

		public IEnumerable<UserStories> getUserStoriesByProjectName(string nameProyect)
		{
			if (nameProyect != string.Empty)
			{
				return backlogRepository.getUserStoriesByProjectName(nameProyect);
			}
			else
			{
				Console.WriteLine("Error: El campo Name del Proyecto no puede ser vacio");
				return null;
			}
		}

		public int getIdByProjectName(string nameProyect)
		{
			if (nameProyect != string.Empty)
			{
				return backlogRepository.getIdByProjectName(nameProyect);
			}
			else
			{
				Console.WriteLine("Error: El campo Name del Proyecto no puede ser vacio");
				return -1;
			}
		}

		public UserStories getUserStoryById(int? id)
		{
			return backlogRepository.getUserStoryById(id);
		}

		public IEnumerable<Users> getTeamUsersByProjectName(string nameProyect)
		{
			if (nameProyect != string.Empty)
			{
				return backlogRepository.getTeamUsersByProjectName(nameProyect);
			}
			else {
				Console.WriteLine("Error: El campo Name del Proyecto no puede ser vacio");
				return null;
			}
		}

		public void addUserStory(UserStories userStories)
		{
			backlogRepository.addUserStory(userStories);
		}

		public void editUserStory(UserStories userStories)
		{
			backlogRepository.editUserStory(userStories);
		}

		public void getDispose()
		{
			backlogRepository.getDispose();
		}

		public void deleteUserStoryById(int? id)
		{
			backlogRepository.deleteUserStoryById(id);
		}

	}
}
