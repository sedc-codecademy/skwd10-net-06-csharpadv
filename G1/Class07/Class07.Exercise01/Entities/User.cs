using Class07.Exercise01.Enums;

namespace Class07.Exercise01.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public PromotionType FavouritePromotion { get; set; }

        public void ReadPromotion(PromotionType promotion)
        {
            Console.WriteLine($"Hi {Name}, currentlly on ptomotion are {promotion} products");
            if(promotion == FavouritePromotion)
            {
                Console.WriteLine("Your favourite!");
            }
        }
    }
}
