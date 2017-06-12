using System.ComponentModel.DataAnnotations;

namespace Filmverwaltung.Models.Metadata
{
	public class SerieMetadata
	{
		[Required]
		[StringLength(200)]
		public string Name { get; set; }

		[Required]
		[StringLength(200)]
		public string Genre { get; set; }

		[Required]
		[Display(Name = "Anz. Staffeln")]
		public int AnzStaffeln { get; set; }

		[Required]
		[Display(Name = "Anz. Episoden")]
		public int AnzEpisoden { get; set; }

		[Required]
		[Display(Name = "Produzent")]
		public int ProduzentId { get; set; }
	}
}