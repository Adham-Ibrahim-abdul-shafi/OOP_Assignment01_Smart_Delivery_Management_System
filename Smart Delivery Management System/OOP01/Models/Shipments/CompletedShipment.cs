using System;
using System.Collections.Generic;
using System.Text;

namespace Smart_Delivery_Management_System.OOP01.Models.Shipments
{
    internal sealed class CompletedShipment : Shipment
    {
        public CompletedShipment(string trackingCode) : base(trackingCode)
        {
        }

        public CompletedShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress deliveryAddress) : base(trackingCode, description, weight, deliveryFee, deliveryAddress)
        {
        }

        public override decimal EstimatedCost => DeliveryFee + (Weight * 5);

        public override void PrintShipment()
        {
            Console.WriteLine("Completed Shipments: ");
            Console.WriteLine();
            Console.WriteLine(base.ToString());
            Console.WriteLine();
            Console.WriteLine("-------------------------------");
            Console.WriteLine();
        }
    }
}
