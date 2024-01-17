using System;
using System.IO; 
using System.Collections.Generic;
using System.Text;
using QuickTools.QCore;
namespace QuickTools.QData
{

    /// <summary>
    /// contains the format for the the key >
    /// </summary>
    public class Key
    {
     

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:QuickTools.QData.Key"/> is empty.
        /// </summary>
        /// <value><c>true</c> if is empty; otherwise, <c>false</c>.</value>
        public bool IsEmpty { get; set; } = false; 
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; } = null;
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public string Value { get; set; } = null;
        /// <summary>
        /// The key terminator char.
        /// </summary>
        public char KeyTerminatorChar { get; set; } = ';';
        /// <summary>
        /// The key assing char.
        /// </summary>
        public char KeyAssingChar { get; set; }  = '=';
        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:QuickTools.QData.Key"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:QuickTools.QData.Key"/>.</returns>
        public override string ToString()
        {
            return $"Key{this.KeyAssingChar}{this.Name}{this.KeyTerminatorChar}Value{this.KeyAssingChar}{this.Value}{this.KeyTerminatorChar}";
        }

        /// <summary>
        /// this returns the text into 2 main formats html and json 
        /// it will return the formatinto a key and value that will be understood by html
        /// and also by json engine 
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public string ToString(string format)
        {
            switch (format)
            {
                case "html":
                    return $"<Key='{this.Name}'Value='{this.Value}'/>".Replace("'", '"'.ToString());
                case "json":
                    return "{\n" +
                        $"\t'{this.Name}':".Replace("'", '"'.ToString())+
                        $"{this.Value}\n" +
                        "}";
                default:
                    return this.ToString();
            }
        }
    }


    /// <summary>
    /// This object creates key files to store data in a key value format for example
    /// KeyName=Value; 
    /// and allow you also to modify the style on how it should be formated such as 
    /// KeyName>Value|
    /// </summary>
    public class KeyManager : Key
    {

        
        private StringBuilder builder = new StringBuilder();

        /// <summary>
        /// This are the keys that are buffered when you either cal/>
        /// </summary>
        /// <value>The keys.</value>
        public List<Key> Keys { get; set; } = new List<Key>();

        /// <summary>
        /// Gets or sets the errors.
        /// </summary>
        /// <value>The errors.</value>
        public List<Error> Errors { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:QuickTools.QData.KeyManager"/> allow debugger.
        /// </summary>
        /// <value><c>true</c> if allow debugger; otherwise, <c>false</c>.</value>
        public bool AllowDebugger { get; set; } = false; 
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:QuickTools.QData.KeyManager"/> check for not
        /// repeted keys.
        /// </summary>
        /// <value><c>true</c> if check for not repeted keys; otherwise, <c>false</c>.</value>
        public bool CheckForNotRepetedKeys { get; set; } = false;
        /// <summary>
        /// Initializes a new instance of the <see cref="T:QuickTools.QData.KeyManager"/> class.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public KeyManager(string fileName)
        {
            if (fileName != "" || fileName != null)
            {
                this.FileName = fileName;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:QuickTools.QData.KeyManager"/> class.
        /// </summary>
        public KeyManager()
        {

        }
        /// <summary>
        /// provides the file name for the file containing the keys
        /// </summary>
        public string FileName { get; set; } = "KeyFile.qkey";

        enum KeyFormat
        {
            Default,
            Html,
            Json
        }



        /// <summary>
        /// Deletes the key file along with all it's data
        /// </summary>
        public void Drop()
        {
            if (File.Exists(this.FileName))
            {
                File.Delete(this.FileName);
            }
        }
        /// <summary>
        /// Create the Key File
        /// </summary>
        public void Create()
        {
            if (!File.Exists(this.FileName))
            {
                File.Create(this.FileName);
            }
        }
        /// <summary>
        /// Gets the key.
        /// </summary>
        /// <returns>The key.</returns>
        /// <param name="key">Key.</param>
        public Key GetKey(string key)
        {
            this.Keys = this.ReadKeys();
            foreach (Key k in this.Keys)
            {
                if (k.Name == key)
                {
                    return k;
                }
            }
            return new Key()
            {
                Name = null,
                Value = null,
                IsEmpty = true
            };
        }

        /// <summary>
        /// Loads the keys from the file 
        /// </summary>
        public void LoadKeys()
        {
            this.Keys = this.ReadKeys();
        }

        /// <summary>
        /// Saves the current Buffer keys 
        /// </summary>
        public void SaveKeys()
        {
            this.WriteKeys(this.Keys);
        }
        /// <summary>
        /// Adds a new key to the list 
        /// </summary>
        /// <param name="key">Key.</param>
        public void AddKey(Key key)
        {
            if (CheckForNotRepetedKeys)
            {
                foreach (Key k in this.Keys)
                {
                    if (key.Name == k.Name)
                    {
                        throw new Exception("Key Already Set");
                    }
                }
            }

            this.Keys.Add(key);


            /*
            if (key.Name != null || key.Name == "")
            {
                throw new Exception("Key name is empty");
            }
            if (this.Exist(key))
            {
                throw new Exception($"The Key.Name={key.Name} already exist");
            }
            else
            {
                

                ///this.WriteKeys(this.Keys);
            }
            */


        }
        /// <summary>
        /// Updates the key.
        /// </summary>
        /// <param name="key">Key.</param>
        public void UpdateKey(Key key)
        {
            //this.Keys = this.ReadKeys();
            for (int item = 0; item<this.Keys.Count; item++)
            {
                if (key.Name == this.Keys[item].Name)
                {
                    this.Keys[item].Value = key.Value;
                    //this.WriteKeys(this.Keys); 
                    return;
                }
            }
            //throw new Exception($"Key {key.Name} Not Found"); 
            //this.AddKey(key); 
        }
        /// <summary>
        /// Deletes the key.
        /// </summary>
        /// <param name="key">Key.</param>
        public void DeleteKey(Key key)
        {
            /*
            if (key.Name != null || key.Name == "")
            {
                throw new Exception("Key name is empty");
            }
            */
            this.Keys = this.ReadKeys();
            for (int item = 0; item < this.Keys.Count; item++)
            {
                if (key.Name == this.Keys[item].Name)
                {
                    this.Keys.RemoveAt(item);
                    this.WriteKeys(this.Keys);
                    return;
                }
            }
        }

        private bool Exist(Key key)
        {
            foreach (Key k in this.Keys)
            {
                if (k.Name == key.Name)
                {
                    return true;
                }
            }
            return false;
        }
        void WriteKeys(List<Key> keys, KeyFormat format)
        {

        }

        /// <summary>
        /// Writes the keys to the provide file 
        /// </summary>
        /// <param name="fileName">File name.</param>
        /// <param name="keys">Keys.</param>
        public void WriteKeys(string fileName, List<Key> keys)
        {
            keys.ForEach((key) => {
                this.builder.Append($"{key.Name}{key.KeyAssingChar}{key.Value}{key.KeyTerminatorChar}\n");
            });
            File.WriteAllText(fileName, this.builder.ToString());
        }

        /// <summary>
        /// Writes the keys.
        /// </summary>
        /// <param name="keys">Keys.</param>
        public void WriteKeys(List<Key> keys)
        {
            keys.ForEach((key) => {
                this.builder.Append($"{key.Name}{key.KeyAssingChar}{key.Value}{key.KeyTerminatorChar}\n");
            });
            File.WriteAllText(this.FileName, this.builder.ToString());
        }
        List<Key> ReadKeys(string input, KeyFormat format)
        {
            List<Key> keys = new List<Key>();
            return keys;
        }
        /// <summary>
        /// Reads the keys.
        /// </summary>
        /// <returns>The keys.</returns>
        /// <param name="file">File.</param>
        public List<Key> ReadKeys(string file)
        {
            this.FileName = file;
            return this.ReadKeys();
        }

        /// <summary>
        /// Reads the keys.
        /// </summary>
        /// <returns>The keys.</returns>
        public List<Key> ReadKeys()
        {
            string keyFile = this.FileName; 
            if (!File.Exists(keyFile)) throw new FileNotFoundException($"The Key {keyFile} was not found or not exist");
            int ch = 0; 
          
                List<Key> keys = new List<Key>();
                this.Errors = new List<Error>();
                //string key, temp, input;
                string key, input;
                StringBuilder temp;
                char term, assing;
                key = "";
                temp = new StringBuilder(); 
                input = File.ReadAllText(keyFile);
                term = this.KeyTerminatorChar;
                assing = this.KeyAssingChar;
                
                for (ch = 0; ch < input.Length; ch++)
                {
                try
                {
                   
                    if (AllowDebugger)
                    {
                        Get.Wait($"Loading Keys Please Wait... Status: [{Get.Status(ch,input.Length-1)}] Keys: [{keys.Count}]", true);
                    }
                    if (input[ch] == assing)
                    {
                        key = temp.ToString();
                        temp.Clear();
                    }
                    if (input[ch] == term)
                    {
                        keys.Add(new Key()
                        {
                            Name = key.Replace(" ", "").Replace("\n", "").Replace("\t", ""),
                            Value = temp.ToString()
                        });
                        //Get.Wait($"{key} : {temp}"); 
                        temp.Clear();
                    }
                    if (input[ch] != assing && input[ch] != term)
                    {
                        temp.Append(input[ch]);
                    }
                    }catch(Exception ex)
                    {
                    this.Errors.Add(new Error()
                    {
                        Message = ex.Message,
                        Type = $"The Keys were not on the correct format or damaged At the Index: {ch} From: {input.Length}" +
                        $"\n Key={key} Temp={temp} KeysCount={keys.Count}"

                    });
                }

            }
            //        }
            //catch(Exception ex)
            //{
            //    this.Errors.Add(new Error()
            //    {
            //        Message = ex.Message,
            //        Type = $"The Keys were not on the correct format or damaged At the Sector: {ch}"
            //    })
            //    //throw new Exception();
            //}

                this.FileName = keyFile;
                return keys;
        
            
        }
    }
}
