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
using System.Diagnostics; 
namespace QuickTools.QCore
{
   /// <summary>
   /// This is an abstraction of Stoop Watch which provide some functionalities from the same class
   /// </summary>
      public class Check:IDisposable
      {

            private Stopwatch sw;
            /// <summary>
            /// Gets or sets the seconds.
            /// </summary>
            /// <value>The seconds.</value>
            public int Seconds { get; set; }

            /// <summary>
            /// Gets or sets the minutes.
            /// </summary>
            /// <value>The minutes.</value>
            public int Minutes { get; set; }

            /// <summary>
            /// Gets or sets the milliseconds.
            /// </summary>
            /// <value>The milliseconds.</value>
            public int Milliseconds { get; set; }

            /// <summary>
            /// Start this instance.
            /// </summary>
            public  void Start()
            {
                  try
                  {
                        sw = new Stopwatch();
                        sw = Stopwatch.StartNew();
                  }
                  catch(Exception ex)
                  {
                        throw new Exception("There Was an error Starting the Check Start"+"\n"+ex);
                  }
            }
            private string STringResults; 
            /// <summary>
            /// Stop this instance.
            /// </summary>
            /// <returns>The stop.</returns>
            public string Stop()
            {

                  try
                  {
                        sw.Stop();
                        Seconds = sw.Elapsed.Seconds;
                        Minutes = sw.Elapsed.Minutes;
                        Milliseconds = sw.Elapsed.Milliseconds;
                        string m, s, ms;
                        m = Minutes == 0 ? "" : $"{Minutes}m ";
                        s = Seconds == 0 ? "" : $"{Seconds}s ";
                        ms = Milliseconds == 0 ? "" : $"{Milliseconds}ms "; 
                        
                        STringResults =  $"{m}{s}{ms}";
                        sw = new Stopwatch(); 
                return STringResults; 
            }
            catch (Exception ex)
                  {
                        throw new Exception("There Was an error Stoping  the Check  so please make sure that the check started sucessfully" + "\n" + ex);
                  }
               
            }


            /// <summary>
            /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:QuickTools.Check"/>.
            /// </summary>
            /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:QuickTools.Check"/>.</returns>
            public override string ToString()
            {
                  return STringResults; 
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

            /// <summary>
            /// Releases all resource used by the <see cref="T:QuickTools.QCore.Check"/> object.
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
