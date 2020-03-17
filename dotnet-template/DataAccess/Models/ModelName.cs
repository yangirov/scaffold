namespace DataAccess.Models
{
    public class {ModelName} : IBaseEntity<int>
    {
        public int Id { get; set; }

        public int Identifier => Id;
    }
}
