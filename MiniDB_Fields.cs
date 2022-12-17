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
using System.Xml;
using System.Data;
using System.Collections.Generic;
using System.IO;
namespace QuickTools
{
      public partial class MiniDB
      {
            /// <summary>
            /// DB object in which the values are formated and stored
            /// </summary>
            public class DB
            {
                  /// <summary>
                  /// Gets or sets the key.
                  /// </summary>
                  /// <value>The key.</value>
                  public string Key { get; set; }

                  /// <summary>
                  /// Gets or sets the value.
                  /// </summary>
                  /// <value>The value.</value>
                  public string Value { get; set; }

                  /// <summary>
                  /// Gets or sets the relation.
                  /// </summary>
                  /// <value>The relation.</value>
                  public string Relation { get; set; }

                 /// <summary>
                 /// Gets or sets the identifier.
                 /// </summary>
                 /// <value>The identifier.</value>
                  public int Id { get; set; }
                  
                  /// <summary>
                  /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:QuickTools.MiniDB.DB"/>.
                  /// </summary>
                  /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:QuickTools.MiniDB.DB"/>.</returns>
                  public override string ToString()
                  {
                        return $"Id: {Id} Key: {Key} Value: {Value} Relation: {Relation} ";
                  }


                  /// <summary>
                  /// This will convert the object to an array
                  /// </summary>
                  /// <returns>Id[0] Key[1] Value[2] Relation[3] </returns>
                  public string[] ToStringArray()
                  {
                        string[] array = new string[4];

                        array[0] = Id.ToString();
                        array[1] = Key;
                        array[2] = Value;
                        array[3] = Relation; 



                        return array; 
                  }
                  /// <summary>
                  /// Tos the string.
                  /// </summary>
                  /// <returns>The string.</returns>
                  /// <param name="type"> json or xml </param>
                  public string ToString(string type)
                  {
                        string obj = null;

                        switch(type)
                        {
                              case "json":
                                    obj = $"[ \n 'ID': {Id}, \n 'Key': {Key}, \n 'Value': {Value}, \n 'Relation': {Relation}\n]".Replace("'",'"'.ToString()).Replace("[","{").Replace("]","}");
                                    break;

                              case "xml":
                                    obj = $"<?xml version='1.0' encoding='UTF - 8'?>\n" +
                                          "<DATA> \n"+
                                    	      $" <ID> {Id} </ID> \n" +
                                    		$" <Key> {Key} </Key> \n"+
                                                $" <Value> {Value} </Value> \n" +
                                                $" <Relation> {Relation} </Relation> \n" +
                                          "</DATA>".Replace("'", '"'.ToString()); 
                                    break;
                              default:
                                    obj = this.ToString();
                                    break; 
                        }


                        return obj; 
                  }
            }




            /// <summary>
            /// This method will be available to be modefied by the user of the class  to handle the relations 
            /// </summary>
            public virtual void Relation()
            {

            }

            /// <summary>
            /// Gets or sets the DBN ame.
            /// </summary>
            /// <value>The DBN ame.</value>
            public string DBName { get; set; }

            /// <summary>
            /// Gets or sets the name of the keys.
            /// </summary>
            /// <value>The name of the keys.</value>
            public string KeysName { get; set; }

            /// <summary>
            /// Gets or sets the type of the relation or.
            /// </summary>
            /// <value>The type of the relation or.</value>
            public string RelationOrType { get; set; }

            /// <summary>
            /// Gets or sets a value indicating whether this <see cref="T:QuickTools.MiniDB"/> allow repeated keys.
            /// </summary>
            /// <value><c>true</c> if allow repeated keys; otherwise, <c>false</c>.</value>
            public bool AllowRepeatedKeys { get; set; }


            /// <summary>
            /// Gets or sets the path.
            /// </summary>
            /// <value>The path.</value>
            public string Path { get; set;  }

            private bool ResentLoaded { get; set;  }

            /// <summary>
            /// Gets or sets the identifier.
            /// </summary>
            /// <value>The identifier.</value>
            public int ID { get; set; }
            XmlDocument Document;

            /// <summary>
            /// Contains the Database from the program
            /// </summary>
            public List<DB> DataBase;
      }
}
