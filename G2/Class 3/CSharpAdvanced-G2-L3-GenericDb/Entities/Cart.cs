namespace CSharpAdvanced_G2_L3_GenericDb.Entities
{
    public class Cart : BaseEntity<Cart>
    {
        public string CartId { get; set; }

        public List<Item> Items { get; set; }

        public Cart(int id, List<Item> items, string cartId) : base(id)
        {
            Items = items;
            CartId = cartId;
        }
    }
}
