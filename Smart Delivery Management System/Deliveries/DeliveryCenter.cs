using Smart_Delivery_Management_System.Interfaces;
using Smart_Delivery_Management_System.OOP01.Models;


namespace Smart_Delivery_Management_System.Deliveries
{
    internal class DeliveryCenter
    {
        private const int size = 20;
        private int _firstIendxAvailable = 0;
        private Shipment[] _shipments;
        public string CenterName { get; set; } = "UnKnown";
        public Driver? Driver { set; get; }

        public DeliveryCenter()
        {
            _shipments = new Shipment[size];
        }

        public DeliveryCenter(Driver driver)
        {
            _shipments = new Shipment[size];
            this.Driver = driver;
        }

        //public DeliveryCenter(DeliveryCenter other)
        //{
        //    Driver = default;
        //    _firstIendxAvailable = other._firstIendxAvailable;
        //    _shipments = new Shipment[size];
        //    for (int i = 0; i < _firstIendxAvailable; i++)
        //    {
        //        Shipment shipment = new Shipment(other._shipments[i]);
        //        _shipments[i] = shipment;
        //    }
        //}

        public Shipment this[int index]
        {
            get
            {
                if (0 <= index && index < _firstIendxAvailable)
                    return _shipments[index];
                else
                    return default!;
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
                return default!;
            }

        }

        public bool AddShipment(Shipment shipment)
        {
            if (_firstIendxAvailable == size) return false;

            _shipments[_firstIendxAvailable++] = shipment;

            return true;
        }

        public bool RemoveShipment(string trackingCode)
        {
            for (int i = 0; i < _firstIendxAvailable; i++)
            {
                if (_shipments[i].TrackingCode == trackingCode)
                {
                    for (int j = i + 1; j < _firstIendxAvailable; j++)
                    {
                        _shipments[i] = _shipments[j];
                    }
                    --_firstIendxAvailable;
                    return true;
                }
            }
            return false;
        }


        public void PrintAllShipments()
        {
            Console.WriteLine();
            Console.WriteLine("================ print All Shipments ===============");
            foreach (Shipment shipment in _shipments)
            {
                if (shipment != null)
                {
                    Console.WriteLine();
                    shipment.PrintShipment();
                    Console.WriteLine();
                }

            }
            Console.WriteLine("===================================================");
        }


        public void PrintTrackingStatuses()
        {
            Console.WriteLine("======================================");
            Console.WriteLine();
            Console.WriteLine("Tracking Status");
            Console.WriteLine();

            foreach (ITrackable shipment in _shipments)
            {
                if (shipment != null)
                {
                    Console.WriteLine();
                    Console.WriteLine(shipment.GetTrackingState());
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            Console.WriteLine("=====================================");
            Console.WriteLine();
        }

        public void PrintInsurable()
        {
            Console.WriteLine("======================================");
            Console.WriteLine();
            Console.WriteLine("Tracking Status");
            Console.WriteLine();
            foreach (Shipment shipment1 in _shipments)
            {
                if (shipment1 is IInsurable shipment)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Shipment {shipment} Insurance = {shipment.CalculateInsurance()}");
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            Console.WriteLine("=====================================");
            Console.WriteLine();
        }
    }
}

