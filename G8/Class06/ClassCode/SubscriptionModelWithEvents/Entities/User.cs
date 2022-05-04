using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionModelWithEvents.Entities
{
    // This class is a subscriber class
    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public ProductType FavouriteType { get; set; }
        public void ReadPromotion(ProductType product)
        {
            Console.WriteLine($"Mr/Ms: {Name}, The product {product} is on sale");
            if (product == FavouriteType) Console.WriteLine("MY FAVOURITE!");
        }
    }
}
