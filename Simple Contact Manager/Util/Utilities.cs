﻿using System;
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
