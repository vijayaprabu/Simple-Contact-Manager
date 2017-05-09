using SimpleContactManager.Interactions;
using System;

namespace SimpleContactManager
{
    /* 
     * The launcher for the program which handles the passed in command line arguments 
     * and displays basic info to the user such as the author and the version.
     */
    public class Program
    {
        private Program() { } // Don't allow initialization of this class from outside as it would serve no purpose.

        private static bool usePersistance = true; // Allow serialization of contacts to file?

        public static bool GetUsePersistance () // Return the usePersistance boolean value
        {
            return usePersistance;
        }

        // Show basic info such as author and program version.
        private void Initialize()
        {
            Console.Title = "Simple Contact Manager Launcher";
            Console.WriteLine("Hello {0}, and welcome to version 1.4 of a simple contact manager by Jared Lung.", Environment.UserName);    
            Console.Write("Press Q to exit and any other key to continue: ");
            ConsoleKeyInfo key = Console.ReadKey();

            if (key.Key == ConsoleKey.Q)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.Title = string.Format("{0}'s Contacts", Environment.UserName);
                Console.Clear();
                Menu menu = new Menu();
                menu.RunMenu();
            }
        }

        public static void Main(string[] args)
        {
            // Cycle through the passed in command line arguments.
            foreach (string s in args)
            {
                if (s.Equals("nosave", StringComparison.OrdinalIgnoreCase)) // If a passed in argument matches nosave (ignore case) then set usePersistance to false
                {
                    usePersistance = false;
                }
            }
            Program launcher = new Program(); 
            launcher.Initialize();
        }      
    }
}
