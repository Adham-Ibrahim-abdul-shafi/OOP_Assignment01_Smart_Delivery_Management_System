using System;
using System.Collections.Generic;
using System.Text;
using Smart_Delivery_Management_System.OOP01.Models.DataTypes;

namespace Smart_Delivery_Management_System.OOP01.Models.Interfaces
{
    internal interface ITrackable
    {

        TypesTrackingState GetTrackingState();
    }
}
