using System;
using System.Collections.Generic;
using System.Linq;
using AutoPark.Model.Vehicles;
using AutoPark.Services;

namespace AutoPark.Controllers
{
    /// <summary>
    /// Level 3 controller
    /// </summary>
    public class InheritanceController : IController
    {
        private readonly IEnumerable<Vehicle> vehicles;
        public InheritanceController(IEnumerable<Vehicle> vehicles)
        {
            this.vehicles = vehicles;
        }

        public void Run()
        {
            OutputService.PrintVehicleTable(vehicles);
            //select same vehicles 
            var sameElements = vehicles.GroupBy(x => x)
                .Where(g => g.Count() > 1)
                .Select(y => new { Value = y.Key, Count = y.Count() });

            Console.WriteLine("Same Elements:");
            foreach (var element in sameElements)
            {
                Console.WriteLine($"vehicle: {element.Value.ModelName}, count: {element.Count}");
            }
        }
    }
}