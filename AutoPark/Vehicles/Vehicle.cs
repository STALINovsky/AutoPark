using System;

namespace AutoPark.Vehicles
{
    public class Vehicle : IComparable<Vehicle>
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
        public const decimal WeightTaxCoefficient = 0.0013m;
        public decimal TaxPerMonth => Weight * WeightTaxCoefficient + VehicleType.TaxCoefficient * 30 + 5;

        public Vehicle
            (VehicleType vehicleType, string modelName, string registrationNumber, int weight, int manufactureYear, int mileage, CarColor color)
        {
            VehicleType = vehicleType;
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

    }
}