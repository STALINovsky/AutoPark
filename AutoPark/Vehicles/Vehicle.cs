using System;
using AutoPark.Vehicles.Engines;

namespace AutoPark.Vehicles
{
    public class Vehicle : IComparable<Vehicle>, IEquatable<Vehicle>
    {

        public VehicleType VehicleType { get; }
        public string ModelName { get; }
        public string RegistrationNumber { get; }
        /// <summary>
        /// Weight in KG
        /// </summary>
        public int Weight { get; }
        public int ManufactureYear { get; }
        /// <summary>
        /// Mileage in kilometers 
        /// </summary>
        public int Mileage { get; set; }
        public CarColor Color { get; set; }
        /// <summary>
        /// Volume in liters or kilowatts
        /// </summary>
        public double VolumeOfTank { get; set; }
        public AbstractEngine AbstractEngine { get; set; }

        public const decimal WeightTaxCoefficient = 0.0013m;
        public decimal TaxPerMonth => Weight * WeightTaxCoefficient + VehicleType.TaxCoefficient * AbstractEngine.TaxCoefficient * 30 + 5;

        public double MaxDrivingRange => AbstractEngine.MaxDrivingRange(VolumeOfTank);

        public Vehicle(VehicleType vehicleType, AbstractEngine engine, 
            string modelName, string registrationNumber, int weight, int manufactureYear, int mileage, CarColor color)
        {
            VehicleType = vehicleType;
            AbstractEngine = engine;
            ModelName = modelName;
            RegistrationNumber = registrationNumber;
            Weight = weight;
            ManufactureYear = manufactureYear;
            Mileage = mileage;
            Color = color;
        }

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