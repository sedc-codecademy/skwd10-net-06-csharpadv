// See https://aka.ms/new-console-template for more information
using CSharpAdvanced_G2_L3_GenericDb.Database;
using CSharpAdvanced_G2_L3_GenericDb.Entities;

List<Item> items = new List<Item>()
{
    new Item(1, "Shoe", 1),
    new Item(2, "Shoe", 2),
    new Item(3, "Shoe", 1),
    new Item(4, "Shoe", 5),
    new Item(5, "Shoe", 4)
};

Cart cart = new Cart(2, items, "123");

Cart cart2 = new Cart(1, items, "124");

//bool isEqual = cart.Equals(cart2);

//Console.WriteLine($"Cart with id {cart.CartId} is equal to {cart2.CartId} : {isEqual}");

InMemoryDatabase.CartDatabase.Add(cart);
InMemoryDatabase.CartDatabase.Add(cart2);

InMemoryDatabase.CartDatabase.Remove(cart);

var cartFromDb = InMemoryDatabase.CartDatabase.Get(cart.Id);

items.ForEach(x => InMemoryDatabase.ItemDatabase.Add(x));

List<Item> itemsWithQuantityThree = InMemoryDatabase.ItemDatabase.GetItemsWithQuantity(3);

Console.WriteLine(itemsWithQuantityThree.Count);