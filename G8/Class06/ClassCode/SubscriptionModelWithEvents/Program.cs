using SubscriptionModelWithEvents.Entities;

#region Markets and Users
Market SuperMart = new Market()
{
    Name = "SuperMart",
    CurrentPromotion = ProductType.Food
};
Market BestMart = new Market()
{
    Name = "BestMart",
    CurrentPromotion = ProductType.Electronics
};
User Bob = new User()
{
    Name = "Bob Bobsky",
    Age = 21,
    FavouriteType = ProductType.Food
};
User Jill = new User()
{
    Name = "Jill Wayne",
    Age = 28,
    FavouriteType = ProductType.Cosmetics
};
User Greg = new User()
{
    Name = "Greg Gregsky",
    Age = 48,
    FavouriteType = ProductType.Electronics
};
#endregion

// Users subscribe to SuperMart for their promotions
SuperMart.SubscribeForPromotion(Bob.ReadPromotion, "bob@gmail.com");
SuperMart.SubscribeForPromotion(Jill.ReadPromotion, "jill@gmail.com");
SuperMart.SubscribeForPromotion(Greg.ReadPromotion, "greg@gmail.com");

// Users subscribe to BestMart for their promotions
BestMart.SubscribeForPromotion(Jill.ReadPromotion, "jill@gmail.com");
BestMart.SubscribeForPromotion(Greg.ReadPromotion, "greg@gmail.com");

SuperMart.SendPromotion();
SuperMart.CurrentPromotion = ProductType.Cosmetics; // The promotion is changed
SuperMart.UnsubscribeForPromotion(Greg.ReadPromotion, "Booring"); 

BestMart.SendPromotion();
BestMart.CurrentPromotion = ProductType.Food;
BestMart.UnsubscribeForPromotion(Greg.ReadPromotion, "Nothing great going on in the promotion");

SuperMart.SendPromotion();
SuperMart.UnsubscribeForPromotion(Bob.ReadPromotion, "Enough is enough");
SuperMart.CurrentPromotion = ProductType.Other;

BestMart.SendPromotion();

SuperMart.ReadZalbiIPoplaki();
BestMart.ReadZalbiIPoplaki();

Console.ReadLine();
