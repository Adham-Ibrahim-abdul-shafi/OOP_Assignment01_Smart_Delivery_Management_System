namespace Smart_Delivery_Management_System.Deliveries
{
    public class DeliveryAddress
    {
        private string _city;
        private string _street;
        private int _bulidingNumber;

        public string City
        {
            get => _city;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _city = value;
                }
            }
        }
        public string Street
        {
            get => _street;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _street = value;
                }
            }
        }
        public int BuildingNumber
        {
            set
            {
                if (value >= 0)
                {
                    _bulidingNumber = value;
                }
            }
            get => _bulidingNumber;
        }

        public DeliveryAddress(string city, string street, int buildingNumber)
        {
            _city = "Unknown";
            _street = "Unknown";
            BuildingNumber = 0;

            City = city;
            Street = street;
            BuildingNumber = buildingNumber;
        }

        public DeliveryAddress(DeliveryAddress other) : this(other.City, other.Street, other.BuildingNumber)
        {

        }

        public DeliveryAddress() : this("Unknown", "Unknown", 0)
        {

        }

        public override string ToString()
        {
            return $"{BuildingNumber} , {Street} , {City}";
        }

        public string GetFullAddress()
        {
            return $"{BuildingNumber} , {Street} , {City}";
        }

        public DeliveryAddress DeepCopy()
        {
            return new DeliveryAddress(this.City, this.Street, this.BuildingNumber);
        }

    }
}
