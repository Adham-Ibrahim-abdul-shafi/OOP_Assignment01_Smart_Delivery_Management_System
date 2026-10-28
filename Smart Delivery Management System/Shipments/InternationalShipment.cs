using Smart_Delivery_Management_System.Delivery;

namespace Smart_Delivery_Management_System.Shipments
{
    internal class InternationalShipment : Shipment
    {
        private string _destinationCountry = "UnKnown";
        private decimal _customFee = 0;



        public InternationalShipment(string trackingCode, decimal customFee, string destinationCountry) : base(trackingCode)
        {
            CustomsFee = customFee;
            DestinationCountry = destinationCountry;
        }

        public InternationalShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress deliveryAddress, decimal customFee, string destinationCountry) : base(trackingCode, description, weight, deliveryFee, deliveryAddress)
        {
            CustomsFee = customFee;
            DestinationCountry = destinationCountry;
        }


        public string DestinationCountry
        {
            get => _destinationCountry;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    _destinationCountry = value;
            }
        }

        public decimal CustomsFee
        {
            get => _customFee;
            set
            {
                if (value < 0)
                {
                    throw new Exception("Invalid value");
                }
                _customFee = value;
            }
        }

        public override void PrintShipment()
        {
            Console.WriteLine("International Shipments: ");
            Console.WriteLine();
            base.PrintShipment();
            Console.WriteLine();
            Console.WriteLine("-------------------------------");
            Console.WriteLine();
        }



        public override decimal EstimatedCost => DeliveryFee + (Weight * 5) + CustomsFee;

        public virtual void GenerateCustomsReport()
        {
            Console.WriteLine($"Customs Report Generate for {TrackingCode} -> {DestinationCountry} ");
        }


    }
}
