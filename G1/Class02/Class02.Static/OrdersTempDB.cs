using Class02.Static.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class02.Static
{
	// This static class is serving as a temporary database
	// While the app is running, the static members of this class will keep their data
	// It can also be accessed from anywhere
	public static class OrdersTempDB
	{
		// This is an ID tracking property so that we generate the Id of orders automatically
		public static int orderId = 5;
		// These are the lists that will serve as tables in a database ( Store items in them )
		public static List<User> Users;
		public static List<Order> Orders;
		// This is a static constructor
		// It will only execute once, the first time this class is instanciated, when the app is started
		// Static constructor does not have access modifier
		static OrdersTempDB()
		{
			Orders = new List<Order>()
			{
				new Order(1, "book of books", "Best book ever", OrderStatus.Delivered),
				new Order(2, "keyboard", "Mechanical", OrderStatus.DeliveryInProgress),
				new Order(3, "Shoes", "Waterproof", OrderStatus.DeliveryInProgress),
				new Order(4, "Set of Pens", "Ordinary pens", OrderStatus.Processing),
				new Order(5, "sticky Notes", "Stickiest notes in the world", OrderStatus.CouldNotDeliver)
			};
			Users = new List<User>()
			{
				new User(12, "Bob22", "Bob St. 44"),
				new User(13, "JillCoolCat", "Wayne St. 109a")
			};
			Users[0].Orders.Add(Orders[0]);
			Users[0].Orders.Add(Orders[1]);
			Users[0].Orders.Add(Orders[2]);
			Users[1].Orders.Add(Orders[3]);
			Users[1].Orders.Add(Orders[4]);
		}
		public static void ListUsers()
		{
			for (int i = 1; i <= Users.Count; i++)
			{
				Console.WriteLine($"{i}) {Users[i - 1].Username}");
			}
		}
		public static void InsertOrder(int userId, Order order)
		{
			// When an order is added, we increment the ID and set it to the new order
			order.Id = ++orderId;
			Orders.Add(order);
			Users.Single(x => x.Id == userId).Orders.Add(order);
			Console.WriteLine("Order successfully added!");
		}
	}
}
