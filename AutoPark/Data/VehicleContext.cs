using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoPark.Extensions;
using AutoPark.Model;
using AutoPark.Model.Vehicles;
using AutoPark.Services;

namespace AutoPark.Data
{
    /// <summary>
    /// Collection for working with data in csv format
    /// </summary>
    public class VehicleContext
    {
        private readonly List<Vehicle> vehicles;
        private readonly List<VehicleType> vehicleTypes;
        private readonly List<Rent> rents;

        public IReadOnlyList<Vehicle> Vehicles => vehicles;
        public IReadOnlyList<VehicleType> VehicleTypes => vehicleTypes;
        public IReadOnlyList<Rent> Rents => rents;

        public decimal TotalProfit => vehicles.Sum(vehicle => vehicle.TotalIncome) -
                                      vehicles.Sum(vehicle => vehicle.TaxPerMonth)
                                      + rents.Sum(rent => rent.RentPrice);

        public VehicleContext(string vehiclesFilePath, string vehicleTypesFilePath, string rentsFilePath)
        {
            vehicleTypes = LoadVehicleTypes(vehicleTypesFilePath);
            rents = LoadRents(rentsFilePath);
            vehicles = LoadVehicles(vehiclesFilePath, vehicleTypes, rents);
        }

        private static readonly string LinesSeparator = Environment.NewLine;

        private static IEnumerable<string> LoadCsvLines(string filePath)
        {
            using var textReader = File.OpenText(filePath);
            var textData = textReader.ReadToEnd();
            return textData.Split(LinesSeparator, StringSplitOptions.RemoveEmptyEntries);
        }

        private static List<Vehicle> LoadVehicles(string filePath, IList<VehicleType> vehicleTypes, IList<Rent> rents)
        {
            var lines = LoadCsvLines(filePath);

            var vehicles = new List<Vehicle>();
            foreach (var line in lines)
            {
                vehicles.Add(CsvDeserializer.DeserializeVehicle(line, vehicleTypes, rents));
            }

            return vehicles;
        }

        private static List<VehicleType> LoadVehicleTypes(string filePath)
        {
            var lines = LoadCsvLines(filePath);

            var vehicleTypes = new List<VehicleType>();
            foreach (var line in lines)
            {
                vehicleTypes.Add(CsvDeserializer.DeserializeVehicleType(line));
            }

            return vehicleTypes;
        }

        private static List<Rent> LoadRents(string filePath)
        {
            var lines = LoadCsvLines(filePath);

            var rents = new List<Rent>();
            foreach (var line in lines)
            {
                rents.Add(CsvDeserializer.DeserializeRent(line));
            }

            return rents;
        }

        public void PrintVehicles()
        {
            OutputService.PrintVehicleTable(vehicles);
        }

        /// <summary>
        /// Delete vehicle its index if index is valid return index of deleted item else -1
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public int DeleteByIndex(int index)
        {
            if (vehicles.IsIndexValid(index))
            {
                vehicles.RemoveAt(vehicles.FindIndex(item => item.Id == index));
                return index;
            }

            return -1;
        }

        public void SortVehicle()
        {
            vehicles.Sort();
        }

        /// <summary>
        /// insert index to the collection if index isn't valid Append this element
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        public void Insert(int index, Vehicle item)
        {
            if (vehicles.IsIndexValid(index))
            {
                vehicles.Insert(index, item);
                return;
            }

            vehicles.Add(item);
        }
    }
}
