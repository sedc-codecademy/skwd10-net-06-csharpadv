namespace TaxiManager9000.DataAccess.Interface
{
    public interface IDatabase<T>
    {
        T GetById(int id);

        void Insert(T item);

        void Remove(T item);

        void Update(T item);

        List<T> GetAll();
    }
}
