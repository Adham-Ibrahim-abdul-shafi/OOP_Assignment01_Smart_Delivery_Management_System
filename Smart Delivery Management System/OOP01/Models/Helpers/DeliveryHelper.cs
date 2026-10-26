using System;
using System.Collections.Generic;
using System.Text;
using Smart_Delivery_Management_System.OOP01.Models.Shipments;

namespace Smart_Delivery_Management_System.OOP01.Models.Helpers
{
    internal class DeliveryHelper
    {
        public static void PrintShipmentDetails(Shipment shipment)
        {
            shipment.PrintShipment();
        }
    }
}
