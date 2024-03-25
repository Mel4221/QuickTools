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
        /// Get all the files retroactively from a path.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
            public string[] RetroMapFiles(string path)
            {
                this.Path = path;
                this.Map();
                return this.Files.ToArray(); 
            }

        /// <summary>
        /// Get all the directories retroactively from a path.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string[] RetroMapFolders(string path)
        {
            this.Path = path;
            this.Map();
            return this.Directories.ToArray();
        }
        /// <summary>
        /// Gets the directosy 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string[] GetDirs(string path) => Directory.GetDirectories(path);
            


         


        private string[] Ignore { get; set; }
      
        /// <summary>
        /// Search requirsively for files and ignore the given files 
        /// that does not meet the file extention given it only requires
        /// a file extention on the falowing way like {txt,pdf,xml}
        /// </summary>
        /// <param name="ignore">Ignore.</param>
        public void Map(string[] ignore)
        {
            this.Map();
            this.Ignore = ignore;
            List<string> files = new List<string>();
            for(int f = 0; f < this.Files.Count; f++)
            {
                foreach (string type in this.Ignore)
                {
                    if (type == Get.FileExention(this.Files[f]))
                    {
                        files.Add(this.Files[f]);
                        if (this.AllowDebugger)
                        {
                            Get.Yellow($"MATCH FILE EXTENTION: [{this.Files[f]}] TYPE: [{type}]");
                        }

                    }
                }
            }
            this.Files = files; 
        }


        /// <summary>
        /// This search recursivly for files that match the given file extention
        /// </summary>
        /// <returns></returns>
        public List<string> MapOnlyFiles(string[] fileExtentiontypes)
        {

            this.Map();
            List<string> files = new List<string>();

            if(this.Files.Count != 0)
            {
                for (int f = 0; f < this.Files.Count; f++)
                {
                    foreach(string type in fileExtentiontypes)
                    {
                        if(type == Get.FileExention(this.Files[f]))
                        {
                            files.Add(this.Files[f]);
                            if (this.AllowDebugger)
                            {
                                Get.Yellow($"MATCH: [{this.Files[f]}]");
                            }

                        }
                    }
                 
                }
            }
            this.Files = files; 
            return files; 
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

          string[] MapFiles(string folderPath)
        {
             if (folderPath == "" || folderPath == null)
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

            if(this.FileList.Count != 0)
            {
                return this.FileList.ToArray();
            }
            return new string[] { }; 

        }




          string[] MapFolders(string folderPath)
        {
            if (folderPath == "" || folderPath == null)
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

            if (this.FileList.Count != 0)
            {
                return this.DirectoryList.ToArray();
            }
            return new string[] { };

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
