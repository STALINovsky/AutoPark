using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using AutoPark.Vehicles;

namespace AutoPark
{
    static class Program
    {
        static readonly List<VehicleType> VehicleTypes = new List<VehicleType>()
        {
            new("Bus", 1.2m),
            new("Car", 1m),
            new("Rink", 1.5m),
            new("Tractor", 1.2m),
        };

        static readonly List<Vehicle> Vehicles = new List<Vehicle>()
        {
            new (VehicleTypes[0],"Volkswagen Crafter", "5427 AX-7", 2022,  2015, 376000, CarColor.Blue),
            new (VehicleTypes[0],"Volkswagen Crafter", "6427 AA-7", 2500,  2014, 227010, CarColor.White),
            new (VehicleTypes[0],"Electric Bus E321",  "6785 BA-7", 12080, 2019, 20451,  CarColor.Green),
            new (VehicleTypes[1],"Golf 5",             "8682 AX-7", 1200,  2006, 230451, CarColor.Gray),
            new (VehicleTypes[1],"Tesla Model S",      "E001 AA-7", 2200,  2019, 10454,  CarColor.White),
            new (VehicleTypes[2],"Hamm HD 12 VV",      null,        3000,  2016, 122,    CarColor.Yellow),
            new (VehicleTypes[3],"МТЗ Беларус-1025.4", "1145 AB-7", 1200,  2020, 109, CarColor.Blue)
        };

        static void Main(string[] args)
        {

            //output vehicleTypes using Display method
            foreach (var vehicleType in VehicleTypes)
            {
                vehicleType.Display();
            }

            var lastVehicleType = VehicleTypes.Last();
            lastVehicleType.TaxCoefficient = 1.3m;

            //select max and average tax coefficients 
            var maxTaxCoefficient = VehicleTypes.Max(type => type.TaxCoefficient);
            var averageCoefficient = VehicleTypes.Average(type => type.TaxCoefficient);
            //show max and average coefficients 
            Console.WriteLine($"max type coefficient: {maxTaxCoefficient}, average type coefficient {averageCoefficient}");

            //show vehicleTypes using ToString method
            OutputService.PrintCollection(VehicleTypes);

            //sorting vehicles
            Vehicles.Sort();

            //show sorted collection to console
            OutputService.PrintCollection(VehicleTypes);

            //selecting min and max mileage
            var lowestMileage = Vehicles.Min(vehicle => vehicle.Mileage);
            var highestMileage = Vehicles.Max(vehicle => vehicle.Mileage);

            //selecting vehicles by min and max mileage 
            var vehicleWithLowestMileage = Vehicles.First(vehicle => vehicle.Mileage == lowestMileage);
            var vehicleWithHighestMileage = Vehicles.First(vehicle => vehicle.Mileage == highestMileage);

            //show vehicles whits lowest and highest mileage
            Console.WriteLine($"vehicle with lowest mileage: {vehicleWithLowestMileage}, vehicle with highest mileage: {vehicleWithHighestMileage}");
        }

    }
}
