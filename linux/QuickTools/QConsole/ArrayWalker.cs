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
using QuickTools.QCore;
using QuickTools.QColors;
namespace QuickTools.QConsole
      {

      /// <summary>
      /// Array walker.
      /// </summary>
      public class ArrayWalker:IDisposable
      {
            /// <summary>
            /// The current.
            /// </summary>
            public int Current;
            /// <summary>
            /// The array.
            /// </summary>
            public string[] Array;

            /// <summary>
            /// Display the specified arrows.
            /// </summary>
            /// <param name="arrows">Arrows.</param>
            public virtual void Display(ArrowsKey arrows)
            {
                  Get.Clear(); 
                  for (int i = 0; i < Array.Length; i++)
                  {
                        Get.Green();
                        if (arrows.X != i)
                        {
                              Get.Write(Array[i]);
                        }
                        if (arrows.X == i)
                        {
                              Get.Yellow();
                              Get.Write(Array[arrows.X] + "|");
                              Get.Reset();
                        }

                  }
            }

            /// <summary>
            /// The key triger.
            /// </summary>
            public string KeyTriger = "Backspace";

            /// <summary>
            /// Initialize the arrows handeler
            /// </summary>
            public ArrowsKey Arrows;

            /// <summary>
            /// This method helps to walk an array word by word
            /// </summary>
            /// <returns>The walk.</returns>
            public int Walk()
            {
                  Arrows = new ArrowsKey(Array.Length - 1, 0);

                  Display(Arrows);
                  Arrows.Capture(KeyTriger, () => {
                        Display(Arrows);
                        //Get.Title(arrows.X);
                  });
                  return Arrows.X; 
            }

           



            /// <summary>
            /// Initializes a new instance of the <see cref="T:QuickTools.ArrayWalker"/> class.
            /// </summary>
            public ArrayWalker()
            {

            }

            /// <summary>
            /// Initializes a new instance of the <see cref="T:QuickTools.ArrayWalker"/> class.
            /// </summary>
            /// <param name="array">Array.</param>
            public ArrayWalker(string[] array)
            {
                   this.Array = array;
            }

            #region IDisposable Support
            private bool disposedValue = false; // To detect redundant calls


            /// <summary>
            /// Dispose the specified disposing.
            /// </summary>
            /// <param name="disposing">If set to <c>true</c> disposing.</param>
            protected virtual void Dispose(bool disposing)
            {
                  if (!disposedValue)
                  {
                        if (disposing)
                        {
                              // TODO: dispose managed state (managed objects).
                        }

                        // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                        // TODO: set large fields to null.

                        disposedValue = true;
                  }
            }

            // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
            // ~ArrayWalker() {
            //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            //   Dispose(false);
            // }



                  /// <summary>
                  /// Releases all resource used by the <see cref="T:QuickTools.ArrayWalker"/> object.
                  /// </summary>
            public void Dispose()
            {
                  // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
                  Dispose(true);
                  // TODO: uncomment the following line if the finalizer is overridden above.
                  // GC.SuppressFinalize(this);
            }
            #endregion

      }
}
