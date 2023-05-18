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
using System.Linq;

namespace QuickTools.QIO
{
      /// <summary>
      /// This is a class developed to assit to be able to retroactively read files and directories 
      /// </summary>
      public partial class FilesMaper
      {


            /// <summary>
            /// Gets the files from the given path
            /// </summary>
            /// <param name="path"></param>
            /// <returns></returns>
            public string[] GetFiles(string path) => Directory.GetFiles(path);
            

            /// <summary>
            /// Gets the directosy 
            /// </summary>
            /// <param name="path"></param>
            /// <returns></returns>
            public string[] GetDirs(string path) => Directory.GetDirectories(path);
            

            private void ProcessDirectory(string targetDirectory)
            {
            if (this.AllowDebugger)
            {
                Get.Blue(targetDirectory);
            }
                this.Directories.Add(targetDirectory);

                // Process the list of files found in the directory.
            string[] fileEntries;
            try
            {
                fileEntries = this.GetFiles(targetDirectory);


                foreach (string fileName in fileEntries)
                {

                    ProcessFile(fileName);
                }

                // Recurse into subdirectories of this directory.
                try
                {
                    string[] subdirectoryEntries = this.GetDirs(targetDirectory);
                    foreach (string subdirectory in subdirectoryEntries)
                    {

                        ProcessDirectory(subdirectory);
                        // Get.Blue(subdirectory);

                    }
                }
                catch (Exception ex)
                {
                    string error = $"File Error: {ex.Message}";
                    if (this.AllowDebugger)
                    {
                        Get.Red(error);
                    }



























































































































                    this.FileErrors.Add(error);

                }
            }
            catch(Exception ex)
            {
                string error = $"Directory Error: {ex.Message}";
                if (this.AllowDebugger)
                {
                    Get.Red(error);
                }
                this.DirectoriesError.Add(error);
            }
        }
              void ProcessFile(string path)
            {
            if (this.AllowDebugger)
            {
                Get.Yellow(path);
            }
              //  Get.Yellow(path);
                this.Files.Add(path);
            }

        /// <summary>
        /// reads the path annd load all the files and directorys that it find allong the way
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void Map()
            {
                if(this.Path == "" || this.Path == null)
                {
                    throw new Exception("The  path can not be empty"); 
                }
                foreach (string path in this.GetFiles(this.Path))
                {
                    if (File.Exists(path))
                    {
                        // This path is a file

                        ProcessFile(path);
                    }
 
                }
                foreach(string path in this.GetDirs(this.Path))
                {
                    if (Directory.Exists(path))
                    {
                        ProcessDirectory(path);
                    }
                }
          
            }


        /// <summary>
        /// reads the path annd load all the files and directorys that it find allong the way
        /// </summary>
        /// <param name="folderPath"></param>
        /// <exception cref="Exception"></exception>
            public void Map(string folderPath)
            {
                if(folderPath == "" || folderPath == null)
                {
                    throw new Exception("The  path can not be empty");
                }
                this.Path = folderPath; 
                foreach (string path in this.GetFiles(this.Path))
                {
                    if (File.Exists(path))
                    {
                        // This path is a file
                        ProcessFile(path);
                    }

                }
                foreach (string path in this.GetDirs(this.Path))
                {
                    if (Directory.Exists(path))
                    {
                        ProcessDirectory(path);
                    }
                }


            }











                   
            /// <summary>
            /// Move the specified from origen to the given destination.
            /// </summary>
            /// <param name="origen">Origen.</param>
            /// <param name="destination">Destination.</param>
                  public static void Move(string origen , string destination)
                  {
                        if(destination.LastIndexOf("/") == -1)
                              {
                                    
                              }
                         Directory.Move(origen.Replace("'" , ""), $"{destination}{Get.FolderFromPath(origen.Replace("'" , ""))}");
                  }

            /// <summary>
            /// Move the specified from origen to the given destination.
            /// </summary>
            /// <param name="origen">Origen.</param>
            /// <param name="destination">Destination.</param>
            public static void MoveHere(string origen , string destination)
                  {
                        Directory.Move(origen.Replace("'" , "") , $"{destination}{Get.FolderFromPath(origen.Replace("'" , ""))}");
                  }


            //private void GetDirs(string[] dirs)
            //{
            //      if (dirs.Length > 0)
            //      {
            //            for (int x = 0; x < dirs.Length; x++)
            //            {
            //                  Get.Green(dirs[x]);
            //                  this.DirectoryList.Add(dirs[x]);
            //                  this.GetFiles(dirs[x]);
            //                  this.GetDirs(Directory.GetDirectories(dirs[x]));
            //            }
            //      }
             

            //}



            ///// <summary>
            ///// Gets the files.
            ///// </summary>
            ///// <param name="path">Path.</param>
            //public string[] GetFiles(string path)
            //{
            //      List<string> files = Directory.EnumerateFiles(path).ToList<string>();
            //      this.FileList = new List<string>();
            //      this.FileList = files;

            //      return IConvert.ToType<string>.ToArray(files);
            //}



            ///// <summary>
            ///// Parse the list of directories given to a list of files and directories 
            ///// </summary>
            ///// <param name="dirs">Dirs.</param>
            //public void Parse(string[] dirs)
            //{

            //      for (int x = 0; x < dirs.Length; x++)
            //      {
            //            //Get.Green(dirs[x]);
            //            this.DirectoryList.Add(dirs[x]);
            //            Get.Green(dirs[x]);
            //            this.GetFiles(dirs[x]);
            //            this.GetDirs(Directory.GetDirectories(dirs[x]));

            //      }

            //      //Get.Wait($"Dirs Count: {DirectoryList.Count}"); 

            //}


            ///// <summary>
            ///// Parse the specified path.
            ///// </summary>
            ///// <param name="path">Path.</param>
            //public void Parse(string path)
            //{
            //      string[] dirs = Directory.GetDirectories(path); 
            //      for (int x = 0; x < dirs.Length; x++)
            //      {
            //            //Get.Green(dirs[x]);
            //            this.DirectoryList.Add(dirs[x]);
            //            Get.Green(dirs[x]);
            //            this.GetFiles(dirs[x]);
            //            this.GetDirs(Directory.GetDirectories(dirs[x]));

            //      }

            //      //Get.Wait($"Dirs Count: {DirectoryList.Count}"); 

            //}


   

    }
}
