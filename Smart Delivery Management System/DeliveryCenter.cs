namespace Smart_Delivery_Management_System
{
    internal struct DeliveryCenter
    {
        private const int _capacity = 10;
        private int _firstIendxAvailable = 0;
        private Shipment[] _shipments;

        public DeliveryCenter()
        {
            _shipments = new Shipment[_capacity];
        }

        public DeliveryCenter(DeliveryCenter other)
        {
            _firstIendxAvailable = other._firstIendxAvailable;
            _shipments = new Shipment[_capacity];
            for (int i = 0; i < _firstIendxAvailable; i++) {
                _shipments[i] = new Shipment(other._shipments[i]);
            }
        }

        public Shipment this[int index]
        {
            get {
                if (0<= index && index < _firstIendxAvailable)
                    return  _shipments[index];
                else
                    return default;
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
                return default;
            }
            
        }

        public bool AddShipment(Shipment shipment)
        {
            if (_firstIendxAvailable == _capacity) return false;

            _shipments[_firstIendxAvailable ++] = shipment;

            return true;
        }
    }
}
