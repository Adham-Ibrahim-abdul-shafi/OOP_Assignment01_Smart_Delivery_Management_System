namespace Smart_Delivery_Management_System
{
    public struct Shipment
    {
        private decimal _weight;
        private decimal _deliveryFee;
        private string _description ;
        private string _trackingCode;
        public DeliveryAddress Destination { set; get; }

        public Shipment(string trackingCode) : this (trackingCode,"UnKnown",1,50,new DeliveryAddress())
        {
          
        }

        public Shipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress deliveryAddress)
        {
            TrackingCode = "UnKnown";
            Description = "UnKnown";
            Weight = 1;
            DeliveryFee = 50;
            Destination = new DeliveryAddress();


            TrackingCode = trackingCode;
            Description = description;
            Weight = weight;
            DeliveryFee = deliveryFee;
            Destination = deliveryAddress;
        }

        public Shipment(Shipment other) : this(new string(other.TrackingCode), new string(other.Description), other.Weight, other.DeliveryFee, other.Destination)
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
            get => _deliveryFee;
            
            private set
            {
                if (value > 0)
                   _deliveryFee = value;
             }
        }
        public decimal Weight
        {
            get => _weight;
            set
            {
                if (value > 0)
                    _weight = value;
            }
        }
        public decimal EstimatedCost => DeliveryFee + (Weight * 5);


        public void UpdateDeliveryAddress(DeliveryAddress newAddress) => Destination = newAddress;

        public void UpdateDeliveryFee(decimal newFee) => DeliveryFee = newFee;

        public override string ToString()

        {
            return  $"Tracking Code     : {_trackingCode}\n" +
                    $"Description       : {_description}\n" +
                    $"Weight            : {_weight} KG\n" +
                    $"Delivery Fee      : {_deliveryFee} EGP\n" +
                    $"Destination       : {Destination.ToString()}\n" +
                    $"Estimated cost    : {EstimatedCost} EGP";
        }
        public void PrintShipment()
        {
            Console.WriteLine(ToString());
        }
    }
}
