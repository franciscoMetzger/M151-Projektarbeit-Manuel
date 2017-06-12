﻿using Filmverwaltung.Business.Domain.Repositories.Interfaces;
using Filmverwaltung.Models;

namespace Filmverwaltung.Business.Domain.Repositories
{
	public class SerieSchauspielerRepository : RepositoryBase<SerieSchauspieler>, ISerieSchauspielerRepository
	{
		public SerieSchauspielerRepository(FilmverwaltungContext context)
			: base(context)
		{
		}
	}
}