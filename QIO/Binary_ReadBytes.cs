
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
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using QuickTools.QCore;

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
                  if(!File.Exists(fileName)) { throw new FileNotFoundException(); }
                  Stopwatch stopwatch = new Stopwatch();
                  stopwatch.Start();


                  string status; 
                  long current, size;


                  FileStream stream = new FileStream(fileName , FileMode.Open , FileAccess.Read);
                  BinaryReader reader = new BinaryReader(stream);
                  this.BufferList = new List<byte[]>();
                  this.FileHash = 0; // other wise it will keep the value 

                  size = stream.Length;
                  current = 0;
                  status = null; 

                  while(current < size)
                        {
                        stream.Seek(current , SeekOrigin.Begin);
                        this.Buffer = new byte[this.Chunck];
                        reader.Read(this.Buffer , 0 , this.Buffer.Length);
                        Blocks++;
                        current += this.Chunck;
                        if(this.AllowListAllocation == true)
                              {
                              this.BufferList.Add(this.Buffer);
                              }
                        this.CallBackAction(current , size , Blocks);
                        this.Buffer = this.BufferCallBack(this.Buffer);

                        status = Get.Status(current , size - 1); 

                        this.FileHash += long.Parse(Get.HashCode(this.Buffer).ToString());
                        this.StatusText = status; 
                     
                        if(AllowDebugger == true)
                              {
                               Get.Green($"{this.DebuggerStatusMessage} {status}");

                              }
                        }


                  }



            /// <summary>
            /// This module allows you to make sure that files are equal no matter the size from them
            /// </summary>
            /// <returns><c>true</c>, if corrupted was ised, <c>false</c> otherwise.</returns>
            /// <param name="file">File.</param>
            /// <param name="secondFile">Second file.</param>
             public bool IsCorrupted(string file,string secondFile)
                  {
                  bool currupted = true;
                  string message,feedback;
                  long hashA,hashB;

                  hashA = 0;
                  hashB = 0;
                  message = null;
                  feedback = null; 
                  Binary binaryA = new Binary();
                  Binary binaryB = new Binary();

                  Thread A = new Thread(()=> {
                       

                        binaryA.AllowListAllocation = false; // other wise  will run out of memory on big files
                        binaryA.ReadBytes(file);
                        hashA = binaryA.FileHash; 
                  });

                  Thread B = new Thread(() => {

                        binaryB.AllowListAllocation = false; // other wise  will run out of memory on big files
                        binaryB.ReadBytes(secondFile);
                        hashB = binaryB.FileHash;



                  });

                  A.Start();
                  B.Start();

                   while(true)
                        {
                        if(AllowDebugger == true)
                              {
                                    feedback = $"Status Thread A: {binaryA.StatusText} Thread B: {binaryB.StatusText}"; 
                                    if(message != feedback)
                                    {
                                          message = feedback;
                                          Get.Yellow(message);
                                    }

                              }
                              if(A.IsAlive == false  &&  B.IsAlive == false)
                              {
                                    if(hashA.ToString() == hashB.ToString())
                                    {
                                                if(AllowDebugger == true)
                                          {
                                          Get.Green($"Files Hash  A: {hashA} B: {hashB}  Are The File Equal: {hashA == hashB}");
                                          }
                                    currupted = false;
                                    return currupted; 
                                    }
                              break;
                              }
                        }
                        if(AllowDebugger == true)
                        {
                        Get.Red("The File Is Currupted");
                        Get.Red($"Files Hash  A: {hashA} B: {hashB}  Are The File Equal: {hashA == hashB}");
                        }

                  return currupted; 
                  }

            }
      }