using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUICKIFYRepository.Board
{
	public class BoardRepository
	{

		public SI657_Entities db = SI657_Entities.getInstance();

		public IEnumerable<HistoriaUsuario> getUserStories(string proyectName)
		{
			return db.HistoriaUsuario.ToList().Where(s => s.isDelete == 0 && s.Proyecto.Nombre == proyectName);
		}
	}
}
