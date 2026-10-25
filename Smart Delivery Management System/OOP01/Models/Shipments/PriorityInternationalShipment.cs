using System;
using System.Collections.Generic;
using System.Text;

namespace Smart_Delivery_Management_System.OOP01.Models.Shipments
{
    internal class PriorityInternationalShipment : InternationalShipment
    {
        public PriorityInternationalShipment(string trackingCode, decimal customFee, string destinationCountry) : base(trackingCode, customFee, destinationCountry)
        {
        }

        public PriorityInternationalShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress deliveryAddress, decimal customFee, string destinationCountry) : base(trackingCode, description, weight, deliveryFee, deliveryAddress, customFee, destinationCountry)
        {
        }

        public override sealed void GenerateCustomsReport()
        {
            
        }
    }
}
