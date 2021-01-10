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
        private IEnumerable<Vehicle> vehicles;

        public InterfaceController(IEnumerable<Vehicle> vehicles)
        {
            this.vehicles = vehicles;
        }

        private Vehicle FindVehiclesWithMinMileage() => vehicles.SelectMin(vehicle => vehicle.Mileage);

        private Vehicle FindVehiclesWithMaxMileage() => vehicles.SelectMax(vehicle => vehicle.Mileage);

        private void SortVehicles()
        {
            //show unsorted collection
            Console.WriteLine("Unsorted collection:");
            OutputService.PrintVehicleTable(vehicles);

            //sorting vehicles
            vehicles = vehicles.OrderBy(item => item);

            //show sorted collection to console
            Console.WriteLine("Sorted collection:");
            OutputService.PrintVehicleTable(vehicles);
        }

        public void Run()
        {
            SortVehicles();

            Console.WriteLine($"Vehicle with min mileage: {FindVehiclesWithMinMileage()}, Vehicle with max mileage: {FindVehiclesWithMaxMileage()}");
        }
    }
}
