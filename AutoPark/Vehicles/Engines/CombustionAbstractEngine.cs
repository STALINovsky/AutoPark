namespace AutoPark.Vehicles.Engines
{
    public abstract class CombustionAbstractEngine : AbstractEngine
    {
        protected CombustionAbstractEngine(string typeName, decimal taxCoefficient) : base(typeName, taxCoefficient)
        {
        }

        /// <summary>
        /// calculates how many kilometers a car can travel on a full tank
        /// </summary>
        /// <param name="fuelTankVolume">tank volume in liters</param>
        /// <returns>kilometers</returns>
        public override double MaxDrivingRange(double fuelTankVolume) => fuelTankVolume * 100 / FuelConsumptionPer100;

        /// <summary>
        /// Fuel consumption per 100 kilometers in liters  
        /// </summary>
        public double FuelConsumptionPer100 { get; protected init; }
        /// <summary>
        /// AbstractEngine volume in liters 
        /// </summary>
        public double EngineVolume { get; protected init; }
    }
}