using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoPark.Extensions;
using AutoPark.Model.Vehicles;
using AutoPark.Services;

namespace AutoPark.Controllers
{
    /// <summary>
    /// Level 2 controller
    /// </summary>
    class InterfaceController : IController
    {
        private readonly List<Vehicle> vehicles;

        public InterfaceController(List<Vehicle> vehicles)
        {
            this.vehicles = vehicles;
        }

        private (Vehicle Min, Vehicle Max) FindVehiclesWithMinAndMaxMileage()
        {
            //selecting vehicles  min and max mileage 
            var vehicleWithLowestMileage = vehicles.SelectMin(vehicle => vehicle.Mileage);
            var vehicleWithHighestMileage = vehicles.SelectMax(vehicle => vehicle.Mileage);

            return (vehicleWithLowestMileage, vehicleWithHighestMileage);
        }

        private void SortVehicles()
        {
            //show unsorted collection
            Console.WriteLine("Unsorted collection:");
            OutputService.PrintVehicleTable(vehicles);

            //sorting vehicles
            vehicles.Sort();

            //show sorted collection to console
            Console.WriteLine("Sorted collection:");
            OutputService.PrintVehicleTable(vehicles);
        }

        public void Run()
        {
            SortVehicles();

            var minAndMax = FindVehiclesWithMinAndMaxMileage();
            Console.WriteLine($"Vehicle with min mileage: {minAndMax.Min}, Vehicle with max mileage: {minAndMax.Max}");
        }
    }
}
