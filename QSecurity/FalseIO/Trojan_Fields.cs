﻿//
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
            /// Gets or sets the payload.
            /// </summary>
            /// <value>The payload.</value>
            public string Payload { get; set; }
                  
                  /// <summary>
                  /// Gets or sets the index start.
                  /// </summary>
                  /// <value>The index start.</value>
                  public string IndexStart { get; set; }
                 
                  /// <summary>
                  /// Gets or sets the index end.
                  /// </summary>
                  /// <value>The index end.</value>
                    public string IndexEnd { get; set; }

                /// <summary>
                /// Gets or sets the description.
                /// </summary>
                /// <value>The description.</value>
                public string Description = "not-given";

                /// <summary>
                /// Gets or sets the date.
                /// </summary>
                /// <value>The date.</value>
                public string Date = DateTime.Now.ToString("M/dd/y h:m:s"); 
                  
                  /// <summary>
                  /// Gets or sets a value indicating whether this <see cref="T:QuickTools.QSecurity.FalseIO.Trojan"/>
                  /// allow debugger.
                  /// </summary>
                  /// <value><c>true</c> if allow debugger; otherwise, <c>false</c>.</value>
                  public bool AllowDebugger { get; set; }
                 
                  /// <summary>
                  /// Gets or sets the trojan file.
                  /// </summary>
                  /// <value>The trojan file.</value>
                    public string TrojanFile { get; set; }
            /// <summary>
            /// This Defines when it will understand that if has reached enought 
            /// intents to find the Payload , so it try to find it in the last 20% of the file as default
            /// </summary>
            public int PorcentOfMaxBreak = 20; 

            /// <summary>
            /// The filnal label identity is set as default (Trojan_+file) Example:  Trojan_FileName.txt
            /// </summary>
            public string DefaultFilnalLabelIdentity = "Trojan_";
            /// <summary>
            /// The default delete source payload.
            /// </summary>
            public bool DefaultDeleteSourceFile = false;

            /// <summary>
            /// deletes the payload file after being used
            /// </summary>
            public bool DefaultRemovePayloadSourceFile = false; 

            /// <summary>
            /// The default delete payload from file.
            /// </summary>
            public bool DefaultDeletePayloadFromFile = false;

            /// <summary>
            /// Coontains some information about the trojan file 
            /// </summary>
            public string MetadData = "not-given"; 
            /// <summary>
            /// The current stage not-started means that no process is being reported 
            /// </summary>
            public string CurrentStage = "not-started";

            /// <summary>
            /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:QuickTools.QSecurity.FalseIO.Trojan"/>.
            /// </summary>
            /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:QuickTools.QSecurity.FalseIO.Trojan"/>.</returns>
            public override string ToString() => $"Payload: {this.Payload} IndexStart: {this.IndexStart} IndexEnd: {this.IndexEnd} Description: {this.Description} Created_Date: {this.Date}";
            }
      }
