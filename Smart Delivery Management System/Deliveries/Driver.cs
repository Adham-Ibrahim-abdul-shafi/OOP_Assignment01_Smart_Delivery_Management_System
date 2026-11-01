namespace Smart_Delivery_Management_System.Deliveries
{
    internal class Driver
    {
        public string Id { get; set; } = "UnKnown";
        public string Name { get; set; } = "UnKnown";
        public string PhoneNumber { get; set; } = "UnKnown";


        public Driver(string id, string name, string phoneNumber)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
        }


    }
}
