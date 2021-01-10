using System;
using System.Collections.Generic;
using System.Linq;
using AutoPark.Collections;
using AutoPark.Data;
using AutoPark.Model;
using AutoPark.Model.Vehicles;
using AutoPark.Model.Vehicles.Engines;

namespace AutoPark.Controllers
{
    /// <summary>
    /// Level 5 controller
    /// </summary>
    public class CollectionController : IController
    {
        const string VEHICLE_PATH = @"Data\vehicles.csv";
        const string VEHICLE_TYPES_PATH = @"Data\types.csv";
        const string RENTS_PATH = @"Data\rents.csv";
        private readonly VehicleContext vehicleContext = new VehicleContext(VEHICLE_PATH, VEHICLE_TYPES_PATH, RENTS_PATH);

        public void AppendNewVehicle()
        {
            //calculating index of new element
            var indexOfNewElement = vehicleContext.Vehicles.Count + 1;
            var typeOfNewElement = vehicleContext.VehicleTypes[3];

            //append item to vehicle collection -1 = AppEnd
            vehicleContext.Insert(-1, new( indexOfNewElement, typeOfNewElement,
                new DieselEngine(4.75, 20.1, 135),60,
                "МТЗ Беларус-1025.4", "1145 AB-7", 1200, 2020, 109, CarColor.Blue, new List<Rent>()));
        }

        public void Run()
        {
            vehicleContext.PrintVehicles();

            AppendNewVehicle();

            vehicleContext.DeleteByIndex(1);
            vehicleContext.DeleteByIndex(4);

            vehicleContext.PrintVehicles();

            vehicleContext.SortVehicle();
        }
    }
}