using Smart_Delivery_Management_System.Delivery;

namespace Smart_Delivery_Management_System.Shipments
{
    public abstract class Shipment
    {
        private decimal _weight;
        private decimal _deliveryFee;
        private string _description = "UnKnown";
        private string _trackingCode = "UnKnown";
        private string _state = "UnKnown";
        public DeliveryAddress Destination { get; set; }

        public Shipment(string trackingCode) : this(trackingCode, "UnKnown", 1, 50, new DeliveryAddress())
        {

        }

        public Shipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress deliveryAddress)
        {
            _trackingCode = "UnKnown";
            _description = "UnKnown";
            Weight = 1;
            DeliveryFee = 50;
            Destination = new DeliveryAddress();


            TrackingCode = trackingCode;
            Description = description;
            Weight = weight;
            DeliveryFee = deliveryFee;
            Destination = deliveryAddress;
        }

        public Shipment(Shipment other) : this(other.TrackingCode, other.Description, other.Weight, other.DeliveryFee, new DeliveryAddress(other.Destination))
        {

        }


        public void UpdateDeliveryAddress(DeliveryAddress newAddress) => Destination = newAddress;

        public string State
        {
            get => _state;
            set {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _state = value;
                }
            
            }
        }

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

        public abstract decimal EstimatedCost { get; }


        public decimal Weight
        {
            get => _weight; 
            set
            {
                if (value > 0)
                    _weight = value;
            }
        }


        public void UpdateDeliveryFee(decimal newFee) => DeliveryFee = newFee;

        public override string ToString()

        {
            return $"trackingCode       : {_trackingCode}\n" +
                    $"description       : {_description}\n" +
                    $"weight            : {_weight} KG\n" +
                    $"deliveryFee       : {_deliveryFee} EGP\n" +
                    $"destination       : {Destination}\n" +
                    $"estimated cost    : {EstimatedCost} EGP";
        }



        public abstract void PrintShipment();


        public void UpdateWeight(decimal weight){
               Weight = weight;
        }

        public void UpdateWeight(decimal weight,decimal extraPackingWeight)
        {
            if (Weight >= 0 && extraPackingWeight >= 0)
                Weight = weight + extraPackingWeight;
  
        }
    }
}
