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
            /*
                  Main() Checklist 
                     ☐  
               
            */
            #region Create a Driver

            /// Create a Driver.
            Console.WriteLine("==========================================");
            Console.WriteLine("Delivery Center ");
            Console.WriteLine("==========================================");


            Console.WriteLine();
            
            string driverName;
            do
            {
                Console.Write("Driver :");
                driverName = Console.ReadLine()!;
            } while (String.IsNullOrWhiteSpace(driverName));
             
            Console.WriteLine();
            Console.WriteLine("------------------------------------------");
            Driver driver = new Driver(driverName);

            #endregion
         
            #region Create a DeliveryCenter

            /// Create a DeliveryCenter.
            DeliveryCenter deliveryCenter = new DeliveryCenter(driver);

            #endregion
            
            #region Assign the Driver to the DeliveryCenter 
            deliveryCenter.driver = driver;
            #endregion

            #region a. Create one StandardShipment

            /// a. Create one StandardShipment. 
            string trackingCode = default!;
            string description;
            decimal weight;
            decimal deliveryFee;
            DeliveryAddress deliveryAddress;
            ReadShipment(out trackingCode, out description, out weight, out deliveryFee, out deliveryAddress);
            StandardShipment standardShipment = new StandardShipment(trackingCode, description, weight, deliveryFee, deliveryAddress);
            Console.WriteLine();
            Console.WriteLine();
            #endregion

            #region b. Create one ExpressShipment

            /// b. Create one ExpressShipment. 
            ReadShipment(out trackingCode, out description, out weight, out deliveryFee, out deliveryAddress);
            decimal extraFee = default;
            do
            {
                Console.Write("Enter Extra Fee:");
            } while (!decimal.TryParse(Console.ReadLine(), out extraFee) || extraFee < 0);
            ExpressShipment expressShipment = new ExpressShipment(trackingCode, description, weight, deliveryFee, deliveryAddress, extraFee);
            Console.WriteLine();
            Console.WriteLine();
            #endregion

            #region c. Create one InternationalShipment

            /// f. Create one InternationalShipment. 
            ReadShipment(out trackingCode, out description, out weight, out deliveryFee, out deliveryAddress);
            decimal customFee;
            do
            {
                Console.Write("Enter Custom Fee:");
            } while (!decimal.TryParse(Console.ReadLine(), out customFee) || customFee < 0);
            string destinationCountry;
            do
            {
                Console.Write("Enter Destination Country:");
                destinationCountry = Console.ReadLine()!;
            } while (string.IsNullOrWhiteSpace(destinationCountry));

            InternationalShipment internationalShipment = new InternationalShipment(trackingCode, description, weight, deliveryFee, deliveryAddress, customFee, destinationCountry);
            Console.WriteLine();
            Console.WriteLine();
            #endregion

            #region  d. Add all shipments to the DeliveryCenter
            bool addStandard = deliveryCenter.AddShipment(standardShipment);
            if (addStandard)
            {
                Console.WriteLine("Done add standard shipment");
            }
            else
            {
                Console.WriteLine("filad add standard shipment");
            }
            Console.WriteLine();

            bool addExpress = deliveryCenter.AddShipment(expressShipment);
            if (addExpress)
            {
                Console.WriteLine("Done add Express shipment");
            }
            else
            {
                Console.WriteLine("Filad add Express shipment");
            }

            Console.WriteLine();
            bool addInternational = deliveryCenter.AddShipment(internationalShipment);
            if (addInternational)
            {
                Console.WriteLine("Done add International Shipment");
            }
            else
            {
                Console.WriteLine("Filad add Internatioal shipment");
            }
            Console.WriteLine();
            #endregion

            #region  e. Print all shipments using PrintAllShipments()
            deliveryCenter.PrintAllShipments();
            #endregion

            #region  e. Call DeliveryHelper.PrintShipmentDetails() for each shipment 

            /// i.Call DeliveryHelper.PrintShipmentDetails() for each shipment. 
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
                DeliveryReport.PrintTrackingState(trackables[i]);
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
                Console.Write($"{deliveryCenter[i].GetType()} : ");
                DeliveryReport.PrintInsurance(insurables[i]);
                Console.WriteLine();
            }
            Console.WriteLine("========================================");
            Console.WriteLine();
            Console.WriteLine("Interface Polymorphism Demonstrated Successfully.");
        }

    }
}
