namespace GenericDatabase
{
    /// <summary>
    /// An incomplete generic database implementation.
    /// In the real world, sometimes an abstract class.
    /// </summary>
    internal class GenericDb<T> where T : BaseEntity
    {
        private List<T> _entities;

        public GenericDb()
        {
            _entities = new List<T>();
        }

        public void PrintAll()
        {
            foreach (T entity in _entities)
            {
                Console.WriteLine(entity.GetInfo());
            }
        }

        public void Insert(T item)
        {
            _entities.Add(item);

            Console.WriteLine($"Item was added in the {item.GetType().Name} database!");
        }

        /// <summary>
        /// Additional method to allow bulk-insert of entities.
        /// </summary>
        public void InsertMany(List<T> items)
        {
            _entities.AddRange(items);

            Console.WriteLine($"{items.Count} items were added in the {typeof(T).Name} database!");
        }
    }
}
