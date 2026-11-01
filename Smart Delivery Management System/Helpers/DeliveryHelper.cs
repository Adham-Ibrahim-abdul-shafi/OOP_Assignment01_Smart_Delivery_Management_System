using System;
using System.Collections.Generic;
using System.Text;
using Smart_Delivery_Management_System.OOP01.Models;


namespace Smart_Delivery_Management_System.Helpers
{
    internal class DeliveryHelper
    {

        public static void PrintShipmentDetails(Shipment shipment)
        {
            shipment.PrintShipment();
            Console.WriteLine($"{shipment.GetType().Name} printed Successfully");
            Console.WriteLine();
        }
    }

}
