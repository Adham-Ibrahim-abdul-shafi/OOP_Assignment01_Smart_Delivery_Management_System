using System.Collections;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Threading.Channels;
using Smart_Delivery_Management_System.OOP01.Models;

namespace Smart_Delivery_Management_System
{
    
    internal class Program
    {
        static public void ReadShipment(out String trackingCode,out string description,out decimal weight,out decimal deliveryFee,out DeliveryAddress deliveryAddress)
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
            #region Question 1
            //  a)What's the difference between a class and a struct?
            //      A class is stored in the heap, so I'll use it when I want the object to have a longer lifetime or if it’s big in size, but accessing it will take a bit longer because it’s stored randomly in the heap.
            //      A struct is stored in the stack, so I can access it faster, but it shouldn’t be too big because the stack space is small.
            //  b) Why are classes considered more suitable than structs for large applications?
            //      Because they allow me to do inheritance, which is closer to real life.
            #endregion

            #region Question 2
            /*
             Consider the following code:

             public class Shipment
            {
                public string TrackingCode { get; set; }
            }
            public class ExpressShipment : Shipment {
                public decimal ExtraFee { get; set; }
            }
             
             */


            //  a) Which class is the parent class?
            //      Charge
            //  b) Which class is the subclass?
            //      Fast Charge
            //  c) Which members are inherited by Fast Charge?
            //      Tracking Code
            //  d) Why is inheritance better than copying the same code into multiple classes?
            //      Because if I want to make a change:
            //      If I copied the code, I’d have to change it in all places.
            //      If I used inheritance, I’d only need to change it once.
            //      Also, copying takes more time and the code would be longer, whereas with inheritance the code is shorter and quicker to write.


            #endregion

            Console.Clear();
            
            /// 1. Create a DeliveryCenter. 
            DeliveryCenter deliveryCenter = new DeliveryCenter();
            ///  2. Read the center name from the user.
            
            do
            {
                Console.Write("Enter Delivery Center Name: ");
                deliveryCenter.CenterName = Console.ReadLine()!;
            } while (string.IsNullOrWhiteSpace(deliveryCenter.CenterName));
            Console.WriteLine();
            Console.WriteLine("============================================");
            Console.WriteLine($"Delivery Center : {deliveryCenter.CenterName}");
            Console.WriteLine("============================================");
            Console.WriteLine();


            #region Create Standerd Shipment

            Console.WriteLine();
            Console.WriteLine("Enter Standard Shipment data:");
            Console.WriteLine();
                        
            string trackingCode=string.Empty, description=string.Empty;
            decimal weight,deliveryFee;
            DeliveryAddress deliveryAddress;
            ReadShipment(out trackingCode,out description,out weight, out deliveryFee, out  deliveryAddress);
            ///  3. Create one StandardShipment. 
            StandardShipment standardShipment = new StandardShipment(trackingCode, description, weight, deliveryFee, deliveryAddress);


            #endregion

            #region Create Express Shipment

            Console.WriteLine();
            Console.WriteLine("Enter Express Shipment data:");
            Console.WriteLine();

            ReadShipment(out trackingCode, out description, out weight, out deliveryFee, out deliveryAddress);
            
            decimal extraFee;
            do
            {
                Console.Write("Enter Extra Fee: ");
            } while (!decimal.TryParse(Console.ReadLine(), out extraFee));


            ///  4.Create one ExpressShipment. 
            ExpressShipment expressShipment = new ExpressShipment(trackingCode, description, weight, deliveryFee, deliveryAddress, extraFee);


            #endregion


            #region Create International Shipment

            ///5.Create one InternationalShipment. 
            Console.WriteLine();
            Console.WriteLine("Enter International Shipment data:");
            Console.WriteLine();

            ReadShipment(out trackingCode, out description, out weight, out deliveryFee, out deliveryAddress);

            string destinationCountry;
            do
            {
                Console.Write("Enter Destination Country: ");
                destinationCountry = Console.ReadLine()!;
            } while (String.IsNullOrWhiteSpace(destinationCountry));


            decimal customsFee;
            do
            {
                Console.Write("Enter Customs Fee: ");

            } while (!decimal.TryParse(Console.ReadLine(), out customsFee) || customsFee <= 0);

            ///  5. Create one InternationalShipment. 
            InternationalShipment internationalShipment = new InternationalShipment(trackingCode, description, weight, deliveryFee, deliveryAddress, customsFee, destinationCountry);

            #endregion


            /// 7. Add the shipments to the delivery center.
            bool successfullAddShipment = deliveryCenter.AddShipment(standardShipment);
            if (successfullAddShipment) {
                Console.WriteLine("Shipment Added Successfully");
            }else
            {
                Console.WriteLine("Shipment not Added Successfully");
            }
            
            successfullAddShipment = deliveryCenter.AddShipment(expressShipment);
            if (successfullAddShipment)
            {
                Console.WriteLine("Shipment Added Successfully");
            }
            else
            {
                Console.WriteLine("Shipment not Added Successfully");
            }

            
            successfullAddShipment =  deliveryCenter.AddShipment(internationalShipment);
            if (successfullAddShipment)
            {
                Console.WriteLine("Shipment Added Successfully");
            }
            else
            {
                Console.WriteLine("Shipment not Added Successfully");
            }

            ///  Print all shipments. 
            deliveryCenter.PrintAllShipments();


            ///9. Search for a shipment using the existing tracking code indexer.
            string searchTrakingCode;
            do
            {
                searchTrakingCode = Console.ReadLine()!;
            } while (string.IsNullOrWhiteSpace(searchTrakingCode));
            Shipment shipment = deliveryCenter[searchTrakingCode];
            if (shipment.Equals(default))
            {
                Console.WriteLine("shipment Not found");
            }else
            {
                Console.WriteLine("shipment found");
                shipment.PrintShipment();
                Console.WriteLine();
            }

            /// 10. Remove one shipment using its tracking code. 
            string removeTrackingCode;
            do
            {
                Console.Write("Enter Tracking Code to Remove: ");
                removeTrackingCode = Console.ReadLine()!;
            }while(String.IsNullOrWhiteSpace(removeTrackingCode));
            bool isDeleteDone = deliveryCenter.RemoveShipment(removeTrackingCode);
            
            Console.WriteLine();
            if (isDeleteDone)
            {
                Console.WriteLine("Shipment Removed Successfully");
            }else
            {
                Console.WriteLine("Shipment not delete");
            }
            /// 11. Print the remaining shipments.
            Console.WriteLine();
            Console.WriteLine("============================================");
            Console.WriteLine("Remaining Shipments");
            Console.WriteLine("============================================");
            Console.WriteLine();

            deliveryCenter.PrintAllShipments();
        }

    }
}
