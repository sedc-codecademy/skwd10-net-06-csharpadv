using CSharp_Advanced_G3_L2.Enteties;
using System.Linq;

namespace CSharp_Advanced_G3_L2
{
    public static class OrdersFakeDB
    {
        public static int orderId = 5;
        public static int userId = 2;

        public static List<Order> Orders { get; set; }

        public static List<User> Users { get; set; }

        static OrdersFakeDB()
        {
            Orders = new List<Order>();
            Users = new List<User>();

            Orders.Add(new Order(1, "Order 1", "order 1 description", OrderStatus.Shipped));
            Orders.Add(new Order(2, "Order 2", "order 2 description", OrderStatus.Processing));
            Orders.Add(new Order(3, "Order 3", "order 3 description", OrderStatus.Delivered));
            Orders.Add(new Order(4, "Order 4", "order 4 description", OrderStatus.Shipped));
            Orders.Add(new Order(5, "Order 5", "order 5 description", OrderStatus.Delivered));

            Users.Add(new User(1, "Ivan", "D2jikovski"));
            Users.Add(new User(2, "Petko", "Petkovski"));

            //Users[0].Orders.Add(Orders[0]);
            //Users[0].Orders.Add(Orders[1]);
            //Users[1].Orders.Add(Orders[2]);
            //Users[1].Orders.Add(Orders[3]);
            //Users[1].Orders.Add(Orders[4]);

            Users.FirstOrDefault(user => user.Name == "Ivan")
                .Orders.Add(Orders.FirstOrDefault(order => order.Id == 1));
            Users.FirstOrDefault(user => user.Name == "Ivan")
                .Orders.Add(Orders.FirstOrDefault(order => order.Id == 2));

            Users.FirstOrDefault(user => user.Name == "Petko")
                .Orders.Add(Orders.FirstOrDefault(order => order.Id == 3));
            Users.FirstOrDefault(user => user.Name == "Petko")
                .Orders.Add(Orders.FirstOrDefault(order => order.Id == 4));
            Users.FirstOrDefault(user => user.Name == "Petko")
                .Orders.Add(Orders.FirstOrDefault(order => order.Id == 5));
        }

        public static void AddOrder(string title, string description, OrderStatus orderStatus, User user)
        {
            orderId++;
            Order order = new Order
            {
                Id = orderId,
                Title = title,
                Description = description,
                OrderStatus = orderStatus
            };

            Orders.Add(order);
            user.Orders.Add(order);
        }

        public static User AddUser(string name, string lastName)
        {
            userId++;
            User user = new User(userId, name, lastName);
            Users.Add(user);
            return user;
        }
    }
}
