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
using System.Text;
using QuickTools.QCore;
using QuickTools.QData;

namespace QuickTools.QIO
{
      public class QBox
      {
            public byte OperatorOpen = 58; //:
            public byte OperatorClose = 59;//;
            public long FileLength;
            public class Block : QBox
            {
                  public byte[] Key;
                  public byte[] Value;
                  public byte[] Relation;
                  public byte[] ID;
                  public DB ToDB()
                  {

                        return new DB()
                        {
                              Key = GetText(this.Key),
                              Value = GetText(this.Value),
                              Relation = GetText(this.Relation),
                              Id = Convert.ToInt32(GetText(this.ID))
                        };
                  }
            }
            public List<Block> Blocks;


            public string GetText(byte[] bytes)
            {
                  return Encoding.ASCII.GetString(bytes);
            }

            private string PrintText(byte[] bytes)
            {

                  string content = Encoding.ASCII.GetString(bytes);
                  Get.Green(content);
                  return content;
            }

            public void ReadBlocks(string fileName)
            {
                  byte[] array = Binary.Reader(fileName);
                  List<byte> current = new List<byte>();
                  List<byte[]> container = new List<byte[]>();
                  Blocks = new List<Block>();

                  byte open, close, counter;
                  bool isNext;

                  FileLength = array.Length;
                  open = this.OperatorOpen;
                  close = this.OperatorClose;
                  counter = 0;
                  isNext = false;

                  for (int _byte = 0; _byte < FileLength; _byte++)
                  {
                        if (array[_byte] == open && isNext == false)
                        {

                        }
                        if (array[_byte] != open && array[_byte] != close)
                        {
                              current.Add(array[_byte]);
                        }
                        if (array[_byte] == close)
                        {
                              byte[] curr = IConvert.ToType<byte>.ToArray(current);
                              container.Add(curr);
                              current.Clear();
                              counter++;
                              // Get.Wait();
                        }

                        if (counter == 4)
                        {
                              Blocks.Add(new Block()
                              {
                                    Key = container[0],
                                    Value = container[1],
                                    Relation = container[2],
                                    ID = container[3]
                              });
                        }



                  }



            }


      }
}
