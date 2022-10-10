using System;
using System.Text; 
using System.IO;
using System.Security.Cryptography;
using System.Diagnostics; 



namespace QuickTools
{
            /// <summary>
            /// The secure class is a class that uses the Aes tecnology to encrypt data by using
            /// a public key and a 
            /// </summary>
        public partial class Secure
        {





            /// <summary>
            /// This allow the encriptor to either try to save the scure key or not  and is set to FALSE <see langword="false"/>  by default for security reasons
            /// </summary>
            public bool AllowToSaveKey = false; 



            /// <summary>
            /// This will contain the public key used to encrypt the file 
            /// be carefull it will stay on memory ONLY 
            /// </summary>
            public byte[] PublicKey = null;
            /// <summary>
            /// This temporaly holds the public Key in an string format 
            /// </summary>
            public string RowPublicKey = null; 

            public byte[] CreatePassword(string password)
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
            /// Encrypt the specified plainText with the password given 
            /// please remember that you will need the Pulic key to Decrypt the text
            /// THIS IS THE AUTOMATIC WAY OF DOING IT . 
            /// </summary>
            /// <returns>The encrypt.</returns>
            /// <param name="plainText">Plain text.</param>
            /// <param name="password">Password.</param>
            public byte[] Encrypt(string plainText, object password)
            {
                 // try {

                        byte[] Key = CreatePassword(password.ToString());
                        byte[] IV = New.RandomByteKey(AllowToSaveKey);
                        this.PublicKey = IV;
                        
                        //Get.Wait($"Text: {plainText.Length} Key: {Key.Length} IV: {IV.Length}");
                        /*
                        Action action = () => {
                        StringBuilder str = new StringBuilder(); 
                        foreach (byte k in IV) 
                        str.Append(k+",");
                        this.RowPublicKey = str.ToString(); 
                        };
                        action();
                        */                       

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
                        using (Aes aes = Aes.Create())
                        {



                              aes.Key = Key;
                              aes.IV = IV;


                              // Create an encryptor to perform the stream transform.
                              ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                              // Create the streams used for encryption.
                              using (MemoryStream msEncrypt = new MemoryStream())
                              {
                                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                                    {
                                          using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                                          {
                                                //Write all data to the stream.
                                                swEncrypt.Write(plainText,0,plainText.Length);
                                          }
                                         encrypted = msEncrypt.ToArray();
                                    }
                              }
                        }

                        // Return the encrypted bytes from the memory stream.
                        //string text = Encoding.ASCII.GetString(encrypted);
                        return encrypted;
                 // }catch(Exception)
                 // {
                    //    return null; 
                  //}
            }












            private byte[] ManualKey = null;
            private byte[] ManualIV = null;
            private string ClearText = null; 
            /// <summary>
            /// This Encription Method is used when you initialize the class with 
            /// the arguments  of text , key and iv  IF this is your first time using the class
            /// please use the more simpler way 
            /// </summary>
            /// <returns>The encrypt.</returns>
            public byte[] Encrypt()
            {
                  try
                  {
                        
                        byte[] Key = ManualKey;
                        byte[] IV = ManualIV; 
                        this.PublicKey = IV;
                        string plainText = this.ClearText; 

                        Action action = () => {
                              StringBuilder str = new StringBuilder();
                              foreach (byte k in IV)
                                    str.Append(k + ",");
                              this.RowPublicKey = str.ToString();
                        };
                        action();

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
                        using (Aes aes = Aes.Create())
                        {



                              aes.Key = Key;
                              aes.IV = IV;


                              // Create an encryptor to perform the stream transform.
                              ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                              // Create the streams used for encryption.
                              using (MemoryStream msEncrypt = new MemoryStream())
                              {
                                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                                    {
                                          using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                                          {
                                                //Write all data to the stream.
                                                swEncrypt.Write(plainText,0,plainText.Length);
                                          }
                                          encrypted = msEncrypt.ToArray();
                                    }
                              }
                        }

                        // Return the encrypted bytes from the memory stream.
                        //string text = Encoding.ASCII.GetString(encrypted);
                        return  encrypted;
                  }
                  catch (Exception)
                  {
                        return null;
                  }
            }







            /// <summary>
            /// Initializes a new instance of the <see cref="T:QuickTools.Secure"/> class.
            /// </summary>
            public Secure()
            {
                  //not implemented 
            }




            /// <summary>
            /// This inizializtion gives you full controll of how to Encrypter the file 
            /// </summary>
            /// <param name="clearText">Clear text.</param>
            /// <param name="key">Key.</param>
            /// <param name="iv">Iv.</param>
            public Secure(object clearText , byte[] key , byte[] iv)
            {
                  this.ManualKey = key;
                  this.ManualIV = iv;
                  this.ClearText = clearText.ToString(); 
            }
           

      }
}