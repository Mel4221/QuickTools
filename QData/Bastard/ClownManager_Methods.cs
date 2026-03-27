using System;
using System.IO;
using System.Collections.Generic;
using QuickTools.QCore;

namespace QuickTools.QData.Bastard
{
    public partial class ClownManager
    {

        private int AdjustedLength() { return this.BufferLength > this.StreamLength ? int.Parse(this.StreamLength.ToString()) : this.BufferLength; }
        private int NewLineLength() => Environment.NewLine.Length;

        private long AdjustedLength(long newLength)
        {
            return newLength;//this.BufferLength > newLength ? newLength : this.BufferLength;
        }
        /// <summary>
        /// Loads the or create the db file;
        /// </summary>
        public void LoadOrCreate()
        {
            if (File.Exists(this.FileName)) 
            {
                this.Load();
                return;
            }
            else
            {
                this.Create();
            }

        }
        /// <summary>
        /// Load the specified fileName.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public void Load(string fileName)
        {
            this.FileName = fileName;
            this.Load();
        }
        /// <summary>
        /// Gets the keys.
        /// </summary>
        /// <returns>The keys.</returns>
        public List<ClownKey> GetKeys()
        {
            return this.Keys;
        }
        /// <summary>
        /// Create this instance.
        /// </summary>
        public void Create()
        {
            this.TextStatus = $"Creatting..: {this.FileName}";
            if(this.AllowDebugger)Get.Yellow(this.TextStatus);
            
            if (!File.Exists(this.FileName))
            {
                File.Create(this.FileName);
                this.TextStatus = $"Already exist..: {this.FileName}";
                if (this.AllowDebugger) Get.Yellow(this.TextStatus);
            }
            return;
        }
      
        /// <summary>
        /// Gets the name of the all by.
        /// </summary>
        /// <returns>The all by name.</returns>
        /// <param name="name">Name.</param>
        public virtual List<ClownKey> GetAllByName(string name)
        {
            this.TextStatus = $"Getting all by name..: {name}";
            if (this.AllowDebugger) Get.Yellow(this.TextStatus);

            List<ClownKey> clownKeys = new List<ClownKey>();
            for (int item = 0; item < this.Keys.Count; item++)
            {
                if (this.Keys[item].Name == name)
                {
                    clownKeys.Add((this.Keys[item]));
                    this.TextStatus = $"Match found..: {name}";
                    if (this.AllowDebugger) Get.Yellow(this.TextStatus);
                }
            }
            this.TextStatus = $"Found..: {clownKeys.Count}";
            if (this.AllowDebugger) Get.Yellow(this.TextStatus);
            return clownKeys;
        }
        /// <summary>
        /// Gets the key.
        /// </summary>
        /// <returns>The key.</returns>
        /// <param name="name">Name.</param>
        public virtual ClownKey GetKey(string name)
        {
            this.TextStatus = $"Get by name..: {name}";
            if (this.AllowDebugger) Get.Yellow(this.TextStatus);

            for (int item = 0; item < this.Keys.Count; item++)
            {
                if (this.Keys[item].Name == name)
                {
                    this.TextStatus = $"Key found at index: {item}";
                    if (this.AllowDebugger) Get.Yellow(this.TextStatus);
                    return this.Keys[item];
                }
            }
            return new ClownKey();
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <returns>The value.</returns>
        /// <param name="name">Name.</param>
        public virtual string GetValue(string name)
        {
            return this.GetKey(name).Value;
        }
        /// <summary>
        /// Searchs the name of the all by.
        /// </summary>
        /// <returns>The all by name.</returns>
        /// <param name="name">Name.</param>
        public virtual List<ClownKey> SearchAllByName(string name)
        {
            this.TextStatus = $"Search all by name..: {name}";
            if (this.AllowDebugger) Get.Yellow(this.TextStatus);

            List<ClownKey> keys = new List<ClownKey>();
            for (int item = 0; item < this.Keys.Count; item++)
            {
                if (this.Keys[item].Name == name)
                {
                    keys.Add(this.Keys[item]);
                    this.TextStatus = $"Match found at index..: {item}";
                    if (this.AllowDebugger) Get.Yellow(this.TextStatus);

                }
            }

            return keys;
        }


        /// <summary>
        /// Drop the specified fileName.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public void Drop(string fileName)
        {
            this.TextStatus = $"Droping..: {fileName}";
            if (this.AllowDebugger) Get.Yellow(this.TextStatus);

            if (File.Exists(fileName)) 
            {
                File.Delete(fileName);
                this.TextStatus = $"Deleted..: {fileName}";
                if (this.AllowDebugger) Get.Yellow(this.TextStatus);
            }
            this.TextStatus = $"The file did not even exist..: {fileName}";
            if (this.AllowDebugger) Get.Yellow(this.TextStatus);


        }

        /// <summary>
        /// Selects all where key.
        /// </summary>
        /// <returns>The all where key.</returns>
        /// <param name="keyValue">Key value.</param>
        public List<ClownKey> SelectAllWhereKey(string keyValue)
        {
            List<ClownKey> keys = new List<ClownKey>();
            for (int key = 0; key < this.Keys.Count; key++)
            {
                if (this.Keys[key].Name == keyValue)
                {
                    keys.Add(this.Keys[key]);
                }
            }
            return keys;
        }
        /// <summary>
        /// Selects all where value.
        /// </summary>
        /// <returns>The all where value.</returns>
        /// <param name="value">Value.</param>
        public List<ClownKey> SelectAllWhereValue(string value)
        {
            List<ClownKey> keys = new List<ClownKey>();
            for(int key = 0; key < this.Keys.Count; key++)
            {
                if(this.Keys[key].Value == value)
                {
                    keys.Add(this.Keys[key]);
                }
            }
            return keys; 
        }
        /// <summary>
        /// Drop this instance.
        /// </summary>
        public void Drop()
        {
            this.Drop(this.FileName);
        }
        /// <summary>
        /// Updates the value.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="value">Value.</param>
        public virtual void UpdateValue(string name, string value)
        {
            throw new System.NotImplementedException("not implemented yet");
        }
        /// <summary>
        /// Updates the name of the key value by.
        /// </summary>
        /// <param name="key">Key.</param>
        public virtual void UpdateKeyValueByName(ClownKey key)
        {
            this.TextStatus = $"Update key value by name..: {key.Name}";
            if (this.AllowDebugger) Get.Yellow(this.TextStatus);

            for (int item = 0; item < this.Keys.Count; item++)
            {
                if (this.Keys[item].Name == key.Name)
                {
                    this.TextStatus = $"Match found at index..: {item}";
                    if (this.AllowDebugger) Get.Yellow(this.TextStatus);

                    this.Keys[item].Name = key.Name;
                    this.Keys[item].Value = key.Value;
                    this.Keys[item].Buffer = key.Buffer;
                    this.Keys[item].Index = key.Index;
                    this.Keys[item].Length = key.Length;
                    return;
                }
            }
        }
    }
}
