namespace DataAccess.Models
{
    public interface IBaseEntity<T>
    {
        T Identifier { get; }
    }
}