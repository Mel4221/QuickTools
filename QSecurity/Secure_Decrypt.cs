﻿using System;
using System.Text;
using System.IO;
using QuickTools.QIO;
using QuickTools.QCore;
using System.Security.Cryptography;
namespace QuickTools.QSecurity
{
    public partial class Secure
    {
        /// <summary>
        /// Decrypt the specified cipherText text  with a password.
        /// and this is the AUTOMATIC way of doing it 
        /// </summary>
        /// <returns>The decrypt.</returns>
        /// <param name="cipherText">Cipher text.</param>
        /// <param name="password">Password.</param>
        /// <param name="iv">Iv.</param>
        public string Decrypt(byte[] cipherText, object password, byte[] iv)
        {

            try
            {
                byte[] Key = CreatePassword(password.ToString());
                byte[] IV = iv;
                // = Encoding.ASCII.GetBytes(text);


                // Check arguments.
                if (cipherText == null || cipherText.Length <= 0)
                    return null;
                if (Key == null || Key.Length <= 0)
                    return null;
                if (IV == null || IV.Length <= 0)
                    return null;

                // Declare the string used to hold
                // the decrypted text.
                string plaintext = null;

                // Create an Aes object
                // with the specified key and IV.
                using (Aes aes = Aes.Create())
                {
                    aes.Key = Key;
                    aes.IV = IV;

                    // Create a decryptor to perform the stream transform.
                    ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                    // Create the streams used for decryption.
                    using (MemoryStream decryptorMem = new MemoryStream(cipherText))
                    {
                        using (CryptoStream csDecrypt = new CryptoStream(decryptorMem, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                            {

                                // Read the decrypted bytes from the decrypting stream
                                // and place them in a string.
                                plaintext = srDecrypt.ReadToEnd();
                                if (plaintext == null || plaintext == "")
                                {
                                    return null;
                                }
                            }
                        }
                    }
                }

                return plaintext;
            }
            catch (Exception)
            {
                return null;
            }




        }

        /// <summary>
        /// Decrypt the specified bytes, password and iv.
        /// </summary>
        /// <returns>The decrypt.</returns>
        /// <param name="bytes">Bytes.</param>
        /// <param name="password">Password.</param>
        /// <param name="iv">Iv.</param>
        public string Decrypt(byte[] bytes, byte[] password, byte[] iv)
        {

            try
            {

                // Declare the string used to hold
                // the decrypted text.
                string plaintext = null;

                // Create an Aes object
                // with the specified key and IV.
                using (Aes aes = Aes.Create())
                {
                    aes.Key = password;
                    aes.IV = iv;

                    // Create a decryptor to perform the stream transform.
                    ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                    // Create the streams used for decryption.
                    using (MemoryStream decryptorMem = new MemoryStream(bytes))
                    {
                        using (CryptoStream csDecrypt = new CryptoStream(decryptorMem, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                            {

                                // Read the decrypted bytes from the decrypting stream
                                // and place them in a string.
                                plaintext = srDecrypt.ReadToEnd();
                                if (plaintext == null || plaintext == "")
                                {
                                    return null;
                                }
                            }
                        }
                    }
                }

                return plaintext;
            }
            catch (Exception)
            {
                return null;
            }




        }
    }
}
