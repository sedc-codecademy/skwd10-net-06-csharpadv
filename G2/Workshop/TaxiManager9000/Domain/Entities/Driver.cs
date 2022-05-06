using TaxiManager9000.Domain.Enums;

namespace TaxiManager9000.Domain.Entities
{
    public class Driver : BaseEntity
    {
        public Shift Shift { get; set; }
    }
}
