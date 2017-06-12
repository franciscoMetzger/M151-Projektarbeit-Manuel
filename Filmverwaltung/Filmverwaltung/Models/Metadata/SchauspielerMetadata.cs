using System.ComponentModel.DataAnnotations;

namespace Filmverwaltung.Models.Metadata
{
	public class SchauspielerMetadata
	{
		[Required]
		[StringLength(200)]
		public string Vorname { get; set; }

		[Required]
		[StringLength(200)]
		public string Name { get; set; }

		[Required]
		[StringLength(200)]
		[Display(Name = "Vermittlungs-Agentur")]
		public string VermittlungsAgentur { get; set; }
	}
}