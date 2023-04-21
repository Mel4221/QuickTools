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

namespace QuickTools.QIO
{
      /// <summary>
      /// This is a class developed to assit to be able to retroactively read files and directories 
      /// </summary>
      public class FilesMaper
      {

            /// <summary>
            /// Contains the list of directoys founded 
            /// </summary>
            public List<string> DirectoryList { get; set; }

            /// <summary>
            /// Contains the list of files founded 
            /// </summary>
            public List<string> FileList { get; set; }



                   
            /// <summary>
            /// Move the specified from origen to the given destination.
            /// </summary>
            /// <param name="origen">Origen.</param>
            /// <param name="destination">Destination.</param>
                  public void Move(string origen , string destination)
                  {
                        if(destination.LastIndexOf("/") == -1)
                              {
                                    
                              }
                         Directory.Move(origen , $"{destination}{Get.FolderFromPath(origen)}");
                  }

            /// <summary>
            /// Move the specified from origen to the given destination.
            /// </summary>
            /// <param name="origen">Origen.</param>
            /// <param name="destination">Destination.</param>
            public void MoveHere(string origen , string destination)
                  {
                        Directory.Move(origen , $"{destination}{Get.FolderFromPath(origen)}");
                  }


            private void GetDirs(string[] dirs)
            {
                  if (dirs.Length > 0)
                  {
                        for (int x = 0; x < dirs.Length; x++)
                        {
                              Get.Green(dirs[x]);
                              this.DirectoryList.Add(dirs[x]);
                              this.GetFiles(dirs[x]);
                              this.GetDirs(Directory.GetDirectories(dirs[x]));
                        }
                  }
             

            }



            private void GetFiles(string path)
            {
                  string[] files = Directory.GetFiles(path);
                  for (int file = 0; file < files.Length; file++)
                  {
                        this.FileList.Add(files[file]);
                        Get.Yellow(files[file]);
                  }
            }



            /// <summary>
            /// Parse the list of directories given to a list of files and directories 
            /// </summary>
            /// <param name="dirs">Dirs.</param>
            public void Parse(string[] dirs)
            {

                  for (int x = 0; x < dirs.Length; x++)
                  {
                        //Get.Green(dirs[x]);
                        this.DirectoryList.Add(dirs[x]);
                        Get.Green(dirs[x]);
                        this.GetFiles(dirs[x]);
                        this.GetDirs(Directory.GetDirectories(dirs[x]));

                  }

                  //Get.Wait($"Dirs Count: {DirectoryList.Count}"); 

            }


            /// <summary>
            /// Parse the specified path.
            /// </summary>
            /// <param name="path">Path.</param>
            public void Parse(string path)
            {
                  string[] dirs = Directory.GetDirectories(path); 
                  for (int x = 0; x < dirs.Length; x++)
                  {
                        //Get.Green(dirs[x]);
                        this.DirectoryList.Add(dirs[x]);
                        Get.Green(dirs[x]);
                        this.GetFiles(dirs[x]);
                        this.GetDirs(Directory.GetDirectories(dirs[x]));

                  }

                  //Get.Wait($"Dirs Count: {DirectoryList.Count}"); 

            }


            /// <summary>
            /// Initializes a new instance of the <see cref="T:QuickTools.FilesMaper"/> class.
            /// </summary>
            public FilesMaper()
            {
                  this.DirectoryList = new List<string>();
                  this.FileList      = new List<string>();

            }
   

    }
}
