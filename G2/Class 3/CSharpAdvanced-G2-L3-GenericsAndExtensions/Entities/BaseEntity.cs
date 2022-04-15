namespace CSharpAdvanced_G2_L3_GenericsAndExtensions.Entities
{
    public abstract class BaseEntity<T>
    {
        public int Id { get; set; }

        protected BaseEntity(int id)
        {
            Id = id;
        }

        public bool IsEqualTo(BaseEntity<T> obj)
        {
            return Id == obj.Id;
        }
    }
}
