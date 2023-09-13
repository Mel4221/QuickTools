//
// ${Melquiceded Balbi Villanueva}
//
// Author:
//       ${Melquiceded} <${melquiceded.balbi@gmail.com}>
//
// Copyright (c) ${2089} MIT
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
using System.IO; 
using System.Security.Cryptography;

namespace QuickTools.QSecurity
{
      public partial class Secure
      {
         

            /// <summary>
            /// The default key.
            /// </summary>
            public byte[] DefaultKey { get; set; }

            /// <summary>
            /// The default iv.
            /// </summary>
            public byte[] DefaultIV { get; set; }


            /// <summary>
            /// Decrypts a binary.
            /// </summary>
            /// <returns>The binary.</returns>
            /// <param name="cipherBytes">Cipher bytes.</param>
            public  byte[] DecryptBinary(byte[] cipherBytes)
            {
                  byte[] bytes;
                  using (var aes = Aes.Create())
                  {

                        using (MemoryStream cipherStream = new MemoryStream(cipherBytes))
                        {
                              using (CryptoStream cryptoStream = new CryptoStream(cipherStream, aes.CreateDecryptor(DefaultKey,DefaultIV), CryptoStreamMode.Read))
                              {
                                    using (var output = new MemoryStream())
                                    {
                                          // same story here, avoid direct reads, use CopyTo, it will copy all data, decrypted, to memory stream
                                          cryptoStream.CopyTo(output);

                                          // again, just ToArray to avoid manage buffer directly
                                          bytes = output.ToArray();
                                    }
                              }
                        }

                        // bool shouldBeTrue = plainBytes.SequenceEqual(wrongPlainBytes);

                        return bytes;
                  }
            }

            /// <summary>
            /// Encrypts a binary file 
            /// </summary>
            /// <returns>The binary.</returns>
            /// <param name="plainBytes">Plain bytes.</param>
            public  byte[] EncryptBinary(byte[] plainBytes)
            {
                  using (var aes = Aes.Create())
                  {
                        byte[] cipherBytes;

                        using (MemoryStream cipherStream = new MemoryStream())
                        {
                              // use leaveOpen parameter here, that way it will NOT dispose cipherStream when closing cryptoStream
                              using (CryptoStream cryptoStream = new CryptoStream(cipherStream, aes.CreateEncryptor(DefaultKey,DefaultIV), CryptoStreamMode.Write))
                              {
                                    // just write
                                    cryptoStream.Write(plainBytes, 0, plainBytes.Length);
                              }
                              // now, cryptoStream is disposed, so we can be sure all data is propertly written to the cipherStream
                              // no need to flush or anything

                              // do not manage buffer yourself, use ToArray
                              cipherBytes = cipherStream.ToArray();
                        }

                        return cipherBytes;
                  }
            }
      }
}
