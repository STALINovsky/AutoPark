using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoPark.Model;
using AutoPark.Model.Vehicles;
using AutoPark.Model.Vehicles.Engines;

namespace AutoPark.Services
{
    public static class CsvDeserializer
    {
        private const char FIELD_SEPARATOR = ',';

        private static List<string> GetFieldsList(string cvsString)
        {
           return cvsString.Split(FIELD_SEPARATOR).ToList();
        }

        public static Vehicle DeserializeVehicle(string csvString, IList<VehicleType> vehicleTypes, IEnumerable<Rent> rents)
        {
            var fields = GetFieldsList(csvString);
            var vehicle =  new Vehicle()
            {
                Id = int.Parse(fields[0]),
                VehicleType = vehicleTypes.First(type => type.Id == int.Parse(fields[1])),
                ModelName = fields[2],

                RegistrationNumber = fields[3],
                Weight = int.Parse(fields[4]),
                ManufactureYear = int.Parse(fields[5]),

                Mileage = int.Parse(fields[6]),
                Color = Enum.Parse<CarColor>(fields[7]),
                AbstractEngine = fields[8] switch
                {
                    EngineTypesNamesConstant.GasolineEngine =>
                        new GasolineEngine(double.Parse(fields[9]), double.Parse(fields[10]), int.Parse(fields[11])),

                    EngineTypesNamesConstant.DieselEngine =>
                        new DieselEngine(double.Parse(fields[9]), double.Parse(fields[10]), int.Parse(fields[11])),

                    EngineTypesNamesConstant.ElectricalEngine =>
                        new ElectricalEngine(double.Parse(fields[9]), double.Parse(fields[11])),

                    _ => throw new ArgumentOutOfRangeException()
                },
            };
            vehicle.Rents = rents.Where(rent => rent.VehicleId == vehicle.Id).ToList();

            return vehicle;
        }

        public static VehicleType DeserializeVehicleType(string csvString)
        {
            var fields = GetFieldsList(csvString);
            return new VehicleType(int.Parse(fields[0]), fields[1], decimal.Parse(fields[2]));
        }

        public static Rent DeserializeRent(string csvString)
        {
            var fields = GetFieldsList(csvString);
            return new Rent(int.Parse(fields[0]), DateTime.Parse(fields[1]), decimal.Parse(fields[2]));
        }

        public static List<string> DeserializeOrders(string csvString)
        {
            return GetFieldsList(csvString);
        }
        
    }
}
