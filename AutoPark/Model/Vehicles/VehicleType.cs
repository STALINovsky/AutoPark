using System;

namespace AutoPark.Model.Vehicles
{
    public class VehicleType
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public decimal TaxCoefficient { get; set; }

        public VehicleType()
        {

        }

        public VehicleType(int id, string typeName, decimal taxCoefficient)
        {
            Id = id;
            TypeName = typeName;
            TaxCoefficient = taxCoefficient;
        }

        public void Display() => Console.WriteLine(ToString());
        public override string ToString() => $"{TypeName}, {TaxCoefficient}";
    }
}