using Smart_Delivery_Management_System.Delivery;
using Smart_Delivery_Management_System.Interfaces;

namespace Smart_Delivery_Management_System.Shipments
{
    internal class InternationalShipment : Shipment,IInsurable, ITrackable
    {
        private string _destinationCountry = "UnKnown";
        private decimal _customFee = 0;

        

        public InternationalShipment(string trackingCode, decimal customFee, string destinationCountry) : base(trackingCode)
        {
            CustomsFee = customFee;
            DestinationCountry = destinationCountry;
            State = "has been Delivered";

        }

        public InternationalShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress deliveryAddress, decimal customFee, string destinationCountry) : base(trackingCode, description, weight, deliveryFee, deliveryAddress)
        {
            CustomsFee = customFee;
            DestinationCountry = destinationCountry;
            State = "has been Delivered";

        }


        public string DestinationCountry {
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

        public override decimal EstimatedCost => DeliveryFee + (Weight * 5) + CustomsFee;


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
        
        public virtual void GenerateCustomsReport()
        {
            Console.WriteLine($"Customs Report Generate for {TrackingCode} -> {DestinationCountry} ");
        }

        public decimal CalculateInsurance()
        {
            return 0.12m * EstimatedCost;
        }

        public string GetTrackingState()
        {
            return State;
        }
    }
}
