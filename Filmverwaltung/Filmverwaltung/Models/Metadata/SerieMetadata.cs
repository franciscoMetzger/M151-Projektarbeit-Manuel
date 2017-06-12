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
		public int AnzStaffeln { get; set; }

		[Required]
		public int AnzEpisoden { get; set; }

		[Required]
		public int ProduzentId { get; set; }
	}
}