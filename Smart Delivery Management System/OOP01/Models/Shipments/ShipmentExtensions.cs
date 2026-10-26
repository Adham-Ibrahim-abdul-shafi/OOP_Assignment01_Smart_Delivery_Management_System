using System;
using System.Collections.Generic;
using System.Text;

namespace Smart_Delivery_Management_System.OOP01.Models.Shipments
{
    internal static class ShipmentExtensions
    {
        public static bool IsDelivered(this Shipment shipment)
        {
            return shipment.GetTrackingState().Equals("Is Delivered");
        }

        public static string GetSummary(this Shipment shipment)
        {
            return $"{shipment.TrackingCode} | {shipment.GetType().Name} | {shipment.Weight} KG | {shipment.GetTrackingState()}";
        }
    }
}
