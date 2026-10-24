using System;
using System.Collections.Generic;
using System.Text;

namespace Smart_Delivery_Management_System.OOP01.Models
{
    internal sealed class CompletedShipment : Shipment
    {
        public CompletedShipment(string trackingCode) : base(trackingCode)
        {
        }

        public CompletedShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress deliveryAddress) : base(trackingCode, description, weight, deliveryFee, deliveryAddress)
        {
        }
    }
}
