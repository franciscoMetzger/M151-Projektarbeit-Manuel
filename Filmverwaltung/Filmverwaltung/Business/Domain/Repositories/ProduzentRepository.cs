using Filmverwaltung.Business.Domain.Repositories.Interfaces;
using Filmverwaltung.Models;

namespace Filmverwaltung.Business.Domain.Repositories
{
	public class ProduzentRepository : RepositoryBase<Produzent>, IProduzentRepository
	{
		public ProduzentRepository(FilmverwaltungContext context)
			: base(context)
		{
		}
	}
}