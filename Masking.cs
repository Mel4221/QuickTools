//
// Masking.cs
//
// Author:
//       melquiceded balbi villanueva <mbv@projects.com>
//
// Copyright (c) 2022 MIT
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using System.Text;
namespace QuickTools
{
      /// <summary>
      /// LowDecryptor is a class that sligly confuse the bytes of a file
      /// and returns the string from the mixed file , is not super secure
      /// becaus it does not use passwords in it but for small files works perfect
      /// </summary>
      public class Mask
      {
            /// <summary>
            /// Returns the decrypted text in a row string 
            /// </summary>
            public static string RowData = null;

            /// <summary>
            /// Mask the file into a form that is harder to read , this is not Encryption
            /// </summary>
            /// <returns>The text.</returns>
            /// <param name="fileData">File data.</param>
            /// <param name="complexyty">Complexyty.</param>
            public static string Text(string fileData,int complexyty)
            {

                  //variables needed 

                  //int password = passwordInput.GetHashCode();
                  //  int salt = LowEncrypter.DataHash * password;
                  int length = fileData.Length;
                  int foward = length;
                  byte[] dataBytes = Encoding.ASCII.GetBytes(fileData);
                  // thiw will be the first time it will be decompress 
                  byte[] firstDecompress = new byte[length];

                  /*
                  /// So on simple words what this loop does is to 
                  /// take  the length of the data saved on that file and it just basically goes through 
                  /// each byte processing a couple of mathematical equations 
                  /// to change the order of the bytes 
                  /// on this case it just put each bytes backwards order and lastly elevate it to the power of 16
                  /// and finally at the end it is converted to plane text 
                  */
                  for (int value = 0; value < length; value++)
                  {

                        firstDecompress[value] = dataBytes[foward - 1];// backward order
                        firstDecompress[value] = Convert.ToByte(firstDecompress[value] ^ complexyty);// matematical operation 


                        foward--;
                  }
                  string finalData = Encoding.ASCII.GetString(firstDecompress);
                  RowData = finalData;
                  // Get.Wait(Data); 
                  return finalData;

            }
      }
}
