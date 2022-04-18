namespace CSharpAdvanced_G2_L3_GenericDb.Entities
{
    public abstract class BaseEntity<T>
    {
        public int Id { get; set; }

        public BaseEntity(int id)
        {
            Id = id;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }

            var other = obj as BaseEntity<T>;

            if (other == null)
            {
                return false;
            }

            return Id == other.Id;
        }
    }
}
