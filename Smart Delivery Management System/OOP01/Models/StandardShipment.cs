namespace Smart_Delivery_Management_System.OOP01.Models
{
    internal class StandardShipment : Shipment
    {
        public StandardShipment(string trackingCode) : base(trackingCode) { }

        public StandardShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress deliveryAddress) : base(trackingCode, description, weight, deliveryFee, deliveryAddress) { }

        public override void PrintShipment()
        {
            Console.WriteLine("Standard Shipments: ");
            Console.WriteLine();
            base.PrintShipment();
            Console.WriteLine();
            Console.WriteLine("-------------------------------");
            Console.WriteLine();
        }
    }
}
