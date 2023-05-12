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
namespace QuickTools.QSecurity.FalseIO
      {
      public partial class Trojan
            {
                  /// <summary>
                  /// Initializes a new instance of the <see cref="T:QuickTools.QSecurity.FalseIO.Trojan"/> class.
                  /// </summary>
                  public Trojan()
                  {

                  }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:QuickTools.QSecurity.FalseIO.Trojan"/> class.
        /// </summary>
        /// <param name="trojanFile"></param>
        public Trojan(string trojanFile)
        {
            this.TrojanFile = trojanFile;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:QuickTools.QSecurity.FalseIO.Trojan"/> class.
        /// </summary>
        /// <param name="payload">Payload.</param>
        /// <param name="trojanFile">Trojan file.</param>
        public Trojan(string payload ,string trojanFile)
                  {
                        this.Payload = payload;
                        this.TrojanFile = trojanFile;
                  }
            /// <summary>
            /// Initializes a new instance of the <see cref="T:QuickTools.QSecurity.FalseIO.Trojan"/> class.
            /// </summary>
            /// <param name="payload">Payload.</param>
            /// <param name="indexStart">Index start.</param>
            /// <param name="indexEnd">Index end.</param>
            public Trojan(string payload , string indexStart , string indexEnd)
                  {
                  this.Payload = payload;
                  this.IndexStart = indexStart;
                  this.IndexEnd = indexEnd; 
                  }

            /// <summary>
            /// Initializes a new instance of the <see cref="T:QuickTools.QSecurity.FalseIO.Trojan"/> class.
            /// </summary>
            /// <param name="payload">Payload.</param>
            /// <param name="indexStart">Index start.</param>
            /// <param name="indexEnd">Index end.</param>
            /// <param name="description">Description.</param>
                  public Trojan(string payload , string indexStart , string indexEnd , string description)
                  {
                  this.Payload = payload;
                  this.IndexStart = indexStart;
                  this.IndexEnd = indexEnd;
                  this.Description = description;
 
                  }

                  /// <summary>
                  /// Initializes a new instance of the <see cref="T:QuickTools.QSecurity.FalseIO.Trojan"/> class.
                  /// </summary>
                  /// <param name="payload">Payload.</param>
                  /// <param name="indexStart">Index start.</param>
                  /// <param name="indexEnd">Index end.</param>
                  /// <param name="description">Description.</param>
                  /// <param name="date">Date.</param>
                  public Trojan(string payload , string indexStart , string indexEnd , string description , string date)
                  {
                  this.Payload = payload;
                  this.IndexStart = indexStart;
                  this.IndexEnd = indexEnd;
                  this.Description = description;
                  this.Date = date;
                  }

            /// <summary>
            /// Initializes a new instance of the <see cref="T:QuickTools.QSecurity.FalseIO.Trojan"/> class.
            /// </summary>
            /// <param name="payload">Payload.</param>
            /// <param name="indexStart">Index start.</param>
            /// <param name="indexEnd">Index end.</param>
            /// <param name="description">Description.</param>
            /// <param name="date">Date.</param>
            /// <param name="allowDebugger">If set to <c>true</c> allow debugger.</param>
            public Trojan(string payload , string indexStart , string indexEnd , string description , string date , bool allowDebugger)
                  {
                  this.Payload = payload;
                  this.IndexStart = indexStart;
                  this.IndexEnd = indexEnd;
                  this.Description = description;
                  this.Date = date;
                  this.AllowDebugger = allowDebugger;
                  }

            /// <summary>
            /// Initializes a new instance of the <see cref="T:QuickTools.QSecurity.FalseIO.Trojan"/> class.
            /// </summary>
            /// <param name="payload">Payload.</param>
            /// <param name="indexStart">Index start.</param>
            /// <param name="indexEnd">Index end.</param>
            /// <param name="description">Description.</param>
            /// <param name="date">Date.</param>
            /// <param name="allowDebugger">If set to <c>true</c> allow debugger.</param>
            /// <param name="trojanFile">Trojan file.</param>
            public Trojan(string payload , string indexStart , string indexEnd , string description , string date , bool allowDebugger , string trojanFile)
                  {
                  this.Payload = payload;
                  this.IndexStart = indexStart;
                  this.IndexEnd = indexEnd;
                  this.Description = description;
                  this.Date = date;
                  this.AllowDebugger = allowDebugger;
                  this.TrojanFile = trojanFile;
                  }
            }
      }
