﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Dieser Code wurde aus einer Vorlage generiert.
//
//    Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten Ihrer Anwendung.
//    Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Filmverwaltung.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FilmverwaltungContext : DbContext
    {
        public FilmverwaltungContext()
            : base("name=FilmverwaltungContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Film> Film { get; set; }
        public DbSet<FilmSchauspieler> FilmSchauspieler { get; set; }
        public DbSet<Produzent> Produzent { get; set; }
        public DbSet<Schauspieler> Schauspieler { get; set; }
        public DbSet<SerieSchauspieler> SerieSchauspieler { get; set; }
        public DbSet<Serie> Serie { get; set; }
    }
}
