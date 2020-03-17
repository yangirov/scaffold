using DataAccess.Models;

namespace DataAccess.Repositories
{
    public abstract class BasePostgresRepository<TEntity, TId> : BaseRepository<TEntity, TId>
        where TEntity : class, IBaseEntity<TId>, new()
    {
        public BasePostgresRepository(string connection) : base(connection) { }
    }
}
