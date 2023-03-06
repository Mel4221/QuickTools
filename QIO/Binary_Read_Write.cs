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
using System.Collections.Generic;
using QuickTools.QCore;
using System.Diagnostics;

namespace QuickTools.QIO
{


      public partial class Binary
      {

          
            /// <summary>
            /// Reads the bytes.
            /// </summary>
            /// <param name="fileName">File name.</param>
            public void ReadBytes(string fileName)
            {
                    //throw exeption if there is not a file 
                  if (!File.Exists(fileName)) { throw new FileNotFoundException(); }
                        Stopwatch stopwatch = new Stopwatch();
                        stopwatch.Start();


                  long current, size;

                  FileStream stream = new FileStream(fileName , FileMode.Open , FileAccess.Read);
                  BinaryReader reader = new BinaryReader(stream);
                  this.BufferList = new List<byte[]>();

                  size = stream.Length;
                  current = 0;

                  while(current < size)
                        {
                        stream.Seek(current , SeekOrigin.Begin);
                        this.Buffer = new byte[this.Chunck];
                        reader.Read(this.Buffer , 0 , this.Buffer.Length);
                        Blocks++;
                        current += this.Chunck;
                        this.BufferList.Add(this.Buffer);
                        this.CallBackAction(current,size,Blocks);
                        this.BufferCallBack(this.Buffer); 
                               if(AllowDebugger == true)
                              {
                              Get.Green($"{this.DebuggerStatusMessage}{Get.Status(current , size)}");

                              }
                        }


                  /*

                                      BytesList.Add(this.Buffer);
                                      this.ByteCallback(x);
                                      this.Blocks++; 
                                      status = 0;
                                      //BytesList.AddLast(this.Buffer);// this was testing ListLink to see if it could be faster
                                      this.Buffer = new byte[Chunck];
                                }

                                      Print(current, fileSize);



                                this.Buffer[status] = x;
                                current++;
                                status++;
                                //stopwatch.Stop();
                                long t = stopwatch.ElapsedMilliseconds == 0 ? 1 : stopwatch.ElapsedMilliseconds;
                                this.ReadSpeed = this.CheckForAllwed((current * this.SpeedUnit) / t); 

                                this.CallBackAction(current,fileSize,stopwatch.ElapsedMilliseconds);


                      stopwatch.Stop(); 
              */

                  }



            private long CheckForAllwed(long value)
            {
                  if(this.AllowMegabytesAsDefault == true)
                  {
                        this.SpeedChars = "MBs";
                        return value / 1000;
                  }
                  else
                  {
                        return value; 
                  }
            }

            /// <summary>
            /// Print the specified current proses  remaining but only if <see cref="QuickTools.QIO.Binary.AllowDebugger"/>.
            /// </summary>
            /// <param name="current">Current.</param>
            /// <param name="fileSize">File size.</param>
            public void Print(long current, long fileSize)
            {
                  if(AllowDebugger)
                  {
                        string x = Get.Status(current, fileSize - 1);
                        if (s != x)
                        {
                              Get.Clear(); 
                              s = Get.Status(current, fileSize - 1);
                              Get.Green($"Speed: {this.ReadSpeed}{this.SpeedChars}  {s}");
                        }
                  }

            }



            /// <summary>
            /// This Process Writes the Bytes of the list but remember is very slow 
            /// </summary>
            /// <param name="fileName">File name.</param>
            public void WriteBytes(string fileName)
            {
                  using (FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                  {
                        Buffer = new byte[Chunck];
                        using (BinaryWriter writer = new BinaryWriter(stream))
                        {
                              for (int b = 0; b < BufferList.Count; b++)
                              {
                                    writer.Write(BufferList[b], 0, BufferList[b].Length);
                                    Print(b, BufferList.Count);
                                    //writer.Write(BytesList.First.Value, 0, BytesList.First.Value.Length);
                                    //BytesList.RemoveFirst(); 
                              }
                        }
                  }
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="T:QuickTools.QIO.Binary"/> class.
            /// </summary>
            /// <param name="fileName">File name.</param>
            public Binary(string fileName)
            {
                  this.FileName = fileName; 
            }
      }
}
