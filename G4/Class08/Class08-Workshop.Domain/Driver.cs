namespace Class05_Workshop.Domain
{
    using System;

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
        public Shift Shift { get; }
        public Car Car { get; private set; }

        /// <summary>
        /// Checks if driver has a valid license.
        /// </summary>
        public bool HasValidLicense
        {
            get
            {
                return LicenseExpiryDate > DateTime.Now;
            }
        }

        public DateTime LicenseExpiryDate { get; }

        /// <summary>
        /// Creates a new <see cref="Driver"/> instance.
        /// Invokes <see cref="BaseEntity"/> default constructor.
        /// </summary>
        /// <param name="firstName">Driver's first name.</param>
        /// <param name="lastName">Driver's last name</param>
        /// <param name="shift">Driver's working shift.</param>
        public Driver(string firstName, string lastName, Shift shift)
        {
            FirstName = firstName;
            LastName = lastName;
            Shift = shift;
        }

        protected override int GetNextEntityId()
        {
            return ++s_lastEntityId;
        }

        public override void Print()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Assigns a <see cref="Car"/> instance to current <see cref="Driver"/>
        /// instance. Not really used in a practical sense in this state, but perhaps
        /// an "unintuitive" way to connect drivers with cars.
        /// </summary>
        /// <param name="car"><see cref="Car"/> instance to be assigned to a driver.</param>
        public void AssignCar(Car car)
        {
            // set driver's car
            Car = car;

            // also set the driver as an AssignedDriver to the Car instance
            car.AssignedDrivers.Add(this);
        }
    }

    /// <summary>
    /// Enum that models working shift for drivers.
    /// </summary>
    public enum Shift
    {
        Morning,
        AfterNoon,
        Evening
    }
}
