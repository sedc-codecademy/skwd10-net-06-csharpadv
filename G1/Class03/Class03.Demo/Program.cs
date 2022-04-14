using Class03.Demo.Entities;
using Class03.Demo.Services;

#region Generics
//List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
//List<string> list2 = new List<string>() { "eden", "Dva" };

//ListHelper.PrintString(list2);
//ListHelper.PrintInt(list);
//Console.WriteLine("========= Generics print ============");
//GenericListHelper<string>.Print(list2);
//GenericListHelper<int>.Print(list);


//PrintItem<bool>(true);
//static void PrintItem<T>(T item)
//{
//    Console.WriteLine(item);
//}
#endregion

#region Generic classes with scope
//Insert orders and products
Order order1 = new Order()
{
    Id = 1,
    Receiver = "Risto",
    Address = "11 Oktomvri 33A"
};

Order order2 = new Order()
{
    Id = 2,
    Receiver = "Pero",
    Address = "11 Oktomvri 32A"
};


Product product1 = new Product()
{
    Id = 1,
    Name = "Gaming - PC Mouse",
    Description = "Gaming - PC Mouse",
};
Product product2 = new Product()
{
    Id=2,
    Name = "Samsung 27 inch monitor",
    Description = "Samsung 27 inch monitor"
};

GenericService<Order> orderService = new GenericService<Order>();
GenericService<Product> productService = new GenericService<Product>();

orderService.Add(order1);
orderService.Add(order2);
productService.Add(product1);
productService.Add(product2);

//Print all orders and products
foreach(Order order in orderService.GetAll())
{
    Console.WriteLine($"Order for {order.Receiver} on address {order.Address}");
}

foreach(Product product in productService.GetAll())
{
    Console.WriteLine($"Product {product.Name} with description: {product.Description}");
}

//get item with ID 2 from orders 

//get product with index 1
#endregion

#region Extension methods
string text = "numberOfWords should be greater or equal to 0";
Console.WriteLine("Whole text: " + text.QuoteText());
Console.WriteLine("Short text: " + text.Shorten(5).QuoteText());

string text2 = string.Empty;
text2.QuoteText();
#endregion