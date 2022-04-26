using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionModelWithEvents.Entities
{
    // This is a publisher class
    public class Market
    {
        public delegate void PromotionSender(ProductType product);
        public delegate void InformationSender(string info);

        private event PromotionSender Promotion;
        private event InformationSender Information;

        // Standard properties
        public string Name { get; set; }
        public ProductType CurrentPromotion { get; set; }
        public List<string> ZalbiIPoplaki { get; set; }
        public List<string> Emails { get; set; }
        public Market()
        {
            ZalbiIPoplaki = new List<string>();
            Emails = new List<string>();
        }

        public void SendPromotion()
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine($"{Name} is sending promotion for {CurrentPromotion}");
            Console.WriteLine("...Sending");
            Thread.Sleep(3000);
            Send();
        }
        private void Send()
        {
            Promotion(CurrentPromotion);
        }
        public void SubscribeForPromotion(PromotionSender subscriber, string email)
        {
            Promotion += subscriber;
            Emails.Add(email);
        }

        public void UnsubscribeForPromotion(PromotionSender unsubscriber, string reason)
        {
            Promotion -= unsubscriber;
            ZalbiIPoplaki.Add(reason);
        }

        public void ReadZalbiIPoplaki()
        {
            Console.WriteLine($"[{Name}] ZALBI I POPLAKI:");
            foreach(string zalba in ZalbiIPoplaki)
            {
                Console.WriteLine(zalba);
            }
        }

    }

    public enum ProductType
    {
        Food,
        Cosmetics,
        Electronics,
        Other
    }
}
