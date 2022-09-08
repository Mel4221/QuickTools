using System;
using System.Text; 
using System.IO;
using System.Security.Cryptography;



namespace QuickTools
{

        public partial class Secure
        {



            private static byte[] CreatePassword(string password)
            {
                  byte[] passByes  = null;

                  byte[] array = Encoding.ASCII.GetBytes(password);
                  if (array.Length <16)
                  {

                        passByes = new byte[16];
                        for (int value=0; value < array.Length; value++)
                        {
                              passByes[value] = array[value]; 
                        }
                        return passByes;
                  }
                  else
                  {
                        passByes = new byte[16];
                        byte[] bigerArray = Encoding.ASCII.GetBytes(password);

                        for (int value=0; value < passByes.Length; value++)
                        {
                              passByes[value] = bigerArray[value]; 
                        }



                        return passByes;
                  }

                 
            }





            /// <summary>
            /// Encrypt the specified plainText and password.
            /// </summary>
            /// <returns>The encrypt.</returns>
            /// <param name="plainText">Plain text.</param>
            /// <param name="password">Password.</param>
            public static byte[] Encrypt(string plainText, object password)
            {
                  try {

                        byte[] Key = CreatePassword(password.ToString());
                        byte[] IV = New.RandomByteKey(true);

                        // Check arguments.
                        if (plainText == null || plainText.Length <= 0)
                              return null;
                        if (Key == null || Key.Length <= 0)
                              return null;
                        if (IV == null || IV.Length <= 0)
                              return null;
                        byte[] encrypted;

                        // Create an Aes object
                        // with the specified key and IV.
                        using (Aes aesAlg = Aes.Create())
                        {



                              aesAlg.Key = Key;
                              aesAlg.IV = IV;

                              // Create an encryptor to perform the stream transform.
                              ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                              // Create the streams used for encryption.
                              using (MemoryStream msEncrypt = new MemoryStream())
                              {
                                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                                    {
                                          using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                                          {
                                                //Write all data to the stream.
                                                swEncrypt.Write(plainText);
                                          }
                                          encrypted = msEncrypt.ToArray();
                                    }
                              }
                        }

                        // Return the encrypted bytes from the memory stream.
                        return encrypted;
                  }catch(Exception)
                  {
                        return null; 
                  }
            }

        
        }
}