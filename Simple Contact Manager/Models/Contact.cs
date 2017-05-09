using System;

namespace SimpleContactManager.Models
{
    /// <summary>
    /// The structure for a user's contact with basic info such as name and phone number. 
    /// </summary>
    [Serializable]
    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string FullName => FirstName + " " + LastName;

        public Contact(string firstName, string lastName, string phoneNumber, string address)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Address = address;
        }

        /// <summary>
        /// Returns all the info about the contact.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Fullname: " + FullName + "\nPhone number: " + PhoneNumber + "\nAddress: " + Address;
        }
    }
}
