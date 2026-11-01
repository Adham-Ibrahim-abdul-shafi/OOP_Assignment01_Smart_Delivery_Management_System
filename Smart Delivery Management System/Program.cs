using System.Collections;
using System.Net;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Threading.Channels;
using Smart_Delivery_Management_System.DataTypes;
using Smart_Delivery_Management_System.Deliveries;
using Smart_Delivery_Management_System.Helpers;
using Smart_Delivery_Management_System.OOP01.Models;
using Smart_Delivery_Management_System.Shipments;
using Smart_Delivery_Management_System.Validators;

namespace Smart_Delivery_Management_System
{

    internal class Program
    {
        static public void ReadShipment(out String trackingCode, out string description, out decimal weight, out decimal deliveryFee, out DeliveryAddress deliveryAddress)
        {

            trackingCode = InputValidator.GetNonWhiteSpaceString("Enter Tracking Code: ");
            description = InputValidator.GetNonWhiteSpaceString("Enter Description: ");

            weight = InputValidator.GetPositiveDecimal("Enter Weight(Kg): ");
            deliveryFee = InputValidator.GetPositiveDecimal("Enter Delivery Fee (EGP): ");

            string city = InputValidator.GetNonWhiteSpaceString("Enter City: ");
            string street = InputValidator.GetNonWhiteSpaceString("Enter Street: ");
            int buildingNumber = InputValidator.GetPositiveInt("Enter Building Number: ");

            deliveryAddress = new DeliveryAddress(city, street, buildingNumber);

        }

         static public void Main(string[] args)
        {
            Console.WriteLine();
            DeliveryUtilities.PrintSystemTitle("Smart Delivery Management System ");
            Console.WriteLine();


            Console.WriteLine();
            Console.WriteLine();
            StandardShipment standardShipment = new StandardShipment("SH001", "Laptop", 3, 20, new DeliveryAddress("Cairo","street1",15), TypesTrackingState.Ready);
            ExpressShipment expressShipment = new ExpressShipment("SH002", "Phone", 3, 20, new DeliveryAddress(),50, TypesTrackingState.OutforDelivery);
            InternationalShipment internationalShipment = new InternationalShipment("SH003", "IPhone", 3, 20, new DeliveryAddress(),120,"Germany", TypesTrackingState.Delivered);


            Console.WriteLine();
            Console.WriteLine();

            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Creating Shipments... ");
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Standard Shipment Created");
            Console.WriteLine("Express Shipment Created");
            Console.WriteLine("International Shipment Created");
            Console.WriteLine();
            Console.WriteLine($"Total Shipments Created : {Shipment.GetTotalShipmentsCreated()}");
            Console.WriteLine();
            Console.WriteLine();


            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Object Copying  ");
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine();

            StandardShipment OriginalShipment = standardShipment;
            StandardShipment AssignedShipment = OriginalShipment;
            Console.WriteLine($"Original Shipment  : {OriginalShipment.TrackingCode} " +
                $"\nAssigned Shipment  : {AssignedShipment.TrackingCode} \n" +
                $"\nSame Object : {OriginalShipment.Equals(AssignedShipment)} ");
            Console.WriteLine();
            Console.WriteLine();


            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Shallow Copy");
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine();
            Console.WriteLine();


            StandardShipment shallowCopyShipment = (StandardShipment) OriginalShipment.ShallowCopy();

            Console.WriteLine($"Original Shipment Address : {OriginalShipment.Destination.City}");
            Console.WriteLine($"Copied Shipment Address   : {shallowCopyShipment.Destination.City}");
            Console.WriteLine();
            shallowCopyShipment.Destination.City = "Giza";
            Console.WriteLine("Changing copied shipment address...");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine($"Original Shipment Address : {OriginalShipment.Destination.City}");
            Console.WriteLine($"Copied Shipment Address   : {shallowCopyShipment.Destination.City}");
            Console.WriteLine();
            Console.WriteLine($"Same DeliveryAddress Object : {OriginalShipment.Destination.Equals(shallowCopyShipment.Destination)}");
            Console.WriteLine();
            Console.WriteLine();



            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Deep Copy");
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine();
            Console.WriteLine();

            OriginalShipment.Destination.City = "Cairo" ;
            StandardShipment deepCopyShipment = (StandardShipment)OriginalShipment.DeepCopy();

            Console.WriteLine($"Original Shipment Address : {OriginalShipment.Destination.City}");
            Console.WriteLine($"Copied Shipment Address   : {deepCopyShipment.Destination.City}");
            Console.WriteLine();
            deepCopyShipment.Destination.City = "Giza";
            Console.WriteLine("Changing copied shipment address...");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine($"Original Shipment Address   : {OriginalShipment.Destination.City}");
            Console.WriteLine($"Copied Shipment Address     : {deepCopyShipment.Destination.City}");
            Console.WriteLine();
            Console.WriteLine($"Same DeliveryAddress Object : {OriginalShipment.Destination.Equals(deepCopyShipment.Destination)}");
            Console.WriteLine();
            Console.WriteLine();

            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Extension Methods ");
            DeliveryUtilities.PrintSeparator();

            Console.WriteLine(  );
            Console.WriteLine();

            Shipment[] shipments = {
                standardShipment,
                expressShipment,
                internationalShipment
            };
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(shipments[i].GetSummary());
            }

            Console.WriteLine();
            Console.WriteLine($"{shipments[0].TrackingCode} Is Delivered : {shipments[0].IsDelivered()}  ");
            Console.WriteLine($"{shipments[2].TrackingCode} Is Delivered : {shipments[2].IsDelivered()}  ");
            Console.WriteLine();


            
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Tracking Status ");
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine();
            standardShipment.UpdateTrackingStatus(TypesTrackingState.OutforDelivery);
            Console.WriteLine();

            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Static Utilities");
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine();

            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Delivery Center");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine();
            Console.WriteLine($"Total Shipments Created : {Shipment.GetTotalShipmentsCreated()} ");
            Console.WriteLine();
            Console.WriteLine();

            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Partial Method ");
            DeliveryUtilities.PrintSeparator();

            Console.WriteLine();
            standardShipment.UpdateTrackingStatus(TypesTrackingState.Delivered);
            Console.WriteLine();

            DeliveryUtilities.PrintSeparator() ;
            Console.WriteLine("Assignment Completed ");
            DeliveryUtilities.PrintSeparator();
        }

    }
}
