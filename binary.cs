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
namespace QuickTools

{

      class Binary

      {

            public static bool CopyBinaryFile(string srcfilename, string destfilename)

            {



                  if (File.Exists(srcfilename) == false)

                  {

                        Console.WriteLine("Could not find the Source file");

                        return false;

                  }



                  Stream s1 = File.Open(srcfilename, FileMode.Open);

                  Stream s2 = File.Open(destfilename, FileMode.Create);



                  BinaryReader f1 = new BinaryReader(s1);

                  BinaryWriter f2 = new BinaryWriter(s2);



                  while (true)

                  {

                        byte[] buf = new byte[10240];

                        int sz = f1.Read(buf, 0, 10240);

                        if (sz <= 0)

                              break;

                        f2.Write(buf, 0, sz);

                        if (sz < 10240)

                              break; // eof reached

                  }

                  f1.Close();

                  f2.Close();

                  return true;

            }



            public static bool CopyTextFile(string srcfilename, string destfilename)

            {



                  if (File.Exists(srcfilename) == false)

                  {

                        Console.WriteLine("Could not find the Source file");

                        return false;

                  }



                  StreamReader f1 = new StreamReader(srcfilename);

                  StreamWriter f2 = new StreamWriter(destfilename);



                  while (true)

                  {

                        char[] buf = new char[1024];

                        int sz = f1.Read(buf, 0, 1024);

                        if (sz <= 0)

                              break;

                        f2.Write(buf, 0, sz);

                        if (sz < 1024)

                              break; // eof reached

                  }

                  f1.Close();

                  f2.Close();

                  return true;

            }



      }
}