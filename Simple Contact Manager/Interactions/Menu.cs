﻿using SimpleContactManager.Models;
using SimpleContactManager.Services;
using System;
using System.Collections.Generic;

namespace SimpleContactManager.Interactions
{
    public class Menu
    {
        private bool doExit;
        private Manager manager;
        private Tasks tasks;

        public Menu()
        {
            List<Contact> contacts;

            if (Program.UsePersistance)
            {
                contacts = Persist.ReadContacts();
                manager = new Manager(contacts);
            }
            else
            {
                contacts = new List<Contact>();
                manager = new Manager(contacts);
            }
            tasks = new Tasks(manager);
        }

        public void RunMenu()
        {
            while (!doExit)
            {
                DisplayOptions();
                int choice = GetSelection();
                PerformAction(choice);
            }
        }

        private void DisplayOptions()
        {
            Console.WriteLine("1) Add a new contact");
            Console.WriteLine("2) List all contacts");
            Console.WriteLine("3) Remove a contact");
            Console.WriteLine("4) Remove all contacts");
            Console.WriteLine("5) View contact information");
            Console.WriteLine("0) Exit the program");
        }

        private int GetSelection()
        {
            string input;
            int choice;

            while (true)
            {
                Console.Write("\nEnter your choice using numbers only: ");
                input = Console.ReadLine();

                if (int.TryParse(input, out choice))
                {
                    if (choice < 0 || choice > 5)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nThe selection {0} is out of range, please try again.\n", choice);
                        Console.ResetColor();
                        continue;
                    }
                    break;
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
