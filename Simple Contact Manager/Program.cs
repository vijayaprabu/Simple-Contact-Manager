using SimpleContactManager.Interactions;
using System;

namespace SimpleContactManager
{
    public class Program
    {
        // Allow serialization of contacts to disk?
        public static bool UsePersistance { get; private set; } = true;

        public static void Main(string[] args)
        {
            foreach (string s in args)
            {
                if (s.Equals("nosave", StringComparison.OrdinalIgnoreCase)) { UsePersistance = false; }
            }
            Initialize();
        }

        private static void Initialize()
        {
            Console.Title = "Simple Contact Manager";
            Console.WriteLine("Hello {0}, and welcome to a simple contact manager by Jared Lung.", Environment.UserName);
            Console.Write("Press Q to exit and any other key to continue: ");
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.Q) { Environment.Exit(0); }
            else
            {
                Console.Title = $"{Environment.UserName}'s Contacts";
                Console.Clear();
                Menu menu = new Menu();
                menu.RunMenu();
            }
        }
    }
}
