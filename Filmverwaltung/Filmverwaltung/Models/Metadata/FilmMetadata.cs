using System;
using System.ComponentModel.DataAnnotations;

namespace Filmverwaltung.Models.Metadata
{
	public class FilmMetadata
	{
		[Required]
		[StringLength(200)]
		public string Name { get; set; }

		[Required]
		[StringLength(200)]
		public string Genre { get; set; }

		[Display(Name = "Länge in Minuten")]
		public int? Laenge { get; set; }

		[Required]
		[Display(Name = "Produzent")]
		public int ProduzentId { get; set; }
	}
}