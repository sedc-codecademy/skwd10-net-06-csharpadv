namespace Class14_Workshop.Domain
{
    using System;
    using System.Linq;

    /// <summary>
    /// <see cref="Driver"/> entity.
    /// </summary>
    public class Driver : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Shift? Shift { get; set; }
        public string TaxiLicenseNumber { get; set; }
        public Car Car { get; set; }

        /// <summary>
        /// Checks if driver has a valid license.
        /// </summary>
        public TaxiLicenseExpiryStatus TaxiLicenseExpiryStatus
        {
            get
            {
                if (TaxiLicenseExpiryDate > DateTime.Now)
                {
                    return TaxiLicenseExpiryDate.AddMonths(3) > DateTime.Now
                        ? TaxiLicenseExpiryStatus.Valid
                        : TaxiLicenseExpiryStatus.Warning;
                }

                return TaxiLicenseExpiryStatus.Expired;
            }
        }

        /// <summary>
        /// Checks if driver is available.
        /// </summary>
        public bool IsAvailable
        {
            get { return TaxiLicenseExpiryStatus != TaxiLicenseExpiryStatus.Expired && Car == null; }
        }

        /// <summary>
        /// Checks if driver is assigned.
        /// </summary>
        public bool IsAssigned
        {
            get { return Car != null; }
        }

        public DateTime TaxiLicenseExpiryDate { get; set; }

        /// <summary>
        /// Needed for deserialization.
        /// </summary>
        public Driver()
        {

        }

        /// <summary>
        /// Creates a new <see cref="Driver"/> instance.
        /// </summary>
        /// <param name="firstName">Driver's first name.</param>
        /// <param name="lastName">Driver's last name</param>
        /// <param name="taxiLicenseNumber">Driver's taxi license number.</param>
        /// <param name="taxiLicenseExpiryDate">Driver's taxi license expiry date.</param>
        public Driver(string firstName, string lastName, string taxiLicenseNumber,
            DateTime taxiLicenseExpiryDate)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("Parameter cannot be empty", nameof(firstName));

            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Parameter cannot be empty", nameof(lastName));

            if (string.IsNullOrWhiteSpace(taxiLicenseNumber))
                throw new ArgumentException("Parameter cannot be empty", nameof(taxiLicenseNumber));

            FirstName = firstName;
            LastName = lastName;
            TaxiLicenseNumber = taxiLicenseNumber;
            TaxiLicenseExpiryDate = taxiLicenseExpiryDate;
        }

        /// <summary>
        /// Static factory method for usage when seeding entities. This is needed because auto-generating Ids for
        /// existing entities in a persistent database will re-insert the same entities with new auto-generated Ids.
        ///
        /// This allows restoring of Ids of seeded data when trying to reinsert them.
        /// </summary>
        /// <param name="id">The Id of the driver.</param>
        /// <param name="firstName">Driver's first name.</param>
        /// <param name="lastName">Driver's last name</param>
        /// <param name="taxiLicenseNumber">Driver's taxi license number.</param>
        /// <param name="taxiLicenseExpiryDate">Driver's taxi license expiry date.</param>
        /// <returns>A new <see cref="Driver"/> instance that can be seeded.</returns>
        public static Driver CreateForSeed(int id, string firstName, string lastName, string taxiLicenseNumber,
            DateTime taxiLicenseExpiryDate)
        {
            return new Driver(firstName, lastName, taxiLicenseNumber, taxiLicenseExpiryDate) { Id = id };
        }
        /// <summary>
        /// Assigns a <see cref="Car"/> instance to current <see cref="Driver"/>
        /// instance. Not really used in a practical sense in this state, but perhaps
        /// an "unintuitive" way to connect drivers with cars.
        /// </summary>
        /// <param name="car"><see cref="Car"/> instance to be assigned to a driver.</param>
        /// <param name="shift">The shift the driver to be assigned to.</param>
        /// <returns><c>true</c> if assignment is successful; otherwise <c>false</c>.</returns>
        public bool AssignCar(Car car, Shift shift)
        {
            if (car.AssignedDrivers.Any(driver => driver.Shift == shift))
                return false;

            // set driver's shift
            Shift = shift;

            // set driver's car
            Car = car;

            // also set the driver as an AssignedDriver to the Car instance
            Car.AssignedDrivers.Add(this);

            return true;
        }

        /// <summary>
        /// Unassigns assigned car from driver. Makes sure that the assigned car instance's
        /// <see cref="Class14_Workshop.Domain.Car.AssignedDrivers"/> is updated as well.
        /// </summary>
        /// <returns><c>true</c> if unassignment is successful; otherwise <c>false</c>.</returns>
        public bool UnassignCar()
        {
            if (!Car.AssignedDrivers.Contains(this))
                return false;

            Car.AssignedDrivers.Remove(this);

            Car = null;

            return true;
        }
    }

    /// <summary>
    /// Enum that models working shift for drivers.
    /// </summary>
    public enum Shift
    {
        Morning = 1,
        AfterNoon,
        Evening
    }

    /// <summary>
    /// Taxi license expiry statuses. Will be used when "prettifying" output.
    /// </summary>
    public enum TaxiLicenseExpiryStatus
    {
        Valid = 1,
        Warning,
        Expired
    }
}
