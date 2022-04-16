namespace Class05_Workshop.Domain
{
    using System;
    using System.Collections.Generic;

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
        public string LicensePlate { get; }
        public DateTime LicensePlateExpiryDate { get; }
        public List<Driver> AssignedDrivers { get; }

        /// <summary>
        /// Creates a new <see cref="Car"/> instance.
        /// Invokes <see cref="BaseEntity"/> default constructor.
        /// </summary>
        /// <param name="model">Model of car.</param>
        /// <param name="licensePlate">License plate of car.</param>
        /// <param name="licensePlateExpiryDate">Date when license plate expires.</param>
        public Car(string model, string licensePlate, DateTime licensePlateExpiryDate) : base()
        {
            Model = model;
            LicensePlate = licensePlate;
            LicensePlateExpiryDate = licensePlateExpiryDate;

            AssignedDrivers = new List<Driver>();
        }

        protected override int GetNextEntityId()
        {
            return ++s_lastEntityId;
        }

        public override void Print()
        {
            throw new NotImplementedException();
        }
    }
}
