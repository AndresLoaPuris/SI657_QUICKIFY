using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUICKIFYRepository.Backlog
{
	public class BacklogRepository
	{
		private SI657_Entities db = new SI657_Entities();

		public UserStories getUserStoryById(int? id) 
		{
			return db.UserStories.Find(id);
		}

		public void editUserStory(UserStories userStories)
		{
			db.Entry(userStories).State = EntityState.Modified;
			db.SaveChanges();
		}

		public void addUserStory(UserStories userStories)
		{
			db.UserStories.Add(userStories);
			db.SaveChanges();
		}

		public IEnumerable<UserStories> getUserStoriesByProjectName(string nameProyect)
		{ 
			return db.UserStories.Where(s => s.isDelete == 0 && s.Proyects.Name == nameProyect).ToList();
		}

		public int getIdByProjectName(string nameProyect)
		{ 
			return db.Proyects.Where(s => s.Name == nameProyect).FirstOrDefault().Id;
		}

		public IEnumerable<Users> getTeamUsersByProjectName(string nameProyect)
		{
			int id = db.Proyects.Where(s => s.Name == nameProyect).FirstOrDefault<Proyects>().Id;
			return db.Database.SqlQuery<Users>("SELECT u.Id , u.Name , u.Email , u.Password FROM [dbo].[Users] u JOIN [dbo].[Team] t ON u.Id = t.User_Id WHERE t.Proyect_Id = @Id ", new SqlParameter("Id", id)).ToList();

		}

		public void deleteUserStoryById(int? id)
		{
			UserStories userStories = db.UserStories.Find(id);
			userStories.isDelete = 1;
			db.Entry(userStories).State = EntityState.Modified;
			db.SaveChanges();
		}

		public void getDispose()
		{
			db.Dispose();
		}
	}
}
