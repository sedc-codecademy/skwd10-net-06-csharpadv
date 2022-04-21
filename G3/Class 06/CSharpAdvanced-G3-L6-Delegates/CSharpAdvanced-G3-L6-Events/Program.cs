// See https://aka.ms/new-console-template for more information

using CSharpAdvanced_G3_L6_Events.Enteties;

Market tineks = new Market()
{
    Name = "Tineks",
    CurrentProdutType = ProductType.Food
};

Market reptil = new Market()
{
    Name = "Reptil",
    CurrentProdutType = ProductType.Cosmetics
};

Market neptun = new Market()
{
    Name = "Neptun",
    CurrentProdutType = ProductType.Electronic
};

User ivan = new User("Ivan", "Djikovski", 34, "ivan.dzikovski@gmail.com");
User vlatko = new User("Vlatko", "Tasevski", 25, "vlatko.tasevski@gmail.com");
User petko = new User("Petko", "Petkovski", 20, "petko.petkovski@gmail.com");
User stanko = new User("Stanko", "Stankovski", 26, "stanko.stankovski@gmail.com");

tineks.SubscribeToPromotion(ivan.ReadPromotion, ivan.Email);
tineks.SubscribeToPromotion(vlatko.ReadPromotion, vlatko.Email);
tineks.SubscribeToPromotion(petko.ReadPromotion, petko.Email);
tineks.Send();

Console.WriteLine("--------------------------");


tineks.Unsubscribe(petko.ReadPromotion, petko.Email);

tineks.Send();

Console.WriteLine("--------------------------");

neptun.SubscribeToPromotion(vlatko.ReadPromotion, vlatko.Email);
neptun.SubscribeToPromotion(stanko.ReadPromotion, stanko.Email);

neptun.Send();

Console.WriteLine("--------------------------");

reptil.SubscribeToPromotion(ReadPromotion, "Console writeline");
reptil.SubscribeToPromotion((type, marketName) =>
{
    Console.WriteLine($"Subscription from anonymus method: Promotion for {type} at {marketName}");
}, "Fake email");

reptil.Send();



static void ReadPromotion(ProductType type, string marketName)
{
    Console.WriteLine($"Subscription from main method: Promotion for {type} at {marketName}");
}
