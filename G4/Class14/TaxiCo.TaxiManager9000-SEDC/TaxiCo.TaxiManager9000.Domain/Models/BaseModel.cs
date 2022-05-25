namespace TaxiManager9000.Domain
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public abstract string Print();
    }
}
