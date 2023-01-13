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
namespace QuickTools
{
   /// <summary>
   /// This is an abstraction of Stoop Watch which provide some functionalities from the same class
   /// </summary>
      public class Check
      {

            private Stopwatch sw;
            /// <summary>
            /// Gets or sets the seconds.
            /// </summary>
            /// <value>The seconds.</value>
            public object Seconds { get; set; }

            /// <summary>
            /// Gets or sets the minutes.
            /// </summary>
            /// <value>The minutes.</value>
            public object Minutes { get; set; }

            /// <summary>
            /// Gets or sets the milliseconds.
            /// </summary>
            /// <value>The milliseconds.</value>
            public object Milliseconds { get; set; }

            /// <summary>
            /// Start this instance.
            /// </summary>
            public  void Start()
            {
                  try
                  {
                        sw = Stopwatch.StartNew();
                  }catch(Exception ex)
                  {
                        throw new Exception("There Was an error Starting the Check Start"+"\n"+ex);
                  }
            }

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
                        return $"Minutes: {Minutes} Seconds: {Seconds} Milliseconds: {Milliseconds}";
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
                  return base.ToString();
            }
      }
}
