namespace Smart_Delivery_Management_System.OOP01.Models
{
    public class Shipment
    {
        private decimal _weight;
        private decimal _deliveryFee;
        private string _description = string.Empty;
        private string _trackingCode = String.Empty;
        public DeliveryAddress _destination;
        public Shipment(string trackingCode)
        {
            TrackingCode = trackingCode;
            DeliveryFee = 50;
            Description = "Unknown";
            Weight = 1;
        }

        public Shipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress deliveryAddress)
        {
            TrackingCode = trackingCode;
            Description = description;
            Weight = weight;
            DeliveryFee = deliveryFee;
            _destination = deliveryAddress;
        }

        public Shipment(Shipment other)
        {
            _weight  = other._weight;
            _deliveryFee = other._deliveryFee;
            _description = new string(other._description);
            _trackingCode = new string(other._trackingCode);
            _destination = new DeliveryAddress(other._destination);
        }

        public void UpdateDeliveryAddress(DeliveryAddress newAddress)=> _destination = newAddress;
        


        public string TrackingCode
        {
            get { return _trackingCode; }
            private set
            {
                if (!String.IsNullOrWhiteSpace(value))
                    _trackingCode = value;
            }
        }




        public string Description
        {
            get { 
                return _description; 
            }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                    _description = value;
            }
        }


        public decimal DeliveryFee
        {
            get {
                return _deliveryFee;
            }
            private set
            {
                if (value > 0)
                   _deliveryFee = value;
             }
        }

        public virtual decimal EstimatedCost
        {
            get { return DeliveryFee + (Weight * 5); }
        }


        public decimal Weight
        {
            get { return _weight; }
            set
            {
                if (value > 0)
                    _weight = value;
            }
        }


        public void UpdateDeliveryFee(decimal newFee) => DeliveryFee = newFee;

        public override string ToString()

        {
            return  $"trackingCode      : {_trackingCode}\n" +
                    $"description       : {_description}\n" +
                    $"weight            : {_weight} KG\n" +
                    $"deliveryFee       : {_deliveryFee} EGP\n" +
                    $"destination       : {_destination.ToString()}\n" +
                    $"estimated cost    : {EstimatedCost} EGP";
        }

        

        public virtual void PrintShipment()
        {
            Console.WriteLine();
            Console.WriteLine(ToString());
            Console.WriteLine();
        }
    }
}
