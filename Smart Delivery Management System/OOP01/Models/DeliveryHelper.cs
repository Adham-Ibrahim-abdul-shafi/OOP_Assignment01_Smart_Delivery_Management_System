using System;
using System.Collections.Generic;
using System.Text;

namespace Smart_Delivery_Management_System.OOP01.Models
{
    internal class DeliveryHelper
    {
        public static void PrintShipmentDetails(Shipment shipment)
        {
            shipment.PrintShipment();
        }
    }
}
