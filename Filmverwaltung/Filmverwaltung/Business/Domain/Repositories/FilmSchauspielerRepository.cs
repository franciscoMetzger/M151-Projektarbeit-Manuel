using Filmverwaltung.Business.Domain.Repositories.Interfaces;
using Filmverwaltung.Models;

namespace Filmverwaltung.Business.Domain.Repositories
{
	public class FilmSchauspielerRepository : RepositoryBase<FilmSchauspieler>, IFilmSchauspielerRepository
	{
		public FilmSchauspielerRepository(FilmverwaltungContext context)
			: base(context)
		{
		}
	}
}