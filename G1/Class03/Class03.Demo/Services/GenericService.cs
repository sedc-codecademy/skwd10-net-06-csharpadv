using Class03.Demo.Entities;

namespace Class03.Demo.Services
{
    public class GenericService<T> where T : BaseEntity
    {
        private GenericDB<T> Database = new GenericDB<T>();
        public void Add(T entity)
        {
            var success = Database.Add(entity);
            if (success)
            {
                Console.WriteLine($"{entity.GetType().FullName} was inserted!");
            }
            else
            {
                Console.WriteLine("Error occured.");
            }
        }

        public void Remove(T entity)
        {
            Database.Remove(entity);
        }

        public List<T> GetAll()
        {
            return Database.GetAll();
        }
    }
}
