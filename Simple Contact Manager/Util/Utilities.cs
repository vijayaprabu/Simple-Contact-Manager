using System;
using System.IO;

namespace Simple_Contact_Manager_util
{
    public class Utilities
    {

        public bool IsFileEmpty(String filePath) // Method to return true or false based on if a particular file is empty.
        {
            long fileSize = new FileInfo(filePath).Length;
            return fileSize != 0;
        }
    }
}
