using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Filmverwaltung.Business.Domain.Repositories.Interfaces
{
	public interface IRepositoryBase<TEntity>
	{
		void Insert(TEntity entity);
		void Delete(TEntity entity);
		void Update(TEntity entity);
		IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> predicate);
		IEnumerable<TEntity> LoadAll();
		TEntity Load(int id);
	}
}