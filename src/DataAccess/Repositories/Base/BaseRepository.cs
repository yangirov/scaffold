using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

using DataAccess.Models;

namespace DataAccess.Repositories
{
	public abstract class BaseRepository<TEntity, TId> : IRepository<TEntity, TId>
		where TEntity : class, IBaseEntity<TId>, new()
	{
		protected virtual string TableName { get; set; }
		protected string Connection { get; private set; }

		public BaseRepository(string connection)
		{
			Connection = connection;
		}

		public Task<TEntity> AddAsync(TEntity entity) => throw new NotImplementedException();

		public Task<TId> AddOrUpdateAsync(TEntity entity) => throw new NotImplementedException();

		public Task<bool> DeleteAsync(TId key) => throw new NotImplementedException();

		public void Dispose() => throw new NotImplementedException();

		public Task<TEntity> GetAsync(TId key) => throw new NotImplementedException();

		public Task<IEnumerable<TEntity>> GetByFilterAsync(string filter, string sortField = null) => throw new NotImplementedException();

		public Task<TEntity> UpdateAsync(TEntity entity, IEnumerable<string> fields = null) => throw new NotImplementedException();

		public IDbConnection GetNewConnection() => throw new NotImplementedException();
	}
}
