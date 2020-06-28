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
			return backlogRepository.getUserStoriesByProjectName(nameProyect);
		}

		public int getIdByProjectName(string nameProyect)
		{
			return backlogRepository.getIdByProjectName(nameProyect);
		}

		public UserStories getUserStoryById(int? id)
		{
			return backlogRepository.getUserStoryById(id);
		}

		public IEnumerable<Users> getTeamUsersByProjectName(string nameProyect)
		{
			return backlogRepository.getTeamUsersByProjectName(nameProyect);
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
