using System;
using System.Collections.Generic;
using System.Linq;
using AutoPark.Extensions;
using AutoPark.Model.Vehicles;

namespace AutoPark.Controllers
{
    /// <summary>
    /// Level 4 controller 
    /// </summary>
    public class AbstractionController : IController
    {
        private readonly IEnumerable<Vehicle> vehicles;

        public AbstractionController(IEnumerable<Vehicle> vehicles)
        {
            this.vehicles = vehicles;
        }

        public void Run()
        {
            var vehicleWithMaxDrivingRange = vehicles.SelectMax(vehicle => vehicle.Mileage);
            Console.WriteLine($"Vehicle with max driving range: {vehicleWithMaxDrivingRange}, max driving range: {vehicleWithMaxDrivingRange.MaxDrivingRange:0.000}");
        }
    }
}