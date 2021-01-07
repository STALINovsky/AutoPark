namespace AutoPark.Vehicles.Engines
{
    public abstract class AbstractEngine
    {
        public AbstractEngine(string typeName, decimal taxCoefficient)
        {
            TypeName = typeName;
            TaxCoefficient = taxCoefficient;
        }

        public string TypeName { get; set; }
        public decimal TaxCoefficient { get; set; }

        /// <summary>
        /// AbstractEngine capacity in horsepower
        /// </summary>
        public double EngineCapacity { get; protected set; }
        
        /// <summary>
        /// Volume of the tank in liters or kilowatts
        /// </summary>
        /// <param name="volumeOfTank"></param>
        /// <returns></returns>
        public abstract double MaxDrivingRange(double volumeOfTank);
    }
}