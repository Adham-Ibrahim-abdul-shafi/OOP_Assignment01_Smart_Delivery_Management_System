using System;
using System.Collections.Generic;
using System.Text;
using Smart_Delivery_Management_System.DataTypes;
using Smart_Delivery_Management_System.Deliveries;

namespace Smart_Delivery_Management_System.Shipments
{
    internal class PriorityInternationalShipment : InternationalShipment
    {
        public PriorityInternationalShipment(string trackingCode, decimal customFee, string destinationCountry) : base(trackingCode, customFee, destinationCountry)
        {
        }

        public PriorityInternationalShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress deliveryAddress, decimal customFee, string destinationCountry,TypesTrackingState trackingState) : base(trackingCode, description, weight, deliveryFee, deliveryAddress, customFee, destinationCountry,trackingState)
        {
        }

        public override sealed void GenerateCustomsReport()
        {
            Console.WriteLine($"[Priority] Customs Report Generate for {TrackingCode} -> {DestinationCountry} ");
        }
    }
}
