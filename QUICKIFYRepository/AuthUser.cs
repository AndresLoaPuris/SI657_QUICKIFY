using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUICKIFYRepository
{
	public class AuthUser
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Error : Ingresar Email")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Error : Ingresar Password")]
		public string Password { get; set; }
	}
}
