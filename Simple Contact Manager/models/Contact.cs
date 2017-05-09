using System;

namespace SimpleContactManager.Models
{
    /*
     * The structure for a user's contact with basic info such as name and phone number. 
     */
    [Serializable] // Allow serialization of this class.
    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public Contact(string firstName, string lastName, string phoneNumber, string address)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Address = address;
        }

        // Returns the fullname of the contact.
        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }

        // Returns all the info about the contact.
        public override string ToString()
        {
            return "Fullname: " + GetFullName() + "\nPhone number: " + PhoneNumber + "\nAddress: " + Address;
        }
    }
}
