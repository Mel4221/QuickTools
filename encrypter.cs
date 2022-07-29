using System;
using System.Text;
using System.Collections.Generic;
namespace QuickTools
{

      ///<summary>
      /// This class Allwo you to Encrypt Files 
      /// And it has 1 method which takes 2 arguments
      /// and write to the file the encrypted text 
      /// </summary>
      public class Encrypter
      {

            /// <summary>
            /// Encrypts the file , and the first argument is the file
            /// the second argument is the password to encrypt the file 
            /// </summary>
            /// <param name="fileToEncrypt">File to encrypt.</param>
            /// <param name="FilePassword">File password.</param>
            public static void EncryptFile(string fileToEncrypt, object FilePassword)
            {
                  /*
                        basically this works on the current way 
                        it gets 2 parameters , the file that will 
                        be enprited and then the password 
                        and if the password fail the process will not be completed                        

                  */
                  string filePassword = FilePassword.ToString(); 
                 Console.Title = "Encrypting File Please Wait...";
                  Get.WaitTime(); 
                  try
                  {
                        byte[] dataBytes = Encoding.ASCII.GetBytes(Reader.Read(fileToEncrypt));
                        double hash = filePassword.GetHashCode();
                        List<double> dataEncrypted = new List<double>();
                        for (int value = 0; value < dataBytes.Length; value++)
                        {
                              dataEncrypted.Add(dataBytes[value] * hash);

                          //    Console.Title = value.ToString(); 
                        }

                        StringBuilder finalData = new StringBuilder();
                        foreach (double val in dataEncrypted)
                        {
                              //RowData.Add(val);
                              finalData.Append(val + ",");
                        }
                        Writer.Write(fileToEncrypt, LowEncrypt.EncryptFile(finalData.ToString()));
                        //done 

                        //Console.Title = "File Encrypted";
                        Get.WaitTime(); 
                   }
                  catch
                  {
                        Get.Wrong("Something went wrong while Encrypting the file "); 
                        throw new InvalidOperationException("The File could not be Encrypted");

                  }
            }
      }
}