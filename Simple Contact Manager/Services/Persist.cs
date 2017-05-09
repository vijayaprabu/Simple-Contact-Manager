using SimpleContactManager.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SimpleContactManager.Services
{
    /// <summary>
    /// Collection of methods responsible for the serialization of the user's contacts.
    /// </summary>
    public class Persist
    {
        // The file path for the file to be read and created at for serialization purposes.
        private readonly string filePath = Environment.CurrentDirectory + "\\Saved Contacts.dat";

        /// <summary>
        /// Serializes a list of contacts to disk.
        /// </summary>
        /// <param name="contacts"></param>
        public void WriteContacts(List<Contact> contacts)
        {
            using (FileStream fileWriter = new FileStream(filePath, FileMode.Create, FileAccess.Write)) // Overwrite the current serialization file with a new updated file.
            {
                try
                {
                    BinaryFormatter writer = new BinaryFormatter();
                    // Start the serialization of the user's contacts.
                    writer.Serialize(fileWriter, contacts);
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

        /// <summary>
        /// Deserializes a list of contacts from a file.
        /// </summary>
        /// <returns></returns>
        public List<Contact> ReadContacts()
        {
            // Create an empty file for serialization if one is not found upon program launch. (assuming persistence is enabled)
            if (!File.Exists(filePath))
            {
                using (FileStream fileWriter = File.Create(filePath)) { }
            }

            // Only try to read the file if it's not empty.
            if (Utilities.IsFileEmpty(filePath))
            {
                using (FileStream fileReader = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    try
                    {
                        BinaryFormatter reader = new BinaryFormatter();
                        // Read the user's saved contacts from a file into a list.
                        List<Contact> contacts = (List<Contact>)reader.Deserialize(fileReader);
                        return contacts;
                    }

                    catch (Exception ex)
                    {
                        // TODO: Catch specific exceptions
                        Console.Write("{0} \nPress any key to continue: ", ex.Message);
                        Console.ReadKey();
                        Console.Clear();
                        // Return nothing incase deserialization fails.
                        return null;
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
