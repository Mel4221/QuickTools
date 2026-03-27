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
namespace QuickTools.QIO
      {
      public partial class Binary:IDisposable
            {


            /// <summary>
            /// Initializes a new instance of the <see cref="T:QuickTools.QIO.Binary"/> class.
            /// </summary>
            public Binary()
                  {
                  this.CallBackAction = (a , b , c) =>
                  {

                  };
                  this.BufferCallBack = (b) => { return b; };
                  }

            #region IDisposable Support
            /// <summary>
            /// The disposed value.
            /// </summary>
            private bool disposedValue = false; // To detect redundant calls


            /// <summary>
            /// Dispose the specified disposing.
            /// </summary>
            /// <param name="disposing">If set to <c>true</c> disposing.</param>
            protected virtual void Dispose(bool disposing)
                  {
                  if(!disposedValue)
                        {
                        if(disposing)
                              {
                              // TODO: dispose managed state (managed objects).
                              }

                        // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                        // TODO: set large fields to null.

                        disposedValue = true;
                        }

                  }

            /// <summary>
            /// Releases all resource used by the <see cref="T:QuickTools.QIO.Binary"/> object.
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
