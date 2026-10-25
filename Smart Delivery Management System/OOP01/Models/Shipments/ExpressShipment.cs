namespace Smart_Delivery_Management_System.OOP01.Models.Shipments
{
    internal class ExpressShipment : Shipment , IInsurable, ITrackable
    {
		private decimal _extraFee;

		public ExpressShipment(string trackingCode,decimal extraFee) : base(trackingCode)
		{
			ExtraFee = extraFee;
		}

		public ExpressShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress deliveryAddress, decimal extraFee) : base(trackingCode, description, weight, deliveryFee, deliveryAddress)
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

        public string GetTrackingState()
        {
            return "is Out for Delivery";
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
