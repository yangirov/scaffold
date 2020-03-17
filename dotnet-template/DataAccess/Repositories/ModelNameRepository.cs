using DataAccess.Models;

namespace DataAccess.Repositories
{
    public class {ModelName}Repository : BasePostgresRepository<{ModelName}, int>
    {
        public {ModelName}Repository(string connection) : base(connection) { }

        protected override string TableName => "{DbTableName}";
    }
}
