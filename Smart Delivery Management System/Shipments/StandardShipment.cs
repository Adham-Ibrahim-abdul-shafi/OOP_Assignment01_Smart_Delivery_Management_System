using Smart_Delivery_Management_System.Delivery;
using Smart_Delivery_Management_System.Interfaces;

namespace Smart_Delivery_Management_System.Shipments
{
    internal class StandardShipment : Shipment , IInsurable,ITrackable
    {
        public StandardShipment(string trackingCode) : base(trackingCode) {
            State = "Is Ready";
        }

        public StandardShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress deliveryAddress) : base(trackingCode, description, weight, deliveryFee, deliveryAddress) 
        {
            State = "Is Ready";
        }

        public override decimal EstimatedCost => DeliveryFee + (Weight * 5);

        public decimal CalculateInsurance()
        {
            return 0.05m * EstimatedCost;
        }

        public string GetTrackingState()
        {
            return $"Shipment {TrackingCode} {State}";
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
