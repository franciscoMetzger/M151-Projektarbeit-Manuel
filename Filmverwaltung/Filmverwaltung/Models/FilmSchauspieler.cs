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
    
    public partial class FilmSchauspieler
    {
        public int ID_FilmSchauspieler { get; set; }
        public int FilmId { get; set; }
        public int SchauspielerId { get; set; }
    
        public virtual Film Film { get; set; }
        public virtual Schauspieler Schauspieler { get; set; }
    }
}
