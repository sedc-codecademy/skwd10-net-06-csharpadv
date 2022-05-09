namespace CSharpAdvanced_G2_L10_FileDb.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        protected BaseEntity(int id)
        {
            Id = id;
        }

        protected BaseEntity()
        {
            Id = -1;
        }
    }
}
