using System;
using System.Text; 
using System.IO;
using System.Security.Cryptography;
using System.Diagnostics;

using QuickTools.QCore;


namespace QuickTools.QSecurity
{
      /// <summary>
      /// The secure class is a class that uses the Aes tecnology to encrypt data by using
      /// a public key and a 
      /// </summary>
      public partial class Secure:IDisposable
        {
        

            /// <summary>
            /// This allow the encriptor to either try to save the scure key or not  and is set to FALSE <see langword="false"/>  by default for security reasons
            /// </summary>
            public bool AllowToSaveKey = false; 

            /// <summary>
            /// Gets or sets a value indicating whether this <see cref="T:QuickTools.Secure"/> use saved key.
            /// </summary>
            /// <value><c>true</c> if use saved key; otherwise, <c>false</c>.</value>
            public bool UseSavedKey { get; set; }



            /// <summary>
            /// This will contain the public key used to encrypt the file 
            /// be carefull it will stay on memory ONLY 
            /// </summary>
            public byte[] PublicKey = null;
            /// <summary>
            /// This temporaly holds the public Key in an string format 
            /// </summary>
            public string RowPublicKey = null; 


            /// <summary>
            /// Creates the password Based on the given input to be able to be addes as a key for the Encription or decription
            /// </summary>
            /// <returns>The password.</returns>
            /// <param name="password">Password.</param>
            public byte[] CreatePassword(object password)
            {
                  byte[] passByes  = null;

                  byte[] array = Encoding.ASCII.GetBytes(password.ToString());
                  if (array.Length < 16)
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
                        byte[] bigerArray = Encoding.ASCII.GetBytes(password.ToString());

                        for (int value=0; value < passByes.Length; value++)
                        {
                              passByes[value] = bigerArray[value]; 
                        }



                        return passByes;
                  }

                 
            }

            /// <summary>
            /// Encrypt the specified bytes, with password and IV.
            /// </summary>
            /// <returns>The encrypt.</returns>
            /// <param name="bytes">Bytes.</param>
            /// <param name="password">Password.</param>
            /// <param name="IV">Iv.</param>
            public byte[] Encrypt(byte[] bytes , byte[] password , byte[] IV)
            {
                  if(bytes.Length == 0 || password.Length == 0 || IV.Length == 0)
                  {
                        throw new ArgumentException("Pleas Check any of your arguments given due to the length is incorrect");
                  }

                  byte[] encrypted;
                  char[] chars = IConvert.ToCharArray(bytes); 

                  // Create an Aes object
                  // with the specified key and IV.
                  using (Aes aes = Aes.Create())
                  {



                        aes.Key = password;
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

                                          swEncrypt.Write(chars,0,chars.Length);
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
                  byte[] IV = UseSavedKey == false ? IRandom.RandomByteKey(AllowToSaveKey) : Get.KeyBytesSaved(); 
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





            /// <summary>
            /// Encrypts the text.
            /// </summary>
            /// <returns>The text.</returns>
            /// <param name="text">Text.</param>
            /// <param name="password">Password.</param>
            public string EncryptText(string text , object password)
            {
                  this.AllowToSaveKey = true; 
                  byte[] data = this.Encrypt(text, password);

                 return IConvert.BytesToString(data); 
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
                 DefaultKey = new byte[16];
                  DefaultIV = new byte[16];
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

            #region IDisposable Support
            private bool disposedValue = false; // To detect redundant calls

            /// <summary>
            /// Dispose the specified disposing.
            /// </summary>
            /// <param name="disposing">If set to <c>true</c> disposing.</param>
            protected virtual void Dispose(bool disposing)
            {
                  if (!disposedValue)
                  {
                        if (disposing)
                        {
                              // TODO: dispose managed state (managed objects).
                        }

                        // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                        // TODO: set large fields to null.

                        disposedValue = true;
                  }
            }

        


            /// <summary>
            /// Releases all resource used by the <see cref="T:QuickTools.Secure"/> object.
            /// </summary>
            /// 
            /// 
            public void Dispose()
            {
                  // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
                  Dispose(true);
                  // TODO: uncomment the following line if the finalizer is overridden above.
                  // GC.SuppressFinalize(this);
            }
            #endregion


      }
}