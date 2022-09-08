/*
using System;
using System.IO;
using static System.Console; 
using System.Security.Cryptography;
using QuickTools; 

namespace Aes_Example
{
    class AesExample
    {
        public static void Main()
        {
            string original = "Here is some data to encrypt!";

            // Create a new instance of the Aes
            // class.  This generates a new key and initialization
            // vector (IV).
            using (Aes myAes = Aes.Create())
            {

                // Encrypt the string to an array of bytes.
                byte[] encrypted = Secure.EncryptStringToBytes_Aes(original, myAes.Key, myAes.IV);
                foreach(byte x in encrypted)
                WriteLine(x); 
                ReadLine(); 
                // Decrypt the bytes to a string.
                string roundtrip = Secure.DecryptStringFromBytes_Aes(encrypted, myAes.Key, myAes.IV);

                //Display the original data and the decrypted data.
                Console.WriteLine("Original:   {0}", original);
                Console.WriteLine("Round Trip: {0}", roundtrip);
            }
        }
       
    }
}
*/