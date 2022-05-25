using TaxiManager9000.Domain;

namespace TaxiManager9000.DataAccess
{
    // Can be called LocalRepository<T>
    // WARNING: Do not explain or get in to the pattern of repository. We will cover that in the future subjects.
    // Repository can only be used as naming here
    public class LocalDb<T> : IDb<T> where T : BaseEntity
    {
        public int IdCount { get; set; }
        private List<T> db;
        public LocalDb()
        {
            db = new List<T>();
            IdCount = 1;
        }

        public List<T> GetAll()
        {
            return db;
        }

        public T GetById(int id)
        {
            return db.SingleOrDefault(x => x.Id == id);
        }

        public int Insert(T entity)
        {
            entity.Id = IdCount;
            db.Add(entity);
            IdCount++;
            return entity.Id;
        }

        public void RemoveById(int id)
        {
            T item = db.SingleOrDefault(x => x.Id == id);
            if (item != null) db.Remove(item);
        }

        public void Update(T entity)
        {
            T item = db.SingleOrDefault(x => x.Id == entity.Id);
            item = entity;
        }
    }
}
