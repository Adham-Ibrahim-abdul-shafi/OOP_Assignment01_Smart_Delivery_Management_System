using System;
using System.Collections.Generic;
using System.Text;
using Smart_Delivery_Management_System.DataTypes;
using Smart_Delivery_Management_System.Interfaces;

namespace Smart_Delivery_Management_System.OOP01.Models
{
    internal  abstract partial class Shipment : ITrackable

    {
        

        private TypesTrackingState _trackingState = TypesTrackingState.Ready;

                    

        public TypesTrackingState TrackingState
        {
            get { return _trackingState; }
            set { _trackingState = value; }
        }

        public TypesTrackingState GetTrackingState()
        {
            return _trackingState;
        }

        public void UpdateTrackingStatus(TypesTrackingState typesTrackingState)
        {
            _trackingState = typesTrackingState;
            OnTrackingStatusChanged(typesTrackingState);
        }

        partial void OnTrackingStatusChanged(TypesTrackingState newStatus);
    }
}
