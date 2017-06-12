using System.ComponentModel.DataAnnotations;

namespace Filmverwaltung.Models.Metadata
{
	public class ProduzentMetadata
	{
		[Required]
		[StringLength(200)]
		public string Vorname { get; set; }

		[Required]
		[StringLength(200)]
		public string Nachname { get; set; }

		[Required]
		[StringLength(200)]
		public string Firma { get; set; }
	}
}