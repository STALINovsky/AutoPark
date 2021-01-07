﻿namespace AutoPark.Vehicles.Engines
{
    public class DieselEngine : CombustionAbstractEngine
    {
        public DieselEngine(double engineVolume, double fuelConsumptionPer100, int engineCapacity) : base("Diesel", 1.2m)
        {
            EngineVolume = engineVolume;
            FuelConsumptionPer100 = fuelConsumptionPer100;
            EngineCapacity = engineCapacity;
        }
    }
}