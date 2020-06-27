using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUICKIFYRepository
{
	public class DefStateKanban
	{
		public DefStateKanban() {
			Name = new List<string>();
			Name.Add("POR HACER");
			Name.Add("EN CURSO");
			Name.Add("TERMINADO");
		}
		public List<string> Name { get; set; }
	}
}
