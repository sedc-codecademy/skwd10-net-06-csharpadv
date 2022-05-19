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
        /// <summary>
        /// Static field to keep track on what was the last assigned
        /// Id for <see cref="Car"/>, so we are able to calculate the
        /// next one when creating a new instance (see <see cref="BaseEntity"/>
        /// constructor in combination with <see cref="BaseEntity.GetNextEntityId"/>
        /// on how this works).
        /// </summary>
        private static int s_lastEntityId = 0;

        public string Model { get; }
        public string LicensePlateNumber { get; }
        public DateTime LicensePlateExpiryDate { get; }
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

        public bool IsOperational
        {
            get
            {
                return LicensePlateExpiryStatus != LicensePlateExpiryStatus.Expired;
            }
        }

        public bool IsAvailable
        {
            get
            {
                return IsOperational && Enum.GetValues<Shift>()
                    .Any(shift => AssignedDrivers.All(driver => driver.Shift != shift));
            }
        }

        /// <summary>
        /// Creates a new <see cref="Car"/> instance.
        /// Invokes <see cref="BaseEntity"/> default constructor.
        /// </summary>
        /// <param name="model">Model of car.</param>
        /// <param name="licensePlateNumber">License plate of car.</param>
        /// <param name="licensePlateExpiryDate">Date when license plate expires.</param>
        public Car(string model, string licensePlateNumber, DateTime licensePlateExpiryDate) : base()
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

        protected override int GetNextEntityId()
        {
            return ++s_lastEntityId;
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
