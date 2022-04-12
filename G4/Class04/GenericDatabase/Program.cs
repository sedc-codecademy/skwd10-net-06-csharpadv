namespace GenericDatabase // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Order> orders = new List<Order> {
                new Order { Id = 1, Address = "adresa1", Receiver = "receiver1" },
                new Order { Id = 2, Address = "adresa2", Receiver = "receiver2" }
            };

            List<Product> products = new List<Product> {
                new Product { Id = 1, Title = "title1", Description = "description1" },
                new Product { Id = 2, Title = "title2", Description = "description2" }
            };

            PrintAll<Order>(orders);
            PrintAll<Product>(products);

            GenericDb<Order> orderDb = new GenericDb<Order>();
            GenericDb<Product> productDb = new GenericDb<Product>();

            orderDb.Insert(new Order { Id = 1, Address = "Bob street 29", Receiver = "Bob" });
            productDb.Insert(new Product { Id = 1, Description = "For gaming", Title = "Mouse" });

            Console.WriteLine("Orders:");
            orderDb.PrintAll();
            Console.WriteLine("Products:");
            productDb.PrintAll();

            orderDb.InsertMany(orders);
            productDb.InsertMany(products);

            Console.WriteLine("Orders:");
            orderDb.PrintAll();
            Console.WriteLine("Products:");
            productDb.PrintAll();
        }

        /// <summary>
        /// Generic method for getting info for all object instances from classes
        /// that inherit from BaseEntity. Note the generic type constraint provided.
        /// </summary>
        /// <typeparam name="T">Type that inherits from <see cref="BaseEntity"/></typeparam>
        /// <param name="list">List of <typeparamref name="T"/>.</param>
        public static void PrintAll<T>(List<T> list) where T : BaseEntity
        {
            foreach (T entity in list)
            {
                Console.WriteLine(entity.GetInfo());
            }
        }
    }
}