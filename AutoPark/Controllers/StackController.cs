using System;
using AutoPark.Collections;
using AutoPark.Model.Vehicles;

namespace AutoPark.Controllers
{
    /// <summary>
    /// Level 7 controller
    /// </summary>
    public class StackController : IController
    {
        private const int VEHICLE_COUNT = 10;
        public void Run()
        {
            Stack<Vehicle> stack = new Stack<Vehicle>();

            for (int i = 0; i < VEHICLE_COUNT; i++)
            {
                stack.Push(new Vehicle() { ModelName = $"car number {i}" });
            }

            while(stack.Length != 0)
            {
                Console.WriteLine($"{stack.Pop().ModelName} left the garage");
            }
        }
    }
}