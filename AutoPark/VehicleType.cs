using System;

namespace AutoPark
{
    public class VehicleType
    {
        public string TypeName { get; set; }
        public decimal TaxCoefficient { get; set; }

        public VehicleType()
        {
            
        }

        public VehicleType(string typeName, decimal taxCoefficient)
        {
            TypeName = typeName;
            TaxCoefficient = taxCoefficient;
        }

        public void Display() => Console.WriteLine(ToString());
        public override string ToString() => $"{TypeName}, {TaxCoefficient}";
    }
}