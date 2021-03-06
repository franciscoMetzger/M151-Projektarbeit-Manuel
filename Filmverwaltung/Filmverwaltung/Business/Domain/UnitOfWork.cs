using Filmverwaltung.Business.Domain.Repositories;
using Filmverwaltung.Business.Domain.Repositories.Interfaces;
using Filmverwaltung.Models;

namespace Filmverwaltung.Business.Domain
{
	internal class UnitOfWork : IUnitOfWork
	{
		private readonly FilmverwaltungContext _context;

		public UnitOfWork(FilmverwaltungContext context)
		{
			_context = context;

			Film = new FilmRepository(context);
			Serie = new SerieRepository(context);
			Produzent = new ProduzentRepository(context);
			Schauspieler = new SchauspielerRepository(context);
			FilmSchauspieler = new FilmSchauspielerRepository(context);
			SerieSchauspieler = new SerieSchauspielerRepository(context);
		}

		public IFilmRepository Film { get; private set; }
		public ISerieRepository Serie { get; private set; }
		public IProduzentRepository Produzent { get; private set; }
		public ISchauspielerRepository Schauspieler { get; private set; }
		public IFilmSchauspielerRepository FilmSchauspieler { get; private set; }
		public ISerieSchauspielerRepository SerieSchauspieler { get; private set; }

		public void SaveChanges()
		{
			_context.SaveChanges();
		}

		public void Dispose()
		{
			_context.Dispose();
		}
	}
}