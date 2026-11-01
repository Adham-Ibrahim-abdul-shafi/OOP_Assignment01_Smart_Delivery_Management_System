namespace Smart_Delivery_Management_System.Helpers
{
    internal static class DeliveryUtilities
    {
        public static void PrintSeparator()
        {
            Console.WriteLine("=========================================================");
        }


        static public void PrintSystemTitle(string SystemName)
        {
            PrintSeparator();
            Console.WriteLine(SystemName);
            PrintSeparator();
        }
    }
}
