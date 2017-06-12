using Filmverwaltung.Business.Domain.Repositories.Interfaces;
using Filmverwaltung.Models;

namespace Filmverwaltung.Business.Domain.Repositories
{
	public class FilmRepository : RepositoryBase<Film>, IFilmRepository
	{
		public FilmRepository(FilmverwaltungContext context)
			: base(context)
		{
		}
	}
}