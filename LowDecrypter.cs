/* 
 * 
 * The low encrypter and decrypter are still not to the level that i would say
 * hey this  would be a chanlenge for sombody to hack in because it is just switcing order
 * and Elevating to the power of a number which is not enoguth for security porpuses.
*/


using System;
using System.Text;
using System.Collections.Generic;

namespace QuickTools
{
      public class LowD
      {
            public static string Data = null;
            public static string DecryptFile(string fileData)
            {

                  //variables needed 
               
                  //int password = passwordInput.GetHashCode();
                  //  int salt = LowEncrypter.DataHash * password;
                  int length = fileData.Length; 
                  int foward = length;
                  byte[] dataBytes = Encoding.ASCII.GetBytes(fileData); 
                  // thiw will be the first time it will be decompress 
                  byte[] firstDecompress = new byte[length];

                  ///<summary>
                  /// So on simple words what this loop does is to 
                  /// take  the length of the data saved on that file and it just basically goes through 
                  /// each byte processing a couple of mathematical equations 
                  /// to change the order of the bytes 
                  /// on this case it just put each bytes backwards order and lastly elevate it to the power of 16
                  /// and finally at the end it is converted to plane text 
                  /// </summary>
                  for (int value = 0; value < length; value++)
                  {
                          
                        firstDecompress[value] = dataBytes[foward - 1];// backward order
                        firstDecompress[value] = Convert.ToByte(firstDecompress[value] ^16);// matematical operation 


                        foward--;
                  }
                  Data = Encoding.ASCII.GetString(firstDecompress);


                  return Encoding.ASCII.GetString(firstDecompress);

            }
      }

}