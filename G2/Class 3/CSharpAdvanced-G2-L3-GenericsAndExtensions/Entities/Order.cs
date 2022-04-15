namespace CSharpAdvanced_G2_L3_GenericsAndExtensions.Entities
{
    public class Order : BaseEntity<Order>
    {
        public Order(int id) : base(id)
        {
        }
    }
}
