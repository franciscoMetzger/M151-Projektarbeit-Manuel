using System.Collections.Generic;
using System.Linq;
using Filmverwaltung.Business.Domain.Repositories.Interfaces;
using Filmverwaltung.Models;

namespace Filmverwaltung.Business.Domain.Repositories
{
	public class SerieSchauspielerRepository : RepositoryBase<SerieSchauspieler>, ISerieSchauspielerRepository
	{
		public SerieSchauspielerRepository(FilmverwaltungContext context)
			: base(context)
		{
		}

		public IEnumerable<SerieSchauspieler> LoadBySchauspieler(int idSchauspieler)
		{
			return Search(x => x.SchauspielerId == idSchauspieler).ToList();
		}

		public IEnumerable<SerieSchauspieler> LoadBySerie(int idSerie)
		{
			return Search(x => x.SerieId == idSerie).ToList();
		}
	}
}