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
namespace QuickTools
{

      /// <summary>
      /// This is a class that create xml files that can be used to save
      /// simple information related with the program  and wants just a simple 
      /// utility that can provide the settings features without having to add extra nugetpackages 
      /// </summary>
      public class Cache
      {

           // public string Tag = @"<?xml version='1.0'?>";
            private string FileName = null;
            /// <summary>
            /// Name of the atribute that will be added 
            /// </summary>
            private string AtributeName = null;
            /// <summary>
            /// This set the value of the atribute
            /// </summary>
            private string FileValue = null; 



            private void ReloadCache()
            {

            }
            /// <summary>
            /// Deletes the item.
            /// </summary>
            public void DeleteItem()
            {

            }
            /// <summary>
            /// Adds the item.
            /// </summary>
            /// <param name="tributeName">Tribute name.</param>
            /// <param name="fileValue">File value.</param>
            public void AddItem(string tributeName, string fileValue)
            {
                  AtributeName = tributeName;
                  FileValue = fileValue; 
            }
            /// <summary>
            /// Add new  item.
            /// </summary>
            /// <param name="name">Name.</param>
            /// <param name="value">Value.</param>
            public void NewItem(string name,string value)
            {

                  string tag = $"<{name}>{value}</{name}>";

                //  Writer.WriteFile("/data/qt/"+FileName,tag); 
            }
            /// <summary>
            /// Saves the item.
            /// </summary>
            /// <param name="atribute">Atribute.</param>
            /// <param name="value">Value.</param>
            public void SaveItem(string atribute ,string value)
            {
                  string file = Get.DataPath() + FileName; 
                  if(File.Exists(file))
                  {
                        // this will write the file 

                  }
            }
            /// <summary>
            /// Gets the item.
            /// </summary>
            /// <returns>The item.</returns>
            /// <param name="atribute">Atribute.</param>
            public string GetItem(string atribute)
            {
                  return null; 
            }


            /// <summary>
            /// Initializes a new instance of the <see cref="T:QuickTools.Cache"/> class.
            /// </summary>
            public Cache()
            {

            }
            /// <summary>
            /// Initializes a new instance of the <see cref="T:QuickTools.Cache"/> class.
            /// </summary>
            /// <param name="fileName">File name.</param>
            public Cache(string fileName)
            {
                  Writer.CreateFile(Get.DataPath()+fileName,"hola");
            }
            /// <summary>
            /// Initializes a new instance of the <see cref="T:QuickTools.Cache"/> class.
            /// </summary>
            /// <param name="fileName">File name.</param>
            /// <param name="atribute">Atribute.</param>
            /// <param name="value">Value.</param>
            public Cache(string fileName,object atribute ,object value)
            {

            }
      }
}
