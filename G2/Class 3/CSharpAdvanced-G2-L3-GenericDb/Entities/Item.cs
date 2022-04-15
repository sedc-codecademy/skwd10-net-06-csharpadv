namespace CSharpAdvanced_G2_L3_GenericDb.Entities
{
    public class Item : BaseEntity<Item>
    {
        public string Name { get; set; }

        public int Quantity { get; set; }

        public Item(int id, string name, int quantity) : base(id)
        {
            Name = name;
            Quantity = quantity;
        }
    }
}
