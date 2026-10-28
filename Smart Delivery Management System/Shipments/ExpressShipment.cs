using Smart_Delivery_Management_System.Delivery;
using Smart_Delivery_Management_System.Interfaces;

namespace Smart_Delivery_Management_System.Shipments
{
    internal class ExpressShipment : Shipment , IInsurable, ITrackable
    {
		private decimal _extraFee = 0;

		public ExpressShipment(string trackingCode,decimal extraFee) : base(trackingCode)
		{
			ExtraFee = extraFee;
            State = "is Out for Delivery";

        }

		public ExpressShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress deliveryAddress, decimal extraFee) : base(trackingCode, description, weight, deliveryFee, deliveryAddress)
        {
            ExtraFee = extraFee;
            State = "is Out for Delivery";
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

        public decimal CalculateInsurance() => 0.08m * EstimatedCost;
        

        public string GetTrackingState() => State;
        

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
