namespace Class11.Exercise1.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public abstract string Info();
    }
}
