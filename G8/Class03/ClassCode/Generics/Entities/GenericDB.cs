using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics.Entities
{
    public class GenericDB<T> where T : BaseEntity
    {
        private List<T> Db;
        public GenericDB()
        {
            Db = new List<T>();
        }
        public void PrintAll()
        {
            foreach (T item in Db)
            {
                Console.WriteLine(item.GetInfo());
            }
        }

        public void Insert(T item)
        {
            Db.Add(item);
            Console.WriteLine($"Item was added in the {item.GetType().Name} Db!");
        }

        public T GetByIndex(int index)
        {
            return Db[index];
        }

        public T GetById(int id)
        {
            //return Db.Where(x => x.Id == id).FirstOrDefault();
            //return Db.FirstOrDefault(x => x.Id == id);
            return Db.Single(x => x.Id == id);
        }

        public void RemoveById(int id)
        {
            T item = Db.SingleOrDefault(x => x.Id == id);
            if(item == null)
            {
                Console.WriteLine($"Item was not found in the {item.GetType().Name} Db!");
            }
            Db.Remove(item);
            Console.WriteLine($"Item {item.Id} was removed from the {item.GetType().Name} Db!");
        }
    }
}
