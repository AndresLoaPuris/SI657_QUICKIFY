using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUICKIFYRepository.Backlog
{
	public class BacklogRepository
	{
		public SI657_Entities db = SI657_Entities.getInstance();


		public IEnumerable<HistoriaUsuario> getUserStories(string proyectName)
		{
			var db = new SI657_Entities();
			return db.HistoriaUsuario.ToList().Where(s => s.isDelete == 0 && s.Proyecto.Nombre == proyectName);
		}


		public string getUserStoryTitle(int id)
		{
			return db.HistoriaUsuario.Find(id).Titulo;
		}

		public IEnumerable<Tarea> getTasksByIdOfAUserStory(int id)
		{
			var db = new SI657_Entities();
			return db.Tarea.ToList().Where(s => s.isDelete == 0 && s.HistoriaUsuario_Id == id);
		}

		public void addTask(Tarea tarea)
		{
			var db = new SI657_Entities();
			db.Tarea.Add(tarea);
			db.SaveChanges();
		}
		public void deleteUserStory(int? id)
		{
			HistoriaUsuario historiaUsuario = db.HistoriaUsuario.Find(id);
			historiaUsuario.isDelete = 1;
			db.Entry(historiaUsuario).State = EntityState.Modified;
			db.SaveChanges();
		}


		public void deleteTask(int? id)
		{
			Tarea tarea = db.Tarea.Find(id);
			tarea.isDelete = 1;
			db.Entry(tarea).State = EntityState.Modified;
			db.SaveChanges();
		}

		public void editUserStory(HistoriaUsuario historiaUsuario)
		{
			var db = new SI657_Entities();
			db.Entry(historiaUsuario).State = EntityState.Modified;
			db.SaveChanges();
		}

		public void editTask(Tarea tarea)
		{
			var db = new SI657_Entities();
			db.Entry(tarea).State = EntityState.Modified;
			db.SaveChanges();
		}

		public void addUserStory(HistoriaUsuario historiaUsuario)
		{
			var db = new SI657_Entities();
			db.HistoriaUsuario.Add(historiaUsuario);
			db.SaveChanges();
		}

		public Tarea getTaskById(int? id)
		{
			return db.Tarea.Find(id);
		}

		public HistoriaUsuario getUserStoryById(int? id)
		{
			return db.HistoriaUsuario.Find(id);
		}


		public int getIdProyectByName(string proyectName)
		{ 
			return db.Proyecto.Where(s => s.Nombre == proyectName).FirstOrDefault().Id;
		}
	}
}
