using System;
using System.IO; 
using QuickTools.QIO;
using QuickTools.QCore;
using System.Collections.Generic; 
namespace QuickTools.QData
{
    /// <summary>
    /// This class take a file and devided into the given amount of files
    /// reducing the size of it into a very small chucks of itself
    /// </summary>
    internal partial class FileChoper
    {

        /// <summary>
        /// Gets the index of the file.
        /// </summary>
        /// <returns>The file index.</returns>
        /// <param name="file">File.</param>
        public string GetFileIndex(string file)
        {
            string temp;
            temp = null;
            if (file.Contains("_") || file.Contains("."))
            {
                temp = file;
                temp = temp.Substring(temp.LastIndexOf("_") + 1);
                temp = temp.Substring(0, temp.IndexOf("."));
            }
            return temp;
        }
        /// <summary>
        /// Gets the name of the file.
        /// </summary>
        /// <returns>The file name.</returns>
        /// <param name="file">File.</param>
        public string GetFileName(string file)
        {
            string temp;
            temp = null;
            if (file.Contains("_") || file.Contains("."))
            {
                temp = file;
                temp = temp.Substring(0, temp.IndexOf("_"));
            }
            return temp;
        }
        /// <summary>
        /// Filter the specified fileName and returns the one that meet the cratieriea.
        /// </summary>
        /// <returns>The filter.</returns>
        /// <param name="fileName">File name.</param>
        /// <param name="files">Files.</param>
        public string[] Filter(string fileName, string[] files)
        {
            string[] filter = null;

            List<string> list = new List<string>();



            return filter;
        }

        private bool ToBool(string value) => value == "False" ? false : true; 

        /// <summary>
        /// Reads the metadata.
        /// </summary>
        /// <returns>The metadata.</returns>
        /// <param name="file">File.</param>
        public Metadata ReadMetadata(string file)
        {
            Metadata meta = new Metadata();
            QKeyManager manager = new QKeyManager();
            List<Key> keys = manager.ReadKeys(file);
            meta.FileName = keys[0].Value;
            meta.FileHash = keys[1].Value;
            meta.From = int.Parse(keys[2].Value);
            meta.Until = int.Parse(keys[3].Value);
            meta.ChuncksSize = keys[4].Value; 
            meta.Created = keys[5].Value;
            meta.IsEncrypted = this.ToBool(keys[6].Value); 
            return meta; 
        }


        /// <summary>
        /// Join the specified file from the row files
        /// </summary>
        /// <param name="file">File.</param>
        public void Join(string file)
        {
            if (!File.Exists(file)) throw new FileNotFoundException($"The {file} was not found"); 
            string  path;
            string[] files;
            path = Get.FolderFromPath(file);
            files = new FilesMaper().GetFiles(path);
            
            /*
            name = GetFileName(file);
            id = GetFileIndex(file);
            Get.Wait($"{name} {id} {files} {path}");
            */
            //Print.List(files); 




        }

        private void BuildMetadata(string file)
        {
        
            Metadata meta = new Metadata();
            QKeyManager manager = new QKeyManager();
            List<Key> keys = new List<Key>();


            meta.FileName = file;
            meta.FileHash = Get.HashCodeFromFile(file).ToString();
            meta.Until = this.BinaryObj.BufferList.Count;
            meta.ChuncksSize = this.BinaryObj.Chunck.ToString();
            meta.IsEncrypted = this.EncryptChunks;
            meta.Created = DateTime.Now.ToString(); 

            manager.FileName = $"{this.OutputPath}{Get.FileNameFromPath(file)}";
            //manager.FileExt = this.ChopFileExtention;

            keys.Add(new Key()
            {
                Name = "FileName",
                Value = meta.FileName,
            });
            keys.Add(new Key()
            {
                Name = "FileHash",
                Value = meta.FileHash,
            });
            keys.Add(new Key()
            {
                Name = "From",
                Value = "0",
            });
            keys.Add(new Key()
            {
                Name = "Until",
                Value = meta.Until.ToString(),
            });
            keys.Add(new Key()
            {
                Name = "ChunksSize",
                Value = Get.FileSize(meta.ChuncksSize),
            });
            keys.Add(new Key()
            {
                Name = "Created",
                Value = meta.Created,
            });
            keys.Add(new Key()
            {
                Name = "IsEncrypted",
                Value = meta.IsEncrypted.ToString(),
            });
            manager.WriteKeys(ref keys); 
        }

        /// <summary>
        /// Ripe the specified file into the chuncks provided 
        /// </summary>
        /// <param name="file">File.</param>
        public void Chop(string file)
        {
            if (file == null || file == "") throw new ArgumentException("No File Provided");
            if (!Directory.Exists(this.OutputPath)) Make.Directory(this.OutputPath);

            this.BinaryObj.ReadBytes(file);
            this.BuildMetadata(file);
            int current, goal;
            string format, status;


            current = 0;
            goal = this.BinaryObj.BufferList.Count - 1;
            format = null;
            status = null;
            for (int buffer = 0; buffer < this.BinaryObj.BufferList.Count; buffer++)
            {
                status = $"File: [{file}] Buffer: [{buffer}] Status: [{Get.Status(current, goal)}]";
                format = $"{this.OutputPath}{Get.FileNameFromPath(file)}_{buffer}{this.FileExtention}";
                Binary.Writer(format, this.BinaryObj.BufferList[buffer]);
                current++;

                this.CurrentStatus = status;
                if (this.AllowDebuger)
                {
                    Get.Yellow(status);
                }
            }
            if (this.AllowDebuger) 
            {
                Get.Green($"The File Was Choped Sucessfully!!!");
            }
            status = "ok"; 
        }
    }
}
