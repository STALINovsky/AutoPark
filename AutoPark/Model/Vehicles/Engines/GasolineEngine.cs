namespace AutoPark.Model.Vehicles.Engines
{
    public class GasolineEngine : CombustionAbstractEngine
    {
        public GasolineEngine(double engineVolume, double fuelConsumptionPer100, int engineCapacity) 
            : base(EngineTypesNamesConstant.GasolineEngine, 1)
        {
            EngineVolume = engineVolume;
            FuelConsumptionPer100 = fuelConsumptionPer100;
            EngineCapacity = engineCapacity;
        }
    }
}