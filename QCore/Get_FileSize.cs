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
namespace QuickTools.QCore
      {
      public partial class Get
            {
            /// <summary>
            /// Size type.
            /// </summary>
            public enum SizeType
                  {
                  /// <summary>
                  /// gigabyte
                  /// </summary>
                  GB,
                  /// <summary>
                  /// megabyte
                  /// </summary>
                  MB,
                  /// <summary>
                  /// kilobyte
                  /// </summary>
                  KB,
                  /// <summary>
                  /// byte
                  /// </summary>
                  B
                  }
            /// <summary>
            /// Files the size.
            /// </summary>
            /// <returns>The size.</returns>
            /// <param name="fileName">File name.</param>
            /// <param name="size">Size.</param>
            public static string FileSize(string fileName , SizeType size)
                  {
                  string fileSize = null;
                  var fileStream = new FileStream(fileName , FileMode.Open , FileAccess.Read);
                  switch(size)
                        {
                        case SizeType.GB:
                              fileSize = $"{fileStream.Length / 1024 / 1024 / 1024}GB";
                              break;
                        case SizeType.MB:
                              fileSize = $"{fileStream.Length / 1024 / 1024 }MB";
                              break;
                        case SizeType.KB:
                              fileSize = $"{fileStream.Length / 1024 }KB";
                              break;
                        default:
                              fileSize = $"{fileStream.Length }B";
                              break; 
                        }
                  return fileSize;
                  }
                  

                              /// <summary>
                              /// gets Files the size.
                              /// </summary>
                              /// <returns>The size.</returns>
                              /// <param name="fileName">File name.</param>
                     public static string FileSize(string fileName)
                  {
                  string fileSize = null;
                  var fileStream = new FileStream(fileName , FileMode.Open , FileAccess.Read);
                         if((fileStream.Length / 1024 / 1024 / 1024) != 0 )
                        {
                        fileSize = $"{fileStream.Length / 1024 / 1024 / 1024}GB";
                        return fileSize; 
                        }
                        if((fileStream.Length / 1024 / 1024 ) != 0)
                        {
                        fileSize = $"{fileStream.Length / 1024 / 1024 }MB";
                        return fileSize;
                        }
                        if((fileStream.Length / 1024 ) != 0)
                        {
                        fileSize = $"{fileStream.Length / 1024 }KB";
                        return fileSize;
                        }
                        fileSize = $"{fileStream.Length }B";

                  return fileSize;
                  }
            }

 

      }
