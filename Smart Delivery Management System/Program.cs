using Smart_Delivery_Management_System.OOP01.Models;

namespace Smart_Delivery_Management_System
{
    internal class Program
    {
        static void Main(string[] args)
        {


            //DeliveryAddress deliveryAddress1 = new DeliveryAddress("city1", "street1", 111);
            //DeliveryAddress deliveryAddress2 = new DeliveryAddress();
            //deliveryAddress2 = deliveryAddress1;
            //Console.WriteLine(deliveryAddress1.GetFullAddress());
            //Console.WriteLine(deliveryAddress2.GetFullAddress());

            //Console.WriteLine("-------------------------------------");

            //deliveryAddress1.City = "city2";
            //deliveryAddress2.BuildingNumber = 10;
            //deliveryAddress2.Street = "street2";
            //Console.WriteLine(deliveryAddress1.GetFullAddress());
            //Console.WriteLine(deliveryAddress2.GetFullAddress());

            //Console.WriteLine("-----------------------------------");
            Console.Clear();
            int size = 3;
            DeliveryCenter deliveryCenter = new DeliveryCenter();

            for (int i = 0; i < size; i++) {
                Console.WriteLine($"Enter Shipment {i+1} Data");
                string trackingCode;
                do
                {
                    Console.Write("Trackong Code: ");
                    trackingCode = Console.ReadLine();
                } while (String.IsNullOrEmpty(trackingCode) || String.IsNullOrWhiteSpace(trackingCode));

                string description;
                do {
                    Console.Write("Description: ");
                    description = Console.ReadLine();
                } while (String.IsNullOrEmpty(description) || String.IsNullOrWhiteSpace(description));

                int weight;
                do {
                    Console.Write("Weight: ");
                } while (!int.TryParse(Console.ReadLine(), out weight)  || weight <= 0);

                int deluveryFee;
                do
                {
                    Console.Write("Delivery Fee: ");
                } while (!int.TryParse(Console.ReadLine(), out deluveryFee) || deluveryFee <= 0);
                

                Console.Write("City: ");
                string city = Console.ReadLine();

                Console.Write("Street: ");
                string street = Console.ReadLine();



                int buildingNumber;
                do
                {
                    Console.Write("Building Number: ");
                } while (!int.TryParse(Console.ReadLine(), out buildingNumber) || buildingNumber <= 0);


               
                DeliveryAddress deliveryAddress = new DeliveryAddress(city,street,buildingNumber);
                
                Shipment shipment = new Shipment(trackingCode, description, weight, deluveryFee,deliveryAddress);

                bool addShimpentIsSuccessfully = deliveryCenter.AddShipment(shipment);
                if (addShimpentIsSuccessfully)
                {
                    Console.WriteLine("\nShipment added successfully\n");
                }else
                {
                    Console.WriteLine("\nShipment added felid\n");
                }
            }
            
            Console.WriteLine("============ All Shipments ==============");
            Console.WriteLine();
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"Shipment {i+1}: ");
                Console.WriteLine(deliveryCenter[i]);
                Console.WriteLine();

            }

            Console.Write("Enter tracking code: ");
            string seacrchCode = Console.ReadLine();
            Shipment shipment1 = deliveryCenter[seacrchCode];
            if (!shipment1.Equals(default))
            {
                Console.WriteLine("Shipment not found");
            }
            else
            {
                Console.WriteLine($"{shipment1}");
            }
            Console.WriteLine();
            Console.WriteLine();


            DeliveryCenter deliveryCenter01 = new DeliveryCenter(deliveryCenter);
            DeliveryAddress deliveryAddress01 = new DeliveryAddress("Cairo", "Makram Ebeid Street", 20);
            
            var shipment01 = deliveryCenter01[0];
            shipment01.UpdateDeliveryAddress(deliveryAddress01);
            deliveryCenter01[0] = shipment01; 

            Console.WriteLine($"Original Address: {deliveryCenter[0]._destination}");
            Console.WriteLine($"New Address: {deliveryCenter01[0]._destination}");

            
            
        }

    }
}
