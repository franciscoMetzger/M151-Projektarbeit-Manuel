using System.ComponentModel.DataAnnotations;
using Filmverwaltung.Models.Metadata;

namespace Filmverwaltung.Models
{
	[MetadataType(typeof(FilmMetadata))]
	public partial class Film
	{

	}

	[MetadataType(typeof(ProduzentMetadata))]
	public partial class Produzent
	{
		public string FullName { get { return Vorname + " " + Nachname; } }
	}

	[MetadataType(typeof(SchauspielerMetadata))]
	public partial class Schauspieler
	{
		public string FullName { get { return Vorname + " " + Name; } }
	}

	[MetadataType(typeof(SerieMetadata))]
	public partial class Serie
	{

	}
}