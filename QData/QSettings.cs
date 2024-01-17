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
using QuickTools.QCore; 
using System.Collections.Generic;
namespace QuickTools.QData
{



      /// <summary>
      /// QSettings helps to create a settings model based on xml 
      /// it actually works pretty well and it is very simple to use 
      /// </summary>
      public class QSettings
      {

        /*
            Start Fields
         */
        /// <summary>
        /// Sedttigns Object
        /// </summary>
        public class Settings
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
                    /// contains the group name of the setting to create a relationship between them
                    /// </summary>
                  public string Group { get; set; } = "Setting";

        }




            /// <summary>
            /// This will contains the list of settings
            /// </summary>
            public List<Settings> SettingsList { get; set; } = new List<Settings>(); 
            /// <summary>
            /// contains the mini db for the settings 
            /// </summary>
            private MiniDB SettingsDB { get; set; } = new MiniDB();
            /// <summary>
            /// Gets or sets the name of the file.
            /// </summary>
            /// <value>The name of the file.</value>
            public string FileName { get; set; } = null;
            
            /// <summary>
            /// Allow to print to the console the current status of the internal MiniDB
            /// </summary>
            public bool AllowDebugger { get; set; } = false; 

            

            /*
                End Fields
             */

            /// <summary>
            /// Create the specified settings file with the given name .
            /// </summary>
            /// <returns> true if created was sucessfull otherwise flase </returns>
            public bool Create()
            {
                if(this.FileName == null)
                {
                    return false;
                }
                else
                {
                    this.SettingsDB = new MiniDB(this.FileName);
                    this.SettingsDB.Create(); 
                    return true; 
                }
            }


            /// <summary>
            /// Load to memory the xml file 
            /// </summary>
            public void Load()
            {
               if(this.FileName != null)
            {
                this.SettingsList = new List<Settings>(); 
                this.SettingsDB = new MiniDB(this.FileName);
                this.SettingsDB.AllowDebugger = this.AllowDebugger; 
                this.SettingsDB.Load();
                List<DB> db = this.SettingsDB.DataBase;
                for (int item = 0; item < db.Count; item++)
                {
                    this.SettingsList.Add(new Settings() 
                    {
                        Key = db[item].Key,
                        Value = db[item].Value,
                        Group = db[item].Relation
                    });
                }
            }
             
            }


            /// <summary>
            /// Load the specified file with the given name .
            /// </summary>
            /// <param name="fileName">File name.</param>
            public void Load(string fileName)
            {
                this.FileName = fileName;
                this.Load(); 
            }
            
            /// <summary>
            /// retuns true if it find the given key setting
            /// </summary>
            /// <param name="setting"></param>
            /// <returns></returns>
            public bool Exist(string setting)
            {
                this.Load();
                foreach(Settings item in this.SettingsList)
                {
                    if(item.Key == setting)
                    {
                        return true; 
                    }
                }
                return false; 
            }
            /// <summary>
            /// Adds the setting with the given key and value 
            /// </summary>
            /// <param name="key">Key.</param>
            /// <param name="value">Value.</param>
            public void AddSetting(string key, object value)
            {
                 this.AddSetting(key, value, "Setting"); 
            }

        /// <summary>
        /// Adds the setting with the given key and value  + a group
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="group"></param>
        public void AddSetting(string key, object value,string group)
            {
                this.Load();
                if (this.Exist(key))
                {
                    return;
                }
                this.SettingsList.Add(new Settings()
                {
                    Key = key,
                    Value = value.ToString(),
                    Group = group
                });
                this.Refresh();
            }
        /// <summary>
        /// Get the setting value from the key 
        /// </summary>
        /// <returns>The setting.</returns>
        /// <param name="key">Key.</param>
        public string GetSetting(string key)
            {
                  this.Load(); 
                  foreach(Settings setting in this.SettingsList)
                    {
                        if(setting.Key == key)
                        {
                            return setting.Value; 
                        }
                    }
                  return null;
            }

        /// <summary>
        /// Removes the setting from the setting file 
        /// </summary>
        /// <param name="key">Key.</param>
        public void RemoveSetting(string key)
        {
            this.Load();
            for (int item = 0; item < this.SettingsList.Count; item++)
            {
                        if (this.SettingsList[item].Key == key)
                        {
                            this.SettingsList.RemoveAt(item);
                            return; 
                        }
            }
            this.Refresh();
        }

            /// <summary>
            /// Refresh the settings values
            /// </summary>
            public void Refresh()
            {
                List<DB> db = new List<DB>();
                foreach(Settings setting in this.SettingsList)
                {
                    db.Add(new DB()
                    {
                        Key = setting.Key,
                        Value = setting.Value,
                        Relation = setting.Group
                    });
                }
                this.SettingsDB.DataBase.Clear(); 
                this.SettingsDB.DataBase = db;
                this.SettingsDB.SaveChanges(); 
            }

            /// <summary>
            /// Updates the setting with the given value 
            /// </summary>
            /// <param name="setting">Setting.</param>
            /// <param name="newValue">New value.</param>
            public void UpdateSetting(string setting, object newValue)
            {
            this.Load();
            for (int item = 0; item < this.SettingsList.Count; item++)
            {
                if (this.SettingsList[item].Key == setting)
                {
                    this.SettingsList[item].Value = newValue.ToString(); 
                    return;
                }
            }
            this.Refresh(); 
        }
        

 

        /// <summary>
        /// Delete the settings file
        /// </summary>
        public void DeleteSettingsFile()
        {
            if (File.Exists(this.FileName))
            {
                File.Delete(this.FileName); 
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:QuickTools.QSettings"/> class.
        /// The fallowing settings are applied as default : 
        /// FileName = "Settings.xml";
        /// ElementName = "Setting";
        /// GroupName = "Settings";
        /// </summary>
        public QSettings()
            {
 

            }
            /// <summary>
            /// Initializes a new instance of the <see cref="T:QuickTools.QSettings"/> class.
            /// with only the file name 
            /// </summary>
            /// <param name="fileName">File name.</param>
            public QSettings(string fileName)
            {

                  //Create();


            }
            /// <summary>
            /// Initializes a new instance of the <see cref="T:QuickTools.QSettings"/> class.
            /// </summary>
            /// <param name="fileName">File name.</param>
            /// <param name="groupName">Element name.</param>
            public QSettings(string fileName,string groupName)
            {
              
            }
    
           


    }
}
