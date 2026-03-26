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
using System.Threading;

namespace QuickTools.QIO
      {
      public partial class Binary
            {




                  /// <summary>
                  /// Bind the specified bufferA and bufferB.
                  /// </summary>
                  /// <returns>The bind.</returns>
                  /// <param name="bufferA">Buffer a.</param>
                  /// <param name="bufferB">Buffer b.</param>
                  public static byte[] Bind(byte[] bufferA , byte[] bufferB)
                  {

                        byte[] binded;
                        binded = new byte[bufferA.Length + bufferB.Length];
                       
                        Thread A,B;
                        A = new Thread(() =>
                        {
                            for (int by = 0; by < bufferA.Length; by++)
                            {
                                binded[by] = bufferA[by];
                            }
                        });
                        B = new Thread(() => {
                            int index = bufferA.Length;
                            for(int by = 0; by < bufferB.Length; by++)
                            {
                                binded[index] = bufferB[by];
                                index++;
                            }
                        });
                    A.Start();
                    B.Start();
                    while (A.IsAlive && B.IsAlive)
                    {
                        
                    }
                  return binded; 
                  }
            }
      }
