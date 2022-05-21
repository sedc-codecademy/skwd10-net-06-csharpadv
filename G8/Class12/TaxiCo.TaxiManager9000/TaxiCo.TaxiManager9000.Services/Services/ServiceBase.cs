using TaxiManager9000.DataAccess;
using TaxiManager9000.Domain;

namespace TaxiManager9000.Services
{
    public abstract class ServiceBase<T> : IServiceBase<T> where T : BaseEntity
    {
        protected IDb<T> _db;

        public ServiceBase()
        {
            // Use this before you get to the File System Class
            _db = new LocalDb<T>();
            // Use this after you pass the File System Class
            //_db = new FileSystemDb<T>();
        }
        public void Add(T item)
        {
            _db.Insert(item);
        }

        public List<T> GetAll()
        {
            return _db.GetAll();
        }

        public List<T> GetAll(Func<T, bool> wherePredicate)
        {
            return _db.GetAll().Where(wherePredicate).ToList();
        }

        public T GetSingle(int id)
        {
            return _db.GetById(id);
        }

        public void Remove(int id)
        {
            _db.RemoveById(id);
        }
        public void Seed(List<T> items)
        {
            if (_db.GetAll().Count > 0) return;
            items.ForEach(x => _db.Insert(x));
        }
    }
}
