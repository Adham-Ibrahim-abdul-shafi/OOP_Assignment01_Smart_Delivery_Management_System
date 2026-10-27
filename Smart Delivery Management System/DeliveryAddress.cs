namespace Smart_Delivery_Management_System
{
    public struct DeliveryAddress
    {
        private string _city;
        private string _street { get; set; }
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
                if(value >= 0)
                {
                    _bulidingNumber = value;
                }
            }
            get => _bulidingNumber;
        }

        
        public DeliveryAddress(string city,string street,int buildingNumber) 
        {
            City = "Unknown";
            Street = "Unknown";
            BuildingNumber = 0;
            
            
            City = city;  
            Street = street;
            BuildingNumber = buildingNumber;
        }

        public DeliveryAddress(DeliveryAddress other) : this(new string(other.City), new string(other.Street),other.BuildingNumber) 
        {}

        public DeliveryAddress()  : this("UnKnown","UnKnown",0)
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

    }
}
