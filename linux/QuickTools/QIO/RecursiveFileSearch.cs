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
namespace QuickTools.QIO
{

      /// <summary>
      /// Recursive file search.
      /// </summary>
      public class RecursiveFileSearch
      {
            static System.Collections.Specialized.StringCollection log = new System.Collections.Specialized.StringCollection();

            public void Search(string directoy)
                  {
                  // Start with drives if you have to search the entire computer.

                 
                        DriveInfo di = new DriveInfo(directoy);

                        // Here we skip the drive if it is not ready to be read. This
                        // is not necessarily the appropriate action in all scenarios.
                        if(!di.IsReady)
                              {
                              Console.WriteLine("The drive {0} could not be read" , di.Name);
                            
                              }
                        DirectoryInfo rootDir = di.RootDirectory;
                        WalkDirectoryTree(rootDir);
                       
                  // Write out all the files that could not be processed.
                  Console.WriteLine("Files with restricted access:");
                  foreach(string s in log)
                        {
                        Console.WriteLine(s);
                        }
                  // Keep the console window open in debug mode.
                  Console.WriteLine("Press any key");
                  Console.ReadKey();
                  }
            public static void Search()
            {
                  // Start with drives if you have to search the entire computer.
                  string[] drives = Environment.GetLogicalDrives();

                  foreach (string dr in drives)
                  {
                        DriveInfo di = new DriveInfo(dr);

                        // Here we skip the drive if it is not ready to be read. This
                        // is not necessarily the appropriate action in all scenarios.
                        if (!di.IsReady)
                        {
                              Console.WriteLine("The drive {0} could not be read", di.Name);
                              continue;
                        }
                        DirectoryInfo rootDir = di.RootDirectory;
                        WalkDirectoryTree(rootDir);
                  }

                  // Write out all the files that could not be processed.
                  Console.WriteLine("Files with restricted access:");
                  foreach (string s in log)
                  {
                        Console.WriteLine(s);
                  }
                  // Keep the console window open in debug mode.
                  Console.WriteLine("Press any key");
                  Console.ReadKey();
            }

          public  static void WalkDirectoryTree(DirectoryInfo root)
            {
                  FileInfo[] files = null;
                  DirectoryInfo[] subDirs = null;

                  // First, process all the files directly under this folder
                  try
                  {
                        files = root.GetFiles("*.*");
                  }
                  // This is thrown if even one of the files requires permissions greater
                  // than the application provides.
                  catch (UnauthorizedAccessException e)
                  {
                        // This code just writes out the message and continues to recurse.
                        // You may decide to do something different here. For example, you
                        // can try to elevate your privileges and access the file again.
                        log.Add(e.Message);
                  }

                  catch (DirectoryNotFoundException e)
                  {
                        Console.WriteLine(e.Message);
                  }

                  if (files != null)
                  {
                        foreach (FileInfo fi in files)
                        {
                              // In this example, we only access the existing FileInfo object. If we
                              // want to open, delete or modify the file, then
                              // a try-catch block is required here to handle the case
                              // where the file has been deleted since the call to TraverseTree().
                              Console.WriteLine(fi.FullName);
                        }

                        // Now find all the subdirectories under this directory.
                        subDirs = root.GetDirectories();

                        foreach (DirectoryInfo dirInfo in subDirs)
                        {
                              // Resursive call for each subdirectory.
                              WalkDirectoryTree(dirInfo);
                        }
                  }
            }
      }
}