using System;
using System.Collections.Generic;
using System.Text;
using Smart_Delivery_Management_System.Interfaces;

namespace Smart_Delivery_Management_System.Helpers
{
    internal static class DeliveryReport
    {
        public static void PrintTrackingState(ITrackable shipment)
        {
            Console.WriteLine($"Tracking State: {shipment.GetTrackingState()}");
        }

        public static void PrintInsurance(IInsurable shipment)
        {
            Console.WriteLine($"CalculateInsurance = {shipment.CalculateInsurance()} EGP");
        }
    }
}
