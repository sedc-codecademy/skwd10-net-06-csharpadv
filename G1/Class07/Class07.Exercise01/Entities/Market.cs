using Class07.Exercise01.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class07.Exercise01.Entities
{
    public class Market
    {
        public delegate void PromotionSender(PromotionType type);

        public event PromotionSender Promotions;

        public string Name { get; set; }
        public string Description { get; set; }
        public PromotionType CurrentPromotion { get; set; }
        public List<string> Complaints { get; set; }

        public Market()
        {
            Complaints = new List<string>();
        }

        public void SendPromotions()
        {
            Console.WriteLine("===================================");
            Console.WriteLine($"Market {Name} is sending promotion for {CurrentPromotion}");
            Send();
        }

        public void ChangePromotion(PromotionType promotion)
        {
            Console.WriteLine("===================================");
            Console.WriteLine($"Market {Name} is sending new promotion for {promotion}");
            CurrentPromotion = promotion;
            SendPromotions();
        }

        public void Send()
        {
            Promotions(CurrentPromotion);
        }

        public void Subscribe(PromotionSender promotion)
        {
            Promotions += promotion;
        }

        public void UnSubscribe(PromotionSender promotion, string complaintMessage)
        {
            Complaints.Add(complaintMessage);
            Promotions -= promotion;
        }

        public void ReadComplaints()
        {
            Console.WriteLine($"Complaints for market {Name} are the following:");
            Complaints.ForEach(x => Console.WriteLine(x));                
        }
    }
}
