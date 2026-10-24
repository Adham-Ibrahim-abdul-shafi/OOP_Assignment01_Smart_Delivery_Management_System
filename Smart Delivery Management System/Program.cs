using System.Collections;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Threading.Channels;
using Smart_Delivery_Management_System.OOP01.Models;

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
            #region a. Create a Driver

            /// a. Create a Driver.
            Console.WriteLine("==========================================");
            Console.WriteLine("Delivery Center ");
            Console.WriteLine("==========================================");


            Console.WriteLine();
            Console.Write("Driver :");
            string driverName = Console.ReadLine()!;
            Console.WriteLine();
            Console.WriteLine("------------------------------------------");
            Driver driver = new Driver(driverName);

            #endregion
           
            #region b. Create a DeliveryCenter

            /// b. Create a DeliveryCenter.
            DeliveryCenter deliveryCenter = new DeliveryCenter();

            #endregion

            #region c. Assign the Driver to the DeliveryCenter 
            deliveryCenter.driver = driver;
            #endregion

            #region d. Create one StandardShipment

            /// d. Create one StandardShipment. 
            string trackingCode = default!;
            string description;
            decimal weight;
            decimal deliveryFee;
            DeliveryAddress deliveryAddress;
            ReadShipment(out trackingCode, out description, out weight, out deliveryFee, out deliveryAddress);
            StandardShipment standardShipment = new StandardShipment(trackingCode, description, weight, deliveryFee, deliveryAddress);

            #endregion
            
            #region e. Create one ExpressShipment

            /// e. Create one ExpressShipment. 
            ReadShipment(out trackingCode, out description, out weight, out deliveryFee, out deliveryAddress);
            decimal extraFee = default;
            do
            {
                Console.Write("Enter Extra Fee:");
            } while (!decimal.TryParse(Console.ReadLine(), out extraFee) || extraFee < 0);
            ExpressShipment expressShipment = new ExpressShipment(trackingCode, description, weight, deliveryFee, deliveryAddress, extraFee);

            #endregion

            

            #region f. Create one InternationalShipment

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

            #endregion

            #region  g. Add all shipments to the DeliveryCenter
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
            }else
            {
                Console.WriteLine("Filad add Express shipment");
            }


            bool addInternational = deliveryCenter.AddShipment(internationalShipment);
            if (addInternational) {
                Console.WriteLine("Done add International Shipment");
            }
            else
            {
                Console.WriteLine("Filad add Internatioal shipment");
            }
            #endregion

            #region  h. Print all shipments using PrintAllShipments()
            deliveryCenter.PrintAllShipments();
            #endregion
            
            #region  i. Call DeliveryHelper.PrintShipmentDetails() for each shipment 

            /// i.Call DeliveryHelper.PrintShipmentDetails() for each shipment. 
            for (int i = 0; i < 3; i++)
            {
                Shipment shipment = deliveryCenter[i];
                DeliveryHelper.PrintShipmentDetails(shipment);
            }

            #endregion
            
            #region j. Demonstrate both versions of UpdateWeight().

            /// j. Demonstrate both versions of UpdateWeight().
            deliveryCenter[0].UpdateWeight(500);
            deliveryCenter[0].UpdateWeight(50, 100);

            #endregion
            
            #region k. Build a Shipment[] holding mixed types and print all of them in a loop. 

            /// k. Build a Shipment[] holding mixed types and print all of them in a loop. 
            Shipment[] shipments =
            {
                standardShipment,
                expressShipment,
                internationalShipment
            };

            foreach (var item in shipments)
            {
                item.PrintShipment();
            }

            #endregion
            
            #region l. Demonstrate the sealed class and sealed method (comments or code). 

            //PriorityInternationalShipment priorityInternationalShipment = new PriorityInternationalShipment(trackingCode,description,weight,deluv,deliveryAddress,customFee,destinationCountry);

            //priorityInternationalShipment.GenerateCustomsReport();

            #endregion
        }

    }
}
