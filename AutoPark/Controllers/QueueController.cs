using System;
using System.Xml;
using AutoPark.Collections;
using AutoPark.Model.Vehicles;

namespace AutoPark.Controllers
{
    /// <summary>
    /// Level 6 controller
    /// </summary>
    public class QueueController : IController
    {
        public QueueController()
        {

        }

        private const int VEHICLES_COUNT = 10;

        public void Run()
        {
            Queue<Vehicle> queue = new Queue<Vehicle>();
            for (int i = 0; i < VEHICLES_COUNT; i++)
            {
                queue.Push(new Vehicle() { ModelName = $"car number {i}" });
            }

            while (queue.Length != 0)
            {
                Console.WriteLine($"{queue.Pop().ModelName} was washed");
            }
        }
    }
}