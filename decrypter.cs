using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.Security.Cryptography;
    /*
       This class will be in charge of generating a 
       random key to protect files and it will 
       store the key value ina a default encryping System
       to make sure that is protected aswell so , in simple words
       1. the key is randomly generated
       2. The encripting process start 
       3. Save a document with a encripting key
       4. it will save internally the value 
       5. lastly i would like to save the key aswell in  a secret part from the app

     */

namespace QuickTools
{
  public class Decrypter
  {
            public static void DecryptFile(string file, byte[] key)
            {

                  using (FileStream fileStream = new FileStream(file,FileMode.Open))
                  {
                        using (Aes aes = Aes.Create())
                        {
                              aes.Key = key;
                              byte[] iv = aes.IV;
                              fileStream.Read(iv,0,iv.Length);
                              /*Everything looks goood so far */
                              // here we have part of the key already 
                              //set 

                              using (CryptoStream cryptoStream = new CryptoStream(
                              fileStream,
                              aes.CreateDecryptor(key, iv),
                              CryptoStreamMode.Read))
                              {

                              }

                              /*
                                    using (StreamReader streamReader = new StreamReader(cryptoStream))
                                    {
                                          while (streamReader.Read() > 0 )
                                          {
                                            //    Get.Box(streamReader.ReadLine()); 
                                          }
                                    } 
                                   
                               
                              }

                              */
                        }
                  }

            }
  }

}
