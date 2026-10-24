namespace Smart_Delivery_Management_System.OOP01.Models
{
    internal class ExpressShipment : Shipment
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

        public override void PrintShipment()
        {
            Console.WriteLine("Express Shipments: ");
            Console.WriteLine();
            base.PrintShipment();
            Console.WriteLine($"Extra Fee       : {ExtraFee}\n");
            Console.WriteLine();
            Console.WriteLine("-------------------------------");
            Console.WriteLine();
        }

    }
}
