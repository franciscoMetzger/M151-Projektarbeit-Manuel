using System;
using Filmverwaltung.Business.Domain.Repositories.Interfaces;

namespace Filmverwaltung.Business.Domain
{
	public interface IUnitOfWork : IDisposable
	{
		IFilmRepository Film { get; }
		ISerieRepository Serie { get; }
		IProduzentRepository Produzent { get; }
		ISchauspielerRepository Schauspieler { get; }
		IFilmSchauspielerRepository FilmSchauspieler { get; }
		void SaveChanges();
	}
}