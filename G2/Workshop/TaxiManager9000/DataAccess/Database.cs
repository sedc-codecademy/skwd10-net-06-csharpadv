using TaxiManager9000.DataAccess.Interface;
using TaxiManager9000.Domain.Entities;

namespace TaxiManager9000.DataAccess
{
    public abstract class Database<T> : IDatabase<T> where T : BaseEntity
    {
        protected List<T> Items;

        public Database()
        {
            Items = new List<T>();
        }

        public void Insert(T item)
        {
            T itemToInsert = AutoIncrementId(item);

            Items.Add(itemToInsert);
        }

        public void Remove(T item)
        {
            Items.Remove(item);
        }

        public void Update(T item)
        {
            // do nothing
        }

        public List<T> GetAll()
        {
            return Items;
        }

        protected T AutoIncrementId(T item)
        {
            int currentId = 0;

            if (Items.Count > 0)
            {
                currentId = Items.OrderByDescending(x => x.Id).First().Id;
            }

            item.Id = ++currentId;

            return item;
        }

        public T GetById(int id)
        {
            return Items.SingleOrDefault(x => x.Id == id);
        }
    }
}
