﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HelpUs
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DbHelpUsEntities : DbContext
    {
        public DbHelpUsEntities()
            : base("name=DbHelpUsEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Casos> Casos { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Empresas> Empresas { get; set; }
        public DbSet<Login> Login { get; set; }
        public DbSet<OutrasEmpresas> OutrasEmpresas { get; set; }
        public DbSet<PessoasSolicitantes> PessoasSolicitantes { get; set; }
    }
}