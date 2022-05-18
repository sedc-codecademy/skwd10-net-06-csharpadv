namespace Class08_Workshop.Domain
{
    using System;
    using System.Linq;

    /// <summary>
    /// <see cref="Driver"/> entity.
    /// </summary>
    public class Driver : BaseEntity 
    {
        /// <summary>
        /// Static field to keep track on what was the last assigned
        /// Id for <see cref="Driver"/>, so we are able to calculate the
        /// next one when creating a new instance (see <see cref="BaseEntity"/>
        /// constructor in combination with <see cref="BaseEntity.GetNextEntityId"/>
        /// on how this works).
        /// </summary>
        private static int s_lastEntityId = 0;
        
        public string FirstName { get; }
        public string LastName { get; }
        public Shift? Shift { get; private set; }
        public string TaxiLicenseNumber { get; }
        public Car Car { get; private set; }

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

        public bool IsAvailable
        {
            get
            {
                return TaxiLicenseExpiryStatus != TaxiLicenseExpiryStatus.Expired && Car == null;
            }
        }

        public bool IsAssigned
        {
            get
            {
                return Car != null;
            }
        }

        public DateTime TaxiLicenseExpiryDate { get; }

        /// <summary>
        /// Creates a new <see cref="Driver"/> instance.
        /// Invokes <see cref="BaseEntity"/> default constructor.
        /// </summary>
        /// <param name="firstName">Driver's first name.</param>
        /// <param name="lastName">Driver's last name</param>
        /// <param name="shift">Driver's working shift.</param>
        /// <param name="taxiLicenseNumber">Driver's taxi license number.</param>
        /// <param name="taxiLicenseExpiryDate">Driver's taxi license expiry date.</param>
        public Driver(string firstName, string lastName, string taxiLicenseNumber, DateTime taxiLicenseExpiryDate)
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

        protected override int GetNextEntityId()
        {
            return ++s_lastEntityId;
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
        /// <see cref="Class08_Workshop.Domain.Car.AssignedDrivers"/> is updated as well.
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
