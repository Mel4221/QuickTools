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
using System.Text;
using QuickTools.QCore;
using QuickTools.QData;

namespace QuickTools.QIO
{
     class QBox
    {
        public string QBoxName { get; set; } = "Pack.qbox";
        public string FileName { get; set; } = "";
        public string[] Files { get; set; } = { };
        public bool AllowDebugger { get; set; } = false; 
        private MiniDB FilesDB { get; set; } 

        private void Echo(string info)
        {
            if(this.AllowDebugger)
            {
                Get.Yellow(info); 
            }
        }

        private void BuildFilesDB()
        {
            if (!this.QBoxName.Contains(".")) this.QBoxName += ".qbox"; 
            this.FilesDB = new MiniDB(this.QBoxName + ".db");
            this.FilesDB.AllowDebugger = this.AllowDebugger;

            this.FilesDB.Drop();
            this.FilesDB.Create();
            string hash, subFile, size;
            long index, length;
            index = 0;
            Echo("Building Metadata...");
            if (this.AllowDebugger)Print.List(this.Files);

            foreach(string file in this.Files)
            {
                hash = new Get().HashCodeFromFile(file,this.AllowDebugger).ToString();
                subFile = file.Substring(file.LastIndexOf(Get.Slash()[0]));
                size = Get.FileSize(file);
                length = Get.FileLength(file);

                this.FilesDB.AddKeyOnHot("FILE",subFile, hash);
                this.FilesDB.AddKeyOnHot("HASH",hash,subFile);
                this.FilesDB.AddKeyOnHot("SIZE", size,hash);
                this.FilesDB.AddKeyOnHot("LENGTH",length, hash);
                this.FilesDB.AddKeyOnHot("INDEX", index, hash);
                this.FilesDB.AddKeyOnHot("DATE",DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"), hash);
                index += length + 1;

                //0 1 2 3 4 5 6 7 8 9
                //                   
            }
            this.FilesDB.SaveChanges();
            if (this.AllowDebugger)
            {
                Get.Ok(); 
            }
        }
        public void Pack()
        {
            if(this.Files.Length == 0)
            {
                if(File.Exists(FileName))
                {
                    this.Files = new string[] { this.FileName };
                }
            }
            this.BuildFilesDB(); 

            for(int file = 0; file < this.Files.Length; file++)
            {

            }

        }

        /*
            1 2 3 4
                    1 2 3 5          
        */

        public QBox()
        {

        }
        public QBox(string fileName)
        {
            this.FileName = fileName;
        }
        public QBox(ref string[] files)
        {
            this.Files = files;
        }
        public QBox(string qboxName ,ref string[] files)
        {
            this.QBoxName = qboxName;
            this.Files = files;
        }
    }
}
/*
namespace QuickTools.QIO
{
      /// <summary>
      /// Create a type of box which will be containing files similar to winrar or zip
      /// </summary>
      class QBox
      {
        /*
            /// <summary>
            /// The operator open.
            /// </summary>
            public byte OperatorOpen = 58; //:

            /// <summary>
            /// The operator close.
            /// </summary>
            public byte OperatorClose = 59;//;

            /// <summary>
            /// The allow debugger.
            /// </summary>
            public bool AllowDebugger = false;


            /// <summary>
            /// The length of the file.
            /// </summary>
            public long FileLength;

            /// <summary>
            /// Block.
            /// </summary>
            public class Block : QBox
            {
                  /// <summary>
                  /// The key.
                  /// </summary>
                  public byte[] Key;

                  /// <summary>
                  /// The value.
                  /// </summary>
                  public byte[] Value;

                  /// <summary>
                  /// The relation.
                  /// </summary>
                  public byte[] Relation;

                  /// <summary>
                  /// The identifier.
                  /// </summary>
                  public byte[] ID;

                  /// <summary>
                  /// Tos the db.
                  /// </summary>
                  /// <returns>The db.</returns>
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


            /// <summary>
            /// The blocks.
            /// </summary>
            public List<Block> Blocks;



            /// <summary>
            /// Gets the text.
            /// </summary>
            /// <returns>The text.</returns>
            /// <param name="bytes">Bytes.</param>
            public string GetText(byte[] bytes)
            {
                  return Encoding.ASCII.GetString(bytes);
            }

            /// <summary>
            /// Prints the text.
            /// </summary>
            /// <returns>The text.</returns>
            /// <param name="bytes">Bytes.</param>
            private string PrintText(byte[] bytes)
            {

                  string content = Encoding.ASCII.GetString(bytes);
                  Get.Green(content);
                  return content;
            }

            

            /// <summary>
            /// Reads the blocks.
            /// </summary>
            /// <param name="fileName">File name.</param>
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


                        if(AllowDebugger == true)
                              {
                              Get.Green(Get.Status(_byte , FileLength-1));
                              }
                        }



            }


      }
}
*/
