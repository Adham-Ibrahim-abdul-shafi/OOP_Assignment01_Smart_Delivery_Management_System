namespace Smart_Delivery_Management_System.OOP01.Models.Shipments
{
    internal class StandardShipment : Shipment , IInsurable,ITrackable
    {
        public StandardShipment(string trackingCode) : base(trackingCode) { }

        public StandardShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress deliveryAddress,TypesTrackingState trackingState) : base(trackingCode, description, weight, deliveryFee, deliveryAddress,trackingState) { }

        public override decimal EstimatedCost => DeliveryFee + (Weight * 5);

        public decimal CalculateInsurance()
        {
            return 0.05m * EstimatedCost;
        }

        public override Shipment DeepCopy()
        {
            return new StandardShipment(TrackingCode, Description, Weight, DeliveryFee, new DeliveryAddress(_destination.City,_destination.Street,_destination.BuildingNumber ),GetTrackingState());
        }

        

        public override void PrintShipment()
        {
            Console.WriteLine("Standard Shipments: ");
            Console.WriteLine();
            Console.WriteLine(base.ToString());
            Console.WriteLine();
            Console.WriteLine("-------------------------------");
            Console.WriteLine();
        }
    }
}
