namespace Class02.Static.Entities
{
    public class User
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public string Address { get; set; }
		public List<Order> Orders { get; set; }
		public User(int id, string username, string address)
		{
			Id = id;
			Username = username;
			Address = address;
			Orders = new List<Order>();
		}
		public void PrintOrders()
		{
			for (int i = 1; i <= Orders.Count; i++)
			{
				Console.WriteLine($"{i}) {Orders[i - 1].Print()}");
			}
		}
	}
}
