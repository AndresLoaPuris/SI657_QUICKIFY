﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SI657_Entities : DbContext
    {
        public SI657_Entities()
            : base("name=SI657_Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<IntendedTimes> IntendedTimes { get; set; }
        public virtual DbSet<Proyects> Proyects { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Tasks> Tasks { get; set; }
        public virtual DbSet<Team> Team { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UserStories> UserStories { get; set; }
    }
}
