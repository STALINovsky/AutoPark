using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPark.Vehicles.Engines
{
    class ElectricalEngine : AbstractEngine
    {
        public ElectricalEngine(double electricConsumption, double engineCapacity) : base("Electrical", 0.1m)
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
