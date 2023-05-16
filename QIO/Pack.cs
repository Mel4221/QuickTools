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
using QuickTools.QCore;
namespace QuickTools.QIO
      {
      /// <summary>
      /// Creates a row string of the bytes from the given file  
      /// </summary>
      public class Pack
            {
            /// <summary>
            /// set the file extention , and the default is set to be row
            /// </summary>
            public string FileExtention = "rowpack";


            /// <summary>
            /// Packs the file and if you want to remove the other file you could just pass true as an argument 
            /// </summary>
            /// <param name="fileName">File name.</param>
            /// <param name="removeSourceFile">If set to <c>true</c> keep old file.</param>
            public void PackFile(string fileName , bool removeSourceFile)
                  {
                        if(File.Exists(fileName))
                        {
                        byte[] bytes = Binary.Reader(fileName);
                        Writer.Write($"{fileName}.{this.FileExtention}" , IConvert.BytesToString(bytes));
                        if(removeSourceFile == true)
                              {
                              File.Delete(fileName); 
                              }
                        return;
                        }
                        else
                        {
                        throw new FileNotFoundException(fileName); 
                        }
                  }
            /// <summary>
            /// Packs the file.
            /// </summary>
            /// <param name="fileName">File name.</param>
            public void PackFile(string fileName)
                  {
                  if(File.Exists(fileName))
                        {
                        byte[] bytes = Binary.Reader(fileName);
                        Writer.Write($"{fileName}.{this.FileExtention}" , IConvert.BytesToString(bytes));
                        return;
                        }
                  else
                        {
                        throw new FileNotFoundException(fileName);
                        }
                  }
            /// <summary>
            /// Unpack the pack file.
            /// </summary>
            /// <param name="fileName">File name.</param>
            public void UnPackFile(string fileName)
                  {
                  if(File.Exists(fileName))
                        {
                        string file = fileName.Substring(0 , fileName.LastIndexOf('.'));
                        Binary.Writer(file , IConvert.StringToBytesArray(Reader.Read(fileName)));
                        File.Delete(fileName);
                        return;
                        }
                  else
                        {
                        throw new FileNotFoundException(fileName); 
                        }
                  }
            /// <summary>
            /// un pack the file and also allows you to remove the source 
            /// </summary>
            /// <param name="fileName">File name.</param>
            /// <param name="removeSource">If set to <c>true</c> remove source.</param>
            public void UnPackFile(string fileName , bool removeSource)
                  {
                  if(File.Exists(fileName))
                        {
                        string file = fileName.Substring(0 , fileName.LastIndexOf('.'));
                        Binary.Writer(file , IConvert.StringToBytesArray(Reader.Read(fileName)));
                        File.Delete(fileName);
                        if(removeSource == true)
                              {
                              File.Delete(fileName); 
                              }
                        return;
                        }
                  else
                        {
                        throw new FileNotFoundException(fileName);
                        }
                  }
            }
      }
