using Generics.Entities;
using Generics.Helpers;

#region Non Generic Helpers
NonGenericListHelper notGeneric = new NonGenericListHelper();
List<string> strings = new List<string>() { "str1", "str2", "str3" };
List<int> ints = new List<int>() { 1, 2, 3 };
List<bool> bools = new List<bool>() { true, false, true };
notGeneric.GoThroughStrings(strings);
notGeneric.GoThroughInts(ints);
notGeneric.GetInfoForStrings(strings);
notGeneric.GetInfoForInts(ints);
#endregion

#region Generic Helpers
GenericListHelper<string>.GoThrough(strings);
GenericListHelper<string>.GetInfo(strings);

GenericListHelper<int>.GoThrough(ints);
GenericListHelper<int>.GetInfo(ints);

GenericListHelper<bool>.GoThrough(bools);
GenericListHelper<bool>.GetInfo(bools);
#endregion

#region Generic Classes

GenericDB<Order> OrderDb = new GenericDB<Order>();
GenericDB<Product> ProductDb = new GenericDB<Product>();

OrderDb.Insert(new Order() { Id = 1, Address = "Bob streeet 29", Receiver = "Bob" });
OrderDb.Insert(new Order() { Id = 2, Address = "Jill streeet 31", Receiver = "Jill" });
OrderDb.Insert(new Order() { Id = 3, Address = "Greg street 11", Receiver = "Greg" });
ProductDb.Insert(new Product() { Id = 1, Description = "For gaming", Title = "Mouse" });
ProductDb.Insert(new Product() { Id = 2, Description = "Mechanical", Title = "Keyboard" });
ProductDb.Insert(new Product() { Id = 3, Description = "64GB", Title = "USB" });
Console.WriteLine("Orders:");
OrderDb.PrintAll();
Console.WriteLine("Products:");
ProductDb.PrintAll();
Console.WriteLine("-------Get by id 1 from Order and Product------");
Console.WriteLine(OrderDb.GetById(1).GetInfo());
Console.WriteLine(ProductDb.GetById(1).GetInfo());
Console.WriteLine("-------Get by index 1 from Order and Product------");
Console.WriteLine(OrderDb.GetByIndex(1).GetInfo());
Console.WriteLine(ProductDb.GetByIndex(1).GetInfo());
Console.WriteLine("-------Remove by index 1 from Order and Product------");
OrderDb.RemoveById(1);
ProductDb.RemoveById(1);
Console.WriteLine("Orders:");
OrderDb.PrintAll();
Console.WriteLine("Products:");
ProductDb.PrintAll();

Console.ReadLine();
#endregion

