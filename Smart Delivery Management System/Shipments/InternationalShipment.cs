using Smart_Delivery_Management_System.DataTypes;
using Smart_Delivery_Management_System.Deliveries;
using Smart_Delivery_Management_System.Interfaces;
using Smart_Delivery_Management_System.OOP01.Models;

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
            TrackingState = TypesTrackingState.Delivered;
        }

        public InternationalShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress deliveryAddress, decimal customFee, string destinationCountry,TypesTrackingState trackingState) : base(trackingCode, description, weight, deliveryFee, deliveryAddress,trackingState)
        {
            CustomsFee = customFee;
            DestinationCountry = destinationCountry;
            TrackingState = TypesTrackingState.Delivered;
        }


        public string DestinationCountry {
            get => _destinationCountry;
            set
            {
                if (!string.IsNullOrWhiteSpace(value)) 
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
            Console.WriteLine($"Customs Report Generate for {TrackingCode} -> {DestinationCountry} ");
        }

        public decimal CalculateInsurance()
        {
            return 0.12m * EstimatedCost;
        }


        public override Shipment DeepCopy()
        {
            return new InternationalShipment(TrackingCode, Description, Weight, DeliveryFee, Destination.DeepCopy(), CustomsFee, DestinationCountry,GetTrackingState());
        }
    }
}
