using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using AutoPark.Model.Vehicles;
using AutoPark.Services;

namespace AutoPark.Controllers
{
    /// <summary>
    /// 1 Level controller
    /// </summary>
    public class ClassesController : IController
    {
        private readonly IEnumerable<VehicleType> types;
        public ClassesController(IEnumerable<VehicleType> types)
        {
            this.types = types ?? throw new ArgumentNullException(nameof(types));
        }

        public void Run()
        {
            //output vehicleTypes using Display method
            foreach (var vehicleType in types)
            {
                vehicleType.Display();
            }

            //select last item and assign some value
            var lastVehicleType = types.Last();
            lastVehicleType.TaxCoefficient = 1.3m;

            //select max and average tax coefficients 
            var maxTaxCoefficient = types.Max(type => type.TaxCoefficient);
            var averageCoefficient = types.Average(type => type.TaxCoefficient);
            //show max and average coefficients 
            Console.WriteLine($"max type coefficient: {maxTaxCoefficient}, average type coefficient {averageCoefficient}");

            //show vehicleTypes using ToString method
            OutputService.PrintCollection(types);
        }
    }
}
