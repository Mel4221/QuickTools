using System;
using System.IO; 
using System.Collections.Generic;
using System.Text;
using QuickTools.QCore;
using QuickTools.QIO;
using System.Threading;
using QuickTools.QConsole;

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

    public partial class QKeyManager : IDisposable
    {

    }
    /// <summary>
    /// This object creates key files to store data in a key value format for example
    /// KeyName=Value; 
    /// and allow you also to modify the style on how it should be formated such as 
    /// KeyName>Value|
    /// </summary>
    public partial class QKeyManager :Key
    {


        //private StringBuilder builder = new StringBuilder();

        /// <summary>
        /// Gets or sets the current status.
        /// </summary>
        /// <value>The current status.</value>
        public string CurrentStatus { get; set; }

        /// <summary>
        /// Gets or sets the QKey version.
        /// </summary>
        /// <value>The QK ey version.</value>
        public int QKeyId { get; set; } = IRandom.Pin(); 

        private readonly string QKey_Id_Key = "QKEYID";

        /// <summary>
        /// This are the keys that are buffered when you the ReadKeys method is called/>
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
        public QKeyManager(string fileName)
        {
            if (fileName != "" || fileName != null)
            {
                this.FileName = fileName;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:QuickTools.QData.KeyManager"/> class.
        /// </summary>
        public QKeyManager()
        {

        }
        /// <summary>
        /// provides the file name for the file containing the keys
        /// </summary>
        public string FileName { get; set; } = Get.DataPath("db")+ "KeyFile.qkey";

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
        /// Creates the on data path.
        /// </summary>
        public void CreateOnDataPath() => this.CreateOnDataPath(this.FileName); 

        /// <summary>
        /// Creates the on data path.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public void CreateOnDataPath(string fileName)
        {
            fileName = Get.DataPath("db") + fileName; 
            if (!File.Exists(fileName))
            {
                File.Create(fileName);
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
        public  Key GetKey(string key)
        {
            this.Keys = this.ReadKeys();
            foreach (Key k in this.Keys)
            {
                if (k.Name == key)
                {
                    return  k;
                }
            }
            return  new Key()
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
            this.ReadKeys();
        }

        /// <summary>
        /// Saves the current Buffer keys 
        /// </summary>
        public void SaveKeys()
        {
            List<Key> _ = this.Keys;
            ref List<Key> keys = ref _; 
            this.WriteKeys(ref keys);
        }

     
        /// <summary>
        /// Adds the key.
        /// </summary>
        /// <param name="key">Key.</param>
        /// <param name="value">Value.</param>
        public void AddKey(string key, string value)
        {
            if (CheckForNotRepetedKeys)
            {
                foreach (Key k in this.Keys)
                {
                    if (key == k.Name)
                    {
                        throw new Exception("Key Already Set");
                    }
                }
            }
            this.Keys.Add(new Key() { Name=key,Value=value});
        }

        /// <summary>
        /// Adds a new key to the list 
        /// </summary>
        /// <param name="key">Key.</param>
        public void AddKey(ref Key key)
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
            //this.Keys = this.ReadKeys();
            for (int item = 0; item < this.Keys.Count; item++)
            {
                if (key.Name == this.Keys[item].Name)
                {
                    this.Keys.RemoveAt(item);
                    List<Key> _ = this.Keys; 
                    this.WriteKeys(ref _);
                    return;
                }
            }
        }


        /// <summary>
        /// Exist the specified key.
        /// </summary>
        /// <returns>The exist.</returns>
        /// <param name="key">Key.</param>
        public bool Exist(ref Key key)
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

        public int Get_QKey_Version() => Get_QKey_Version(this.FileName);

        public int Get_QKey_Version(string fileName)
        {
            int version = 0;
            if (!File.Exists(this.FileName))
            {
                return version; 
            }
            string textVersion = File.ReadAllLines(fileName)[0];
            string temp = "";
            foreach (char ch in textVersion)
            {
                if (Get.IsNumber(ch))
                {
                    temp += ch;
                }
            }
            int.TryParse(temp, out version); 
            return version;
        }


        /// <summary>
        /// Matchs the identifier.
        /// </summary>
        /// <returns><c>true</c>, if identifier was matched, <c>false</c> otherwise.</returns>
        public bool MatchId() => this.MatchId(this.FileName);


        
         /// <summary>
         /// Matchs the identifier.
         /// </summary>
         /// <returns><c>true</c>, if identifier was matched, <c>false</c> otherwise.</returns>
         /// <param name="fileName">File name.</param>
        public bool MatchId(string fileName)
        {
          
            if(this.QKeyId == this.Get_QKey_Version(fileName))
            {
                return true; 
            }else
            {
                return false; 
            }
            //int version = int.Parse(textVersion.Substring(textVersion.IndexOf('='),textVersion.IndexOf(';')); 
         }


        /// <summary>
        /// Writes the keys to the given file
        /// </summary>
        /// <param name="fileName">File name.</param>
        /// <param name="keys">Keys.</param>
        public void WriteKeys(string fileName, ref List<Key> keys)
        {
            //this.builder = new StringBuilder();
            if (keys.Count == 0) throw new ArgumentException("No Keys were provided!!!");
            if (!File.Exists(fileName)) throw new FileNotFoundException($"The Key File was not Found!!! at the Given Path: {fileName}");
            using (FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                int isFirst, current, goal;
                byte[] buffer = new byte[0];
                long indexer = 0;
                isFirst = 0;
                current = 0;
                goal = keys.Count;
                QProgressBar bar = new QProgressBar(); 

                         
                    using (BinaryWriter writer = new BinaryWriter(stream))
                    {
                    for (int item = 0; item < keys.Count; item++)
                    {
                        this.CurrentStatus = $"Writting Keys... Status: [{Get.Status(current, goal)}]";
                        if (this.AllowDebugger)
                        {
                            bar.Label = this.CurrentStatus;
                            bar.Display(Get.Status(current, goal));
                        }
                        if (isFirst == 1)
                        {
                            buffer = Get.Bytes($"{keys[item].Name}{keys[item].KeyAssingChar}{keys[item].Value}{keys[item].KeyTerminatorChar}\n");
                            writer.Write(buffer, 0, buffer.Length);
                        }
                        if (isFirst == 0)
                        {
                            buffer = Get.Bytes($"{QKey_Id_Key}{keys[0].KeyAssingChar}{this.QKeyId}{keys[0].KeyTerminatorChar}\n");
                            writer.Write(buffer, 0, buffer.Length);
                            isFirst = 1;
                        }
                     
                        indexer += buffer.Length;
                        current++;
                        stream.Seek(indexer, SeekOrigin.Begin);

                    }
                }
                   
               
            }
            //this.builder.Append();
           
            //File.WriteAllText(fileName, this.builder.ToString());
            /*
            using (FileStream stream = new FileStream(fileName, FileMode.Append, FileAccess.Write))
            { 
                byte[] buffer = Get.Bytes(this.builder.ToString());
                stream.Write(buffer, 0, buffer.Length);
            }
            */
        }

        /// <summary>
        /// Writes the keys.
        /// </summary>
        /// <param name="keys">Keys.</param>
        public void WriteKeys(ref List<Key> keys) => this.WriteKeys(this.FileName, ref keys); 
        
        
      
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
                Check check = new Check();
                check.Start(); 
                this.Errors = new List<Error>();
                this.Keys.Clear(); 
                //string key, temp, input;
                string key, input;
                StringBuilder temp;
                char term, assing;
                bool idLoaded = false; 
                key = "";
                temp = new StringBuilder(); 
                input = IConvert.ToString(Binary.Reader(keyFile));
               
                term = this.KeyTerminatorChar;
                assing = this.KeyAssingChar;
                
                QProgressBar bar = new QProgressBar();

                for (ch = 0; ch < input.Length; ch++)
                {
                try
                {

                    this.CurrentStatus = $"Loading Keys Please Wait... Status: [{Get.Status(ch, input.Length - 1)}] Keys: [{this.Keys.Count}]";
                    if (AllowDebugger)
                    {
                        bar.Label = this.CurrentStatus;
                        bar.Display(Get.Status(ch, input.Length));
                    }
                    if (input[ch] == assing)
                    {
                        key = temp.ToString();
                        temp.Clear();
                    }
                    if (input[ch] == term)
                    {
                        if (idLoaded)
                        {
                            this.Keys.Add(new Key()
                            {
                                Name = key.Replace(" ", "").Replace("\n", "").Replace("\t", ""),
                                Value = temp.ToString()
                            });
                        }
                        idLoaded = true; 

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
                        $"\n Key={key} Temp={temp} KeysCount={this.Keys.Count}"

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
                if(this.AllowDebugger)
                {
                    Get.Box($"Execution Time: {check.Stop()}"); 
                }
            return this.Keys;


        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~QKeyManager() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
