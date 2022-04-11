// See https://aka.ms/new-console-template for more information

using CSharp_Advanced_G3_L3_Generics.Enteties;

/*GenericMethods genericMethods = new GenericMethods();

genericMethods.PrintObject("Something", 34);
genericMethods.PrintObject<DateTime, int>(DateTime.Now, 46);
genericMethods.PrintObject<int, string>(34, "Hello Generic Methods");

NonGenericHelper nonGenericHelper = new NonGenericHelper();

List<string> stringList = new List<string>() { "Hello", "World", "Generic", "Methods"};
nonGenericHelper.GoThroughList(stringList);
nonGenericHelper.GetInfoForList(stringList);

List<int> intList = new List<int>() { 1, 2, 3 , 4, 5, 6};
nonGenericHelper.GoThroughList(intList);
nonGenericHelper.GetInfoForList(intList);

Console.WriteLine("----------------");

GenericHelper genericHelper = new GenericHelper();
genericHelper.GoThroughList<string>(stringList);
genericHelper.GetInfoForList<string>(stringList);
genericHelper.GoThroughList<int>(intList);
genericHelper.GetInfoForList<int>(intList);

GenericClass<double> genericClass = new GenericClass<double>(3.5);
genericClass.PrintPropertyTypeAndValue();

GenericClass<bool> genericBool = new GenericClass<bool>(true);
genericBool.PrintPropertyTypeAndValue();

GenericClass<decimal> genericDecimal = new GenericClass<decimal>(5.8m);
genericDecimal.PrintPropertyTypeAndValue();*/

GenericDB<Product> productDB = new GenericDB<Product>();
productDB.Add(new Product { Id = 1, Title = "Book", Description = "C# Advanced" });
productDB.Add(new Product { Id = 2, Title = "Book 1", Description = "C# Basic" });
productDB.Add(new Product { Id = 3, Title = "Book 2", Description = "Java Advanced" });

GenericDB<Order> orderDB = new GenericDB<Order>();
orderDB.Add(new Order { Id = 4, Address = "Partizanska", Product = new Product { Id = 1, Title = "Book", Description = "C# Advanced" } });
orderDB.Add(new Order { Id = 5, Address = "Vasil Gjorgov", Product = new Product { Id = 2, Title = "Book 1", Description = "C# Basic" } });
orderDB.Add(new Order { Id = 6, Address = "Teodosij Gologanov", Product = new Product { Id = 3, Title = "Book 2", Description = "Java Advanced" } });

//productDB.PrintInfo();
//orderDB.PrintInfo();



Product productForDelete = new Product() { Id = 4, Title = "Book", Description = "C# Advanced" };

Product secondProduct = productForDelete;

productDB.DeleteItem(productForDelete);


productDB.Add(productForDelete);

productDB.DeleteItem(productForDelete);
productDB.DeleteItem(secondProduct);

productDB.DeleteItemById(2);

productDB.DeleteItemById(10);
