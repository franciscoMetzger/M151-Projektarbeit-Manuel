using Filmverwaltung.Business.Domain.Repositories.Interfaces;
using Filmverwaltung.Models;

namespace Filmverwaltung.Business.Domain.Repositories
{
	public class SerieRepository : RepositoryBase<Serie>, ISerieRepository
	{
		public SerieRepository(FilmverwaltungContext context)
			: base(context)
		{
		}
	}
}