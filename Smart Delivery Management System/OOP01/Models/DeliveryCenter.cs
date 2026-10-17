namespace Smart_Delivery_Management_System.OOP01.Models
{
    internal struct DeliveryCenter
    {
        private const int size = 10;
        private int _firstIendxAvailable = 0;
        private Shipment[]? _shipments;

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
                    return default;
            }
            set
            {
                if (index < _firstIendxAvailable)
                    _shipments[index] = (Shipment)value!;
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
            if (_firstIendxAvailable == size) return false;

            _shipments[_firstIendxAvailable ++] = shipment;

            return true;
        }
    }
}
