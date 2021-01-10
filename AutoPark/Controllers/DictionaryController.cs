using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoPark.Services;

namespace AutoPark.Controllers
{
    /// <summary>
    /// Level 8 controller
    /// </summary>
    public class DictionaryController : IController
    {
        private const string RENT_FILE_PATH = @"Data/orders.csv";

        private void PrintOrders(Dictionary<string, int> orders)
        {
            foreach (var order in orders)
            {
                Console.WriteLine($"{order.Key} - {order.Value}");
            }
        }

        public void Run()
        {
            var data = File.ReadAllText(RENT_FILE_PATH);
            var lines = data.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var orderFields = new List<string>();
            foreach (var line in lines)     
            {
                orderFields.AddRange(CsvDeserializer.DeserializeOrders(line));
            }

            var orders = new Dictionary<string, int>();
            foreach (var field in orderFields)
            {
                if (orders.ContainsKey(field))
                {
                    orders[field]++;
                }
                else
                {
                    orders.Add(field, 1);
                }
            }

            PrintOrders(orders);
        }
    }
}