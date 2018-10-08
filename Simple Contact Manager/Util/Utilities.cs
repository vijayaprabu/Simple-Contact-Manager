using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace SimpleContactManager.Util
{
    public static class Utilities
    {
        public static bool IsFileEmpty(string filePath)
        {
            long fileSize = new FileInfo(filePath).Length;
            return fileSize != 0;
        }

        public static string GetAndValidateName(string prompt)
        {
            string name;

            while (true)
            {
                Console.Write(prompt);
                name = Console.ReadLine();

                if (!Regex.IsMatch(name, @"^[a-zA-Z]+$"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nUse letters only.");
                    Console.ResetColor();
                    continue;
                }
                break;
            }
            // Ensures proper capitalization of names and trim whitespace.
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name.Trim().ToLower());
        }

        public static string GetAndValidatePhoneNumber(string prompt)
        {
            string phoneNumber;

            while (true)
            {
                Console.Write(prompt);
                phoneNumber = Console.ReadLine();

                if (!Regex.IsMatch(phoneNumber, @"^(1-)?\d{3}-\d{3}-\d{4}$"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nThe phone number must be in ###-###-#### format and contain no spaces.");
                    Console.ResetColor();
                    continue;
                }
                break;
            }
            return phoneNumber;
        }

        public static void ConsoleShowErrorMsg(string message)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Thread.Sleep(2500);
            Console.ResetColor();
            Console.Clear();
        }

        public static void ConsoleShowSuccessMsg(string message)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Thread.Sleep(2500);
            Console.ResetColor();
            Console.Clear();
        }
    }
}
