using System;
using System.Collections.Generic;
using AutoPark.Collections;
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
        private readonly VehicleCollection vehicleCollection = new VehicleCollection(VEHICLE_PATH, VEHICLE_TYPES_PATH, RENTS_PATH);

        public void AppendNewVehicle()
        {
            //calculating index of new element
            var indexOfNewElement = vehicleCollection.Vehicles.Count + 1;
            var typeOfNewElement = vehicleCollection.VehicleTypes[3];

            //append item to vehicle collection -1 = AppEnd
            vehicleCollection.Insert(-1, new( indexOfNewElement, typeOfNewElement,
                new DieselEngine(4.75, 20.1, 135),60,
                "МТЗ Беларус-1025.4", "1145 AB-7", 1200, 2020, 109, CarColor.Blue, new List<Rent>()));
        }

        public void Run()
        {
            vehicleCollection.PrintVehicles();

            AppendNewVehicle();

            vehicleCollection.Delete(1);
            vehicleCollection.Delete(4);

            vehicleCollection.PrintVehicles();

            vehicleCollection.SortVehicle();
        }
    }
}