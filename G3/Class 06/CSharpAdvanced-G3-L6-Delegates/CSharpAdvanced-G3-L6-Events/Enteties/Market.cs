
namespace CSharpAdvanced_G3_L6_Events.Enteties
{
    public class Market
    {
        public delegate void PromotionSender(ProductType productType, string name);

        event PromotionSender PromotionsSenderEvent;

        public ProductType CurrentProdutType { get; set; }

        public List<string> Emails { get; set; }

        public string Name { get; set; }

        public Market()
        {
            Emails = new List<string>();
        }

        public void SubscribeToPromotion(PromotionSender eventHandler, string email)
        {
            PromotionsSenderEvent += eventHandler;
            Emails.Add(email);
        }

        public void Send()
        {
            PromotionsSenderEvent(CurrentProdutType, Name);
        }

        public void Unsubscribe(PromotionSender eventHandler, string email)
        {
            PromotionsSenderEvent -= eventHandler;
            string emailToDelete = Emails.FirstOrDefault(x => x == email);
            Emails.Remove(emailToDelete);
        }
    }

    public enum ProductType
    {
        Food,
        Cosmetics,
        Electronic,
        Other
    }
}
