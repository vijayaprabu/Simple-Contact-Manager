using Simple_Contact_Manager_view;
using System;

namespace Simple_Contact_Manager
{
    public class Launcher
    {

        private Launcher() { } // Don't allow initialization of this class from outside as it would serve no purpose.

        private static bool usePersistance = true;

        public static bool GetUsePersistance ()
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
                menu.runMenu();
            }
        }

        public static void Main(string[] args)
        {
            // Cycle through the passed in command line arguments.
            foreach (string s in args)
            {
                if (s.Equals("nosave", StringComparison.OrdinalIgnoreCase))
                {
                    usePersistance = false;
                }
            }
            Launcher launcher = new Launcher();
            launcher.Initialize();
        }      
    }
}
