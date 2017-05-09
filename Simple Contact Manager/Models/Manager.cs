using SimpleContactManager.Services;
using System;
using System.Collections.Generic;

namespace SimpleContactManager.Models
{
    /*
     * Stores the user's contacts in an arraylist and provides various methods to interact with it.
     */
    public class Manager
    {
        private List<Contact> contacts;

        public Manager(List<Contact> contacts)
        {
            this.contacts = contacts;
        }

        // Return the managers arraylist
        public List<Contact> GetContacts()
        {
            return contacts;
        }

        // Get a specific contact from the managers arraylist based off a given index.
        public Contact GetContact(int index)
        {
            return contacts[index];
        }

        // Add a given contact to the managers arraylist.
        public bool AddContact(Contact contact)
        {
            foreach (Contact c in contacts) // Cycle through the arraylist
            {
                if (contact.GetFullName().Equals(c.GetFullName(), StringComparison.OrdinalIgnoreCase)) // If the contact to add has the same name as an already existing contact.
                {
                    Utilities.ConsoleShowErrorMsg(string.Format("Failed to add {0}, the contact {1} already exists.", contact.GetFullName(), contact.GetFullName()));
                    return false; // A contact with the same name as the contact to be added already exists.
                }
            }
            contacts.Add(contact);
            Utilities.ConsoleShowSuccessMsg(string.Format("{0} has been successfully added to your contacts.", contact.GetFullName()));
            return true; // The contact to be added is completely unique and does not share the same name as an already existing contact.
        }

        // Remove a specific contact based on a given index from the managers arraylist.
        public void RemoveContact(int index)
        {
            Contact removedContact = contacts[index];
            contacts.RemoveAt(index);
            Utilities.ConsoleShowSuccessMsg(string.Format("{0} has been successfully removed from your contacts.", removedContact.GetFullName()));
        }

        // Removes all contacts in the managers arraylist.
        public void RemoveAllContacts()
        {
            int numberRemoved = contacts.Count; // Get the number of contacts that were removed
            contacts.RemoveRange(0, contacts.Count); 
            Utilities.ConsoleShowSuccessMsg(string.Format("{0} contact(s) have been removed.", numberRemoved));
        }
    }
}
