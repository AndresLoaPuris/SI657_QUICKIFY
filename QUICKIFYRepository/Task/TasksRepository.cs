using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUICKIFYRepository.Task
{
	public class TasksRepository
	{

		private SI657_Entities db = new SI657_Entities();

		public IEnumerable<UserStories> getTasksByNameProyect(string nameProyect, string email)
		{
			return db.UserStories.Where(s => s.isDelete == 0 && s.Proyects.Name == nameProyect && s.Users.Email == email).ToList();
		}

		public IEnumerable<Tasks> getTasksByNameProyectAndIdUserStory(string nameProyect , int userStory_Id)
		{
			return db.Tasks.Where(s => s.isDelete == 0 && s.UserStories.Proyects.Name == nameProyect && s.UserStory_Id == userStory_Id).ToList();
		}

		public void finishTask(int? id, int? UserStory_id)
		{

            Tasks tasks = db.Tasks.Find(id);
            tasks.isCompleted = 1;
            db.Entry(tasks).State = EntityState.Modified;
            db.SaveChanges();

            UserStories userStories = db.UserStories.Find(UserStory_id);

            int userStoriesFinish = 0;

            foreach (var item in userStories.Tasks.Where(s => s.isDelete == 0))
            {
                if (item.isCompleted == 1)
                {
                    userStoriesFinish += 1;
                }
            }

            if (userStoriesFinish == 0)
            {
                userStories.StateKanban = "POR HACER";

            }
            else if (userStoriesFinish > 0 && userStoriesFinish < userStories.Tasks.Where(s => s.isDelete == 0).Count())
            {
                userStories.StateKanban = "EN CURSO";
            }
            else if (userStoriesFinish == userStories.Tasks.Where(s => s.isDelete == 0).Count())
            {
                userStories.StateKanban = "TERMINADO";
            }

            db.Entry(userStories).State = EntityState.Modified;
            db.SaveChanges();

        }


        public void restoreTask(int? id, int? UserStory_id)
        {
            Tasks tasks = db.Tasks.Find(id);
            tasks.isCompleted = 0;
            db.Entry(tasks).State = EntityState.Modified;
            db.SaveChanges();
            UserStories userStories = db.UserStories.Find(UserStory_id);

            int userStoriesFinish = 0;

            foreach (var item in userStories.Tasks.Where(s => s.isDelete == 0))
            {
                if (item.isCompleted == 1)
                {
                    userStoriesFinish += 1;
                }
            }

            if (userStoriesFinish == 0)
            {
                userStories.StateKanban = "POR HACER";

            }
            else if (userStoriesFinish > 0 && userStoriesFinish < userStories.Tasks.Where(s => s.isDelete == 0).Count())
            {
                userStories.StateKanban = "EN CURSO";
            }
            else if (userStoriesFinish == userStories.Tasks.Where(s => s.isDelete == 0).Count())
            {
                userStories.StateKanban = "TERMINADO";
            }

            db.Entry(userStories).State = EntityState.Modified;
            db.SaveChanges();
        }


        public void getDispose()
        {
            db.Dispose();
        }


        public void deleteTask(int? id)
        {
            Tasks tasks = db.Tasks.Find(id);
            tasks.isDelete = 1;
            db.Entry(tasks).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void editTask(Tasks tasks)
        {
            db.Entry(tasks).State = EntityState.Modified;
            db.SaveChanges();
        }

        public string getTitleUserStoryById(int id)
        { 
            return db.UserStories.Find(id).Title;
        }

        public Tasks getUserStoryById(int? id)
        {
            return db.Tasks.Find(id);
        }

        public void addTask(Tasks tasks)
        {
            db.Tasks.Add(tasks);
            db.SaveChanges();
        }

    }
}
