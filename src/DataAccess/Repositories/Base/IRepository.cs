using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

using DataAccess.Models;

namespace DataAccess.Repositories
{
	public interface IRepository<T, U> : IDisposable
		where T : class, IBaseEntity<U>
	{
		Task<T> AddAsync(T entity);

		Task<U> AddOrUpdateAsync(T entity);

		Task<T> GetAsync(U key);

		Task<IEnumerable<T>> GetByFilterAsync(string filter, string sortField = null);

		Task<T> UpdateAsync(T entity, IEnumerable<string> fields = null);

		Task<bool> DeleteAsync(U key);

		IDbConnection GetNewConnection();
	}
}
