﻿//
// Zip.cs
//
// Author:
//       melquiceded balbi villanueva <mbv@projects.com>
//
// Copyright (c) 2022 MIT
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
using System.IO.Compression;
namespace QuickTools
{
      /// <summary>
      /// ****EXPERIMENTAL****
      /// Zip is a class that contaings some abstraction
      /// from the IO.Compress.Zipfile that can compress
      /// and decompress files.
      /// </summary>
      public class Zip
      {
         /// <summary>
         /// Compress the specified file.
         /// </summary>
         /// <param name="file">File.</param>
            public static void Compress(string file)
            {
                  ZipFile.CreateFromDirectory(file, "Ziped_"+file);

                     
            }
            /// <summary>
            /// Decompress the specified file.
            /// </summary>
            /// <param name="file">File.</param>
            public static void Decompress(string file)
            {
                  ZipFile.ExtractToDirectory(file, file);
            }
      }
}