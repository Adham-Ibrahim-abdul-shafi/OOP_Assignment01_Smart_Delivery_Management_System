
namespace Smart_Delivery_Management_System.OOP01.Models
{
    internal abstract partial class Shipment 
    {
        private static int TotalShipmentsCreated;
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
            _destination = new DeliveryAddress("Unknown", "Unknown", 0);

            ++TotalShipmentsCreated;
        }

        public static int GetTotalShipmentsCreated()
        {
            return TotalShipmentsCreated;
        }

        static Shipment()
        {
            TotalShipmentsCreated = 0;
            Console.WriteLine("Shipment System Initialized");
        }

        public Shipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress deliveryAddress,TypesTrackingState trackingState)
        {
            TrackingCode = trackingCode;
            Description = description;
            Weight = weight;
            DeliveryFee = deliveryFee;
            _destination = deliveryAddress;
            _trackingState = trackingState;
            ++TotalShipmentsCreated;
        }

        public Shipment(Shipment other)
        {
            _weight = other._weight;
            _deliveryFee = other._deliveryFee;
            _description = new string(other._description);
            _trackingCode = new string(other._trackingCode);
            _destination = new DeliveryAddress(other._destination);
            _trackingState = other._trackingState;
            ++TotalShipmentsCreated;
        }

        public void UpdateDeliveryAddress(DeliveryAddress newAddress) => _destination = newAddress;



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
                    $"destination       : {_destination.ToString()}\n" +
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
            else
                throw new InvalidDataException($"{nameof(weight)} or {nameof(extraPackingWeight)} is invalid value");
        }

        public Shipment CopyShipment() => DeepCopy();

        public abstract Shipment DeepCopy();

        public Shipment ShallowCopy()
        {
            return (Shipment)MemberwiseClone();
        }


        partial void OnTrackingStatusChanged(TypesTrackingState newStatus)
        {
            Console.WriteLine($"Tracking status changed to: {newStatus} \n");
        }

    }
}
