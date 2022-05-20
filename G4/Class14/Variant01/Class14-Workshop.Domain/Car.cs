namespace Class14_Workshop.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// <see cref="Car"/> entity.
    /// </summary>
    public class Car : BaseEntity
    {
        public string Model { get; set; }
        public string LicensePlateNumber { get; set; }
        public DateTime LicensePlateExpiryDate { get; set; }


        public List<Driver> AssignedDrivers { get; set; }

        public LicensePlateExpiryStatus LicensePlateExpiryStatus
        {
            get
            {
                if (LicensePlateExpiryDate > DateTime.Now)
                {
                    return LicensePlateExpiryDate.AddMonths(3) > DateTime.Now
                        ? LicensePlateExpiryStatus.Valid
                        : LicensePlateExpiryStatus.Warning;
                }

                return LicensePlateExpiryStatus.Expired;
            }
        }

        /// <summary>
        /// Checks if car is operational.
        /// </summary>
        public bool IsOperational
        {
            get
            {
                return LicensePlateExpiryStatus != LicensePlateExpiryStatus.Expired;
            }
        }

        /// <summary>
        /// Checks if car is available.
        /// </summary>
        public bool IsAvailable
        {
            get
            {
                return IsOperational && Enum.GetValues<Shift>()
                    .Any(shift => AssignedDrivers.All(driver => driver.Shift != shift));
            }
        }

        /// <summary>
        /// Needed for deserialization.
        /// </summary>
        public Car()
        {
            AssignedDrivers = new List<Driver>();
        }

        /// <summary>
        /// Creates a new <see cref="Car"/> instance.
        /// </summary>
        /// <param name="model">Model of car.</param>
        /// <param name="licensePlateNumber">License plate of car.</param>
        /// <param name="licensePlateExpiryDate">Date when license plate expires.</param>
        public Car(string model, string licensePlateNumber, DateTime licensePlateExpiryDate) : this()
        {
            if (string.IsNullOrWhiteSpace(model))
                throw new ArgumentException("Parameter cannot be empty", nameof(model));

            if (string.IsNullOrWhiteSpace(licensePlateNumber))
                throw new ArgumentException("Parameter cannot be empty", nameof(licensePlateNumber));

            Model = model;
            LicensePlateNumber = licensePlateNumber;
            LicensePlateExpiryDate = licensePlateExpiryDate;
        }

        /// <summary>
        /// Static factory method for usage when seeding entities. This is needed because auto-generating Ids for
        /// existing entities in a persistent database will re-insert the same entities with new auto-generated Ids.
        ///
        /// This allows restoring of Ids of seeded data when trying to reinsert them.
        /// </summary>
        /// <param name="id">The car Id.</param>
        /// <param name="model">Model of car.</param>
        /// <param name="licensePlateNumber">License plate of car.</param>
        /// <param name="licensePlateExpiryDate">Date when license plate expires.</param>
        /// <returns>A new <see cref="Car"/> instance that can be seeded.</returns>
        public static Car CreateForSeed(int id, string model, string licensePlateNumber,
            DateTime licensePlateExpiryDate)
        {
            return new Car(model, licensePlateNumber, licensePlateExpiryDate) { Id = id };
        }
    }

    /// <summary>
    /// License plate expiry statuses. Will be used when "prettifying" output.
    /// </summary>
    public enum LicensePlateExpiryStatus
    {
        Valid,
        Warning,
        Expired
    }
}
