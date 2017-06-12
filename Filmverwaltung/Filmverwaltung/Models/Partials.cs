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

	}

	[MetadataType(typeof(SchauspielerMetadata))]
	public partial class Schauspieler
	{

	}

	[MetadataType(typeof(SerieMetadata))]
	public partial class Serie
	{

	}
}