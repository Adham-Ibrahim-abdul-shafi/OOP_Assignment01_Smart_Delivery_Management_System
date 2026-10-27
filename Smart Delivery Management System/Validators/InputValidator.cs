using System;
using System.Collections.Generic;
using System.Text;

namespace Smart_Delivery_Management_System.Validators
{
    internal static class InputValidator
    {
        public static string GetNonWhiteSpaceString(string message)
        {
            string input;
            do
            {
                Console.Write(message);
                input = Console.ReadLine()!;

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Error: The entered value is empty or null or White Space. Please try again.");
                }
            }
            while (string.IsNullOrWhiteSpace(input));

            return input;
        }

        public static int GetPositiveInt(string prompt)
        {
            int number;
            bool isValid;

            do
            {
                Console.Write(prompt);
                string input = Console.ReadLine()!;

                isValid = int.TryParse(input, out number) && number > 0;

                if (!isValid)
                {
                    Console.WriteLine("Error: Please enter a valid positive integer greater than zero.");
                }
            }
            while (!isValid);

            return number;
        }

        public static decimal GetPositiveDecimal(string prompt)
        {
            decimal number;
            bool isValid;

            do
            {
                Console.Write(prompt);
                string input = Console.ReadLine()!;

                isValid = decimal.TryParse(input, out number) && number > 0;

                if (!isValid)
                {
                    Console.WriteLine("Error: Please enter a valid positive integer greater than zero.");
                }
            }
            while (!isValid);

            return number;
        }
        public static decimal GetNonNegativeDecimal(string prompt)
        {
            decimal number;
            bool isValid;

            do
            {
                Console.Write(prompt);
                string input = Console.ReadLine()!;

                isValid = decimal.TryParse(input, out number) && number >= 0;

                if (!isValid)
                {
                    Console.WriteLine("Error: Please enter a valid positive integer greater than zero.");
                }
            }
            while (!isValid);

            return number;
        }
    }
}
