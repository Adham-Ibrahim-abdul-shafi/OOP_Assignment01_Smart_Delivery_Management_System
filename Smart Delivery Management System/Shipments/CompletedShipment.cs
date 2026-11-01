using System;
using System.Collections.Generic;
using System.Text;
using Smart_Delivery_Management_System.DataTypes;
using Smart_Delivery_Management_System.Deliveries;
using Smart_Delivery_Management_System.OOP01.Models;

namespace Smart_Delivery_Management_System.Shipments
{
    internal sealed class CompletedShipment : Shipment
    {
        public CompletedShipment(string trackingCode) : base(trackingCode)
        {
            TrackingState = TypesTrackingState.Completed;
        }

        public CompletedShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress deliveryAddress) : base(trackingCode, description, weight, deliveryFee, deliveryAddress,TypesTrackingState.Completed)
        {
            
        }

        public override decimal EstimatedCost => DeliveryFee + (Weight * 5);

        public override void PrintShipment()
        {
            Console.WriteLine("Completed Shipments: ");
            Console.WriteLine();
            Console.WriteLine(base.ToString());
            Console.WriteLine("status : Completed");
            Console.WriteLine();
            Console.WriteLine("-------------------------------");
            Console.WriteLine();
        }

        public override Shipment DeepCopy()
        {
            return new CompletedShipment(TrackingCode, Description, Weight, DeliveryFee,  Destination.DeepCopy());
        }

        

    }
}
