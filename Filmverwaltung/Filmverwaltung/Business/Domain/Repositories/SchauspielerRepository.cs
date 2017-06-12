using Filmverwaltung.Business.Domain.Repositories.Interfaces;
using Filmverwaltung.Models;

namespace Filmverwaltung.Business.Domain.Repositories
{
	public class SchauspielerRepository : RepositoryBase<Schauspieler>, ISchauspielerRepository
	{
		public SchauspielerRepository(FilmverwaltungContext context)
			: base(context)
		{
		}
	}
}