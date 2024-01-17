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
using System.IO;
using System.IO.Compression;
using QuickTools.QCore;
using QuickTools.QData; 

namespace QuickTools.QIO
{
      /// <summary>
      /// QZip is 
      /// </summary>
      public partial class QZip
      {
            private string FileName;
            private string Prefix = ".zip"; 
            private readonly List<string> FileList;


            private void Check() {if (this.FileName.Length == 0)throw new Exception("The file was not provided "); }

           

            /// <summary>
            /// Compress a list of files given on the Initialization
            /// </summary>
            public void CompressList()
            {
                  if(FileList.Count == 0)
                  {
                        throw new Exception("The list of file is Empty");
                  }
                  for (int item = 0; item < FileList.Count; item++)
                  {
                        var bytes = File.ReadAllBytes(FileList[item]);
                        string zipFile = FileList[item] + Prefix;
                        using (FileStream fs = new FileStream(zipFile, FileMode.Create))
                        {
                              using (GZipStream zipStream = new GZipStream(fs, CompressionLevel.Optimal, false))
                              {
                                    zipStream.Write(bytes, 0, bytes.Length);
                              }
                        }
                  }
            }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:QuickTools.QIO.QZip"/> allow debugger.
        /// </summary>
        /// <value><c>true</c> if allow debugger; otherwise, <c>false</c>.</value>
        public bool AllowDebugger { get; set; } = false;

        /// <summary>
        /// Gets or sets the status of the current state of the Action either Zip or UnZip are suported
        /// </summary>
        /// <value>The status.</value>
        public string Status { get; set; } = "not-started";
        /// <summary>
        /// Zip the specified archiveName and files.
        /// </summary>
        /// <param name="archiveName">Archive name.</param>
        /// <param name="files">Files.</param>
        public void Zip(string archiveName , string[] files)
        {
            using (FileStream stream = new FileStream(archiveName,FileMode.Create,FileAccess.Write))
            {
                using (ZipArchive archive = new ZipArchive(stream, ZipArchiveMode.Create))
                {
                    int current, goal;
                    string status;
                    current = 0;
                    goal = files.Length - 1;
                    foreach (var item in files)
                    {
                        try
                        {
                            archive.CreateEntryFromFile(item, Get.FileNameFromPath(item), CompressionLevel.Optimal);
                            current++;
                            status = $"{Get.FileNameFromPath(item)} [OK] [{Get.Status(current, goal)}]";
                            this.Status = status;
                            if (this.AllowDebugger)
                            {
                                Get.Yellow(status);
                            }
                        }
                        catch (Exception ex)
                        {
                            this.Errors.Add(new Error() { Message = ex.Message, Type = $"Failed To Zip {Get.FileNameFromPath(item)} Due to: \n {ex}" });
                        }

                    }
                    if (this.AllowDebugger && this.Errors.Count > 0)
                    {
                        this.Errors.ForEach(item => Get.Red(item.ToString()));
                    }

                }
            }
        }
        /// <summary>
        /// Contains the list of error .
        /// </summary>
        public List<Error> Errors;
        /// <summary>
        /// Uns the zip.
        /// </summary>
        /// <param name="archive">Archive.</param>
        /// <param name="outPath">Out path.</param>
        public void UnZip(string archive, string outPath)
        {
            this.Errors = new List<Error>();

            using (ZipArchive unzip = ZipFile.OpenRead(archive))
            {
                string status;
                int current, goal;
                goal = unzip.Entries.Count - 1;
                current = 0;
                foreach (ZipArchiveEntry entry in unzip.Entries)
                {
                    try
                    {
                        entry.ExtractToFile(Path.Combine(outPath, entry.FullName),true);
                        current++;
                        status = $"{entry.FullName} [OK] [{Get.Status(current, goal)}]";
                        this.Status = status;
                        if (this.AllowDebugger)
                        {
                            Get.Yellow(status);
                        }

                    }
                    catch (Exception ex)
                    {
                        this.Errors.Add(new Error() { Message = ex.Message, Type = $"Failed To UnZip {entry.FullName} Due to: \n {ex}" });
                    }
                    if (this.AllowDebugger && this.Errors.Count > 0)
                    {
                        this.Errors.ForEach(item => Get.Red(item.ToString()));
                    }

                }
            }
        }

        /// <summary>
        /// Decompresses the list of files
        /// </summary>
        public void DecompressList()
            {
                  if (FileList.Count == 0)
                  {
                        throw new Exception("The list of file is Empty");
                  }

                  for (int item = 0; item < FileList.Count; item++)
                  {
                        string zipFile = FileList[item].Substring(0, FileList[item].LastIndexOf('.'));
                        FileStream fs = new FileStream(zipFile, FileMode.Create);
                        FileStream compressed = new FileStream(FileList[item], FileMode.Open, FileAccess.Read);
                        byte[] bytes = new byte[File.ReadAllBytes(FileList[item]).Length];
                        //Get.Yellow(bytes.Length); 
                        GZipStream zipStream = new GZipStream(compressed, CompressionMode.Decompress, false);
                        byte[] buffer = new byte[1024];
                        int nRead;
                        while ((nRead = zipStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                              fs.Write(buffer, 0, nRead);
                        }
                  }
                  
            }




            /// <summary>
            /// Compress this instance.
            /// </summary>
            public void Compress()
            {
                  this.Check();
                  var bytes = File.ReadAllBytes(this.FileName);
                  string zipFile = this.FileName + Prefix;
                  using (FileStream fs = new FileStream(zipFile, FileMode.Create))
                  {
                        using (GZipStream zipStream = new GZipStream(fs, CompressionLevel.Optimal, false))
                        {
                              zipStream.Write(bytes, 0, bytes.Length);
                        }
                  }
            }

            /// <summary>
            /// Compress the specified file.
            /// </summary>
            /// <param name="file">File.</param>
            public void Compress(string file)
            {
                  var bytes = File.ReadAllBytes(file);
                  string zipFile = file +Prefix;
                  using (FileStream fs = new FileStream(zipFile, FileMode.Create))
                  {
                        using (GZipStream zipStream = new GZipStream(fs, CompressionLevel.Optimal, false))
                        {
                              zipStream.Write(bytes, 0, bytes.Length);
                        }
                  }
            }


            /// <summary>
            /// Decompress this instance.
            /// </summary>
            public void Decompress()
            {
                  Check();
                  string zipFile = this.FileName.Substring(0, this.FileName.LastIndexOf('.'));
                  FileStream fs = new FileStream(zipFile, FileMode.Create);
                  FileStream compressed = new FileStream(this.FileName, FileMode.Open, FileAccess.Read);
                  byte[] bytes = new byte[File.ReadAllBytes(this.FileName).Length];
                  //Get.Yellow(bytes.Length); 
                  GZipStream zipStream = new GZipStream(compressed, CompressionMode.Decompress, false);
                  byte[] buffer = new byte[1024];
                  int nRead;
                  while ((nRead = zipStream.Read(buffer, 0, buffer.Length)) > 0)
                  {
                        fs.Write(buffer, 0, nRead);
                  }
            }

            /// <summary>
            /// Decompress the specified file.
            /// </summary>
            /// <param name="file">File.</param>
            public void Decompress(string file)
            {

                  string zipFile = file.Substring(0, file.LastIndexOf('.'));
                  FileStream fs = new FileStream(zipFile, FileMode.Create);
                  FileStream compressed = new FileStream(file, FileMode.Open, FileAccess.Read);
                  byte[] bytes = new byte[File.ReadAllBytes(file).Length];
                  //Get.Yellow(bytes.Length); 
                  GZipStream zipStream = new GZipStream(compressed, CompressionMode.Decompress, false);
                  byte[] buffer = new byte[1024];
                  int nRead;
                  while ((nRead = zipStream.Read(buffer, 0, buffer.Length)) > 0)
                  {
                        fs.Write(buffer, 0, nRead);
                  }
            }

            internal void Decompress(string file,bool withPrefix)
            {

                  string zipFile = file + ".temp"; 
                  byte[] bytes = new byte[File.ReadAllBytes(file).Length];
                  FileStream compressed = new FileStream(file, FileMode.Open, FileAccess.Read);
                  FileStream fs = new FileStream(zipFile, FileMode.Create);
                  GZipStream zipStream = new GZipStream(compressed, CompressionMode.Decompress, false);
                  byte[] buffer = new byte[1024];
                  int nRead;
                  while ((nRead = zipStream.Read(buffer, 0, buffer.Length)) > 0)
                  {
                        fs.Write(buffer, 0, nRead);
                  }
                  File.Delete(file);
                  File.Move(zipFile, file);
            }
            /// <summary>
            /// Initializes a new instance of the <see cref="T:QuickTools.QZip"/> class.
            /// </summary>
            public QZip()
            {
                  this.FileName = null;
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="T:QuickTools.QZip"/> class.
            /// </summary>
            /// <param name="file">File.</param>
            public QZip(string file)
            {
                  this.FileName = file; 
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="T:QuickTools.QZip"/> class.
            /// </summary>
            /// <param name="fileList">File list.</param>
            public QZip(string[] fileList)
            {
                  this.FileList = IConvert.ToType<string>.ToList(fileList); 
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="T:QuickTools.QZip"/> class.
            /// </summary>
            /// <param name="fileList">File list.</param>
            public QZip(List<string> fileList)
            {
                  this.FileList = fileList;
            }
      }
}
