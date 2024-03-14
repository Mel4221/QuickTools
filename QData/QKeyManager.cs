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
    /// This object creates key files to store data in a key value format for example
    /// KeyName=Value; 
    /// and allow you also to modify the style on how it should be formated such as 
    /// KeyName>Value|
    /// </summary>
    public partial class QKeyManager : Key
    {




        /// <summary>
        /// Initializes a new instance of the <see cref="T:QuickTools.QData.KeyManager"/> class.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public QKeyManager(string fileName)
        {
            if (!string.IsNullOrEmpty(fileName))
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
        public string FileName { get; set; } = Get.DataPath("db") + "KeyFile.qkey";

        enum KeyFormat
        {
            Default,
            Html,
            Json
        }



        /// <summary>
        /// Tos the key list.
        /// </summary>
        /// <returns>The key list.</returns>
        /// <param name="text">Text.</param>
        public static List<Key> ToKeyList(string text, Key type)
        {
            // string keyFile = this.FileName;
            //if (!File.Exists(keyFile)) throw new FileNotFoundException($"The Key {keyFile} was not found or not exist");
            int ch = 0;
            Check check = new Check();
            check.Start();
            //StaticErrors = new List<Error>();
            List<Key> keys = new List<Key>();
            //string key, temp, input;
            string key, input;
            StringBuilder temp;
            char term, assing;
            bool idLoaded;
            idLoaded = false;
            key = "";
            temp = new StringBuilder();
            input = text;//IConvert.ToString(Binary.Reader(keyFile));

            term = type.KeyTerminatorChar;
            assing = type.KeyAssingChar;

            QProgressBar bar = new QProgressBar();

            for (ch = 0; ch < input.Length; ch++)
            {
                try
                {

                    //CurrentStatus = $"Loading Keys Please Wait... Status: [{Get.Status(ch, input.Length - 1)}] Keys: [{this.Keys.Count}]";
                    /*
                    if (AllowDebugger)
                    {
                        bar.Label = this.CurrentStatus;
                        bar.Display(Get.Status(ch, input.Length));
                    }
                    */
                    if (input[ch] == assing)
                    {
                        key = temp.ToString();
                        temp.Clear();
                    }
                    if (input[ch] == term)
                    {
                        if (idLoaded)
                        {
                            keys.Add(new Key()
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
                    // return this.Keys;
                }
                catch
                {
                    /*
                    this.Errors.Add(new Error()
                    {
                        Message = ex.Message,
                        Type = $"The Keys were not on the correct format or damaged At the Index: {ch} From: {input.Length}" +
                        $"\n Key={key} Temp={temp} KeysCount={this.Keys.Count}"

                    });
                    */
                }
            }
            return keys;

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
            this.Keys.Add(new Key() { Name = key, Value = value });
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
            for (int item = 0; item < this.Keys.Count; item++)
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

        /// <summary>
        /// Gets the QKey version.
        /// </summary>
        /// <returns>The QK ey version.</returns>
        public int Get_QKey_Version() => Get_QKey_Version(this.FileName);

        /// <summary>
        /// Gets the QKey version.
        /// </summary>
        /// <returns>The QK ey version.</returns>
        /// <param name="fileName">File name.</param>
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

            if (this.QKeyId == this.Get_QKey_Version(fileName))
            {
                return true;
            }
            else
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
            List<Key> stats = new List<Key>();
            try
            {
                using (FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    int current, goal;
                    byte[] buffer = new byte[0];
                    long indexer = 0;
                    //isFirst = 0;
                    current = 0;
                    goal = keys.Count;
                    QProgressBar bar = new QProgressBar();


                    using (BinaryWriter writer = new BinaryWriter(stream))
                    {
                        /*
                            i had to add a way to keep a control
                            on where does the QKey starts and where it ends
                            so the way to fix it was to add one , but at first
                            it was writting on top of previus written areas so 
                            the indexer had to be moved foward the length of the 
                            start tag                    
                        */
                        //buffer = Get.Bytes($"#START#\n");
                        //writer.Write(buffer, 0, buffer.Length);
                        //indexer += buffer.Length;

                        //Adding the default keyid to be able to be use depending on the situation
                        buffer = Get.Bytes($"{QKey_Id_Key}{keys[0].KeyAssingChar}{this.QKeyId}{keys[0].KeyTerminatorChar}\n");
                        writer.Write(buffer, 0, buffer.Length);
                        indexer += buffer.Length;
                        stream.Seek(indexer, SeekOrigin.Begin);

                        for (int item = 0; item < keys.Count; item++)
                        {
                            this.CurrentStatus = $"Writting Keys... Status: [{Get.Status(current, goal)}]";
                            if (this.AllowDebugger)
                            {
                                bar.Label = this.CurrentStatus;
                                bar.Display(Get.Status(current, goal));
                                //stats.Add(new Key() { Name = "status", Value = CurrentStatus});
                            }

                            buffer = Get.Bytes($"{keys[item].Name}{keys[item].KeyAssingChar}{keys[item].Value}{keys[item].KeyTerminatorChar}\n");
                            writer.Write(buffer, 0, buffer.Length);


                            indexer += buffer.Length;
                            current++;
                            stream.Seek(indexer, SeekOrigin.Begin);

                        }
                        //buffer = Get.Bytes($"#END#\n");
                        //writer.Write(buffer, 0, buffer.Length);
                        //stats.ForEach(item => Get.Write($"{item.ToString()}\n"));
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
            catch (AccessViolationException e)
            {
                Thread.Sleep(10);
                if (this.AllowDebugger)
                {
                    Get.Yellow(e.Message);
                }
                this.WriteKeys(fileName, ref keys);
            }
            catch (Exception ex)
            {
                if (this.AllowDebugger)
                {
                    Get.Red(ex);
                }
            }
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
            this.Keys = this.ReadKeys();
            return this.Keys;
        }




        /// <summary>
        /// Reads the keys.
        /// </summary>
        /// <returns>The keys.</returns>
        public List<Key> ReadKeys()
        {

            string keyFile = this.FileName;
            if (!File.Exists(keyFile)) throw new FileNotFoundException($"The Key {keyFile} was not found or not exist");
            Check check = new Check();
            check.Start();
            this.Errors = new List<Error>();
            this.Keys.Clear();
            //string key, temp, input;
            string key, input;
            StringBuilder temp;
            int ch, current, is1Next; //., is2Next;
            char term, assing;
            bool idLoaded, isOpen, isNext;
            idLoaded = false;
            isOpen = false;
            isNext = false;
            current = 0;
            is1Next = 0;
            // int ch = 0;
            //ch = 0; 
            //isCMD = false;
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
                    // Get.Write(input[ch]);
                    current = ch;
                    this.CurrentStatus = $"Loading Keys Please Wait... Status: [{Get.Status(ch, input.Length - 1)}] Keys: [{this.Keys.Count}]";
                    if (AllowDebugger)
                    {
                        bar.Label = this.CurrentStatus;
                        bar.Display(Get.Status(ch, input.Length));
                    }
                    if (input[ch] == assing && !isOpen)
                    {
                        key = temp.ToString();
                        temp.Clear();
                        isOpen = true;
                        current = IRandom.Pin();
                       // Get.Blue($"Key Founded: [{key}]");
                    }
                    if (input[ch] == term && input[ch + 1] == '\n')
                    {
                        //Get.Wait($"{input[ch]} Next: {input[ch+1]} After: {input[ch+2]}");

                        if (idLoaded)
                        {
                            Key _ = new Key()
                            {
                                Name = key.Replace(" ", "").Replace("\n", "").Replace("\t", ""),
                                Value = temp.ToString()
                            };
                            this.Keys.Add(_);
                           // Get.Green($"KEY VALUE Aquired: {_.ToString()}");
                        }
                        if (!idLoaded)
                        {
                            idLoaded = true;
                            int number;

                            bool isValid = int.TryParse(temp.ToString(),out number);
                            if (key != "QKEYID") isValid = false; 
                            if (this.AllowDebugger)
                            {
                                switch(isValid)
                                {
                                    case true:
                                                Get.Red($"ID LOADED [{temp}]");
                                                this.QKeyId = number; 
                                        break;
                                    case false:
                                                Get.Red($"\nFailed to load the QKEYID\n");
                                                
                                                Get.Beep();
                                        break;
                                }
                            }
                        }

                        //Get.Wait($"{key} : {temp}"); 
                        temp.Clear();
                        isOpen = false;
                        //is2Next = ch + 2;
                        current = IRandom.Pin();


                    }
                    if (ch == current)//(input[ch] != assing && input[ch] != term)
                    {
                       // Get.Yellow($"Appended Char: [{input[ch]}]");
                        temp.Append(input[ch]);
                    }
                }
                catch (Exception ex)
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
            if (this.AllowDebugger)
            {
                Get.WriteL("\n");
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
