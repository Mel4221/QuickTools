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

using System.Xml;
using System.Collections.Generic;
namespace QuickTools.QData
{
      public partial class MiniDB
      {


        /// <summary>
        /// Gets or sets the DBN ame.
        /// </summary>
        /// <value>The DBN ame.</value>
        public string DBName { get; set; } = "";

        /// <summary>
        /// The mini db version.
        /// </summary>
        public readonly string MiniDB_Version = "1.0.0.2";

        /// <summary>
        /// Gets or sets the size of the mini db max.
        /// </summary>
        /// <value>The size of the mini db max.</value>
        public int MiniDB_MaxSize { get; set; } = 0;

        /// <summary>
        /// Gets or sets the mini db metadata.
        /// </summary>
        /// <value>The mini db metadata.</value>
        public string MiniDB_Metadata { get; set; } = ""; 

        /// <summary>
        /// Gets or sets the name of the keys.
        /// </summary>
        /// <value>The name of the keys.</value>
        public string KeysName { get; set; } = "";

        /// <summary>
        /// Gets or sets the type of the relation or.
        /// </summary>
        /// <value>The type of the relation or.</value>
        public string RelationOrType { get; set; } = "";

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:QuickTools.MiniDB"/> allow repeated keys.
        /// </summary>
        /// <value><c>true</c> if allow repeated keys; otherwise, <c>false</c>.</value>
        public bool AllowRepeatedKeys { get; set; } = false;


        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:QuickTools.MiniDB"/> is interactive.
        /// </summary>
        /// <value><c>true</c> if interactive; otherwise, <c>false</c>.</value>
        public bool Interactive { get; set; } = false; 

            /// <summary>
            /// Gets or sets the path.
            /// </summary>
            /// <value>The path.</value>
            public string Path { get; set; } = "";

        private bool ResentLoaded { get; set; } = false;

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int ID { get; set; } = 0;
    
        XmlDocument Document; // deprecated
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:QuickTools.QData.MiniDB"/> allow debuger.
        /// </summary>
        /// <value><c>true</c> if allow debuger; otherwise, <c>false</c>.</value>
        public bool AllowDebugger { get; set; } = false;

        /// <summary>
        /// Gets or sets the dubugger mode.
        /// </summary>
        /// <value>The dubugger mode.</value>
        public int DubuggerMode { get; set; } = 0; 
        /// <summary>
        /// Contains the Database from the program
        /// </summary>
        public List<DB> DataBase { get; set; } = new List<DB>();

        /// <summary>
        /// Gets or sets the data manager.
        /// </summary>
        /// <value>The data manager.</value>
        public QKeyManager DataManager { get; set; } = new QKeyManager();


        /// <summary>
        /// Gets or sets the format.
        /// </summary>
        /// <value>The format.</value>
        public MiniDB_Format Format { get; set; } = MiniDB_Format.Default; 

        /// <summary>
        /// MiniDB Format.
        /// </summary>
        public enum MiniDB_Format
        {
            Default,
            Compress
        }
    }
}
