using System.Collections.Generic;
using Filmverwaltung.Models;

namespace Filmverwaltung.Business.Domain.Repositories.Interfaces
{
	public interface IFilmSchauspielerRepository : IRepositoryBase<FilmSchauspieler>
	{
		IEnumerable<FilmSchauspieler> LoadBySchauspieler(int id);
		IEnumerable<FilmSchauspieler> LoadByFilm(int id);
	}
}