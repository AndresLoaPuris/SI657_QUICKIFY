using QUICKIFYRepository;
using QUICKIFYRepository.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUICKIFYService.Board
{
	public class BoardService
	{

		private BoardRepository boardRepository = new BoardRepository();

		public IEnumerable<UserStories> getUserStoriesByNameProyect(string nameProyect)
		{
			if (nameProyect != string.Empty)
			{
				return boardRepository.getUserStoriesByNameProyect(nameProyect);
			}
			else {
				Console.WriteLine("Error: El campo Nombre no puede ser vacio");
				return null;
			}
			
		}

	}
}
