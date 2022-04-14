using Class02.Static.Helpers;

namespace Class02.Static.Entities
{
    public class Order
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public OrderStatus Status { get; set; }
		public Order()
		{
			Status = OrderStatus.Processing;
		}
		public Order(int id, string title, string desc, OrderStatus status)
		{
			Id = id;
			Title = title;
			Description = desc;
			Status = status;
		}
		public string Print()
		{
			// We can use the helper class anywhere we need it without an instance
			return $"{TextHelper.CapitalFirstLetter(Title)} - {Description}";
		}
	}

	// This enum can be in a seprate file
	// It can also be implemented with the class that it is used in
	public enum OrderStatus
	{
		Processing,
		Delivered,
		DeliveryInProgress,
		CouldNotDeliver
	}
}
