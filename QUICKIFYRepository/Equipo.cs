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
    
    public partial class Equipo
    {
        public int Id { get; set; }
        public int Usuario_Id { get; set; }
        public int isAdmin { get; set; }
        public int Proyecto_Id { get; set; }
    
        public virtual Proyecto Proyecto { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
