namespace AutoPark.Model.Vehicles.Engines
{
    class ElectricalEngine : AbstractEngine
    {
        public ElectricalEngine(double electricConsumption, double engineCapacity) :
            base(EngineTypesNamesConstant.ElectricalEngine, 0.1m)
        {
            ElectricConsumption = electricConsumption;
            EngineCapacity = engineCapacity;
        }
        /// <summary>
        /// consumption of abstractEngine in kilowatts
        /// </summary>
        public double ElectricConsumption { get; set; }

        public override double MaxDrivingRange(double volumeOfTank) => volumeOfTank / ElectricConsumption;
    }
}
