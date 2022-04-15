namespace CSharpAdvanced_G2_L3_GenericsAndExtensions.Entities
{
    public class Pear : Box<Pear>
    {
        public Pear(int id) : base(id)
        {
        }
    }
}
