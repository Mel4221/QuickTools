using QuickTools.QIO;
using System;
using System.Collections.Generic;
using System.Text;
using QuickTools.QCore; 
using System.IO; 
namespace QuickTools.QData
{

    /// <summary>
    /// contains the format for the the key >
    /// </summary>
    public class Key
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public char KeyTerminatorChar = ';';
        public char KeyAssingChar = '=';
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

    public class KeyManager : Key
    {
        private StringBuilder builder = new StringBuilder();

        /// <summary>
        /// provides the file name for the file containing the keys
        /// </summary>
        public string FileName { get; set; } = "KeyFile";
        /// <summary>
        /// Provides the file extention for the key File 
        /// </summary>
        public string FileExt { get; set; } = ".qkey";
        enum KeyFormat
        {
            Default,
            Html,
            Json
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
            Writer.Write(fileName, this.builder.ToString());
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
            Writer.Write(this.FileName+this.FileExt, this.builder.ToString());
        }
        List<Key> ReadKeys(string input, KeyFormat format)
        {
            List<Key> keys = new List<Key>();
            return keys;
        }

       /// <summary>
       /// Reads the keys from the provided file
       /// </summary>
       /// <returns>The keys.</returns>
       /// <param name="keyFile">Key file.</param>
        public List<Key> ReadKeys(string keyFile)
        {
            if (!File.Exists(keyFile)) throw new FileNotFoundException($"The Key {keyFile} was not found or not exist");
            try
            { 
                List<Key> keys = new List<Key>();
                string key, temp, input; 
                char term, assing;
                key = "";
                temp = "";
                input = Reader.Read(keyFile); 
                term = this.KeyTerminatorChar;
                assing = this.KeyAssingChar;

                for (int ch = 0; ch<input.Length; ch++)
                {
                    if (input[ch] == assing)
                    {
                        key = temp;
                        temp = "";
                    }
                    if (input[ch] == term)
                    {
                        keys.Add(new Key()
                        {
                            Name = key.Replace(" ", "").Replace("\n","").Replace("\t",""),
                            Value = temp
                        });
                        //Get.Wait($"{key} : {temp}"); 
                        temp = "";
                    }
                    if (input[ch] != assing && input[ch] != term)
                    {
                        temp += input[ch];
                    }

                }

                this.FileName = keyFile;
                return keys;
            }
            catch
            {
                throw new Exception("The Keys were not on the correct format or damaged");
            }
        }
    }
}
