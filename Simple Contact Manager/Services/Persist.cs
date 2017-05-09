using SimpleContactManager.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SimpleContactManager.Services
{
    /*
     * Responsible for the serialization of the user's contacts.
     */
    public class Persist
    {

        private readonly string filePath = Environment.CurrentDirectory + "\\Saved Contacts.dat"; // The file path for the file to be read and created at for serialization.

        public void WriteContacts(List<Contact> contacts)
        {
            using (FileStream fileWriter = new FileStream(filePath, FileMode.Create, FileAccess.Write)) // Overwrite the current serialization file with a new updated file.
            {
                try
                {
                    BinaryFormatter writer = new BinaryFormatter();
                    writer.Serialize(fileWriter, contacts); // Start the serialization of the user's contacts.
                }

                catch (Exception ex)
                {
                    // TODO: Catch specific exceptions
                    Console.Write("{0} \nPress any key to continue: ", ex.Message);
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        public List<Contact> ReadContacts()
        {
            if (!File.Exists(filePath)) // Create an empty file for serialization if one is not found upon program launch. (assuming persistence is enabled)
            {
                using (FileStream fileWriter = File.Create(filePath)) { }
            }

            if (Utilities.IsFileEmpty(filePath)) // Only try to read the file if it's not empty.
            {
                using (FileStream fileReader = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    try
                    {
                        BinaryFormatter reader = new BinaryFormatter();
                        List<Contact> contacts = (List<Contact>)reader.Deserialize(fileReader); // Read the user's saved contacts from a file into an arraylist.
                        return contacts;
                    }

                    catch (Exception ex)
                    {
                        // TODO: Catch specific exceptions
                        Console.Write("{0} \nPress any key to continue: ", ex.Message);
                        Console.ReadKey();
                        Console.Clear();
                        return null; // Return nothing incase deserialization fails.
                    }
                }
            }

            else
            {
                List<Contact> contacts = new List<Contact>();
                return contacts;
            }
        }

        public void DeleteSaveFile()
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
