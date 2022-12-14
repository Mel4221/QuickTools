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

      /// <summary>
      /// Mini DB is a class that provide a semy no relation database 
      /// based on the key value method 
      /// </summary>
      public class MiniDB
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
                  /// Gets or sets the identity.
                  /// </summary>
                  /// <value>The identity.</value>
                  public double Identity { get; set; }
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
            double ID;
            XmlDocument Document;

            /// <summary>
            /// Contains the Database from the program
            /// </summary>
            public List<DB> DataBase;

                  
            /// <summary>
            /// Adds the key to the database 
            /// </summary>
            /// <returns><c>true</c>, if key was added, <c>false</c> otherwise.</returns>
            /// <param name="key">Key.</param>
            /// <param name="value">Value.</param>
            public bool AddKey(object key, object value)
            {
                  bool keyAdded = false;



                  this.Load();
                  if (this.GetKey(key) != null)
                   {
                        return false; 
                   }
                
                  ID++;
                  Document = new XmlDocument();
                  Document.Load(DBName);
                  XmlNode root = Document.FirstChild;
                  XmlElement element = Document.CreateElement(KeysName);
                  //key:relationship:hash
                  element.SetAttribute("Value", $"[{key}:{RelationOrType}:{ID}]{value}");
                  root.AppendChild(element);
                  Document.Save(DBName);
                  this.Load();

                  return keyAdded; 

            }
            /// <summary>
            /// Adds the key.
            /// </summary>
            /// <param name="key">Key.</param>
            /// <param name="value">Value.</param>
            /// <param name="relationOrType">Relation or type.</param>
            public bool AddKey(object key, object value, object relationOrType)
            {

                  bool keyAdded = false;



                  this.Load();
                  if (this.GetKey(key) != null)
                  {
                        return false;
                  }
                  ID++;
                  Document = new XmlDocument();
                  Document.Load(DBName);
                  XmlNode root = Document.FirstChild;
                  XmlElement element = Document.CreateElement(KeysName);
                  element.SetAttribute("Value", $"[{key}:{relationOrType}:{ID}]{value}");
                  root.AppendChild(element);
                  Document.Save(DBName);
                  this.Load();


                  return keyAdded; 
            }

            /// <summary>
            /// Gets the key and returns the result
            /// </summary>
            /// <returns>The key.</returns>
            /// <param name="key">Key.</param>
            public string GetKey(object key)
            {
                  for (int x = 0; x < DataBase.Count; x++)
                  {
                        if ((DataBase[x].Key).Equals(key))
                        {
                              return DataBase[x].Value;
                        }
                  }

                  return null;
            }


            /// <summary>
            /// Gets the key and returns the DB Object.
            /// </summary>
            /// <returns>The key object.</returns>
            /// <param name="key">Key.</param>
            public DB GetKeyObject(object key)
            {
                  for (int x = 0; x < DataBase.Count; x++)
                  {
                        if ((DataBase[x].Key).Equals(key))
                        {
                              return DataBase[x];
                        }
                  }

                  return null;
            }

            /// <summary>
            /// Removes the key 
            /// </summary>
            /// <returns><c>true</c>, if key was removed, <c>false</c> otherwise.</returns>
            /// <param name="keyName">Key name.</param>
            public bool RemoveKey(object keyName)
            {
                  this.Load();
                  bool removed = true;
                  try
                  {
                        for (int value = 0; value < DataBase.Count; value++)
                        {
                              if ((DataBase[value].Key).Equals(keyName))
                              {
                                    DataBase.Remove(DataBase[value]);

                                    this.RefreshDb();
                                    return removed;
                              }

                        }
                        return removed;
                  }
                  catch
                  {
                        return false;
                  }



            }
            /// <summary>
            /// Updates the key value.
            /// </summary>
            /// <returns><c>true</c>, if key value was updated, <c>false</c> otherwise.</returns>
            /// <param name="Key">Key.</param>
            /// <param name="newValue">New value.</param>
            public bool UpdateKeyValue(object Key, object newValue)
            {
                  bool refreshed = false;

                  for (int value = 0; value < DataBase.Count; value++)
                  {
                        if ((DataBase[value].Key).Equals(Key))
                        {
                              DataBase[value].Value = newValue.ToString();

                              this.RefreshDb();
                              return true;
                        }


                  }

                  return refreshed;

            }



            /// <summary>
            /// Updates the key with the object DB
            /// </summary>
            /// <returns><c>true</c>, if key was updated, <c>false</c> otherwise.</returns>
            /// <param name="keyName">Key name.</param>
            /// <param name="key">Key.</param>
            public bool UpdateKey(object keyName, DB key)
            {


                  bool refreshed = false;
                  for (int x = 0; x < DataBase.Count; x++)
                  {
                        if ((DataBase[x].Key).Equals(keyName))
                        {
                              if (key.Value != null)
                              {
                                    DataBase[x].Value = key.Value;
                              }
                              if (key.Key != null)
                              {
                                    DataBase[x].Key = key.Key;

                              }
                              if (key.Relation != null)
                              {
                                    DataBase[x].Relation = key.Relation;

                              }
                              if (key.Identity > 0)
                              {
                                    DataBase[x].Identity = key.Identity;

                              }

                              this.RefreshDb();
                              return true;
                        }
                  }



                  return refreshed;

            }
            /// <summary>
            /// Refreshs the DataBase.
            /// </summary>
            public void RefreshDb()
            {

                  XmlWriterSettings settings = new XmlWriterSettings();
                  settings.Indent = true;
                  settings.IndentChars = ("    ");
                  settings.CloseOutput = true;
                  settings.OmitXmlDeclaration = true;

                  //Get.Wait(dbName); 
                  using (XmlWriter writer = XmlWriter.Create(DBName, settings))
                  {
                        writer.WriteStartElement("DATA");
                        writer.WriteEndElement();
                        writer.WriteEndDocument();

                        writer.Flush();
                  }
                  for (int x = 0; x < DataBase.Count; x++)
                  {
                        Document = new XmlDocument();
                        Document.Load(DBName);
                        XmlNode root = Document.FirstChild;
                        XmlElement element = Document.CreateElement(KeysName);
                        //key:relationship:hash
                        element.SetAttribute("Value", $"[{DataBase[x].Key}:{DataBase[x].Relation}:{DataBase[x].Identity}]{DataBase[x].Value}");
                        root.AppendChild(element);
                        Document.Save(DBName);
                  }
                  this.Load();

            }
            /// <summary>
            /// Loads the data base 
            /// </summary>
            public bool Load()
            {

                  DataBase = new List<DB>();
                  try
                  {
                        using (XmlReader reader = XmlReader.Create(DBName))
                        {


                              while (reader.Read())
                              {


                                    if ((reader.NodeType == XmlNodeType.Element) && reader.Name != "")//(reader.Name.IndexOf("DATE") == 0))
                                    {
                                          if (reader.HasAttributes)
                                          {

                                                if (reader.GetAttribute(0).IndexOf("[") == 0 && reader.GetAttribute(0).IndexOf("]") > 0)
                                                {

                                                      //string key = reader.GetAttribute(0).Substring(reader.GetAttribute(0).IndexOf("[") + 1, reader.GetAttribute(0).IndexOf("]") - 1);
                                                      // string value = reader.GetAttribute(0).Substring(reader.GetAttribute(0).IndexOf("]") + 1);
                                                      string key, value, relation, id, row, relationFase, subId;


                                                      row = reader.GetAttribute(0);

                                                      /*
                                                          this clear the line of the key to get at the end the key , value relation and id 
                                                          is a step by fases and a kind of hard to read but it works                                       
                                                      */
                                                      key = row.Substring(row.IndexOf("[") + 1, row.IndexOf(":") - 1);
                                                      value = row.Substring(row.IndexOf("]") + 1);
                                                      relationFase = row.Substring(row.IndexOf(":") + 1);
                                                      relation = relationFase.Substring(0, relationFase.IndexOf(":"));
                                                      subId = relationFase.Substring(relationFase.IndexOf(":") + 1);
                                                      id = subId.Substring(0, subId.IndexOf("]"));


                                                      DataBase.Add(new DB()
                                                      {

                                                            Key = key,
                                                            Value = value,
                                                            Identity = Convert.ToDouble(id),
                                                            Relation = relation

                                                      });

                                                      ID = Convert.ToDouble(id);
                                                      //Get.Blue($"Key: {key} Value: {value} ID: {id} Relation: {relation}");
                                                      //Get.Wait();


                                                }
                                          }

                                    }


                              }
                        }
                        return true; 
                  }
                  catch
                  {
                        return false; 
                  }
            }

            /// <summary>
            /// Load the specified database
            /// </summary>
            /// <param name="db">Db.</param>
            public bool Load(object db)
            {
                  DBName = db.ToString();
                  DataBase = new List<DB>();
                  bool loaded = false;
                  try
                  {
                        using (XmlReader reader = XmlReader.Create(DBName))
                        {


                              while (reader.Read())
                              {


                                    if ((reader.NodeType == XmlNodeType.Element) && reader.Name != "")//(reader.Name.IndexOf("DATE") == 0))
                                    {
                                          if (reader.HasAttributes)
                                          {

                                                if (reader.GetAttribute(0).IndexOf("[") == 0 && reader.GetAttribute(0).IndexOf("]") > 0)
                                                {

                                                      //string key = reader.GetAttribute(0).Substring(reader.GetAttribute(0).IndexOf("[") + 1, reader.GetAttribute(0).IndexOf("]") - 1);
                                                      // string value = reader.GetAttribute(0).Substring(reader.GetAttribute(0).IndexOf("]") + 1);
                                                      string key, value, relation, id, row, relationFase, subId;


                                                      row = reader.GetAttribute(0);

                                                      /*
                                                          this clear the line of the key to get at the end the key , value relation and id 
                                                          is a step by fases and a kind of hard to read but it works                                       
                                                      */
                                                      key = row.Substring(row.IndexOf("[") + 1, row.IndexOf(":") - 1);
                                                      value = row.Substring(row.IndexOf("]") + 1);
                                                      relationFase = row.Substring(row.IndexOf(":") + 1);
                                                      relation = relationFase.Substring(0, relationFase.IndexOf(":"));
                                                      subId = relationFase.Substring(relationFase.IndexOf(":") + 1);
                                                      id = subId.Substring(0, subId.IndexOf("]"));


                                                      DataBase.Add(new DB()
                                                      {

                                                            Key = key,
                                                            Value = value,
                                                            Identity = Convert.ToDouble(id),
                                                            Relation = relation

                                                      });

                                                      ID = Convert.ToDouble(id);
                                                      //Get.Blue($"Key: {key} Value: {value} ID: {id} Relation: {relation}");
                                                      //Get.Wait();


                                                }
                                          }

                                    }


                              }


                        }

                        return true;
                  }catch
                  {
                        return loaded;    
                  }
            }

            /// <summary>
            /// Create the specified Database.
            /// </summary>
            /// <param name="dbName">Db name.</param>
            public void Create(string dbName)
            {

                        if(this.Load(dbName) == false)
                  {
                        Writer.Write(dbName, "");

                  }



                  DBName = dbName;
                  XmlWriterSettings settings = new XmlWriterSettings();
                  settings.Indent = true;
                  settings.IndentChars = ("    ");
                  settings.CloseOutput = true;
                  settings.OmitXmlDeclaration = true;

                  //Get.Wait(dbName); 
                  using (XmlWriter writer = XmlWriter.Create(dbName, settings))
                  {
                        writer.WriteStartElement("DATA");
                        writer.WriteEndElement();
                        writer.WriteEndDocument();

                        writer.Flush();
                  }
            }


            /// <summary>
            /// Create the DB file.
            /// </summary>
            public void Create()
            {
                  string dbName = DBName;

                  if (this.Load(dbName) == false)
                  {
                        Writer.Write(dbName, "");

                  }


                  DBName = dbName;
                  XmlWriterSettings settings = new XmlWriterSettings();
                  settings.Indent = true;
                  settings.IndentChars = ("    ");
                  settings.CloseOutput = true;
                  settings.OmitXmlDeclaration = true;

                  //Get.Wait(dbName); 
                  using (XmlWriter writer = XmlWriter.Create(dbName, settings))
                  {
                        writer.WriteStartElement("DATA");
                        writer.WriteEndElement();
                        writer.WriteEndDocument();

                        writer.Flush();
                  }
            }
            /// <summary>
            /// Initializes a new instance of the <see cref="T:QuickTools.MiniDB"/> VERY IMPORTANT WHEN INITIALIZES LIKE THIS 
            /// IT WILL NOT LOAD THE DATABASE IT WILL HAVE TO BE LOADED MANUALLY BY CALLING  THE  Load() METHOD.
            /// </summary>
            public MiniDB()
            {
                  DBName = "MINIDB.xml";
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
                  this.Load();
            }
            /// <summary>
            /// Initializes a new instance of the <see cref="T:QuickTools.MiniDB"/> class.
            /// </summary>
            /// <param name="dbName">Db name.</param>
            /// <param name="autoLoad">If set to <c>true</c> auto load.</param>
            public MiniDB(string dbName, bool autoLoad)
            {
                  DBName = dbName;
                  KeysName = "Key";
                  RelationOrType = "NULL";
                  ID = 1000;
                  if (autoLoad)
                  {

                        this.Load();
                  }

            }
            /// <summary>
            /// Initializes a new instance of the <see cref="T:QuickTools.MiniDB"/> class.
            /// </summary>
            /// <param name="dbName">Db name.</param>
            /// <param name="keyName">Key name.</param>
            /// <param name="relationOrType">Relation or type.</param>
            public MiniDB(string dbName, string keyName, string relationOrType)
            {
                  DBName = dbName;
                  KeysName = keyName;
                  RelationOrType = relationOrType;
                  ID = 1000;

                  this.Load();

            }
            /// <summary>
            /// Initializes a new instance of the <see cref="T:QuickTools.MiniDB"/> class.
            /// </summary>
            /// <param name="dbName">Db name.</param>
            /// <param name="keyName">Key name.</param>
            /// <param name="relationOrType">Relation or type.</param>
            /// <param name="id">Identifier.</param>
            public MiniDB(string dbName, string keyName, string relationOrType, double id)
            {
                  DBName = dbName;
                  KeysName = keyName;
                  RelationOrType = relationOrType;
                  ID = id;
                  this.Load();


            }
      }
}
