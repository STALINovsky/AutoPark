using System;
using System.Collections.Generic;
using System.Linq;
using AutoPark.Model.Vehicles.Engines;

namespace AutoPark.Model.Vehicles
{
    public class Vehicle : IComparable<Vehicle>, IEquatable<Vehicle>
    {
        public int Id { get; init; }
        public VehicleType VehicleType { get; init; }
        public string ModelName { get; init; }
        public string RegistrationNumber { get; init; }
        /// <summary>
        /// Weight in KG
        /// </summary>
        public int Weight { get; init; }
        public int ManufactureYear { get; init; }
        /// <summary>
        /// Mileage in kilometers 
        /// </summary>
        public int Mileage { get; init; }
        public CarColor Color { get; init; }
        /// <summary>
        /// Volume in liters or kilowatts
        /// </summary>
        public double VolumeOfTank { get; init; }
        public AbstractEngine AbstractEngine { get; init; }
        public List<Rent> Rents { get; set; }

        public Vehicle()
        {
            
        }

        public Vehicle(int id, VehicleType vehicleType, AbstractEngine engine, double volumeOfTank,
            string modelName, string registrationNumber, int weight, int manufactureYear, int mileage, CarColor color, List<Rent> rents)
        {
            Id = id;
            VehicleType = vehicleType;
            AbstractEngine = engine;
            VolumeOfTank = volumeOfTank;
            ModelName = modelName;
            RegistrationNumber = registrationNumber;
            Weight = weight;
            ManufactureYear = manufactureYear;
            Mileage = mileage;
            Color = color;
            Rents = rents;
        }

        public const decimal WeightTaxCoefficient = 0.0013m;
        public decimal TaxPerMonth => Weight * WeightTaxCoefficient + VehicleType.TaxCoefficient * AbstractEngine.TaxCoefficient * 30 + 5;

        public double MaxDrivingRange => AbstractEngine.MaxDrivingRange(VolumeOfTank);
        public decimal TotalIncome => Rents.Sum(rent => rent.RentPrice);
        public decimal TotalProfit => TotalIncome - TaxPerMonth;

        public override string ToString() =>
            $"{VehicleType}, {ModelName}, {RegistrationNumber}, {Weight}, {ManufactureYear}, {Mileage}, {Color}";

        public int CompareTo(Vehicle other) => TaxPerMonth.CompareTo(TaxPerMonth);

        public bool Equals(Vehicle other)
        {
            if (other == null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return other.ModelName == ModelName
                   && VehicleType.TypeName == other.VehicleType.TypeName
                   && VehicleType.TaxCoefficient == other.VehicleType.TaxCoefficient;
        }

        public override bool Equals(object obj)
        {
            if (obj is Vehicle vehicle)
            {
                return Equals(vehicle);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(VehicleType, ModelName);
        }
    }
}