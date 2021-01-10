using AutoPark.Model.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoPark.Collections;
using AutoPark.Controllers;
using AutoPark.Model;
using AutoPark.Model.Vehicles.Engines;
using AutoPark.Services;

namespace AutoPark
{
    static class Program
    {
        //default list of vehicle types
        static readonly List<VehicleType> VehicleTypes = new List<VehicleType>()
        {
            new(1,"Bus", 1.2m),
            new(2,"Car", 1m),
            new(3,"Rink", 1.5m),
            new(4,"Tractor", 1.2m),
        };
        //default list of vehicles
        static readonly List<Vehicle> Vehicles = new()
        {
            new(1, VehicleTypes[0], new GasolineEngine(2, 8.1, 75), 100,
                "Volkswagen Crafter", "5427 AX-7", 2022, 2015, 376000, CarColor.Blue, new List<Rent>()),

            new(2, VehicleTypes[0], new GasolineEngine(2.18, 8.5, 75), 100,
                "Volkswagen Crafter", "6427 AA-7", 2500, 2014, 227010, CarColor.White, new List<Rent>()),

            new(3, VehicleTypes[0], new ElectricalEngine(50, 150), 200,
                "Electric Bus E321", "6785 BA-7", 12080, 2019, 20451, CarColor.Green, new List<Rent>()),

            new(4, VehicleTypes[1], new DieselEngine(1.6, 7.2, 55), 60,
                "Golf 5", "8682 AX-7", 1200, 2006, 230451, CarColor.Gray, new List<Rent>()),

            new(5, VehicleTypes[1], new ElectricalEngine(25, 75), 45,
                "Tesla Model S", "E001 AA-7", 2200, 2019, 10454, CarColor.White, new List<Rent>()),

            new(6, VehicleTypes[2], new DieselEngine(3.2, 25, 20), 70,
                "Hamm HD 12 VV", null, 3000, 2016, 122, CarColor.Yellow, new List<Rent>()),

            new(7, VehicleTypes[3], new DieselEngine(4.75, 20.1, 135), 80,
                "МТЗ Беларус-1025.4", "1145 AB-7", 1200, 2020, 109, CarColor.Blue, new List<Rent>())
        };


        static void Main(string[] args)
        {
            //init list of controllers
            var controllers = new List<IController>()
            {
                new ClassesController(VehicleTypes),
                new InterfaceController(Vehicles),
                new InheritanceController(Vehicles),
                new AbstractionController(Vehicles),
                new CollectionController(),
                new QueueController(),
                new StackController(),
                new DictionaryController()
            };

            //run every controller
            for (var index = 0; index < controllers.Count; index++)
            {
                Console.WriteLine(new string('-', 20) + $"\n Level {index + 1}", '\n');

                var controller = controllers[index];
                controller.Run();
            }
        }
    }
}
