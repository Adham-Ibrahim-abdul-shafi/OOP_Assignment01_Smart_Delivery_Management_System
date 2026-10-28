using System;
using System.Collections.Generic;
using System.Text;
using Smart_Delivery_Management_System.Interfaces;

namespace Smart_Delivery_Management_System.Reports
{
    internal static class DeliveryReport
    {
        public static void PrintShipment(ITrackable shipment)
        {
            Console.WriteLine($"Tracking State: {shipment.GetTrackingState()}");
        }

        public static void PrintInsurance(IInsurable shipment)
        {
            Console.WriteLine($"CalculateInsurance = {shipment.CalculateInsurance():0.00} EGP");
        }
    }
}
