namespace Class14_Workshop.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// <see cref="Car"/> entity.
    /// </summary>
    public class Car : BaseEntity
    {
        /// <summary>
        /// Static field to keep track on what was the last assigned
        /// Id for <see cref="Car"/>, so we are able to calculate the
        /// next one when creating a new instance (see <see cref="BaseEntity"/>
        /// constructor on how this works).
        /// </summary>
        private static int s_lastEntityId = 0;

        private static Func<int> s_customIdFactory;

        /// <summary>
        /// Allows customizing Id generation for <see cref="Car"/> entity.
        ///
        /// It can be set only once, because it employs the "singleton pattern".
        /// Should be set in a static context before the application actually starts running (e.g. static constructor).
        /// </summary>
        public static Func<int> CustomIdFactory
        {
            get => s_customIdFactory;
            set
            {
                if (s_customIdFactory == null)
                {
                    s_customIdFactory = value;
                }
            }
        }

        public string Model { get; }
        public string LicensePlateNumber { get; }
        public DateTime LicensePlateExpiryDate { get; }
        
        /// <summary>
        /// Needs the <see cref="JsonProperty"/> attribute with <see cref="JsonProperty.ItemReferenceLoopHandling"/> == <see cref="ReferenceLoopHandling.Ignore"/>
        /// to avoid issues with circular dependencies. The <see cref="JsonProperty.ItemIsReference"/> is an optimization for Newtonsoft.Json to try to restore
        /// object reference data when deserializing entities.
        /// </summary>
        [JsonProperty(ItemReferenceLoopHandling = ReferenceLoopHandling.Ignore, ItemIsReference = true)]
        public List<Driver> AssignedDrivers { get; }

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
        /// Private constructor to allow setting of the Id property (used by <see cref="CreateForSeed"/> method.
        /// It is marked with [<see cref="JsonConstructorAttribute"/>] so we force Newtonsoft.Json to use this constructor
        /// when deserializing the entity.
        /// </summary>
        /// <param name="id">The car Id.</param>
        /// <param name="model">Model of car.</param>
        /// <param name="licensePlateNumber">License plate of car.</param>
        /// <param name="licensePlateExpiryDate">Date when license plate expires.</param>
        [JsonConstructor]
        private Car(int id, string model, string licensePlateNumber,
            DateTime licensePlateExpiryDate) : base(id)
        {
            if (string.IsNullOrWhiteSpace(model))
                throw new ArgumentException("Parameter cannot be empty", nameof(model));

            if (string.IsNullOrWhiteSpace(licensePlateNumber))
                throw new ArgumentException("Parameter cannot be empty", nameof(licensePlateNumber));

            Model = model;
            LicensePlateNumber = licensePlateNumber;
            LicensePlateExpiryDate = licensePlateExpiryDate;

            AssignedDrivers = new List<Driver>();
        }

        /// <summary>
        /// Creates a new <see cref="Car"/> instance.
        /// Invokes <see cref="BaseEntity"/> default constructor.
        /// </summary>
        /// <param name="model">Model of car.</param>
        /// <param name="licensePlateNumber">License plate of car.</param>
        /// <param name="licensePlateExpiryDate">Date when license plate expires.</param>
        public Car(string model, string licensePlateNumber, DateTime licensePlateExpiryDate) : this(0, model,
            licensePlateNumber, licensePlateExpiryDate)
        {

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
            return new Car(id, model, licensePlateNumber, licensePlateExpiryDate);
        }

        protected override int GetNextEntityId()
        {
            if (CustomIdFactory != null)
            {
                return CustomIdFactory();
            }

            return  ++s_lastEntityId;
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
