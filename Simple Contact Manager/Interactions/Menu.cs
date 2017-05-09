using SimpleContactManager.Models;
using SimpleContactManager.Services;
using System;
using System.Collections.Generic;

namespace SimpleContactManager.Interactions
{
    /*
     * Provides a menu to the user and then processes there input and performs an action based off of it.
     */
    public class Menu
    {
        private bool doExit = false; // Keep displaying the menu and thus running the program?
        private Persist persist;
        private Manager manager;
        private Tasks tasks;

        public Menu()
        {
            List<Contact> contacts;
            persist = new Persist();

            if (Program.UsePersistance) // If persistence is enabled, get the user's contacts from a save file.
            {
                contacts = persist.ReadContacts();
                manager = new Manager(contacts);
            }
            else // If persistence is not enabled, don't load the user's contacts from a save file. (start fresh)
            {
                contacts = new List<Contact>();
                manager = new Manager(contacts);
            }
            tasks = new Tasks(manager, persist);
        }

        public void RunMenu() // Main program loop
        {
            while (!doExit)
            {
                DisplayOptions();
                int choice = GetSelection(); 
                PerformAction(choice);
            }
        }

        private void DisplayOptions() // Display a list of options the user can choose from.
        {
            Console.WriteLine("1) Add a new contact");
            Console.WriteLine("2) List all contacts");
            Console.WriteLine("3) Remove a contact");
            Console.WriteLine("4) Remove all contacts");
            Console.WriteLine("5) View contact information");
            Console.WriteLine("0) Exit the program");
        }

        // Get a choice from the user regarding the listed options above.
        private int GetSelection() 
        {
            string input;
            int choice;

            while (true)
            {
                Console.Write("\nEnter your choice using numbers only: ");
                input = Console.ReadLine();

                if (int.TryParse(input, out choice)) // If the user's input is of type integer.
                {
                    if (choice < 0 || choice > 5) // If the user's input is not between 0 and 5.
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nThe selection {0} is out of range, please try again.\n", choice);
                        Console.ResetColor();
                        continue;
                    }
                    else // Return the user's choice if it's completely valid.
                    {
                        break;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n{0} is not a valid whole number, please use numbers only.\n", input);
                    Console.ResetColor();
                }
            }
            return choice;
        }
        
        // Call one of the methods in Task.cs based on what the user choose to do in the menu.
        private void PerformAction(int choice)  
        {
            switch (choice)
            {
                case 1:
                    tasks.AddContactProcess();
                    break;

                case 2:
                    tasks.ListAllContacts();
                    break;

                case 3:
                    tasks.RemoveContactProcess();
                    break;

                case 4:
                    tasks.RemoveAllContactsProcess();
                    break;

                case 5:
                    tasks.ShowContactDetails();
                    break;

                case 0:
                    doExit = true;
                    break;
            }
        }
    }
}
