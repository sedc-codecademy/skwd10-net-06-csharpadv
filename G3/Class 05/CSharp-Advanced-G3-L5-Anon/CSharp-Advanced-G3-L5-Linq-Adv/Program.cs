// See https://aka.ms/new-console-template for more information

List<Order> orderList = new List<Order>
{
    new Order(){Id= 1, Name = "Order1", OrderStatus = OrderStatus.Processing, Quantity = 15 },
    new Order(){Id= 5, Name = "Order5", OrderStatus = OrderStatus.Shipped, Quantity = 30 },
    new Order(){Id= 9, Name = "Order9", OrderStatus = OrderStatus.Processing, Quantity = 25 },
    new Order(){Id= 4, Name = "Order4", OrderStatus = OrderStatus.Shipped, Quantity = 4 },
    new Order(){Id= 11, Name = "Order11", OrderStatus = OrderStatus.Processing, Quantity = 3 },
    new Order(){Id= 10, Name = "Order10", OrderStatus = OrderStatus.Processing, Quantity = 10 },
    new Order(){Id= 3, Name = "Order3", OrderStatus = OrderStatus.Shipped, Quantity = 60 },
    new Order(){Id= 8, Name = "Order8", OrderStatus = OrderStatus.Processing, Quantity = 17 },
    new Order(){Id= 6, Name = "Order6", OrderStatus = OrderStatus.Deliverd, Quantity = 7 },
    new Order(){Id= 2, Name = "Order2", OrderStatus = OrderStatus.Deliverd, Quantity = 10 },
    new Order(){Id= 7, Name = "Order7", OrderStatus = OrderStatus.Deliverd, Quantity = 22 },
};


List<Order> copyList = orderList.Select(x => x).ToList();

Console.WriteLine("Original List");
orderList.ForEach((x) => Console.WriteLine(x));

orderList.FirstOrDefault(x=> x.Id == 1).Name = "Order 1 Changed";
orderList.FirstOrDefault(x => x.Id == 4).Name = "Order 4 Changed";

Console.WriteLine("Copy List");
copyList.ForEach((x) => Console.WriteLine(x));

List<Order> realCopyList = orderList.Select(x => new Order
{
    Id = x.Id,
    Name = x.Name,
    OrderStatus = x.OrderStatus,
    Quantity = x.Quantity,
}).ToList();


orderList.FirstOrDefault(x => x.Id == 11).Name = "Order 11 Changed";
orderList.FirstOrDefault(x => x.Id == 3).Name = "Order 3 Changed";

Console.WriteLine("Real Copy List");
realCopyList.ForEach((x) => Console.WriteLine(x));


public class Order
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }

    public OrderStatus OrderStatus { get; set; }

    public override string ToString()
    {
        return $"Id: {Id} Name: {Name} Quantity: {Quantity} Order Status: {OrderStatus}";
    }
}

public enum OrderStatus
{
    Processing,
    Shipped,
    Deliverd
}
