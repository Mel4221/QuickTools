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
using System.Linq; 
using System.Data;
using System.Collections.Generic;
using System.IO;
using System.Threading; 

namespace QuickTools
{

      /// <summary>
      /// Mini DB is a class that provide a semy no relation database 
      /// based on the key value method 
      /// </summary>
      public partial class MiniDB: IDisposable
      {



            private bool Init { get; set; }
            /// <summary>
            /// Adds the key but mainly turns on or off the loaded which could help on speed up write time 
            /// below i provide the benefits from using  this method 
            /// Minutes: 2 Seconds: 28 Milliseconds: 354
            /// Minutes: 3 Seconds: 53 Milliseconds: 761
            /// Minutes: 5 Seconds: 34 Milliseconds: 55
            /// with no repeated initialization
            /// Minutes: 6 Seconds: 47 Milliseconds: 990
            /// with repatead inizialation
            /// </summary>
            /// <returns><c>true</c>, if key was added, <c>false</c> otherwise.</returns>
            /// <param name="key">Key.</param>
            /// <param name="value">Value.</param>
            /// <param name="autoLoad">If set to <c>true</c> auto load.</param>
            public bool AddKey(string key, string value,bool autoLoad)
            {
                  bool keyAdded = false;


                  if (autoLoad == true)
                  {
                        this.Load();
                  }
                  if ((AllowRepeatedKeys == false) && (RelationOrType == "NULL") &&  (ID  <= 0))
                  {
                        throw new Exception("RelationOrType is required or the AllowRepeatedKeys is Set to False or ID is not provided or set to 0");
                  }
                  if(Init == false)
                  {
                        Document = new XmlDocument();
                        Document.Load(DBName);
                        Init = true; 
                  }
                        ID++;
                        XmlNode root = Document.FirstChild;
                        XmlElement element = Document.CreateElement(KeysName);
                        //key:relationship:hash
                        element.SetAttribute("Value", $"[{key}:{RelationOrType}:{ID}]{value}");
                        root.AppendChild(element);
                        Document.Save(DBName);
            

                  keyAdded = true;
                  if(autoLoad == true)
                  {
                        this.Load();
                  }
                  return keyAdded;

            }
            /// <summary>
            /// Adds the key to the database 
            /// </summary>
            /// <returns><c>true</c>, if key was added, <c>false</c> otherwise.</returns>
            /// <param name="key">Key.</param>
            /// <param name="value">Value.</param>
            public bool AddKey(object key, object value)
            {
                  bool keyAdded = false;


                  if(ResentLoaded == false)
                  {
                        this.Load();
                  }
                  if ((this.GetKey(key) != null) && (AllowRepeatedKeys == false) || (RelationOrType == "NULL"))
                   {
                        return keyAdded; 
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
                  keyAdded = true; 
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


                  if (ResentLoaded == false)
                  {
                        this.Load();
                  }
                  if ((this.GetKey(key) != null) && (AllowRepeatedKeys == false) || (RelationOrType == "NULL"))
                  {
                        return keyAdded;
                  }
                  ID++;
                  Document = new XmlDocument();
                  Document.Load(DBName);
                  XmlNode root = Document.FirstChild;
                  XmlElement element = Document.CreateElement(KeysName);
                  element.SetAttribute("Value", $"[{key}:{relationOrType}:{ID}]{value}");
                  root.AppendChild(element);
                  Document.Save(DBName);
                  keyAdded = true; 
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
                  try
                  {
                        for (int x = 0; x < DataBase.Count; x++)
                        {
                              if ((DataBase[x].Key).Equals(key))
                              {
                                    return DataBase[x];
                              }
                        }
                        return new MiniDB.DB(); 
                  }
                  catch (Exception ex)
                  {
                        Get.Yellow($"This has been an Exception that was cosed by an object being NULL or more likely due to the object was not founded so it will not be able to return nothing but an exception  the result of this will end up being null \n"+ex);
                        return new MiniDB.DB();
                  }
            }


            /// <summary>
            /// Get the keys that match the given key 
            /// </summary>
            /// <returns>The keys.</returns>
            /// <param name="key">Key.</param>
            public List<DB> GetKeys(object key)
            {
                  try
                  {


                        List<DB> temp = new List<DB>();
                        for (int x = 0; x < DataBase.Count; x++)
                        {
                              if ((DataBase[x].Key).Equals(key))
                              {
                                    temp.Add(DataBase[x]);
                              }
                        }
                        return temp;
                  }
                  catch (Exception ex)
                  {
                        Get.Yellow($"This has been an Exception that was cosed by an object being NULL or more likely due to the object was not founded so it will not be able to return nothing but an exception  the result of this will end up being null \n" + ex);
                        return new List<DB>();
                  }
            }

            /// <summary>
            /// Removes the key 
            /// </summary>
            /// <returns><c>true</c>, if key was removed, <c>false</c> otherwise.</returns>
            /// <param name="keyName">Key name.</param>
            public bool RemoveKey(object keyName)
            {
                  this.Load();
                  bool removed = false;
                  if (this.SelectWhereKey(keyName.ToString()).Count > 1)
                  {
                        return removed; 
                  }



                  try
                  {
                        for (int value = 0; value < DataBase.Count; value++)
                        {
                              if ((DataBase[value].Key).Equals(keyName))
                              {
                                    DataBase.Remove(DataBase[value]);
                                    removed = true; 
                                    this.RefreshDB();
                                    return removed;
                              }

                        }
                        return removed;
                  }
                  catch
                  {
                        return removed;
                  }



            }

         

            /// <summary>
            /// Removes the key.
            /// </summary>
            /// <returns><c>true</c>, if key was removed, <c>false</c> otherwise.</returns>
            /// <param name="KeyIndex">Key index.</param>
               public bool RemoveKey( int KeyIndex)
            {
                  this.Load();
                  bool removed = false;
                  //int KeyIndex = 1013;
                  for (int x = 0; x <DataBase.Count; x++)
                  {
                        if (DataBase[x].Identity == KeyIndex)
                        {

                              DataBase.Remove(DataBase[x]);
                              RefreshDB();
                              //  removed = true;
                              //return removed;
                        }
                  }

                  return removed; 
            }

            /// <summary>
            /// Find the specified object that mactch the critirias.
            /// </summary>
            /// <returns>The find.</returns>
            /// <param name="cratiria">Cratiria.</param>
            public List<DB> Find(string cratiria)
            {
                  try
                  {
                        List<DB> temp = new List<DB>();

                        for (var x = 0; x < DataBase.Count; x++)
                        {

                              if (DataBase[x].Value == cratiria)
                              {
                                    temp.Add(DataBase[x]);
                              }
                              if (DataBase[x].Key == cratiria)
                              {
                                    temp.Add(DataBase[x]);
                              }
                              if (DataBase[x].Relation == cratiria)
                              {
                                    temp.Add(DataBase[x]);
                              }
                              if (Get.IsNumber(cratiria))
                              {
                                    if (DataBase[x].Identity == Convert.ToDouble(Get.Number))
                                    {
                                          temp.Add(DataBase[x]);

                                    }
                              }
                        }


                        return temp;
                  }
                  catch (Exception ex)
                  {
                        Get.Yellow($"This has been an Exception that was cosed by an object being NULL or more likely due to the object was not founded so it will not be able to return nothing but an exception  the result of this will end up being null \n" + ex);
                        return new List<DB>();
                  }
            }
         
                  

            /// <summary>
            /// Updates the key value.
            /// </summary>
            /// <returns><c>true</c>, if key value was updated, <c>false</c> otherwise.</returns>
            /// <param name="id">Identifier.</param>
            /// <param name="newValue">New value.</param>
            public bool UpdateKeyValue(int id, object newValue)
            {
                  bool refreshed = false;

                  for (int value = 0; value < DataBase.Count; value++)
                  {
                        if ((DataBase[value].Identity).Equals(id))
                        {
                              DataBase[value].Value = newValue.ToString();

                              this.RefreshDB();
                              refreshed = true;
                              return refreshed; 
                        }


                  }

                  return refreshed;

            }



            /// <summary>
            /// Updates the key with the object DB IT WILL ONLY UPDATE THE PROPERTIES THAT ARE NOT NULL SO 
            /// IF THE OBJECT PROPERTY HAS DEFINED ONLY THE VALUE TO BE CHANGED , THE VALUE WILL BE THE ONLY CHANGED          
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
                                    refreshed = true; 
                              }
                              if (key.Key != null)
                              {
                                    DataBase[x].Key = key.Key;
                                    refreshed = true;
                              }
                              if (key.Relation != null)
                              {
                                    DataBase[x].Relation = key.Relation;
                                    refreshed = true;
                              }
                              if (key.Identity > 0)
                              {
                                    DataBase[x].Identity = key.Identity;
                                    refreshed = true;
                              }

                              this.RefreshDB();
                              return refreshed;
                        }
                  }



                  return refreshed;

            }

            /// <summary>
            /// Updates the key.
            /// </summary>
            /// <returns><c>true</c>, if key was updated, <c>false</c> otherwise.</returns>
            /// <param name="keyId">Key identifier.</param>
            /// <param name="key">Key.</param>
            public bool UpdateKey(int keyId, DB key)
            {


                  bool refreshed = false;
                  for (int x = 0; x < DataBase.Count; x++)
                  {
                        if ((DataBase[x].Identity).Equals(keyId))
                        {
                              if (key.Value != null)
                              {
                                    DataBase[x].Value = key.Value;
                                    refreshed = true;
                              }
                              if (key.Key != null)
                              {
                                    DataBase[x].Key = key.Key;
                                    refreshed = true;
                              }
                              if (key.Relation != null)
                              {
                                    DataBase[x].Relation = key.Relation;
                                    refreshed = true;
                              }
                              if (key.Identity > 0)
                              {
                                    DataBase[x].Identity = key.Identity;
                                    refreshed = true;
                              }

                              this.RefreshDB();
                              return refreshed;
                        }
                  }



                  return refreshed;

            }

            /// <summary>
            /// Refreshs the DataBase.
            /// </summary>
            public bool RefreshDB()
            {
                  bool refreshed = false; 
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
                  refreshed  = this.Load();
                  return refreshed; 
            }
            /// <summary>
            /// Loads the data base 
            /// </summary>
            public bool Load()
            {
                  ResentLoaded = true; 
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
                                                            Identity = int.Parse(id),
                                                            Relation = relation

                                                      });

                                                      ID = int.Parse(id);
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
                  ResentLoaded = true; 
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
                                                            Identity = Convert.ToInt32(id),
                                                            Relation = relation

                                                      });

                                                      ID = Convert.ToInt32(id);
                                                      //Get.Blue($"Key: {key} Value: {value} ID: {id} Relation: {relation}");
                                                      //Get.Wait();


                                                }
                                          }

                                    }


                              }


                        }
                        loaded = true; 
                        return loaded;
                  }catch
                  {
                        loaded = false; 
                        return loaded;    
                  }
            }

            /// <summary>
            /// Create the specified Database if returns true it means it was created sucessfully
            /// if ir returns false is that there is already a db named like that 
            /// </summary>
            /// <param name="dbName">Db name.</param>
            public bool Create(string dbName)
            {
                  bool created = this.Load(dbName);

                  if (created == true)
                        return false; 
                  if(created == false)
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

                  return true; 
            }



            /// <summary>
            /// Create the specified Database if returns true it means it was created sucessfully
            /// if ir returns false is that there is already a db named like that 
            /// </summary>
            public bool Create()
            {
                  string dbName = DBName;

                  bool created = this.Load(dbName);
                  if (created == true)
                        return false;
                  if (created == false)
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
                  return true; 
            }


            /// <summary>
            /// Drop the specified database.
            /// </summary>
            /// <returns>The drop.</returns>
            /// <param name="dbName">Db name.</param>
            public bool Drop(string dbName)
            {
                  bool removed = false;

                  if (File.Exists(dbName))
                  {
                        File.Delete(dbName);
                        removed = true; 
                        return removed; 
                  }
                  return removed; 
            }
       

            /// <summary>
            /// Drop this database .
            /// </summary>
            /// <returns>The drop.</returns>
            public bool Drop()
            {
                  string dbName = DBName; 
                  bool removed = false;

                  if (File.Exists(dbName))
                  {
                        File.Delete(dbName);
                        removed = true;
                        return removed;
                  }
                  return removed;
            }

            /// <summary>
            /// Gets the related objects that are in the database 
            /// </summary>
            /// <returns>The related.</returns>
            /// <param name="relation">Relation.</param>
            public virtual List<DB> GetRelated(string relation)
            {
                  try
                  {
                        List<DB> listOfRelated = this.DataBase.Where(a => a.Relation == relation).ToList();

                        return listOfRelated;
                  }
                  catch (Exception ex)
                  {
                        Get.Yellow($"This has been an Exception that was cosed by an object being NULL or more likely due to the object was not founded so it will not be able to return nothing but an exception  the result of this will end up being null \n" + ex);
                        return null;
                  }
            }

            /// <summary>
            /// Gets the related.
            /// </summary>
            /// <returns>The related.</returns>
            /// <param name="dbName">Db name.</param>
            /// <param name="relation">Relation.</param>
            public virtual List<DB> GetRelated(string dbName ,string relation)
            {
                  try
                  {
                        using (MiniDB db = new MiniDB(dbName))
                        {
                              List<DB> listOfRelated = db.DataBase.Where(a => a.Relation == relation).ToList();

                              return listOfRelated;
                        }
                  }
                  catch (Exception ex)
                  {
                        Get.Yellow($"This has been an Exception that was cosed by an object being NULL or more likely due to the object was not founded so it will not be able to return nothing but an exception  the result of this will end up being null \n" + ex);
                        return new List<DB>();
                  }
            }

            /// <summary>
            /// Matchs the related value with the objects  that are in the database 
            /// </summary>
            /// <returns>The value.</returns>
            /// <param name="contains">Contains.</param>
            public virtual List<DB> MatchValue(string contains)
            {
                  try
                  {
                        List<DB> listOfRelated = this.DataBase.Where(a => a.Value.Contains(contains)).ToList();

                        return listOfRelated;
                  }
                  catch (Exception ex)
                  {
                        Get.Yellow($"This has been an Exception that was cosed by an object being NULL or more likely due to the object was not founded so it will not be able to return nothing but an exception  the result of this will end up being null \n" + ex);
                        return null;
                  }
            }


            /// <summary>
            /// Select the specified key.
            /// </summary>
            /// <returns>The select.</returns>
            /// <param name="key">Key.</param>
            public string[] Select(string key)
            {
                  this.Load();
                  string[] selected;
                  List<string> temp = new List<string>(); 
                  for(int x  = 0; x< DataBase.Count; x++)
                  {
                        if (DataBase[x].Key == key)
                        {
                              temp.Add(DataBase[x].Key); 
                        }
                  }

                  selected = new string[temp.Count];
                  for(int item = 0; item< temp.Count; item++)
                  {
                        selected[item] = temp[item]; 
                  }
                  return selected; 
            }

            /// <summary>
            /// Has the specified dbName and posibleValue.
            /// </summary>
            /// <returns>The has.</returns>
            /// <param name="dbName">Db name.</param>
            /// <param name="posibleValue">Posible value.</param>
            public bool Has(string dbName , string  posibleValue)
            {
                  bool hasIt = false; 
                  using (MiniDB db = new MiniDB(dbName))
                  {
                        db.Load(dbName);
                        for (int x = 0; x < DataBase.Count; x++)
                        {
                              if (db.DataBase[x].Value == posibleValue)
                              {
                                    hasIt = true;
                                    return hasIt; 
                              }
                        }
                  }
                  return hasIt; 
            }

            /// <summary>
            /// Has the specified posibleValue.
            /// </summary>
            /// <returns>The has.</returns>
            /// <param name="posibleValue">Posible value.</param>
            public bool Has(string posibleValue)
            {
                  bool hasIt = false;
                  using (MiniDB db = new MiniDB(DBName))
                  {
                        db.Load();
                        for (int x = 0; x < DataBase.Count; x++)
                        {
                              if (db.DataBase[x].Value == posibleValue)
                              {
                                    hasIt = true;
                                    return hasIt;
                              }
                        }
                  }
                  return hasIt;
            }



            /// <summary>
            /// Checks if thereis a relation between the value and the given relation
            /// Ises the related.
            /// </summary>
            /// <returns><c>true</c>, if related was ised, <c>false</c> otherwise.</returns>
            /// <param name="dbName">Db name.</param>
            /// <param name="value">Value.</param>
            /// <param name="relation">Relation.</param>
            public bool IsRelated(string dbName, string value, string relation)
            {
                  bool hasIt = false;
                  using (MiniDB db = new MiniDB(dbName))
                  {
                        db.Load(dbName);
                        for (int x = 0; x < DataBase.Count; x++)
                        {
                              if ((db.DataBase[x].Relation == relation ) && (value == db.DataBase[x].Value))
                              {
                                    hasIt = true;
                                    return hasIt;
                              }
                        }
                  }
                  return hasIt;
            }
            /// <summary>
            /// Ises the related.
            /// </summary>
            /// <returns><c>true</c>, if related was ised, <c>false</c> otherwise.</returns>
            /// <param name="value">Value.</param>
            /// <param name="relation">Relation.</param>
            public bool IsRelated(string value, string relation)
            {
                  bool hasIt = false;
                  using (MiniDB db = new MiniDB(DBName))
                  {
                        db.Load();
                        for (int x = 0; x < DataBase.Count; x++)
                        {
                              if ((db.DataBase[x].Relation == relation) && (value == db.DataBase[x].Value))
                              {
                                    hasIt = true;
                                    return hasIt;
                              }
                        }
                  }
                  return hasIt;
            }

            /// <summary>
            /// Selects the by value.
            /// </summary>
            /// <returns>The by value.</returns>
            /// <param name="dbName">Db name.</param>
            /// <param name="contains">Contains.</param>
            public virtual List<DB> SelectByValue(string dbName ,string contains)
            {
                  try
                  {
                        List<DB> listOfRelated;
                        using (MiniDB db = new MiniDB(dbName))
                        {
                              //Get.Wait(dbName); 
                              //Get.Wait(db.Load());
                              db.Load();
                              listOfRelated = db.DataBase.Where(a => a.Value.Contains(contains)).ToList();

                              //Get.Wait(listOfRelated.Count); 
                              return listOfRelated;
                              // selected = db.GetKey(key);
                        }
                  }
                  catch (Exception ex)
                  {
                        Get.Yellow($"This has been an Exception that was cosed by an object being NULL or more likely due to the object was not founded so it will not be able to return nothing but an exception  the result of this will end up being null \n" + ex);
                        return new List<DB>();
                  }

            }
            /// <summary>
            /// Selects the by value.
            /// </summary>
            /// <returns>The by value.</returns>
            /// <param name="contains">Contains.</param>
            public virtual List<DB> SelectByValue(string contains)
            {
                  try
                  {
                        List<DB> listOfRelated;
                        using (MiniDB db = new MiniDB(this.DBName))
                        {
                              //Get.Wait(dbName); 
                              //Get.Wait(db.Load());
                              db.Load();
                              listOfRelated = db.DataBase.Where(a => a.Value.Contains(contains)).ToList();

                              //Get.Wait(listOfRelated.Count); 
                              return listOfRelated;
                              // selected = db.GetKey(key);
                        }
                  }
                  catch (Exception ex)
                  {
                        Get.Yellow($"This has been an Exception that was cosed by an object being NULL or more likely due to the object was not founded so it will not be able to return nothing but an exception  the result of this will end up being null \n" + ex);
                        return new List<DB>();
                  }

            }




            /// <summary>
            /// Selects the where key.
            /// </summary>
            /// <returns>The where key.</returns>
            /// <param name="value">Value.</param>
            public virtual List<DB> SelectWhereKey(object value)
            {
                  try
                  {
                        using (MiniDB db = new MiniDB(this.DBName))
                        {
                              return db.DataBase.Where(a => a.Key == value.ToString()).ToList();
                        }
                  }
                  catch (Exception ex)
                  {
                        Get.Yellow($"This has been an Exception that was cosed by an object being NULL or more likely due to the object was not founded so it will not be able to return nothing but an exception  the result of this will end up being null \n" + ex);
                        return new List<DB>();
                  }
            }

            /// <summary>
            /// Selects the where value.
            /// </summary>
            /// <returns><c>true</c>, if where value was selected, <c>false</c> otherwise.</returns>
            /// <param name="dbName">Db name.</param>
            /// <param name="value">Value.</param>
            public virtual bool SelectWhereValue(string dbName , string value)
            {
                  bool val = false; 
                  using (MiniDB db = new MiniDB(dbName))
                  {
                        var result = db.DataBase.Where(a => a.Value == value).ToList(); 

                        if ((result != null) && (result[0].Value == value))
                        {
                              val = true;  
                        }
                  }
                  return val;
            }


            /// <summary>
            /// Selects the where value.
            /// </summary>
            /// <returns>The where value.</returns>
            /// <param name="value">Value.</param>
            public virtual DB SelectWhereValue(string value)
            {
                  DB dbValue;
                  try
                  {
                       
                        using (MiniDB db = new MiniDB(this.DBName))
                        {
                              var result = db.DataBase.Where(a => a.Value == value).ToList();

                              if ((result != null) && (result[0].Value == value))
                              {
                                    dbValue = result[0];
                                    return dbValue;
                              }
                        }
                        return dbValue = new DB(); 
                  }
                  catch (Exception ex)
                  {
                        Get.Yellow($"This has been an Exception that was cosed by an object being NULL or more likely due to the object was not founded so it will not be able to return nothing but an exception  the result of this will end up being null \n" + ex);
                        return new DB();
                  }
            }
            /// <summary>
            /// Selects all by value.
            /// </summary>
            /// <returns>The all by value.</returns>
            /// <param name="value">Value.</param>
            public virtual List<DB> SelectAllByValue(string value)
            {
                  try
                  {
                        using (MiniDB db = new MiniDB(this.DBName))
                        {
                              return db.DataBase.Where(a => a.Value == value).ToList();
                        }
                  }
                  catch (Exception ex)
                  {
                        Get.Yellow($"This has been an Exception that was cosed by an object being NULL or more likely due to the object was not founded so it will not be able to return nothing but an exception  the result of this will end up being null \n" + ex);
                        return new List<DB>();
                  }
            }
            /// <summary>
            /// Selects all by value.
            /// </summary>
            /// <returns>The all by value.</returns>
            /// <param name="dbName">Db name.</param>
            /// <param name="value">Value.</param>
            public virtual List<DB> SelectAllByValue(string dbName, string value)
            {
                  try
                  {

                        using (MiniDB db = new MiniDB(dbName))
                        {
                              return db.DataBase.Where(a => a.Value == value).ToList();
                        }
                  }
                  catch (Exception ex)
                  {
                        Get.Yellow($"This has been an Exception that was cosed by an object being NULL or more likely due to the object was not founded so it will not be able to return nothing but an exception  the result of this will end up being null \n" + ex);
                        return new List<DB>();
                  }

            }
            /// <summary>
            /// Selects the by relation.
            /// </summary>
            /// <returns>The by relation.</returns>
            /// <param name="dbName">Db name.</param>
            /// <param name="relation">Relation.</param>
            public virtual List<DB> SelectByRelation(string dbName, string relation)
            {
                  try
                  {
                        List<DB> listOfRelated;

                        using (MiniDB db = new MiniDB(dbName))
                        {
                              listOfRelated = db.DataBase.Where(a => a.Relation == relation).ToList();
                        }
                        return listOfRelated;
                  }
                  catch (Exception ex)
                  {
                        Get.Yellow($"This has been an Exception that was cosed by an object being NULL or more likely due to the object was not founded so it will not be able to return nothing but an exception  the result of this will end up being null \n" + ex);
                        return new List<DB>();
                  }
            }

            /// <summary>
            /// Selects the by relation.
            /// </summary>
            /// <returns>The by relation.</returns>
            /// <param name="relation">Relation.</param>
            public virtual List<DB> SelectByRelation(object relation)
            {
                  try
                  {
                        List<DB> listOfRelated;

                        using (MiniDB db = new MiniDB(this.DBName))
                        {
                              listOfRelated = db.DataBase.Where(a => a.Relation == relation.ToString()).ToList();
                        }
                        return listOfRelated;
                  }
                  catch (Exception ex)
                  {
                        Get.Yellow($"This has been an Exception that was cosed by an object being NULL or more likely due to the object was not founded so it will not be able to return nothing but an exception  the result of this will end up being null \n" + ex);
                        return new List<DB>();
                  }
            }




            /// <summary>
            /// Releases all resource used by the <see cref="T:QuickTools.MiniDB"/> object.
            /// </summary>
            public void Dispose()
            {
                  Dispose(true);
                  GC.SuppressFinalize(this);

            }
            /// <summary>
            /// Gets a value indicating whether this <see cref="T:QuickTools.MiniDB"/> is disposed.
            /// </summary>
            /// <value><c>true</c> if disposed; otherwise, <c>false</c>.</value>
            protected bool Disposed { get; private set; }
            /// <summary>
            /// Dispose the specified disposing.
            /// </summary>
            /// <param name="disposing">If set to <c>true</c> disposing.</param>
            protected virtual void Dispose(bool disposing)
            {
                  Disposed = true;
            }
      }
}
