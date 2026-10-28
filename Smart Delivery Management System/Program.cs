using Smart_Delivery_Management_System.Delivery;
using Smart_Delivery_Management_System.Helpers;
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

            #region a. Create a Driver

            /// a. Create a Driver.
          
            Console.WriteLine();
            string driverId = InputValidator.GetNonWhiteSpaceString("Enter Driver ID: ");
            string driverName = InputValidator.GetNonWhiteSpaceString("Enter Driver Name: ");
            string driverPhoneNumber = InputValidator.GetNonWhiteSpaceString("Enter Driver Phone Number: ");
            Console.WriteLine();
            Console.WriteLine("------------------------------------------");
            Driver driver = new Driver(driverId ,driverName,driverPhoneNumber);

            #endregion

            #region b. Create a DeliveryCenter

            /// b. Create a DeliveryCenter.
            DeliveryCenter deliveryCenter = new DeliveryCenter();

            #endregion

            #region c. Assign the Driver to the DeliveryCenter 
            deliveryCenter.Driver = driver;
            #endregion

            Console.WriteLine("==============================================");
            Console.WriteLine($"Delivery Center {deliveryCenter.Driver.Name}");
            Console.WriteLine("==============================================");



            #region d. Create one StandardShipment
            Console.WriteLine();
            Console.WriteLine("Enter Standard Shipment data:");
            Console.WriteLine();

            string trackingCode, description;
            decimal weight, deliveryFee;


            DeliveryAddress deliveryAddress;
            ReadShipment(out trackingCode, out description, out weight, out deliveryFee, out deliveryAddress);

            StandardShipment standardShipment = new StandardShipment(trackingCode, description, weight, deliveryFee, deliveryAddress);

            #endregion

            #region e. Create one ExpressShipment

            /// e. Create one ExpressShipment. 

            Console.WriteLine();
            Console.WriteLine("Enter Express Shipment data:");
            Console.WriteLine();

            ReadShipment(out trackingCode, out description, out weight, out deliveryFee, out deliveryAddress);
            decimal extraFee = InputValidator.GetNonNegativeDecimal("Enter Extra Fee (EGP): ");

            ExpressShipment expressShipment = new ExpressShipment(trackingCode, description, weight, deliveryFee, deliveryAddress, extraFee);


            #endregion

            #region f. Create one InternationalShipment

            /// f. Create one InternationalShipment. 
            Console.WriteLine();
            Console.WriteLine("Enter International Shipment data:");
            Console.WriteLine();

            ReadShipment(out trackingCode, out description, out weight, out deliveryFee, out deliveryAddress);
            string destinationCountry = InputValidator.GetNonWhiteSpaceString("Enter Destination Country: ");
            decimal customsFee = InputValidator.GetPositiveDecimal("Enter Customs Fee (EGP): ");

            InternationalShipment internationalShipment = new InternationalShipment(trackingCode, description, weight, deliveryFee, deliveryAddress, customsFee, destinationCountry);

            #endregion

            #region  g. Add all shipments to the DeliveryCenter
            bool successfullAddShipment = deliveryCenter.AddShipment(standardShipment);
            if (successfullAddShipment)
            {
                Console.WriteLine("Standard Shipment Added Successfully");
            }
            else
            {
                Console.WriteLine("Standard Shipment not Added Successfully");
            }

            successfullAddShipment = deliveryCenter.AddShipment(expressShipment);
            if (successfullAddShipment)
            {
                Console.WriteLine("Express Shipment Added Successfully");
            }
            else
            {
                Console.WriteLine("Express Shipment not Added Successfully");
            }


            successfullAddShipment = deliveryCenter.AddShipment(internationalShipment);
            if (successfullAddShipment)
            {
                Console.WriteLine("International Shipment Added Successfully");
            }
            else
            {
                Console.WriteLine("International Shipment not Added Successfully");
            }
            #endregion

            #region  h. Print all shipments using PrintAllShipments()
            Console.WriteLine();
            Console.WriteLine("Printing Using PrintAllShipment() method");
            deliveryCenter.PrintAllShipments();
            Console.WriteLine("===============================================");
            Console.WriteLine();

            #endregion

            #region  i. Call DeliveryHelper.PrintShipmentDetails() for each shipment 

            /// i.Call DeliveryHelper.PrintShipmentDetails() for each shipment. 
            Console.WriteLine();
            Console.WriteLine("Printing Using DeliveryHelper..... ");
            for (int i = 0; i < 3; i++)
            {
                Shipment shipment = deliveryCenter[i];
                DeliveryHelper.PrintShipmentDetails(shipment);
            }

            #endregion

            #region j. Demonstrate both versions of UpdateWeight().

            /// j. Demonstrate both versions of UpdateWeight().
            Console.WriteLine();
            Console.WriteLine("=======================================");
            Console.WriteLine("Updating Weight... ");
            Console.WriteLine();
            Console.WriteLine($"Original Weight : {deliveryCenter[0].Weight}");
            deliveryCenter[0].UpdateWeight(500);
            Console.WriteLine($"Updated Weight : {deliveryCenter[0].Weight}");
            deliveryCenter[0].UpdateWeight(50, 100);
            Console.WriteLine($"Updated Weight After Packing : {deliveryCenter[0].Weight}");

            #endregion

            #region k. Build a Shipment[] holding mixed types and print all of them in a loop. 

            /// k. Build a Shipment[] holding mixed types and print all of them in a loop. 
            Console.WriteLine("printing using Shipment[] ...");
            
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

            PriorityInternationalShipment priorityInternationalShipment = new PriorityInternationalShipment(trackingCode, description, weight, deliveryFee, deliveryAddress, customsFee, destinationCountry);

            priorityInternationalShipment.GenerateCustomsReport();

            #endregion
        }

    }
}
