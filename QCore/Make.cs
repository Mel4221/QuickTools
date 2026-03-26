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
using QuickTools.QIO;
 
namespace QuickTools.QCore
      {

      /// <summary>
      ///  Contains a list of shurtcuts to some IO functions 
      /// </summary>
      public static class Make
            {
                  /// <summary>
                  /// Directory the specified directoryName.
                  /// </summary>
                  /// <param name="directoryName">Directory name.</param>
                  public static void Directory(string directoryName)
                  {
                        if(System.IO.Directory.Exists(directoryName))
                        {
                            Get.Red($"The directory '{directoryName}' already exist!!!");
                            return;
                        }                        
                        System.IO.Directory.CreateDirectory(directoryName); 
                  }

            /// <summary>
            /// File the specified fileName.
            /// </summary>
            /// <param name="fileName">File name.</param>
                  public static void File(string fileName)
                  {
			            if (System.IO.File.Exists(fileName))
			            {
				            Get.Red($"The File '{fileName}' already exist!!!");
				            return;
			            }
			            System.IO.File.Create(fileName); 
                  }
            /// <summary>
            /// File the specified fileName and content.
            /// </summary>
            /// <param name="fileName">File name.</param>
            /// <param name="content">Content.</param>
                  public static void File(string fileName,byte[] content)
                  {
                        Binary.Writer(fileName , content); 
                  }
            }     
      }
