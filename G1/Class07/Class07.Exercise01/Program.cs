
using Class07.Exercise01.Entities;
using Class07.Exercise01.Enums;

Market vero = new Market()
{
    Name = "Vero",
    CurrentPromotion = PromotionType.Drink,
    Description = "Some description"
};

Market ramstore = new Market()
{
    Name = "Ramstore",
    CurrentPromotion = PromotionType.Cosmetics,
    Description = "Some description"
};

User john = new User()
{
    Id = 1,
    Name = "John",
    Age = 25,
    FavouritePromotion = PromotionType.Electronics
};

User jim = new User()
{
    Id = 2,
    Name = "Jim",
    Age = 35,
    FavouritePromotion = PromotionType.Food
};

User sean = new User()
{
    Id = 3,
    Name = "Sean",
    Age = 15,
    FavouritePromotion = PromotionType.Other
};

User jane = new User()
{
    Id = 4,
    Name = "Jane",
    Age = 29,
    FavouritePromotion = PromotionType.Drink
};

vero.Subscribe(john.ReadPromotion);
vero.Subscribe(sean.ReadPromotion);
vero.Subscribe(jane.ReadPromotion);
ramstore.Subscribe(jim.ReadPromotion);

vero.SendPromotions();
ramstore.SendPromotions();

vero.UnSubscribe(jane.ReadPromotion, "Not very usefull");
vero.SendPromotions();
vero.ReadComplaints();

vero.ChangePromotion(PromotionType.Other);