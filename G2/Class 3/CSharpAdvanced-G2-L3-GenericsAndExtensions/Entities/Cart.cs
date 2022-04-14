namespace CSharpAdvanced_G2_L3_GenericsAndExtensions.Entities
{
    public class Cart : BaseEntity<Cart>
    {
        public Cart(int id) : base(id)
        {
        }
    }
}
