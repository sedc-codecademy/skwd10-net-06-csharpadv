namespace Class03.Demo.Entities
{
    public class GenericDB<T> where T : BaseEntity
    {
        private List<T> TableInDB;

        public GenericDB()
        {
            TableInDB = new List<T>();
        }

        public void PrintAll()
        {
            foreach(T item in TableInDB)
            {
                Console.WriteLine(item.GetInfo());
            }
        }

        public bool Add(T item)
        {
            try
            {
                TableInDB.Add(item);
            }
            catch(Exception)
            {
                return false;
            }

            return true;
        }

        public bool Remove(T item)
        {
            try
            {
                TableInDB.Remove(item);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public T GetById(int id)
        {
            return TableInDB.Single(x => x.Id == id);
        }

        public T GetByIndex(int id)
        {
            return TableInDB[id];
        }

        public List<T> GetAll()
        {
            return TableInDB;
        }
    }
}
