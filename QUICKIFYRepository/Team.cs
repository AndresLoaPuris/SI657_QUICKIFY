//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QUICKIFYRepository
{
    using System;
    using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;

	public partial class Team
    {
        public int Id { get; set; }
        
        public int User_Id { get; set; }
        
        public int Proyect_Id { get; set; }
        
        public int Role_Id { get; set; }
    
        public virtual Proyects Proyects { get; set; }
        public virtual Role Role { get; set; }
        public virtual Users Users { get; set; }
    }
}
