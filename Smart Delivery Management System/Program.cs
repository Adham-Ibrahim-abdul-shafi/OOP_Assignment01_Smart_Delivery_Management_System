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
                    trackingCode = Console.ReadLine()!;
                } while (String.IsNullOrWhiteSpace(trackingCode));

                string description;
                do {
                    Console.Write("Description: ");
                    description = Console.ReadLine()!;
                } while (String.IsNullOrWhiteSpace(description));
                
                int weight;
                do {
                    Console.Write("Weight: ");
                } while (!int.TryParse(Console.ReadLine(), out weight)  || weight <= 0);

                int deluveryFee;
                do
                {
                    Console.Write("Delivery Fee: ");
                } while (!int.TryParse(Console.ReadLine(), out deluveryFee) || deluveryFee <= 0);
                

                
                string city ;
                do
                {
                    Console.Write("City: ");
                    city = Console.ReadLine()!;
                } while (String.IsNullOrWhiteSpace(city));


                string street ;
                do
                {
                    Console.Write("Street: ");
                    street = Console.ReadLine()!;
                } while (String.IsNullOrWhiteSpace(street));



                int buildingNumber;
                do
                {
                    Console.Write("Building Number: ");
                } while (!int.TryParse(Console.ReadLine(), out buildingNumber) || buildingNumber <= 0);


               
                DeliveryAddress deliveryAddress = new DeliveryAddress(city,street,buildingNumber);
                
                Shipment shipment = new Shipment(trackingCode, description, weight, deluveryFee,deliveryAddress);

                bool addedShimpentSuccessfully = deliveryCenter.AddShipment(shipment);
                if (addedShimpentSuccessfully)
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

            
            string seacrchCode;
            do
            {
                Console.Write("Enter a tracking code to search: ");
                seacrchCode = Console.ReadLine()!;
            } while (String.IsNullOrWhiteSpace(seacrchCode));

            Shipment shipment1 = deliveryCenter[seacrchCode];
            if (shipment1.TrackingCode is null)
            {
                Console.WriteLine("Shipment not found");
            }
            else
            {
                Console.WriteLine("Shipment found");
                Console.WriteLine($"{shipment1}");
            }
            Console.WriteLine();
            Console.WriteLine();


            Console.WriteLine("------------ Struct Copy Test ---------------");


            DeliveryAddress original = new DeliveryAddress("Cairo", "Tarir Street", 15);
            DeliveryAddress copy = original;
            Console.WriteLine($"Original Address: {original}");
            Console.WriteLine($"Copied Address: {copy}");


            copy.Street = "Makram Ebeid Street";
            copy.BuildingNumber = 20;
            Console.WriteLine("After Update Copy Address");

            Console.WriteLine($"Original Address: {original}");
            Console.WriteLine($"Copied Address: {copy}");

            
            
        }

    }
}
