using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUICKIFYRepository.Board
{
	public class BoardRepository
	{
		private SI657_Entities db = new SI657_Entities();

		public IEnumerable<UserStories> getUserStoriesByNameProyect(string nameProyect) {

            var userStories = db.UserStories.ToList().Where(s => s.isDelete == 0 && s.Proyects.Name == nameProyect);


            foreach (var item in userStories)
            {

                int userStoriesFinish = 0;

                foreach (var task in item.Tasks.Where(x => x.isDelete == 0))
                {
                    if (task.isCompleted == 1)
                    {
                        userStoriesFinish += 1;
                    }
                }

                if (userStoriesFinish == 0)
                {
                    item.StateKanban = "POR HACER";

                }
                else if (userStoriesFinish > 0 && userStoriesFinish < item.Tasks.Where(x => x.isDelete == 0).Count())
                {
                    item.StateKanban = "EN CURSO";
                }
                else if (userStoriesFinish == item.Tasks.Where(x => x.isDelete == 0).Count())
                {
                    item.StateKanban = "TERMINADO";
                }

                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
            }


            return userStories;
        }

    }
}
