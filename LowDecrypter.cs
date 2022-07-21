using System;
using System.Text;
using System.Collections.Generic;

namespace QuickTools 
{
  public class LowDecrypter
    {
        public static string Data = null;
        public static string DecryptFile(List<int> data)
        {

                  /*
                        this class and the LowEncrypter has something in particular
                        they both do not require password tox` be decrypted byt they use
                        the algorithom to be able to decrypt the data sucessfully
                        and even thought for me is not effective as much
                         i think that it can definily have a very good chance if is 
                         optimized a bit plus the counderies and connections between them both 
                         is not that healthy so i will be correcting that on the next update , lastly 
                         this is just one section from the Encryptor i think that this can definetly be part of the 
                         phase of the encryption process 
                  */
 
            //variables needed 

            //int password = passwordInput.GetHashCode();
          //  int salt = LowEncrypter.DataHash * password;
            int foward = LowEncrypter.DataLength;
            // thiw will be the first time it will be decompress 
            byte[] firstDecompress = new byte[LowEncrypter.DataLength];
                  //the LowEncrypter should not be called to decrypt the file it just makes no sence 
                  // i don't know what was i thinking , but it can not be on that way 

            for (int value = 0; value < LowEncrypter.DataLength; value++)// this is not correct this is taking data from the wrong place
            {
                firstDecompress[value] = LowEncrypter.DataBytes[foward-1];
                firstDecompress[value] = Convert.ToByte(firstDecompress[value]^8);
                 

                foward--;
            }
            Data = Encoding.ASCII.GetString(firstDecompress);


            return Encoding.ASCII.GetString(firstDecompress);

        }
    }

}