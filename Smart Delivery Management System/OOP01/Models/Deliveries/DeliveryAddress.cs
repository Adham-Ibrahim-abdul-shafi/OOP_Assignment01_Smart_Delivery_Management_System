namespace Smart_Delivery_Management_System.OOP01.Models.Deliveries
{
    public class DeliveryAddress
    {
        
        public string City { get; set; }

        public string Street { get; set; }

        public int BuildingNumber {  set; get; }
        public DeliveryAddress(string city,string street,int buildingNumber)
        {
            City = city;  
            Street = street;
            BuildingNumber = buildingNumber;
        }

        public DeliveryAddress(DeliveryAddress other)
        {
            City =new string(other.City);
            Street = new string(other.Street);
            BuildingNumber = other.BuildingNumber;
        }

        public DeliveryAddress() {
            City = "Unknown";
            Street = "Unknown";
            BuildingNumber = 0;
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
