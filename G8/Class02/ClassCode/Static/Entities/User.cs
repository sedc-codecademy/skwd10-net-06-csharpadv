using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Adress { get; set; }
        public List<Order> Orders { get; set; }
        public User(int id, string username, string address)
        {
            Id = id;
            UserName = username;
            Adress = address;
            Orders = new List<Order>();
        }
        public void PrintOrders()
        {
            for(int i = 1; i <= Orders.Count; i++)
            {
                Console.WriteLine($"{i} {Orders[i - 1].Print()}");
            }
        }
    }
}
