using TaxiManager9000.Domain;

namespace TaxiManager9000.DataAccess
{
    // Can be called IRepository<T>
    // WARNING: Do not explain or get in to the pattern of repository. We will cover that in the future subjects.
    // Repository can only be used as naming here
    public interface IDb<T> where T : BaseEntity
    {
        List<T> GetAll();
        T GetById(int id);
        int Insert(T entity);
        void RemoveById(int id);
        void Update(T entity);
    }
}
