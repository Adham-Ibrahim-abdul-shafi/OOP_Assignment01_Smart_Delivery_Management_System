using System.Collections;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Threading.Channels;
using Smart_Delivery_Management_System.OOP01.Models;
using Smart_Delivery_Management_System.OOP01.Models.Shipments;

namespace Smart_Delivery_Management_System
{

    internal class Program
    {
        static public void ReadShipment(out String trackingCode, out string description, out decimal weight, out decimal deliveryFee, out DeliveryAddress deliveryAddress)
        {
            do
            {
                Console.Write("Enter Tracking Code: ");
                trackingCode = Console.ReadLine()!;
            } while (String.IsNullOrWhiteSpace(trackingCode));

            do
            {
                Console.Write("Enter Description: ");
                description = Console.ReadLine()!;
            } while (String.IsNullOrWhiteSpace(description));

            do
            {
                Console.Write("Enter Weight(Kg): ");

            } while (!decimal.TryParse(Console.ReadLine(), out weight) || weight <= 0);

            do
            {
                Console.Write("Enter Delivery Fee: ");

            } while (!decimal.TryParse(Console.ReadLine(), out deliveryFee) || deliveryFee <= 0);


            string city;
            do
            {
                Console.Write("Enter City: ");
                city = Console.ReadLine()!;
            } while (String.IsNullOrWhiteSpace(city));

            string street;
            do
            {
                Console.Write("Enter Street: ");
                street = Console.ReadLine()!;
            } while (String.IsNullOrWhiteSpace(street));

            int buildingNumber;
            do
            {
                Console.Write("Enter Building Number: ");
            } while (!int.TryParse(Console.ReadLine(), out buildingNumber));

            deliveryAddress = new DeliveryAddress(city, street, buildingNumber);

        }

        static void Main(string[] args)
        {
            Shipment shipment1 = new StandardShipment("SH001","Laptop",3,80,new DeliveryAddress("Cairo","AL Tahrir",15),TypesTrackingState.Ready);
            Shipment shipment2 = shipment1;
            Shipment shipment3 = shipment1.CopyShipment();

            Console.WriteLine($"Shipment 1 Weight {shipment1.Weight}");
            Console.WriteLine($"Shipment 2 Weight {shipment2.Weight}");
            Console.WriteLine($"Shipment 3 Weight {shipment3.Weight}");
            Console.WriteLine();

            shipment2.Weight = 4;
            shipment3.Weight = 5;
            
            Console.WriteLine("After update weight:");
            Console.WriteLine();
            Console.WriteLine($"Shipment 1 Weight {shipment1.Weight}");
            Console.WriteLine($"Shipment 2 Weight {shipment2.Weight}");
            Console.WriteLine($"Shipment 3 Weight {shipment3.Weight}");
            Console.WriteLine();


            shipment2 = shipment1.ShallowCopy();
            shipment3 = shipment1.DeepCopy();

            Console.WriteLine($"Shipment 1 Address {shipment1._destination}");
            Console.WriteLine($"Shipment 2 Address {shipment2._destination}");
            Console.WriteLine($"Shipment 3 Address {shipment3._destination}");
            Console.WriteLine();

            shipment2._destination.City = "Giza";
            shipment2._destination.BuildingNumber = 20;

            shipment3._destination.City = "Al Sharqia";
            shipment3._destination.BuildingNumber = 30;

            Console.WriteLine("After update Address:");
            Console.WriteLine();
            Console.WriteLine($"Shipment 1 Address {shipment1._destination}");
            Console.WriteLine($"Shipment 2 Address {shipment2._destination}");
            Console.WriteLine($"Shipment 3 Address {shipment3._destination}");
            Console.WriteLine();


            Console.WriteLine($"Total Shipments Created : {Shipment.GetTotalShipmentsCreated()} \n");

            DeliveryUtilities.PrintSeparator();
            DeliveryUtilities.PrintSystemTitle("Smart Delivery Management System ");
            DeliveryUtilities.PrintSeparator();


            Console.WriteLine(shipment1.GetSummary());
            Console.WriteLine(shipment1.IsDelivered());

        }

    }
}
