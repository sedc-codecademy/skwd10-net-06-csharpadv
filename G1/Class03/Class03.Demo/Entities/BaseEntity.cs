namespace Class03.Demo.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public abstract string GetInfo();
    }
}
