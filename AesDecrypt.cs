
using System;
using System.IO;
using System.Security.Cryptography;


namespace QuickTools
{
      /// <summary>
      /// Secure.
      /// </summary>
    public partial class Secure 
    {







            /// <summary>
            /// Decrypt the specified cipherText with  password.
            /// </summary>
            /// <returns>The decrypt.</returns>
            /// <param name="cipherText">Cipher text.</param>
            /// <param name="password">Password.</param>
            public static string Decrypt(byte[] cipherText, object password)
            {

                  try {
                        byte[] Key = CreatePassword(password.ToString());
                        byte[] IV = Get.KeyBytesSaved();



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
                        using (Aes aesAlg = Aes.Create())
                        {
                              aesAlg.Key = Key;
                              aesAlg.IV = IV;

                              // Create a decryptor to perform the stream transform.
                              ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                              // Create the streams used for decryption.
                              using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                              {
                                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                                    {
                                          using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                                          {

                                                // Read the decrypted bytes from the decrypting stream
                                                // and place them in a string.
                                                plaintext = srDecrypt.ReadToEnd();
                                          }
                                    }
                              }
                        }

                        return plaintext;
                  }catch(Exception)
                  {
                        return null; 
                  }

            }
    }
}