using System;
using System.Collections.Generic;
using System.Text;
using Smart_Delivery_Management_System.DataTypes;

namespace Smart_Delivery_Management_System.Interfaces
{
    internal interface ITrackable
    {

        TypesTrackingState GetTrackingState();
    }
}
