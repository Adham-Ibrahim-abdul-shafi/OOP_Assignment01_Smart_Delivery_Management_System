namespace Smart_Delivery_Management_System.OOP01.Models.Helpers
{
    internal static class DeliveryUtilities
    {
        public static void PrintSeparator()
        {
            Console.WriteLine("=========================================================");
        }

        static public void PrintSystemTitle()
        {
            Console.WriteLine("Delivery Center ");
        }

        static public void PrintSystemTitle(string SystemName)
        {
            Console.WriteLine($"Delivery Center : {SystemName}");
        }
    }
}
