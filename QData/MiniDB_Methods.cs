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
using System.IO;
using System.Xml;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using QuickTools.QCore;

using QuickTools.QIO;

namespace QuickTools.QData
{

    /// <summary>
    /// Mini DB is a class that provide a semy no relation database 
    /// based on the key value method 
    /// </summary>
    public partial class MiniDB : IDisposable
    {



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
        public bool AddKey(object key, object value, bool autoLoad)
        {

            try
            {
                this.AddKeyOnHot(key, value, null);
                if (autoLoad)
                {
                    this.SaveChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Clear this Database by calling this.DataBase.Clear() <see cref="DataBase"/>.
        /// </summary>
        public void Clear()
        {
            this.DataBase.Clear();
        }

        /// <summary>
        /// Saves the changes that are in the <see cref="DataBase"/>
        /// </summary>
        public void SaveChanges()
        {
            this.RefreshDB();
        }
        /// <summary>
        /// Adds the key on hot and you later desides when to write it to the db file 
        /// is important to keep in mind that the hot add don't have any effect if the Refresh is not fallowed after the 
        /// addition 
        /// </summary>
        /// <param name="key">Key.</param>
        /// <param name="value">Value.</param>
        /// <param name="relation">Relation.</param>
        public void AddKeyOnHot(object key, object value, object relation)
        {
            this.ID++;
            this.DataBase.Add(new DB()
            {
                Id = this.ID,
                Key = key.ToString(),
                Value = value.ToString(),
                Relation = relation.ToString(),
                IsEmpty = false//this was always supposed to be here but it seems i forgot that i had to add it 
            });

        }

        //private StringBuilder container = new StringBuilder(); 
        /// <summary>
        /// This saves the Database that is on memory to the database file 
        /// is important to keep in mind that the hot add don't have any effect if the Refresh is not fallowed after the 
        /// addition 
        /// </summary>
        public void HotRefresh()
        {
            this.RefreshDB();
            /*
                  container.Append("<DATA>\n");
                  for(int index =0;index<this.DataBase.Count; index++)
                  {
                        container.Append(this.DataBase[index].ToString("hot")+"\n");
                  }
                  container.Append("</DATA>\n");
                  Writer.Write(this.DBName,container.ToString());
            */
        }

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
        /// <param name="relation">Relation.</param>
        /// <param name="autoLoad">If set to <c>true</c> auto load.</param>
        bool AddKey(object key, object value, object relation, bool autoLoad)
        {
            try
            {
                this.AddKeyOnHot(key, value, relation);
                if (autoLoad)
                {
                    this.RefreshDB();
                }
                return true;
            }
            catch
            {
                return false;
            }

            /*
                  bool keyAdded = false;


                  if (autoLoad == true)
                  {
                        this.Load();
                  }
                  if ((AllowRepeatedKeys == false) && ((string)relation == "NULL") &&  (ID  <= 0))
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
                        element.SetAttribute("Value", $"[{key}:{relation}:{ID}]{value}");
                        root.AppendChild(element);
                        Document.Save(DBName);
            

                  keyAdded = true;
                  if(autoLoad == true)
                  {
                        this.Load();
                  }
                  return keyAdded;
            */
        }
        /// <summary>
        /// Adds the key to the database 
        /// </summary>
        /// <returns><c>true</c>, if key was added, <c>false</c> otherwise.</returns>
        /// <param name="key">Key.</param>
        /// <param name="value">Value.</param>
        bool AddKey(object key, object value)
        {
            try
            {
                this.AddKeyOnHot(key, value, null);

                this.RefreshDB();

                return true;
            }
            catch
            {
                return false;
            }

        }





        /*
         DB AddKey(string key, string value, string relation)
        {


              ID++;
              Document = new XmlDocument();
              Document.Load(DBName);
              XmlNode root = Document.FirstChild;
              XmlElement element = Document.CreateElement(KeysName);
              //key:relationship:hash
              element.SetAttribute("Value", $"[{key}:{relation}:{ID}]{value}");
              root.AppendChild(element);
              Document.Save(DBName);
              this.Load();

              return new DB
              {
                    Key = key,
                    Relation = RelationOrType,
                    Id = ID,
                    Value = value 
              };

        }
        */
        /// <summary>
        /// Adds the key.
        /// </summary>
        /// <param name="key">Key.</param>
        /// <param name="value">Value.</param>
        /// <param name="relationOrType">Relation or type.</param>
        public bool AddKey(object key, object value, object relationOrType)
        {
            try
            {
                this.AddKeyOnHot(key, value, relationOrType);
                this.RefreshDB();

                return true;
            }
            catch
            {
                return false;
            }

            /*
                  bool keyAdded = false;


                  if (ResentLoaded == false)
                  {
                        this.Load();
                  }
                  if ((this.GetKey(key) != null))
                  {
                        if((AllowRepeatedKeys == false))return keyAdded;
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
            */
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
                if (DataBase[x].Key == key.ToString())
                {
                    return DataBase[x].Value;
                }
            }
            return null;
        }


        /*
         DB GetKeyObject(object key)
        {
              try
              {
                    for (int x = 0; x < DataBase.Count; x++)
                    {
                            if (DataBase[x].Key == key.ToString())
                           {
                            return DataBase[x];
                           }
                    }
                    return new DB();  
              }
              catch 
              {
            if (this.AllowDebugger)
            {
                Get.Yellow($"NO VALUES OR VALUE WERE FOUNDED THAT MATCH THAT CRITERIA SO THE RETURNED VALUE WAS NULL \n YOU ALSO MAY GET AN EXCEPTION BUT IS NORMAL SINCE THE VALUE WAS NOT FOUNDED");
            }
                       return new DB(); 
              }
        }
    */


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
                    if (DataBase[x].Key == key.ToString())
                    {
                        temp.Add(DataBase[x]);
                    }
                }
                return temp;
            }
            catch
            {
                if (this.AllowDebugger)
                {
                    Get.Yellow($"NO VALUES OR VALUE WERE FOUNDED THAT MATCH THAT CRITERIA SO THE RETURNED VALUE WAS NULL \n YOU ALSO MAY GET AN EXCEPTION BUT IS NORMAL SINCE THE VALUE WAS NOT FOUNDED");

                }
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
            //this.Load();
            bool removed = false;

            try
            {
                for (int value = 0; value < DataBase.Count; value++)
                {
                    if (DataBase[value].Key == keyName.ToString())
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
        public bool RemoveKey(int KeyIndex)
        {
            // this.Load();
            bool removed = false;
            //int KeyIndex = 1013;
            for (int x = 0; x < DataBase.Count; x++)
            {
                if (DataBase[x].Id == KeyIndex)
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
                        if (DataBase[x].Id == Convert.ToDouble(Get.Number))
                        {
                            temp.Add(DataBase[x]);
                        }
                    }
                }


                return temp;
            }
            catch
            {
                if (this.AllowDebugger)
                {
                    Get.Yellow($"NO VALUES OR VALUE WERE FOUNDED THAT MATCH THAT CRITERIA SO THE RETURNED VALUE WAS NULL \n YOU ALSO MAY GET AN EXCEPTION BUT IS NORMAL SINCE THE VALUE WAS NOT FOUNDED");

                }
                return new List<DB>();
            }
        }


        /// <summary>
        /// Updates the key value.
        /// </summary>
        /// <returns><c>true</c>, if key value was updated, <c>false</c> otherwise.</returns>
        /// <param name="key">Key.</param>
        /// <param name="newValue">New value.</param>
        public bool UpdateKeyValue(string key, object newValue)
        {
            bool refreshed = false;

            for (int value = 0; value < DataBase.Count; value++)
            {
                if (DataBase[value].Key == key)
                {
                    DataBase[value].Value = newValue.ToString();

                    // this.RefreshDB();
                    refreshed = true;
                    return refreshed;
                }


            }

            return refreshed;
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
                if (DataBase[value].Id == id)
                {
                    DataBase[value].Value = newValue.ToString();

                    //   this.RefreshDB();
                    refreshed = true;
                    return refreshed;
                }


            }

            return refreshed;
        }




        /// <summary>
        /// Updates the key where key.
        /// </summary>
        /// <returns><c>true</c>, if key where key was updated, <c>false</c> otherwise.</returns>
        /// <param name="keyName">Key name.</param>
        /// <param name="key">Key.</param>
        public bool UpdateKeyWhereKey(object keyName, DB key)
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
                    if (key.Id > 0)
                    {
                        DataBase[x].Id = key.Id;
                        refreshed = true;
                    }


                }


            }


            //this.RefreshDB();
            return refreshed;

        }




        /// <summary>
        /// Updates the key where identifier.
        /// </summary>
        /// <returns><c>true</c>, if key where identifier was updated, <c>false</c> otherwise.</returns>
        /// <param name="keyId">Key identifier.</param>
        /// <param name="key">Key.</param>
        public bool UpdateKeyWhereId(int keyId, DB key)
        {

            //this.Load(); 
            bool refreshed = false;
            //if the id is bigger than the half of the collection
            // it means that it should start by the end of the collection


            Get.Green("Forward");
            for (int x = 0; x < DataBase.Count; x++)
            {
                if (DataBase[x].Id == keyId)
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
                    if (key.Id > 0)
                    {
                        DataBase[x].Id = key.Id;
                        refreshed = true;
                    }

                    this.RefreshDB();
                    return refreshed;
                }

            }



            this.RefreshDB();
            return refreshed;

        }

        /// <summary>
        /// Refreshs the DataBase
        /// was hidden due to a mayor issue while refreshing the db manually by calling this method from outside the class
        /// used to drop and remove the entired db so until the bug is founnded this class most be hidden 
        /// </summary>
        bool RefreshDB()
        {
            bool refreshed = false;

            /* try
            {
                //ID : Key : Value : Relation
                */
            List<Key> keys = new List<Key>();
            for (int item = 0; item < this.DataBase.Count; item++)
            {
                keys.Add(new Key()
                {
                    Name = "ID",
                    Value = this.DataBase[item].Id.ToString()
                });
                keys.Add(new Key()
                {
                    Name = "Key",
                    Value = this.DataBase[item].Key
                });
                keys.Add(new Key()
                {
                    Name = "Value",
                    Value = this.DataBase[item].Value
                });
                keys.Add(new Key()
                {
                    Name = "Relation",
                    Value = this.DataBase[item].Relation
                });
            }
            if (this.AllowDebugger)
            {
                keys.ForEach((obj) => Get.Write(obj.ToString()));
                Get.Yellow($"Keys Count: [{keys.Count}]");
            }
            this.DataManager.FileName = this.DBName;
            //new KeyManager().WriteKeys(keys);  
            this.DataManager.WriteKeys(ref keys);
            

            refreshed = true;
            return refreshed;
            /*
            }
            catch
            {
                return refreshed;
            }
    */

            /*
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
                        element.SetAttribute("Value", $"[{DataBase[x].Key}:{DataBase[x].Relation}:{DataBase[x].Id}]{DataBase[x].Value}");
                        root.AppendChild(element);
                        Document.Save(DBName);
                  }
                  refreshed  = this.Load();
            */
        }
        /// <summary>
        /// Loads the data base 
        /// </summary>
        public bool Load()
        {
            if (!File.Exists(this.DBName))
            {
                this.Create();
                return false;
            }
            if (string.IsNullOrEmpty(this.DBName))
            {
                return false;
            }
            this.ResentLoaded = true;
            this.DataBase = new List<DB>();
            this.DataManager = new QKeyManager(this.DBName);
            this.DataManager.AllowDebugger = this.AllowDebugger;
            this.DataManager.LoadKeys();
            //to makes sure that we return if the keys count is cero
            if (this.DataManager.Keys.Count == 0)
            {
                return false;
            }
            int sw = 0;
            DB db = new DB();

            try
            {
                //Key : Value : Relation : Id
                //ID : Key : Value : Relation
                for (int key = 0; key < this.DataManager.Keys.Count; key++)
                {
                    switch (sw)
                    {
                        case 0:
                            db.Id = int.Parse(this.DataManager.Keys[key].Value);
                            sw++;
                            break;
                        case 1:
                            db.Key = this.DataManager.Keys[key].Value;
                            sw++;
                            break;
                        case 2:
                            db.Value = this.DataManager.Keys[key].Value;
                            sw++;
                            break;
                        case 3:
                            db.Relation = this.DataManager.Keys[key].Value;
                            this.DataBase.Add(new DB()
                            {
                                Key = db.Key,
                                Value = db.Value,
                                Id = db.Id,
                                Relation = db.Relation
                            });
                            if (this.AllowDebugger)
                            {
                                Get.WriteL($"Loading Keys: [{Get.Status(key, this.DataManager.Keys.Count - 1)}] {db.ToString()}");
                            }
                            db.Clear();
                            sw = 0;
                            this.ID++;
                            break;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.Event("MiniDB_Error", $"There was an error while loading the Database info:\n{ex}");
                return false;
            }
            /*
        try
        {

            return true; 
        }
        catch
        {
            return false; 
        }
        */









            /*
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

                                                      
                                                          this clear the line of the key to get at the end the key , value relation and id 
                                                          is a step by fases and a kind of hard to read but it works                                       
                                                      //Key : Value : Relation : Id
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
                                                            Id = int.Parse(id),
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
            */
        }

        /// <summary>
        /// Load the specified database
        /// </summary>
        /// <param name="db">Db.</param>
        public bool Load(string db)
        {
            this.DBName = db;
            return this.Load();



            /*
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

                                                      
                                                          this clear the line of the key to get at the end the key , value relation and id 
                                                          is a step by fases and a kind of hard to read but it works                                       
                                                      
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
                                                            Id = Convert.ToInt32(id),
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
                    */

        }

        /// <summary>
        /// Create the specified Database if returns true it means it was created sucessfully
        /// if ir returns false is that there is already a db named like that 
        /// </summary>
        /// <param name="dbName">Db name.</param>
        public bool Create(string dbName)
        {
            if (!File.Exists(dbName))
            {
                using (FileStream stream = new FileStream(dbName, FileMode.Create, FileAccess.Write))
                {
                    try
                    {

                        stream.Write(new byte[] { }, 0, 0);
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
            return true;


            /*

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
            */
        }



        /// <summary>
        /// Create the specified Database if returns true it means it was created sucessfully
        /// if ir returns false is that there is already a db named like that 
        /// </summary>
        public bool Create()
        {


            return this.Create(this.DBName);
            /*


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
            }*/
        }


        /// <summary>
        /// Drop the specified database.
        /// </summary>
        /// <returns>The drop.</returns>
        /// <param name="dbName">Db name.</param>
        public bool Drop(string dbName)
        {
            bool removed = false;
            try
            {
                if (File.Exists(dbName))
                {
                    File.Delete(dbName);
                    removed = true;
                    return removed;
                }
                return removed;

            }
            catch
            {
                return removed;
            }
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
        /// Removes all by valuePath.
        /// </summary>
        /// <param name="value">Value.</param>
        public void RemoveAllByValue(string value)
        {
            //  this.Load();
            List<DB> temp = new List<DB>();
            //    this.Load();
            for (int x = 0; x < this.DataBase.Count; x++)
            {
                if (this.DataBase[x].Value != value)
                {
                    temp.Add(DataBase[x]);
                }
                //Get.Red(DataBase[x].Relation); 
                Get.Green($" From: {DataBase.Count} Current: {x} Porcent: {Get.Status(x, DataBase.Count)}");
            }
            this.DataBase.Clear();
            this.DataBase = temp;
            RefreshDB();

        }
        /// <summary>
        /// Removes all by key.
        /// </summary>
        /// <param name="key">Key.</param>
        public void RemoveAllByKey(string key)
        {
            List<DB> temp = new List<DB>();
            // this.Load();
            for (int x = 0; x < this.DataBase.Count; x++)
            {
                if (this.DataBase[x].Key != key)
                {
                    temp.Add(DataBase[x]);
                }
                //Get.Red(DataBase[x].Relation); 
                //   Get.Green($" From: {DataBase.Count} Current: {x} Porcent: {Get.Status(x, DataBase.Count)}");
            }
            this.DataBase.Clear();
            this.DataBase = temp;

            RefreshDB();
        }
        /// <summary>
        /// Removes all by relation.
        /// </summary>
        /// <param name="relation">Relation.</param>
        public void RemoveAllByRelation(string relation)
        {
            List<DB> temp = new List<DB>();
            //this.Load();
            for (int x = 0; x < this.DataBase.Count; x++)
            {
                if (this.DataBase[x].Relation != relation)
                {
                    temp.Add(DataBase[x]);
                }
                //Get.Red(DataBase[x].Relation); 
                //  Get.Green($" From: {DataBase.Count} Current: {x} Porcent: {Get.Status(x, DataBase.Count)}");
            }
            this.DataBase.Clear();
            this.DataBase = temp;
            RefreshDB();
        }

        /// <summary>
        /// Removes  all by identifier.
        /// </summary>
        /// <param name="id">Identifier.</param>
        public void RemoveAllbyId(int id)
        {
            // this.Load();
            List<DB> temp = new List<DB>();
            //this.Load();
            for (int x = 0; x < this.DataBase.Count; x++)
            {
                if (this.DataBase[x].Id != id)
                {
                    temp.Add(DataBase[x]);
                }
                //Get.Red(DataBase[x].Relation); 
                // Get.Green($" From: {DataBase.Count} Current: {x} Porcent: {Get.Status(x, DataBase.Count)}");
            }
            this.DataBase.Clear();
            this.DataBase = temp;
            RefreshDB();
        }






        /*
       public bool IsRelated(string dbName, string value, object relation)
       {
             bool hasIt = false;
             using (MiniDB db = new MiniDB(DBName))
             {
                   db.Load();
                   if (db.SelectWhereValue(value).Relation == relation.ToString())
                   {
                         hasIt = true;
                         return hasIt;
                   }
             }
             return hasIt;
       }


       public bool IsRelated(string value, object relation)
       {
             bool hasIt = false;
             using (MiniDB db = new MiniDB(DBName))
             {
                   db.Load();
                   if(this.DataBase.SelectWhereValue(value).Relation == relation.ToString())
                   {
                         hasIt = true;
                         return hasIt; 
                   }
             }
             return hasIt;
       }
   */

        /*
        public virtual List<DB> SelectAllByValue(string dbName ,string contains)
        {
              try
              {
                    List<DB> listOfRelated;

                    using (MiniDB db = new MiniDB(dbName))
                    {
                          //Get.Wait(dbName); 
                          //Get.Wait(db.Load());
                          db.Load();

                          listOfRelated = this.DataBase.Where(a => a.Value.Contains(contains)).ToList();

                          //Get.Wait(listOfRelated.Count); 
                          return listOfRelated;
                          // selected = db.GetKey(key);
                    //}
              }
              catch 
              {
                    Get.Yellow($"NO VALUES OR VALUE WERE FOUNDED THAT MATCH THAT CRITERIA SO THE RETURNED VALUE WAS NULL \n YOU ALSO MAY GET AN EXCEPTION BUT IS NORMAL SINCE THE VALUE WAS NOT FOUNDED");
                    return new List<DB>();
              }

        }*/


        /*
          public virtual List<DB> SelectAllByValue(string contains)
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
             catch 
             {
                   Get.Yellow($"NO VALUES OR VALUE WERE FOUNDED THAT MATCH THAT CRITERIA SO THE RETURNED VALUE WAS NULL \n YOU ALSO MAY GET AN EXCEPTION BUT IS NORMAL SINCE THE VALUE WAS NOT FOUNDED");
                   return new List<DB>();
             }

       }
   */



        /*
        public virtual DB SelectWhereKey(object value)
        {
              try
              {
                    for(int db = 0; db < this.DataBase.Count; db++)
                    {
                          if(DataBase[db].Key == value.ToString())
                          {
                                return DataBase[db]; 
                          }
                    }
                    return new DB(); 
              }
              catch 
              {
                    Get.Yellow($"NO VALUES OR VALUE WERE FOUNDED THAT MATCH THAT CRITERIA SO THE RETURNED VALUE WAS NULL \n YOU ALSO MAY GET AN EXCEPTION BUT IS NORMAL SINCE THE VALUE WAS NOT FOUNDED");
                    return new DB();
              }
        }

    */


        /*
        public virtual List<DB> SelecAlltWhereKey(object value)
        {
              try
              {
                    List<DB> dbList = new List<DB>(); 
                    for (int db = 0; db < this.DataBase.Count; db++)
                    {
                          if (DataBase[db].Key == value.ToString())
                          {
                                dbList.Add(DataBase[db]); 
                          }
                    }

                    return dbList;
              }
              catch
              {
                    Get.Yellow($"NO VALUES OR VALUE WERE FOUNDED THAT MATCH THAT CRITERIA SO THE RETURNED VALUE WAS NULL \n YOU ALSO MAY GET AN EXCEPTION BUT IS NORMAL SINCE THE VALUE WAS NOT FOUNDED");
                    return new List<DB>(); 
              }
        }


        public virtual List<DB> SelectWhereKey(string dbName , string value)
        {
              try
              {
                    using (MiniDB db = new MiniDB(dbName))
                    {
                          return db.DataBase.Where(a => a.Key == value.ToString()).ToList();
                    }
              }
              catch
              {
                    Get.Yellow($"NO VALUES OR VALUE WERE FOUNDED THAT MATCH THAT CRITERIA SO THE RETURNED VALUE WAS NULL \n YOU ALSO MAY GET AN EXCEPTION BUT IS NORMAL SINCE THE VALUE WAS NOT FOUNDED");
                    return new List<DB>();
              }
        }


        public virtual DB SelectWhereValue(string dbName , string value)
        {
              try
              {

                    using (MiniDB db = new MiniDB(dbName))
                    {
                          for (int x = 0; x < db.DataBase.Count; x++)
                          {
                                if (db.DataBase[x].Value == value)
                                {
                                      return db.DataBase[x];
                                }
                          }

                    }
                    return new DB();
              }
              catch
              {
                    Get.Yellow($"NO VALUES OR VALUE WERE FOUNDED THAT MATCH THAT CRITERIA SO THE RETURNED VALUE WAS NULL \n YOU ALSO MAY GET AN EXCEPTION BUT IS NORMAL SINCE THE VALUE WAS NOT FOUNDED");
                    return new DB();
              }
        }


        public virtual DB SelectWhereValue(string value)
        {
              try
              {
                   foreach(DB db in this.DataBase)
            {
                if(db.Value == value)
                {
                    return db; 
                }
            }
            return new DB()
            {
                IsEmpty = true
            }; 

        }
              catch 
              {
                    Get.Yellow($"NO VALUES OR VALUE WERE FOUNDED THAT MATCH THAT CRITERIA SO THE RETURNED VALUE WAS NULL \n YOU ALSO MAY GET AN EXCEPTION BUT IS NORMAL SINCE THE VALUE WAS NOT FOUNDED");
            return new DB()
            {
                IsEmpty = true
            };
        }
        }

      public virtual DB SelectWhereRelation(string relation)
        {
              try
              {

                    using (MiniDB db = new MiniDB(this.DBName))
                    {
                          for (int x = 0; x < db.DataBase.Count; x++)
                          {
                                if (db.DataBase[x].Relation == relation)
                                {
                                      return db.DataBase[x];
                                }
                          }

                    }
            return new DB()
            {
                IsEmpty = true
            };
        }
              catch
              {
                    Get.Yellow($"NO VALUES OR VALUE WERE FOUNDED THAT MATCH THAT CRITERIA SO THE RETURNED VALUE WAS NULL \n YOU ALSO MAY GET AN EXCEPTION BUT IS NORMAL SINCE THE VALUE WAS NOT FOUNDED");
                    return new DB();
              }
        }



        public virtual DB SelectWhereId(int Id)
        {
              try
              {


                          for (int x = 0; x < this.DataBase.Count; x++)
                          {
                                if (this.DataBase[x].Id == Id)
                                {
                                      return this.DataBase[x];
                                }
                          }


                    return new DB();
              }
              catch
              {
                    Get.Yellow($"NO VALUES OR VALUE WERE FOUNDED THAT MATCH THAT CRITERIA SO THE RETURNED VALUE WAS NULL \n YOU ALSO MAY GET AN EXCEPTION BUT IS NORMAL SINCE THE VALUE WAS NOT FOUNDED");
                    return new DB();
              }
        }



        public virtual List<DB> SelectAllByRelation(string dbName, string relation)
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
              catch 
              {
                    Get.Yellow($"NO VALUES OR VALUE WERE FOUNDED THAT MATCH THAT CRITERIA SO THE RETURNED VALUE WAS NULL \n YOU ALSO MAY GET AN EXCEPTION BUT IS NORMAL SINCE THE VALUE WAS NOT FOUNDED");
                    return new List<DB>();
              }
        }


        public virtual List<DB> SelectAllByRelation(object relation)
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
              catch 
              {
                    Get.Yellow($"NO VALUES OR VALUE WERE FOUNDED THAT MATCH THAT CRITERIA SO THE RETURNED VALUE WAS NULL \n YOU ALSO MAY GET AN EXCEPTION BUT IS NORMAL SINCE THE VALUE WAS NOT FOUNDED");
                    return new List<DB>();
              }
        }
    */



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
