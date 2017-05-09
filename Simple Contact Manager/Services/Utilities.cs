using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace SimpleContactManager.Services
{
    /// <summary>
    /// A class representing a collection of useful methods used throughout the code.
    /// </summary>
    public static class Utilities
    {
        /// <summary>
        /// Checks if a given file is empty or not.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool IsFileEmpty(string filePath)
        {
            long fileSize = new FileInfo(filePath).Length;
            return fileSize != 0;
        }

        /// <summary>
        /// Validate a first name or last name (no numbers, no special characters, etc)
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Validate a phone number using basic rules regarding phone numbers.
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns></returns>
        public static string GetAndValidatePhoneNumber(string prompt)
        {
            //TODO: Make the validation smarter
            string phoneNumber;

            while (true)
            {
                Console.Write(prompt);
                phoneNumber = Console.ReadLine();

                if (!phoneNumber.All(char.IsDigit))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nPhone number can only contain numbers.");
                    Console.ResetColor();
                    continue;
                }
                break;
            }
            return phoneNumber;
        }

        /// <summary>
        /// Display a message in the console in red text.
        /// </summary>
        /// <param name="message"></param>
        public static void ConsoleShowErrorMsg(string message)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Thread.Sleep(2500);
            Console.ResetColor();
            Console.Clear();
        }

        /// <summary>
        /// Display a message in the console in green text.
        /// </summary>
        /// <param name="message"></param>
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
