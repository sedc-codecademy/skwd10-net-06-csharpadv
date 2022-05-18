namespace Class14_Workshop.UI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Domain;

    /// <summary>
    /// Extensions for printing entities.
    /// </summary>
    static class PrintEntityExtensions
    {
        /// <summary>
        /// Default printing of list of cars.
        /// </summary>
        /// <param name="cars">The car list.</param>
        public static void Print(this IEnumerable<Car> cars)
        {
            Console.WriteLine("Cars list:");
            Console.WriteLine("~~~~~~~~~~");

            foreach (var car in cars)
            {
                Console.WriteLine(
                    $"{car.Id}) {car.Model} with License Plate {car.LicensePlateNumber} and utilized {(!car.AssignedDrivers.Any() ? 0 : 100 / 3 * car.AssignedDrivers.Count + 1)}%");
            }
        }

        /// <summary>
        /// Print car list's license plate expiry statuses.
        /// </summary>
        /// <param name="cars">The car list.</param>
        public static void PrintLicensePlateExpiryStatuses(this IEnumerable<Car> cars)
        {
            Console.WriteLine("Car license expiry statuses:");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            foreach (var car in cars)
            {
                Console.WriteLine(
                    $"{car.LicensePlateExpiryStatus}) Car Id {car.Id} - Plate {car.LicensePlateNumber} expiring on {car.LicensePlateExpiryDate}");
            }
        }

        /// <summary>
        /// Default printing of list of drivers.
        /// </summary>
        /// <param name="drivers">The driver list.</param>
        public static void Print(this IEnumerable<Driver> drivers)
        {
            Console.WriteLine("Driver list:");
            Console.WriteLine("~~~~~~~~~~~~");

            foreach (var driver in drivers)
            {
                var sbDriverInfo = new StringBuilder();
                sbDriverInfo.Append($"{driver.Id}) {driver.FirstName} {driver.LastName} ");

                if (driver.Car != null && driver.Shift.HasValue)
                {
                    sbDriverInfo.Append($"Driving in the {driver.Shift.Value} shift with a {driver.Car.Model} car");
                }
                else
                {
                    sbDriverInfo.Append("with no assigned car");
                }

                Console.WriteLine(sbDriverInfo.ToString());
            }
        }

        /// <summary>
        /// Print driver list's taxi license expiry statuses.
        /// </summary>
        /// <param name="drivers">The driver list.</param>
        public static void PrintTaxiLicenseExpiryStatuses(this IEnumerable<Driver> drivers)
        {
            Console.WriteLine("Taxi license expiry statuses:");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            foreach (var driver in drivers)
            {
                Console.WriteLine(
                    $"{driver.TaxiLicenseExpiryStatus}) Driver {driver.FirstName} {driver.LastName} with license {driver.TaxiLicenseNumber} expiring on {driver.TaxiLicenseExpiryDate}");
            }
        }

        /// <summary>
        /// Default printing of list of users.
        /// </summary>
        /// <param name="users">The user list.</param>
        public static void Print(this IEnumerable<User> users)
        {
            Console.WriteLine("Current users");
            Console.WriteLine("~~~~~~~~~~~~~");

            foreach (var user in users)
            {
                Console.WriteLine($"{user.Id}) {user.UserName}, Role {user.Role}");
            }
        }
    }
}
