namespace AutoPark
{
    public class Vehicle
    {
        public VehicleType VehicleType { get; set; }
        public string ModelName { get; set; }
        public string RegistrationNumber { get; set; }
        /// <summary>
        /// Weight in KG
        /// </summary>
        public int Weight { get; set; }

        public int ManufactureYear { get; set; }
        public int Mileage { get; set; }

    }
}