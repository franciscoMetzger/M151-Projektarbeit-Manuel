using System.Collections.Generic;
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

		public IEnumerable<FilmSchauspieler> LoadBySchauspieler(int id)
		{
			return Search(x => x.SchauspielerId == id);
		}

		public IEnumerable<FilmSchauspieler> LoadByFilm(int id)
		{
			return Search(x => x.FilmId == id);
		}
	}
}