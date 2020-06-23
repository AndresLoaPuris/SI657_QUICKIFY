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
		BoardRepository boardRepository = new BoardRepository();

		public IEnumerable<HistoriaUsuario> getUserStories(string proyectName)
		{
			return boardRepository.getUserStories(proyectName);
		}
	}
}
