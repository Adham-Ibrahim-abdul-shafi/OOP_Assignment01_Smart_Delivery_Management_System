namespace Smart_Delivery_Management_System.OOP01.Models
{
    internal class InternationalShipment : Shipment
    {
        private string _destinationCountry = default!;
        private decimal _customFee;

        

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


        public string DestinationCountry {
            get => _destinationCountry;
            set
            {
                if (!string.IsNullOrEmpty(value) && !string.IsNullOrWhiteSpace(value)) 
                    _destinationCountry = value;
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
        
        public decimal CustomsFee {
            get => _customFee;
            set
            {
                if(value < 0)
                {
                    throw new Exception("Invalid value");
                }
                _customFee = value;
            } 
        }
        
        public override decimal EstimatedCost  => DeliveryFee + (Weight * 5) + CustomsFee; 
        
    }
}
