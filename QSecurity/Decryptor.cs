
using System;
using System.Text; 
using System.IO;
using QuickTools.QIO; 
using QuickTools.QCore;
using System.Security.Cryptography;


namespace QuickTools.QSecurity
{
      /// <summary>
      /// The Secure class works pretty well so far on text DO NOT USE IT ON BINARY DATA IT COULD BREAK 
      /// THE FILES    
      /// </summary>
    public partial class Secure 
    {

            /// <summary>
            /// set the printing time speed
            /// </summary>
            public int PrintingTime { get; set; } = 1000; 
            /// <summary>
            /// Set an out file for the EncryptFile method
            /// </summary>
            public string OutFile { get; set; } = null;
            
            /// <summary>
            /// Allows to print information about the setatus of the 
            /// methods in use
            /// </summary>
            public bool AllowDebugger { get; set; } = false;
            /// <summary>
            /// display the current status of the function
            /// </summary>
            public string CurrentStatus { get; set; } = null; 
            
            /// <summary>
            /// Encrypt a file with the given password and iv key
            /// </summary>
            /// <param name="file"></param>
            /// <param name="password"></param>
            /// <param name="iv"></param>
            /// <exception cref="FileNotFoundException"></exception>
            /// <exception cref="ArgumentNullException"></exception>
            public void EncryptFile(string file,string password, byte[] iv)
            {
                /*
                    Creatting the checks to make sure that we are good to go
                 */
                if (!File.Exists(file)){
                throw new FileNotFoundException($"The Given file '{file}' was not found");
                }if(password == "" || password == null) { 
                throw new ArgumentNullException("No password was provided");
                }if(iv.Length == 0){
                throw new ArgumentNullException("The IV key was not provided");
                }
                Check check = new Check(); 
                byte[] bytes, pass, binary;
                string data, message;
                binary = new byte[0];
                /*
                    displaying the size of the file that we will be working with 
                 */
                check.Start();
                bytes = Binary.Reader(file);
                if(bytes.Length == 0)
                {
                    throw new Exception("The File is enpty");
                    return; 
                }

                message = $"File Size: {Get.FileSize(bytes)} & Converting to String Format...";
                if (this.AllowDebugger)
                {
                    Get.Yellow(message);
                    Get.WaitTime(PrintingTime);
                }
                /*
                    Converting the bytes to a text format to encrypt the program
                    as a text format
                 */
                data = IConvert.BytesToString(bytes, this.AllowDebugger);
                if(data == null)
                {
                    message = $"The Conversion Failed very likely due to running out of RAM";
                if (this.AllowDebugger)
                    Get.Red(message);
                    return;
                }
                message = $"Building Password...";
                if (this.AllowDebugger)
                {
                    Get.Yellow(message);
                    Get.WaitTime(PrintingTime);
                }
            /*
                if allow the debugger print a loop in the mind time is waitting
                other wise just wait until is encrypted 
             */

                file = this.OutFile==null ? file : this.OutFile;

                if (this.AllowDebugger)
                {
                    Get.Wait($"Please wait encrypting {file}...",() => { 
                        pass = this.CreatePassword(password);
                        bytes = Get.Bytes(data);
                        binary = this.Encrypt(bytes, pass, iv);
                    });
                }
                if (!this.AllowDebugger)
                {
                    pass = this.CreatePassword(password);
                    bytes = Get.Bytes(data);
                    binary = this.Encrypt(bytes, pass, iv);
                }


                message = $"Encrypted File size: {Get.FileSize(binary)} & Writting to: {file}";
                if (this.AllowDebugger)
                {
                    Get.Yellow(message);
                    Get.WaitTime(PrintingTime);
                }

                Binary.Writer(file, binary);
                message = $"{file} Sucessfully Encrypted!!! \nEncrypting Time: {check.Stop()}";
                if (this.AllowDebugger)
                {
                    Get.Yellow(message);
                    Get.Ok();
                    Get.WaitTime(PrintingTime);
                }
        }

        /// <summary>
        /// Decrypt the file with the given information 
        /// </summary>
        /// <param name="file"></param>
        /// <param name="password"></param>
        /// <param name="iv"></param>
        /// <exception cref="FileNotFoundException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception">Invalid Password Exseption</exception>
        public void DecryptFile(string file, string password, byte[] iv)
        {
            if (!File.Exists(file))
            {
                throw new FileNotFoundException($"The Given file '{file}' was not found");
            }
            if (password == "" || password == null)
            {
                throw new ArgumentNullException("No password was provided");
            }
            if (iv.Length == 0)
            {
                throw new ArgumentNullException("The IV key was not provided");
            }
            byte[] bytes, pass;
            string data, message;

            bytes = Binary.Reader(file);
            message = $"File Size: {Get.FileSize(bytes)} & Creatting password...";
            if (this.AllowDebugger)
            {
                Get.Yellow(message);
                Get.WaitTime(PrintingTime);
            }
            pass = this.CreatePassword(password);
            
            data = this.Decrypt(bytes, pass, iv);
            message = $"Dcrypting...";
            if (this.AllowDebugger)
            {
                Get.Yellow(message);
                Get.WaitTime(PrintingTime);
            }
            if (data == null || data == "")
            {
                message = $"Decrypting Failed due to wrong format or wrong password";
                if (this.AllowDebugger)
                {
                    Get.Red(message);
                    Get.WaitTime(PrintingTime);
                }
                throw new Exception($"Invalid Password");
            }
            message = $"Converting String Format to Binary...";
            if (this.AllowDebugger)
            {
                Get.Yellow(message);
                Get.WaitTime(PrintingTime);
            }
            bytes = IConvert.StringToBytesArray(data);
            file = this.OutFile==null ? file : this.OutFile;
            message = $"Writting bytes to {file}";
            if (this.AllowDebugger)
            {
                Get.Yellow(message);
                Get.WaitTime(PrintingTime);
            }
            Binary.Writer(file, bytes);
            message = $"{file} Sucessfully Decrypted!!!";
            if (this.AllowDebugger)
            {
                Get.Yellow(message);
                Get.Ok();
                Get.WaitTime(PrintingTime);
            }
        }

        /// <summary>
        /// Decrypt the specified cipherText text  with a password.
        /// and this is the AUTOMATIC way of doing it 
        /// </summary>
        /// <returns>The decrypt.</returns>
        /// <param name="cipherText">Cipher text.</param>
        /// <param name="password">Password.</param>
        /// <param name="iv">Iv.</param>
        public string Decrypt(byte[] cipherText, object password,byte[] iv )
            {

                  try {
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
                  }catch(Exception)
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

            /// <summary>
            /// Decrypts the text.
            /// </summary>
            /// <returns>The text.</returns>
            /// <param name="text">Text.</param>
            /// <param name="password">Password.</param>
            public string DecryptText(string text, object password) => this.Decrypt(IConvert.StringToBytesArray(text), this.CreatePassword(password), Get.KeyBytesSaved());





            /// <summary>
            /// Decrypts the bytes.
            /// </summary>
            /// <returns>The bytes.</returns>
            /// <param name="bytes">Bytes.</param>
            /// <param name="password">Password.</param>
            /// <param name="iv">Iv.</param>
            public byte[] DecryptBytes(byte[] bytes , byte[] password , byte[] iv)
            {

                  byte[] data;
                   
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
                                          // data = srDecrypt.ReadToEnd();
                                                data = Encoding.ASCII.GetBytes(srDecrypt.ReadToEnd()); 

                                          }
                                    }
                              }
                        }

                        return data;

            }



      }
}