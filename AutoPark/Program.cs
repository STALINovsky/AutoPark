using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace AutoPark
{
    static class Program
    {
        static List<VehicleType> CreateVehicleTypes()
        {
            return new List<VehicleType>()
            {
                new ("Bus", 1.2m),
                new ("Car", 1m),
                new ("Rink", 1.5m),
                new ("Tractor", 1.2m),
            };
        }

        static void Main(string[] args)
        {

            var vehicleTypes = CreateVehicleTypes();
            foreach (var vehicleType in vehicleTypes)
            {
                vehicleType.Display();
            }

            var lastVehicleType = vehicleTypes.Last();
            lastVehicleType.TaxCoefficient = 1.3m;

            decimal CoefficientSelector(VehicleType vehicleType) => vehicleType.TaxCoefficient;
            var maxTaxCoefficient = vehicleTypes.Max(CoefficientSelector);
            var averageCoefficient = vehicleTypes.Average(CoefficientSelector);

            foreach (var vehicleType in vehicleTypes)
            {
                Console.WriteLine(vehicleType);
            }

        }
    }
}
