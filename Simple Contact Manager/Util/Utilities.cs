using System;
using System.IO;
using System.Threading;

namespace Simple_Contact_Manager_util
{
    public static class Utilities
    {

        public static bool IsFileEmpty(String filePath) // Method to return true or false based on if a particular file is empty.
        {
            long fileSize = new FileInfo(filePath).Length;
            return fileSize != 0;
        }

        public static void ConsoleShowErrorMsg(String message)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Thread.Sleep(2500);
            Console.ResetColor();
            Console.Clear();
        }

        public static void ConsoleShowSuccessMsg(String message)
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
