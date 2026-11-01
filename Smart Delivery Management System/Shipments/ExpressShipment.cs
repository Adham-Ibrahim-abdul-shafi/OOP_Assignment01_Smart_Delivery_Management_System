using Smart_Delivery_Management_System.DataTypes;
using Smart_Delivery_Management_System.Deliveries;
using Smart_Delivery_Management_System.Interfaces;
using Smart_Delivery_Management_System.OOP01.Models;

namespace Smart_Delivery_Management_System.Shipments
{
    internal class ExpressShipment : Shipment , IInsurable, ITrackable
    {
		private decimal _extraFee = 0;

		public ExpressShipment(string trackingCode,decimal extraFee) : base(trackingCode)
		{
			ExtraFee = extraFee;
            TrackingState = TypesTrackingState.OutforDelivery;
		}

		public ExpressShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress deliveryAddress, decimal extraFee,TypesTrackingState trackingState) : base(trackingCode, description, weight, deliveryFee, deliveryAddress,trackingState)
        {
            ExtraFee = extraFee;
        }

        public decimal ExtraFee
        {
			get { return _extraFee; }
			set {
				if(value >= 0) 
					_extraFee = value; 
			}
		}

		

		public override decimal EstimatedCost => DeliveryFee + (Weight * 5) + ExtraFee;

        public decimal CalculateInsurance()
        {
            return 0.08m * EstimatedCost;
        }

        public override Shipment DeepCopy()
        {
            return new ExpressShipment(TrackingCode,Description,Weight,DeliveryFee,Destination,ExtraFee,GetTrackingState());
        }



        public override void PrintShipment()
        {
            Console.WriteLine("Express Shipments: ");
            Console.WriteLine();
            Console.WriteLine(base.ToString());
            Console.WriteLine($"Extra Fee       : {ExtraFee}\n");
            Console.WriteLine();
            Console.WriteLine("-------------------------------");
            Console.WriteLine();
        }

    }
}
