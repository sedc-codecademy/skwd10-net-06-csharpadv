using CSharpAdvanced_G2_L3_GenericDb.Entities;

namespace CSharpAdvanced_G2_L3_GenericDb.Database
{
    public abstract class Database<T> where T : BaseEntity<T>
    {
        private readonly List<T> _entities;

        public Database()
        {
            _entities = new List<T>();
        }

        public void Add(T entity)
        {
            _entities.Add(entity);
        }

        public T Get(int id)
        {
            return _entities.FirstOrDefault(x => x.Id == id);
        }

        public void Remove(T entity)
        {
            // Implementation if equals was not overriden
            //int index = _entities.IndexOf(entity);

            //if (index == -1)
            //{
            //    return;
            //}
            
            //_entities.RemoveAt(index);

            _entities.Remove(entity);
        }

        protected List<T> GetAll()
        {
            return _entities;
        }
    }
}
