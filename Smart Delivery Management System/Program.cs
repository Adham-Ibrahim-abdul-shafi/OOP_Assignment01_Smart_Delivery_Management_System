using Smart_Delivery_Management_System.Delivery;
using Smart_Delivery_Management_System.Shipments;
using Smart_Delivery_Management_System.Validators;


namespace Smart_Delivery_Management_System
{
    
    internal class Program
    {
        static public void ReadShipment(out String trackingCode,out string description,out decimal weight,out decimal deliveryFee,out DeliveryAddress deliveryAddress)
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
                        
            string trackingCode, description;
            decimal weight,deliveryFee;

            
            DeliveryAddress deliveryAddress ;
            ReadShipment(out trackingCode, out description, out weight, out deliveryFee, out deliveryAddress);
            ///  3. Create one StandardShipment. 
            StandardShipment standardShipment = new StandardShipment(trackingCode, description, weight, deliveryFee, deliveryAddress);


            #endregion

            #region Create Express Shipment

            Console.WriteLine();
            Console.WriteLine("Enter Express Shipment data:");
            Console.WriteLine();

            ReadShipment(out trackingCode, out description, out weight, out deliveryFee, out deliveryAddress);
            
            decimal extraFee = InputValidator.GetNonNegativeDecimal("Enter Extra Fee (EGP): ");
            

            ///  4.Create one ExpressShipment. 
            ExpressShipment expressShipment = new ExpressShipment(trackingCode, description, weight, deliveryFee, deliveryAddress, extraFee);


            #endregion


            #region Create International Shipment

            ///5.Create one InternationalShipment. 
            Console.WriteLine();
            Console.WriteLine("Enter International Shipment data:");
            Console.WriteLine();

            ReadShipment(out trackingCode, out description, out weight, out deliveryFee, out deliveryAddress);

            string destinationCountry = InputValidator.GetNonWhiteSpaceString("Enter Destination Country: ");
            
            decimal customsFee = InputValidator.GetPositiveDecimal("Enter Customs Fee (EGP): ");

            ///  5. Create one InternationalShipment. 
            InternationalShipment internationalShipment = new InternationalShipment(trackingCode, description, weight, deliveryFee, deliveryAddress, customsFee, destinationCountry);

            #endregion


            /// 7. Add the shipments to the delivery center.
            bool successfullAddShipment = deliveryCenter.AddShipment(standardShipment);
            if (successfullAddShipment) {
                Console.WriteLine("Standard Shipment Added Successfully");
            }else
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

            
            successfullAddShipment =  deliveryCenter.AddShipment(internationalShipment);
            if (successfullAddShipment)
            {
                Console.WriteLine("International Shipment Added Successfully");
            }
            else
            {
                Console.WriteLine("International Shipment not Added Successfully");
            }

            ///  Print all shipments. 
            deliveryCenter.PrintAllShipments();


            ///9. Search for a shipment using the existing tracking code indexer.
            string searchTrakingCode = InputValidator.GetNonWhiteSpaceString("Enter Tracking Code to Remove: ");


            Shipment shipment = deliveryCenter[searchTrakingCode];
            if (shipment == null || shipment.TrackingCode == searchTrakingCode)
            {
                Console.WriteLine("shipment Not found");
            }else
            {
                Console.WriteLine("shipment found");
                shipment.PrintShipment();
                Console.WriteLine();
            }

            /// 10. Remove one shipment using its tracking code. 
            string removeTrackingCode = InputValidator.GetNonWhiteSpaceString("Enter Tracking Code to Remove: ");
            
            bool isDeleteDone = deliveryCenter.RemoveShipment(removeTrackingCode);
            
            Console.WriteLine();
            if (shipment == null || isDeleteDone)
            {
                Console.WriteLine("Shipment Removed Successfully");
            }else
            {
                Console.WriteLine("Shipment not found");
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
