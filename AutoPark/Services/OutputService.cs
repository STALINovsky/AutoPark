using System;
using System.Collections.Generic;
using System.Linq;
using AutoPark.Model.Vehicles;

namespace AutoPark.Services
{
    public static class OutputService
    {
        public static void PrintCollection<T>(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }

        public static void PrintVehicleTable(IEnumerable<Vehicle> vehicles)
        {
            Console.WriteLine($"{"Id",-5}{"Type",-10}{"ModelName",-25}{"Number",-15}" +
                              $"{"Weight (kg)",-15}{"Year",-10}{"Mileage",-10}{"Color",-10}" +
                              $"{"Income",-10}{"Tax",-10}{"Profit",-10}");

            foreach (var item in vehicles)
            {
                Console.WriteLine(
                    $"{item.Id,-5}{item.VehicleType.TypeName,-10}{item.ModelName,-25}" +
                    $"{item.RegistrationNumber,-15}{item.Weight,-15}{item.ManufactureYear,-10}" +
                    $"{item.Mileage,-10}{item.Color,-10}{item.TotalIncome,-10:0.00}" +
                    $"{item.TaxPerMonth,-10:0.00}{item.TotalProfit,-10:0.00}");
            }
        }
    }
}