namespace Smart_Delivery_Management_System.OOP01.Models.Shipments
{
    internal class InternationalShipment : Shipment,IInsurable, ITrackable
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
            Console.WriteLine(base.ToString());
            Console.WriteLine($"Destination Country: {DestinationCountry}\n");
            Console.WriteLine($"Customs Fee        : {CustomsFee }\n");
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

        public virtual void GenerateCustomsReport()
        {
            Console.WriteLine("welcome in GenerateCustomsReport method :)");
        }

        public decimal CalculateInsurance()
        {
            return 0.12m * EstimatedCost;
        }

        public string GetTrackingState()
        {
            return "has been Delivered";
        }
    }
}
