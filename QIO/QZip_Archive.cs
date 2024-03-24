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
using QuickTools.QCore;
using QuickTools.QData;


namespace QuickTools.QIO
{
      public partial class QZip
      {

            /// <summary>
            /// Archive Generator 
            /// </summary>
            public class Archive
            {

                  private string ArchiveName;
                  private List<string> FilesList;
                  private List<FileInfo> FilesData;

                  /// <summary>
                  /// Gets or sets a value indicating whether this <see cref="T:QuickTools.QZip.Archive"/> create build list.
                  /// </summary>
                  /// <value><c>true</c> if create build list; otherwise, <c>false</c>.</value>
                  public bool CreateBuildList { get; set; }
                  internal class FileInfo
                  {
                        internal string FileName;
                        internal string FileBytes;
                        internal double FileHash; 
                  }

                  /// <summary>
                  /// The fail list.
                  /// </summary>
                  public  List<FailInfo> FailList;
                  private enum Reasons
                  {
                        ArchiveNameNotGiven,
                        FileListNotGiven,
                        FailToReadBytes,
                        FailToBuild,
                        FailtToUnBuild
                  }
                  /// <summary>
                  /// Fail info.
                  /// </summary>
                  public class FailInfo
                  {
                        /// <summary>
                        /// Gets or sets the name of the file.
                        /// </summary>
                        /// <value>The name of the file.</value>
                        public string FileName { get; set; }
                        /// <summary>
                        /// Gets or sets the reason.
                        /// </summary>
                        /// <value>The reason.</value>
                        public string Reason { get; set; }
                  }

             
                    
                  private bool LoadAllBytes()
                  {
                        bool status = false;
                        string content;
                        byte[] fileBytes; 
                        this.FilesData = new List<FileInfo>();
                        this.FailList = new List<FailInfo>();

                        for (int file = 0; file < FilesList.Count; file++)
                        {

                              try
                              {
                                          Get.Blue($"Reading Bytes From: {this.FilesList[file]}");

                                          fileBytes = File.ReadAllBytes(this.FilesList[file]); 
                                          content = IConvert.BytesToString(fileBytes);

                                    this.FilesData.Add(new FileInfo() {
                                          FileName = FilesList[file],
                                          FileBytes = content,
                                          FileHash = fileBytes.GetHashCode()
                                          });

                              }
                              catch (Exception ex)
                              {
                                    FailList.Add(new FailInfo()
                                    {
                                          FileName = this.FilesList[file],
                                          Reason = $"Reason: {ex.Message} \n {ex}"
                                    });
                                    Get.Wrong("Loading Files");
                              }
                        }
                        status = true; 
                        return status; 
                  }

                  /// <summary>
                  /// Build this instance.
                  /// </summary>
                  public void Build()
                  {
                        this.ArchiveName += ".qbox"; 
                        new MiniDB(this.ArchiveName).Drop(); 
                        Get.Yellow("Reading Bytes...");
                        bool status = LoadAllBytes();
                        Get.Ok();
                        QZip zip = new QZip();
                        using (MiniDB db = new MiniDB(this.ArchiveName))
                        {
                              db.Drop();
                              db.Create();
                              for (int file = 0; file < this.FilesData.Count; file++)
                              {
                                    string fileName = this.FilesData[file].FileName.Substring(this.FilesData[file].FileName.LastIndexOf('/') + 1);

                                    db.AddKeyOnHot(fileName, this.FilesData[file].FileBytes, "FILE");

                                    Get.Title(Get.Status(file, this.FilesData.Count - 1));
                              }
                              db.HotRefresh();
                              Get.Yellow($"Building... {this.ArchiveName}");
                              Get.WaitTime(1000);

                              //db.HotRefresh();
                        }

                        zip.Prefix = "";
                       // zip.Compress(this.ArchiveName);
                        this.PrintBuildResults();
                        this.CreateBuildListFile(); 
                  }

                  /// <summary>
                  /// Uns the build.
                  /// </summary>
                  public void UnBuild()
                  {
                        QZip zip = new QZip();
                        zip.Prefix = "";
                        zip.Decompress(this.ArchiveName,true);
                        Get.Ok(); 


                  }

                  private void CreateBuildListFile()
                  {
                        if (CreateBuildList)
                        {
                              Get.Yellow("Building Build List...");
                              using (MiniDB db = new MiniDB(this.ArchiveName + ".BuildList"))
                              {
                                    db.Drop(); 
                                    db.Create();
                                    int n = 0; 
                                    FilesData.ForEach((item) => 
                                          {
                                                db.AddKeyOnHot(item.FileName, $"FILE NO: {n+1} Hash: {item.FileHash}",null);
                                                n++; 

                                          });
                                    db.HotRefresh(); 
                              }

                        }
                  }
                  /// <summary>
                  /// Prints the build results.
                  /// </summary>
                  public void PrintBuildResults()
                  {
                        this.FilesList.ForEach((obj) => Get.Green($"File Process: {obj}"));
                        for (int fail = 0; fail < this.FailList.Count; fail++)
                        {
                              Get.Red($"\n\n Fail No: {fail+1} File Name: {this.FailList[fail].FileName} \n {this.FailList[fail].Reason}");
                        }
                  }

                  /// <summary>
                  /// Initializes a new instance of the <see cref="T:QuickTools.QZip.Archive"/> class.
                  /// </summary>
                  public Archive()
                  {
                        throw new NotImplementedException("Not Implemented yet");
                  }

                  /// <summary>
                  /// Initializes a new instance of the <see cref="T:QuickTools.QZip.Archive"/> class.
                  /// </summary>
                  /// <param name="archiveName">Archive name.</param>
                  /// <param name="files">Files.</param>
                  public Archive(string archiveName, string[] files)
                  {
                        if (archiveName == null || archiveName.Length == 0) throw new Exception($"Error "+Reasons.ArchiveNameNotGiven);
                        if(files.Length == 0 ) throw new Exception($"Error: " + Reasons.FileListNotGiven);
                        this.ArchiveName = archiveName; 
                        this.FilesList = IConvert.ToType<string>.ToList(files);
                  }
            }
      }
}
