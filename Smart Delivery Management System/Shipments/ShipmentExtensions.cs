using System;
using System.Collections.Generic;
using System.Text;
using Smart_Delivery_Management_System.DataTypes;
using Smart_Delivery_Management_System.OOP01.Models;

namespace Smart_Delivery_Management_System.Shipments
{
    internal static class ShipmentExtensions
    {

        public static bool IsDelivered(this Shipment shipment)
        {
            return shipment.GetTrackingState() == TypesTrackingState.Delivered;
        }

        public static string GetSummary(this Shipment shipment)
        {
            return $"{shipment.TrackingCode} | {shipment.GetType().Name} | {shipment.Weight} KG | {shipment.GetTrackingState()}";
        }
    }
}
