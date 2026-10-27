 using Smart_Delivery_Management_System.Shipments;

namespace Smart_Delivery_Management_System.Delivery
{
    internal class DeliveryCenter
    {
        private const int size = 20;
        private int _firstIendxAvailable = 0;
        private Shipment[] _shipments;

        public string CenterName { get; set; } = "Unknown";

        public DeliveryCenter()
        {
            _shipments = new Shipment[size];
        }

        public DeliveryCenter(DeliveryCenter other)
        {
            _firstIendxAvailable = other._firstIendxAvailable;
            _shipments = new Shipment[size];
            for (int i = 0; i < _firstIendxAvailable; i++) {
                _shipments[i] = new Shipment(other._shipments[i]);
            }
        }

        public override string ToString()
        {
            return $"{_firstIendxAvailable}";
        }

        public Shipment this[int index]
        {
            get {
                if (0<= index && index < _firstIendxAvailable)
                    return  _shipments[index];
                else
                    return default!;
            }
            set
            {
                if (index < _firstIendxAvailable)
                    _shipments[index] = value;
            }
        }

        public Shipment this[string trcaCode]
        {
            get
            {

                for (int i = 0; i < _shipments.Length; i++)
                {
                    if (trcaCode == _shipments[i].TrackingCode)
                    {
                        return _shipments[i];
                    }
                }
                return default!;
            }
            
        }

        public bool AddShipment(Shipment shipment)
        {
            if (_firstIendxAvailable == size) return false;

            _shipments[_firstIendxAvailable ++] = shipment;

            return true;
        }

        public bool RemoveShipment(string trackingCode)
        {
            for (int i = 0; i < _firstIendxAvailable; i++)
            {
                if (_shipments[i].TrackingCode == trackingCode)
                {
                    for (int j = i+1; j < _firstIendxAvailable; j++)
                    {
                        _shipments[i] = _shipments[j];
                    }
                    -- _firstIendxAvailable;
                    return true;
                }
            }
            return false;
        }
        public void PrintAllShipments()
        {
            Console.WriteLine();
            Console.WriteLine("================ print All Shipments ===============");
            for (int i = 0; i < _firstIendxAvailable; i++)
            {
                Console.WriteLine();
                _shipments[i].PrintShipment();
                Console.WriteLine();
            }
            Console.WriteLine("====================================================");
        }
    }
}
