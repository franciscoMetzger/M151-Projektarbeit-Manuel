using System.Collections.Generic;
using Filmverwaltung.Models;

namespace Filmverwaltung.Business.Domain.Repositories.Interfaces
{
	public interface ISerieSchauspielerRepository : IRepositoryBase<SerieSchauspieler>
	{
		IEnumerable<SerieSchauspieler> LoadBySchauspieler(int idSchauspieler);
		IEnumerable<SerieSchauspieler> LoadBySerie(int idSerie);
	}
}