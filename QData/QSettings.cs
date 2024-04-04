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
    /// Sedttigns Object
    /// </summary>
    public class Setting
    {
        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>The key.</value>
        public string Name { get; set; } = null;

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public string Value { get; set; } = null;

        /// <summary>
        /// contains the group name of the setting to create a relationship between them
        /// </summary>
        public string Group { get; set; } = "Setting";
        /// <summary>
        /// Ises the empty.
        /// </summary>
        /// <returns><c>true</c>, if empty was ised, <c>false</c> otherwise.</returns>
        public bool IsEmpty() => string.IsNullOrEmpty(this.Name); 
        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:QuickTools.QData.Setting"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:QuickTools.QData.Setting"/>.</returns>
        public override string ToString()
        {
            return $"SETTING: [{this.Name}] VALUE: [{this.Value}] GROUP: [{this.Group}]";
        }

    }


    /// <summary>
    /// QSettings helps to create a settings model based on xml 
    /// it actually works pretty well and it is very simple to use 
    /// </summary>
    public class QSettings : Setting
    {

        /// <summary>
        /// This will contains the list of settings
        /// </summary>
        public List<Setting> Settings { get; set; } = new List<Setting>();
        /// <summary>
        /// contains the mini db for the settings 
        /// </summary>
        private MiniDB SettingsDB { get; set; } 
        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>The name of the file.</value>
        public string FileName { get; set; } = null;
        /// <summary>
        /// Allow to print to the console the current status of the internal MiniDB
        /// </summary>
        public bool AllowDebugger { get; set; } = false;
        /// <summary>
        /// Gets or sets the current text status.
        /// </summary>
        /// <value>The current text status.</value>
        public string CurrentTextStatus { get; set; } = "not-started";
        /// <summary>
        /// Gets or sets the current int status.
        /// </summary>
        /// <value>The current int status.</value>
        public int CurrentIntStatus { get; set; } = 0; 



            /// <summary>
            /// Create the specified settings file with the given name .
            /// </summary>
            /// <returns> true if created was sucessfull otherwise flase </returns>
            public bool Create()
            {
                try
                {
                    this.SettingsDB.AllowDebugger = this.AllowDebugger;
                    this.SettingsDB.DBName = this.FileName;
                    this.SettingsDB.Create();
                    return true; 
                }
                catch (Exception)
                {
                    return false;
                }
            }


        /// <summary>
        /// Load to memory the xml file 
        /// </summary>
        public void Load()
        {
            this.SettingsDB = new MiniDB(this.FileName);
            this.Settings = new List<Setting>(); 
            this.SettingsDB.Load();
            if (this.SettingsDB.DataBase.Count == 0) return;
            DB db;
            for(int item = 0; item < this.SettingsDB.DataBase.Count; item++)
            {
                this.CurrentTextStatus = $"LOADING SETTINGS: [{Get.Status(item, this.SettingsDB.DataBase.Count-1)}]";
                this.CurrentIntStatus = Get.StatusNumber(item, this.SettingsDB.DataBase.Count);
                if (this.AllowDebugger) Get.Green(this.CurrentIntStatus);
                db = this.SettingsDB.DataBase[item];
                this.Settings.Add(new Setting()
                {
                    Name = db.Key,
                    Value = db.Value,
                    Group = db.Relation
                });
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
                if (this.Settings.Count == 0) this.Load();
                for (int item = 0; item < this.Settings.Count; item++)
                {
                    Setting s = this.Settings[item];
                    if (s.Name == setting) return true;
                }
                return false; 
            }
        /// <summary>
        /// Adds the setting with the given key and value 
        /// </summary>
        /// <param name="name">Key.</param>
        /// <param name="value">Value.</param>
        public void AddSetting(string name, object value) => this.AddSetting(new Setting() { Name = name, Value = value.ToString()});

        /// <summary>
        /// Adds the setting with the given key and value  + a group
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="group"></param>
        public void AddSetting(string name, object value, string group) => this.AddSetting(new Setting() {Name= name, Value=value.ToString(),Group=group});

            
            /// <summary>
            /// Adds the setting.
            /// </summary>
            /// <param name="setting">Setting.</param>
            public void AddSetting(Setting setting)
            {
                if (setting.IsEmpty()) throw new Exception($"THE SETTING IS MISSING IT'S KEY: {setting}");
                this.Load();
                if (this.Exist(setting.Name)) throw new Exception($"SETTING ALREADY ADDED: [{setting.Name}]");
                this.Settings.Add(setting);
                this.Save();
            }
             private void Save()
            {
                this.SettingsDB = new MiniDB(this.FileName);
                this.SettingsDB.AllowDebugger = this.AllowDebugger;
                for(int item = 0; item < this.Settings.Count; item++)
                {
                    Setting s = this.Settings[item];
                    this.SettingsDB.AddKeyOnHot(s.Name, s.Value, s.Group);
                }
                this.SettingsDB.SaveChanges();
            }
            /// <summary>
            /// Get the setting value from the key 
            /// </summary>
            /// <returns>The setting.</returns>
            /// <param name="key">Key.</param>
            public string GetSetting(string key)
            {
                return this.GetSettingObject(key).Value;
            }
            /// <summary>
            /// Gets the setting object.
            /// </summary>
            /// <returns>The setting object.</returns>
            /// <param name="setting">Key name.</param>
            public Setting GetSettingObject(string setting)
            {
                if (this.Settings.Count == 0) this.Load();
                for (int item = 0; item < this.Settings.Count; item++)
                {
                    Setting s = this.Settings[item];
                    if (s.Name == setting)
                    {
                        return s; 
                    }
                }
                return new Setting() { };
            }
            /// <summary>
            /// Removes the setting from the setting file 
            /// </summary>
            /// <param name="name">Key.</param>
            public void RemoveSetting(string name)
            {
                this.Load();
                for (int item = 0; item < this.Settings.Count; item++)
                {
                    if (this.Settings[item].Name == name)
                    {
                        this.Settings.RemoveAt(item);
                        this.Save();
                        return;
                    }
                }
            }
            /// <summary>
            /// Updates the setting with the given value 
            /// </summary>
            /// <param name="setting">Setting.</param>
            /// <param name="newValue">New value.</param>
            public void UpdateSetting(string setting, object newValue) => this.UpdateSetting(new Setting() {Name=setting,Value=newValue.ToString() });
            /// <summary>
            /// Updates the setting.
            /// </summary>
            /// <param name="setting">Setting.</param>
            public void UpdateSetting(Setting setting)
            {
                if (setting.IsEmpty()) throw new Exception($"THE SETTING IS MISSING IT'S KEY: {setting}");
                    for (int item = 0; item < this.Settings.Count; item++)
                    {
                        if(this.Settings[item].Name == setting.Name)
                        {
                            this.Settings[item] = setting;
                            this.Save();
                            return;
                        }
                    }
            }
            /// <summary>
            /// Delete the settings file
            /// </summary>
            public void DeleteSettingsFile()
            {
                this.SettingsDB.DBName = this.FileName;
                this.SettingsDB.Drop();
            }
            /// <summary>
            /// Initializes a new instance of the <see cref="T:QuickTools.QData.QSettings"/> class.
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
                this.FileName = fileName; 
                this.SettingsDB = new MiniDB(this.FileName);
            }
            /// <summary>
            /// Initializes a new instance of the <see cref="T:QuickTools.QSettings"/> class.
            /// </summary>
            /// <param name="fileName">File name.</param>
            /// <param name="groupName">Element name.</param>
            public QSettings(string fileName,string groupName)
            {
                this.FileName = fileName;
                this.Group = groupName;
                this.SettingsDB = new MiniDB(this.FileName);
            }

    }
}
