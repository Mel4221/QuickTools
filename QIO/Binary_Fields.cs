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
namespace QuickTools.QIO
{
      public partial class Binary
      {
            /// <summary>
            /// The current status.
            /// </summary>
            public  long CurrentStatus;
            /// <summary>
            /// The buffer.
            /// </summary>
            public byte[] Buffer;
      
            /// <summary>
            /// The chunck.
            /// </summary>
            public int Chunck = 1024;

            /// <summary>
            /// The current.
            /// </summary>
            public long Current;

            /// <summary>
            /// The counter.
            /// </summary>
            public int Counter = 0;

            /// <summary>
            /// The bytes list.
            /// </summary>
            public static List<byte[]> BytesList;
            //public static LinkedList<byte[]> BytesList; 
            private string s;

            /// <summary>
            /// Gets or sets a value indicating whether this <see cref="T:QuickTools.QIO.Binary"/> allow debugger.
            /// </summary>
            /// <value><c>true</c> if allow debugger; otherwise, <c>false</c>.</value>
            public bool AllowDebugger { get; set; }


            /// <summary>
            /// Gets or sets the name of the file.
            /// </summary>
            /// <value>The name of the file.</value>
            public string FileName { get; set; }


            /// <summary>
            /// Gets or sets the read speed.
            /// </summary>
            /// <value>The read speed.</value>
            public long ReadSpeed { get; set; }

            /// <summary>
            /// Gets or sets the speed chars.
            /// </summary>
            /// <value>The speed chars.</value>
            public string SpeedChars = "Kbs"; 

            /// <summary>
            /// Gets or sets the speed unit default is set to kbs
            /// </summary>
            /// <value>The speed unit.</value>
            public int SpeedUnit = 8;


            /// <summary>
            /// The allow megabytes as default.
            /// </summary>
            public bool AllowMegabytesAsDefault;

            /// <summary>
            /// The call back function.
            /// </summary>
            public Action<long,long,long> CallBackAction;
 


            /// <summary>
            /// Initializes a new instance of the <see cref="T:QuickTools.QIO.Binary"/> class.
            /// </summary>
            public Binary()
            {
                  this.CallBackAction = (a,b,c) =>
                  {
                      
                  };
            }
      }
}

/*
              return new Binary()
                        {
                              FileName = this.FileName,
                              CurrentStatus = this.CurrentStatus,
                              Buffer = this.Buffer,
                              Chunck = this.Chunck,
                              AllowDebugger = this.AllowDebugger,
                              ReadSpeed = this.ReadSpeed,
                              SpeedChars = this.SpeedChars,
                              SpeedUnit = this.SpeedUnit
                        };
*/
