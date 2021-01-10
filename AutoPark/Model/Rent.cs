using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPark.Model
{
    public class Rent
    {
        public int VehicleId { get; init; }
        public DateTime LeaseDate { get; init; }
        public decimal RentPrice { get; init; }

        public Rent()
        {

        }

        public Rent(int vehicleId, DateTime leaseDate, decimal rentPrice)
        {
            VehicleId = vehicleId;
            LeaseDate = leaseDate;
            RentPrice = rentPrice;
        }

    }
}
