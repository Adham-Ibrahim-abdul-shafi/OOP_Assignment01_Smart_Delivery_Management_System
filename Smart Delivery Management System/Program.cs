using System.Collections;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Threading.Channels;
using Smart_Delivery_Management_System.Delivery;
using Smart_Delivery_Management_System.Helpers;
using Smart_Delivery_Management_System.Interfaces;
using Smart_Delivery_Management_System.Reports;
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



        static void Main(string[] args)
        {

            #region Create a Driver

            /// Create a Driver.
            Console.WriteLine("==========================================");
            Console.WriteLine("Delivery Center ");
            Console.WriteLine("==========================================");


            Console.WriteLine();
            
            string driverId = InputValidator.GetNonWhiteSpaceString("Enter Deiver ID: ");
            string driverName = InputValidator.GetNonWhiteSpaceString("Enter Deiver Name: ");
            string driverPhoneNumber = InputValidator.GetNonWhiteSpaceString("Enter Deiver Phone Number: ");

            Console.WriteLine();
            Console.WriteLine("------------------------------------------");
            Driver driver = new Driver(driverId,driverName,driverPhoneNumber);

            #endregion
         
            #region Create a DeliveryCenter

            /// Create a DeliveryCenter.
            DeliveryCenter deliveryCenter = new DeliveryCenter();

            #endregion
            
            #region Assign the Driver to the DeliveryCenter 
            deliveryCenter.Driver = driver;
            #endregion

            #region a. Create one StandardShipment

            /// a. Create one StandardShipment. 
            Console.WriteLine();
            Console.WriteLine("Enter Standard Shipment data:");
            Console.WriteLine();

            string trackingCode, description;
            decimal weight, deliveryFee;


            DeliveryAddress deliveryAddress;
            ReadShipment(out trackingCode, out description, out weight, out deliveryFee, out deliveryAddress);

            StandardShipment standardShipment = new StandardShipment(trackingCode, description, weight, deliveryFee, deliveryAddress);

            #endregion

            #region b. Create one ExpressShipment

            /// b. Create one ExpressShipment. 

            Console.WriteLine();
            Console.WriteLine("Enter Express Shipment data:");
            Console.WriteLine();

            ReadShipment(out trackingCode, out description, out weight, out deliveryFee, out deliveryAddress);
            decimal extraFee = InputValidator.GetNonNegativeDecimal("Enter Extra Fee (EGP): ");

            ExpressShipment expressShipment = new ExpressShipment(trackingCode, description, weight, deliveryFee, deliveryAddress, extraFee);

            #endregion

            #region c. Create one InternationalShipment

            /// c. Create one InternationalShipment. 
            Console.WriteLine();
            Console.WriteLine("Enter International Shipment data:");
            Console.WriteLine();

            ReadShipment(out trackingCode, out description, out weight, out deliveryFee, out deliveryAddress);
            string destinationCountry = InputValidator.GetNonWhiteSpaceString("Enter Destination Country: ");
            decimal customsFee = InputValidator.GetPositiveDecimal("Enter Customs Fee (EGP): ");

            InternationalShipment internationalShipment = new InternationalShipment(trackingCode, description, weight, deliveryFee, deliveryAddress, customsFee, destinationCountry);
            
            #endregion

            #region  d. Add all shipments to the DeliveryCenter

            bool successfullAddShipment = deliveryCenter.AddShipment(standardShipment);
            if (successfullAddShipment)
            {
                Console.WriteLine("Standard Shipment Added Successfully");
            }
            else
            {
                Console.WriteLine("Standard Shipment not Added Successfully");
            }
            Console.WriteLine();

            successfullAddShipment = deliveryCenter.AddShipment(expressShipment);
            if (successfullAddShipment)
            {
                Console.WriteLine("Express Shipment Added Successfully");
            }
            else
            {
                Console.WriteLine("Express Shipment not Added Successfully");
            }
            Console.WriteLine();

            successfullAddShipment = deliveryCenter.AddShipment(internationalShipment);
            if (successfullAddShipment)
            {
                Console.WriteLine("International Shipment Added Successfully");
            }
            else
            {
                Console.WriteLine("International Shipment not Added Successfully");
            }
            Console.WriteLine();
            #endregion

            #region  e. Print all shipments using PrintAllShipments()

            Console.WriteLine();
            Console.WriteLine("Printing Using PrintAllShipment() method");
            deliveryCenter.PrintAllShipments();
            Console.WriteLine("===============================================");
            Console.WriteLine();

            #endregion

            #region  e. Call DeliveryHelper.PrintShipmentDetails() for each shipment 

            /// i.Call DeliveryHelper.PrintShipmentDetails() for each shipment. 
            Console.WriteLine();
            Console.WriteLine("Printing Using DeliveryHelper..... ");
            for (int i = 0; i < 3; i++)
            {
                Shipment shipment = deliveryCenter[i];
                DeliveryHelper.PrintShipmentDetails(shipment);
            }

            #endregion

            #region f. Print the tracking status of every shipment.
            deliveryCenter.PrintTrackingStatuses();
            #endregion

            #region g. Print the insurance cost of every shipment.
            Console.WriteLine("Standard Shipment Insurance: ");
            deliveryCenter.PrintInsurable();
            #endregion

            ITrackable[] trackables =
            {
                standardShipment,
                expressShipment,
                internationalShipment
            };

            Console.WriteLine();
            Console.WriteLine("======================================");
            Console.WriteLine();
            Console.WriteLine("Tracking Status");
            Console.WriteLine();

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine();
                Console.Write($"Shipment {deliveryCenter[i].TrackingCode} ");
                DeliveryReport.PrintShipment(trackables[i]);
                Console.WriteLine();
            }

            IInsurable[] insurables = {
                standardShipment,
                expressShipment,
                internationalShipment
            };

            Console.WriteLine();
            Console.WriteLine("======================================");
            Console.WriteLine();

            Console.WriteLine("Insurance");
            Console.WriteLine();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine();
                Console.Write($"{deliveryCenter[i].GetType().Name} : ");
                DeliveryReport.PrintInsurance(insurables[i]);
                Console.WriteLine();
            }
            Console.WriteLine("========================================");
            Console.WriteLine();
            Console.WriteLine("Interface Polymorphism Demonstrated Successfully.");
        }

    }
}
