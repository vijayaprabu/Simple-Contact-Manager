using SimpleContactManager.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SimpleContactManager.Services
{
    /// <summary>
    /// Represents a collection of static methods responsible for the serialization of the user's contacts.
    /// </summary>
    public static class Persist
    {

        // The paths on disk the application uses to save the user's contacts to.
        private static readonly string appSaveFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Simple Contact Manager\Saved Contacts");
        private static readonly string appSaveFile = "Contacts.dat";

        /// <summary>
        /// Serializes a list of contacts to disk.
        /// </summary>
        /// <param name="contacts"></param>
        public static void WriteContacts(List<Contact> contacts)
        {
            ValidatePath();
            using (FileStream fileWriter = new FileStream(Path.Combine(appSaveFolder, appSaveFile), FileMode.Create, FileAccess.Write)) // Overwrite the current serialization file with a new updated file.
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
        public static List<Contact> ReadContacts()
        {
            ValidatePath();
            // Only try to read the file if it's not empty.
            if (Utilities.IsFileEmpty(Path.Combine(appSaveFolder, appSaveFile)))
            {
                using (FileStream fileReader = new FileStream(Path.Combine(appSaveFolder, appSaveFile), FileMode.Open, FileAccess.Read))
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

        /// <summary>
        /// Deletes the file that stores the user's saved contacts from the disk.
        /// </summary>
        public static void DeleteSaveData()
        {
            if (Directory.Exists(appSaveFolder)) { Directory.Delete(appSaveFolder, true); }
        }

        /// <summary>
        /// Validates whether or not the directories and the file the application uses for serialization purposes exist.
        /// </summary>
        private static void ValidatePath()
        {
            // Creates an empty file and directory for serialization if one is not found upon program launch. (assuming persistence is enabled)
            if (!Directory.Exists(appSaveFolder))
            {
                Directory.CreateDirectory(appSaveFolder);
                using (FileStream fileWriter = File.Create(Path.Combine(appSaveFolder, appSaveFile))) { }
            }
        }
    }
}
