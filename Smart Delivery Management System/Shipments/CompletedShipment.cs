using System;
using System.Collections.Generic;
using System.Text;
using Smart_Delivery_Management_System.Delivery;

namespace Smart_Delivery_Management_System.Shipments
{
    internal sealed class CompletedShipment : Shipment
    {
        public CompletedShipment(string trackingCode) : base(trackingCode)
        {
        }

        public CompletedShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress deliveryAddress) : base(trackingCode, description, weight, deliveryFee, deliveryAddress)
        {
        }
        public override void PrintShipment()
        {
            Console.WriteLine("Completed Shipments: ");
            Console.WriteLine();
            base.PrintShipment();
            Console.WriteLine("status : Completed");
            Console.WriteLine("-------------------------------");
            Console.WriteLine();
        }
    }
}
