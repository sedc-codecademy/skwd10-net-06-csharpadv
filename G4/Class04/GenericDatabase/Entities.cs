namespace GenericDatabase
{
    /// <summary>
    /// Abstract class that all (database) entities will
    /// inherit from. Has some predefined members that would
    /// be used in generic methods that use it as generic
    /// type parameter.
    /// </summary>
    internal abstract class BaseEntity
    {
        public int Id { get; set; }
        public abstract string GetInfo();
    }

    internal class Order : BaseEntity
    {
        public string Receiver { get; set; }
        public string Address { get; set; }

        public override string GetInfo()
        {
            return $"{Id}) {Receiver} - {Address}";
        }
    }

    internal class Product : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public override string GetInfo()
        {
            return $"{Id}) {Title} - {Description}";
        }
    }
}
