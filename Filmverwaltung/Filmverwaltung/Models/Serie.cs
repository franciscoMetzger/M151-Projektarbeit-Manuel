//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Serie
    {
        public Serie()
        {
            this.SerieSchauspieler = new HashSet<SerieSchauspieler>();
        }
    
        public int ID_Serie { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public int AnzStaffeln { get; set; }
        public int AnzEpisoden { get; set; }
        public int ProduzentId { get; set; }
    
        public virtual Produzent Produzent { get; set; }
        public virtual ICollection<SerieSchauspieler> SerieSchauspieler { get; set; }
    }
}
