using Smart_Delivery_Management_System.DataTypes;
using Smart_Delivery_Management_System.Deliveries;
using Smart_Delivery_Management_System.Interfaces;
using Smart_Delivery_Management_System.OOP01.Models;

namespace Smart_Delivery_Management_System.Shipments
{
    internal class StandardShipment : Shipment , IInsurable,ITrackable
    {
        public StandardShipment(string trackingCode) : base(trackingCode) 
        {
            TrackingState = TypesTrackingState.Ready;
        }

        public StandardShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress deliveryAddress,TypesTrackingState trackingState) : base(trackingCode, description, weight, deliveryFee, deliveryAddress,trackingState) 
        {
            TrackingState = TypesTrackingState.Ready;
        }

        public override decimal EstimatedCost => DeliveryFee + (Weight * 5);

        public decimal CalculateInsurance()
        {
            return 0.05m * EstimatedCost;
        }

        

        public override Shipment DeepCopy()
        {
            return new StandardShipment(TrackingCode, Description, Weight, DeliveryFee, Destination.DeepCopy(),GetTrackingState());
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
