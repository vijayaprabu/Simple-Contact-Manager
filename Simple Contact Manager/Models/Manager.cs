using SimpleContactManager.Services;
using System;
using System.Collections.Generic;

namespace SimpleContactManager.Models
{
    /// <summary>
    /// Stores the user's contacts into a list and provides various methods to interact with it.
    /// </summary>
    public class Manager
    {
        private readonly List<Contact> contacts;

        public Manager(List<Contact> contacts)
        {
            this.contacts = contacts;
        }

        /// <summary>
        /// Returns the managers list containing the user's contacts.
        /// </summary>
        /// <returns></returns>
        public List<Contact> GetContacts()
        {
            return contacts;
        }

        /// <summary>
        /// Get a specific contact from the managers list based off a given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Contact GetContact(int index)
        {
            return contacts[index];
        }

        /// <summary>
        /// Add a given contact to the managers list.
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        public bool AddContact(Contact contact)
        {
            // Cycle through the managers list.
            foreach (Contact c in contacts)
            {
                // If the contact to add has the same name as an already existing contact.
                if (contact.FullName.Equals(c.FullName, StringComparison.OrdinalIgnoreCase))
                {
                    Utilities.ConsoleShowErrorMsg(string.Format("Failed to add {0}, the contact {1} already exists.", contact.FullName, contact.FullName));
                    // A contact with the same name as the contact to be added already exists.
                    return false;
                }
            }
            contacts.Add(contact);
            Utilities.ConsoleShowSuccessMsg(string.Format("{0} has been successfully added to your contacts.", contact.FullName));
            // The contact to be added is completely unique and does not share the same name as an already existing contact.
            return true;
        }

        /// <summary>
        /// Remove a specific contact based on a given index from the managers list.
        /// </summary>
        /// <param name="index"></param>
        public void RemoveContact(int index)
        {
            Contact removedContact = contacts[index];
            contacts.RemoveAt(index);
            Utilities.ConsoleShowSuccessMsg(string.Format("{0} has been successfully removed from your contacts.", removedContact.FullName));
        }

        /// <summary>
        /// Removes all contacts in the managers list.
        /// </summary>
        public void RemoveAllContacts()
        {
            // Get the number of contacts that were removed.
            int numberRemoved = contacts.Count;
            contacts.RemoveRange(0, contacts.Count);
            Utilities.ConsoleShowSuccessMsg(string.Format("{0} contact(s) have been removed.", numberRemoved));
        }
    }
}
