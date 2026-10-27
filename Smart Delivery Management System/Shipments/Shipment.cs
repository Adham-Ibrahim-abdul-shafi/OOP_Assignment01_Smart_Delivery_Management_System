using Smart_Delivery_Management_System.Delivery;

namespace Smart_Delivery_Management_System.Shipments
{
    public class Shipment
    {
        private decimal _weight;
        private decimal _deliveryFee;
        private string _description = string.Empty;
        private string _trackingCode = String.Empty;
        public DeliveryAddress Destination { set; get; }


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

        public Shipment(Shipment other) : this(other.TrackingCode, other.Description, other.Weight, other.DeliveryFee, other.Destination)
        {

        }


    
        


        public string TrackingCode
        {
            get => _trackingCode; 
            private set
            {
                if (!String.IsNullOrWhiteSpace(value))
                    _trackingCode = value;
            }
        }




        public string Description
        {
            get => _description; 
            
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

        


        public decimal Weight
        {
            get { return _weight; }
            set
            {
                if (value > 0)
                    _weight = value;
            }
        }

        public virtual decimal EstimatedCost => DeliveryFee + (Weight * 5);
        

        public void UpdateDeliveryAddress(DeliveryAddress newAddress) => Destination = newAddress;
        public void UpdateDeliveryFee(decimal newFee) => DeliveryFee = newFee;

        public override string ToString()

        {
            return  $"trackingCode      : {_trackingCode}\n" +
                    $"description       : {_description}\n" +
                    $"weight            : {_weight} KG\n" +
                    $"deliveryFee       : {_deliveryFee} EGP\n" +
                    $"destination       : {Destination}\n" +
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
