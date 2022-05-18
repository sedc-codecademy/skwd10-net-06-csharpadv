using TaxiCo.TaxiManager9000.Domain;
using TaxiCo.TaxiManager9000.Domain.Enums;
using TaxiCo.TaxiManager9000.Domain.Models;

namespace System.Collections.Generic
{
    public static class ListExtension
    {
        private static readonly Dictionary<ExpieryStatus, ConsoleColor> StatusColorMap = new Dictionary<ExpieryStatus, ConsoleColor>()
        {
            {ExpieryStatus.Valid, ConsoleColor.Green },
            {ExpieryStatus.Warning, ConsoleColor.Yellow},
            {ExpieryStatus.Expired, ConsoleColor.Red }
        };

        public static void Print<T>(this List<T> list) where T : BaseEntity
        {
            if (list.Count == 0) ExtendedConsole.NoItemsMessage<T>();
            else foreach (var item in list) Console.WriteLine(item.Print());
            Console.ReadLine();
        }

        public static void PrintStatus(this List<Car> list)
        {
            if(list.Count == 0) ExtendedConsole.NoItemsMessage<Car>();
            else foreach (var car in list)
                {
                    ExpieryStatus expieryStatus = car.IsLicenseExpired();
                    ExtendedConsole.Write($"[{expieryStatus}])", StatusColorMap[expieryStatus]);
                    Console.WriteLine($"Car Id: {car.Id} - Plate: {car.LicensePlate} with expiery date: {car.LicensePlateExpieryDate}");
                }
            Console.ReadLine();
        }

        public static void PrintStatus(this List<Driver> list)
        {
            if (list.Count == 0) ExtendedConsole.NoItemsMessage<Driver>();
            else foreach (var driver in list)
                {
                    ExpieryStatus expieryStatus = driver.IsLicenseExpired();
                    ExtendedConsole.Write($"[{expieryStatus}])", StatusColorMap[expieryStatus]);
                    Console.WriteLine($"Driver: {driver.FullName} with license {driver.License} with expiery date: {driver.LicenseExpieryDate}");
                }
            Console.ReadLine();
        }
    }
}
