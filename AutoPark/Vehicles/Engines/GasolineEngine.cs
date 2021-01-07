namespace AutoPark.Vehicles.Engines
{
    public class GasolineEngine : CombustionAbstractEngine
    {
        public GasolineEngine(double engineVolume, double fuelConsumptionPer100, int engineCapacity) : base("Gasoline", 1)
        {
            EngineVolume = engineVolume;
            FuelConsumptionPer100 = fuelConsumptionPer100;
            EngineCapacity = engineCapacity;
        }
    }
}