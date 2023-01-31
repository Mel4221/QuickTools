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


using QuickTools.QCore;
namespace QuickTools.QData
{
      public partial class MiniDB
      {
            /// <summary>
            /// Initializes a new instance of the <see cref="T:QuickTools.MiniDB"/> VERY IMPORTANT WHEN INITIALIZES LIKE THIS 
            /// IT WILL NOT LOAD THE DATABASE IT WILL HAVE TO BE LOADED MANUALLY BY CALLING  THE  Load() METHOD.
            /// </summary>
            public MiniDB()
            {
                  KeysName = "Key";
                  RelationOrType = "NULL";
                  ID = 1000;
            }
            /// <summary>
            /// Initializes a new instance of the <see cref="T:QuickTools.MiniDB"/> class.
            /// </summary>
            /// <param name="dbName">Db name.</param>
            public MiniDB(string dbName)
            {
                  DBName = dbName;
                  KeysName = "Key";
                  RelationOrType = "NULL";
                  ID = 1000;
                  DBName = Path + dbName; 
                  this.Load();
            }
       

            /// <summary>
            /// Initializes a new instance of the <see cref="T:QuickTools.MiniDB"/> class.
            /// </summary>
            /// <param name="dbName">Db name.</param>
            /// <param name="defaultPath">If set to <c>true</c> default path.</param>
            public MiniDB(string dbName, bool defaultPath)
            {
                  KeysName = "Key";
                  RelationOrType = "NULL";
                  ID = 1000;
                  if (defaultPath)
                  {
                        Path = Get.DataPath("db/");
                  }
                  DBName = Path + dbName;
                  this.Load();

            }

            /// <summary>
            /// Initializes a new instance of the <see cref="T:QuickTools.MiniDB"/> class.
            /// </summary>
            /// <param name="dbName">Db name.</param>
            /// <param name="keyName">Key name.</param>
            /// <param name="relationOrType">Relation or type.</param>
            public MiniDB(string dbName, string keyName, string relationOrType)
            {
                  KeysName = keyName;
                  RelationOrType = relationOrType;
                  ID = 1000;
                  DBName = Path + dbName;
                  this.Load();

            }

            /// <summary>
            /// Initializes a new instance of the <see cref="T:QuickTools.MiniDB"/> class.
            /// </summary>
            /// <param name="dbName">Db name.</param>
            /// <param name="keyName">Key name.</param>
            /// <param name="relationOrType">Relation or type.</param>
            /// <param name="defaultPath">If set to <c>true</c> default path.</param>
            public MiniDB(string dbName, string keyName, string relationOrType, bool defaultPath)
            {
                  KeysName = keyName;
                  RelationOrType = relationOrType;
                  ID = 1000;
                  if (defaultPath)
                  {
                        Path = Get.DataPath("db/"); 
                  }
                  DBName = Path + dbName;
                  this.Load();

            }
            /// <summary>
            /// Initializes a new instance of the <see cref="T:QuickTools.MiniDB"/> class.
            /// </summary>
            /// <param name="dbName">Db name.</param>
            /// <param name="keyName">Key name.</param>
            /// <param name="relationOrType">Relation or type.</param>
            /// <param name="id">Identifier.</param>
            public MiniDB(string dbName, string keyName, string relationOrType, int id)
            {
                  KeysName = keyName;
                  RelationOrType = relationOrType;
                  ID = id;
                  DBName = Path+dbName;
                  this.Load();


            }

            /// <summary>
            /// Initializes a new instance of the <see cref="T:QuickTools.MiniDB"/> class.
            /// </summary>
            /// <param name="dbName">Db name.</param>
            /// <param name="keyName">Key name.</param>
            /// <param name="relationOrType">Relation or type.</param>
            /// <param name="id">Identifier.</param>
            /// <param name="allowRepeatedKeys">If set to <c>true</c> allow repeated keys.</param>
            public MiniDB(string dbName, string keyName, string relationOrType, int id, bool allowRepeatedKeys)
            {
                  DBName = dbName;
                  KeysName = keyName;
                  RelationOrType = relationOrType;
                  ID = id;
                  AllowRepeatedKeys = allowRepeatedKeys;
                  this.Load();


            }


      }
}
