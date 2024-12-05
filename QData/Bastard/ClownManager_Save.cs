using System;
using System.IO;
using QuickTools.QCore;
using System.Linq;
using QuickTools.QIO;

namespace QuickTools.QData.Bastard
{
    public partial class ClownManager
    {
        /*
        using (MemoryStream ms = new MemoryStream())
{
    ms.Write(meta, 0, meta.Length);
    ms.Write(key.Buffer, 0, key.Buffer.Length);
    ms.Write(end, 0, end.Length);
    buffer = ms.ToArray();
}

        
            */
        /// <summary>
        /// Save this instance.
        /// </summary>
        public void Save()
        {

            if (this.Keys.Count == 0) throw new InvalidOperationException("The list of keys is empty please add some keys...");
            byte[] buffer;
            /*
            long current, goal;
            current = 0;
            goal = this.Keys.Count;
            */  

            Binary.Writer(this.FileName, new byte[this.Indexer]);
            Get.WaitWhileIsBusy(this.FileName,this.AllowDebugger,()=> { });
            //System.Text.Encoding.ASCII.GetBytes()
            using (FileStream stream = new FileStream(this.FileName, FileMode.OpenOrCreate,FileAccess.Write))
            {
                for (int item = 0; item < this.Keys.Count; item++)
                {

                    //Get.Red(this.Indexer);
                    //Get.Yellow(key);
                        if (this.Keys[item].HasBinaryData())
                        {
                            //Get.Wait(Get.FileSize(key.Buffer));
                            this.TextStatus = $"Saving buffer as bytes..: {Get.FileSize(this.Keys[item].Buffer)} Index: {this.Keys[item].Index}";
                            if (this.AllowDebugger) Get.Yellow(this.TextStatus);
                            using (MemoryStream ms = new MemoryStream())
                            {
                                byte[] meta = Get.Bytes($"{this.Keys[item].Name}[{this.Keys[item].Buffer.Length}]");
                                byte[] end = Get.Bytes(Environment.NewLine);
                                ms.Write(meta, 0, meta.Length);
                                ms.Write(this.Keys[item].Buffer, 0, this.Keys[item].Buffer.Length);
                                ms.Write(end, 0, end.Length);
                                buffer = ms.ToArray();
                            }
                            //buffer = meta.Concat(key.Buffer).Concat(end).ToArray();
                            stream.Seek(this.Keys[item].Index, SeekOrigin.Begin);
                            if (this.AllowDebugger) Get.Red($"BUFFER: {Get.FileSize(buffer)} INDEX: {this.Keys[item].Index}");
                            stream.Write(buffer, 0, buffer.Length);
                        }
                        if (!this.Keys[item].HasBinaryData())
                        {
                            buffer = Get.Bytes($"{this.Keys[item].Name}[{this.Keys[item].Value.Length}]{this.Keys[item].Value}{Environment.NewLine}");
                            this.TextStatus = $"Saving buffer as text..: {Get.FileSize(buffer)} Index: {this.Keys[item].Index}";
                            if (this.AllowDebugger) Get.Green(this.TextStatus);
                            stream.Seek(this.Keys[item].Index, SeekOrigin.Begin);
                            if (this.AllowDebugger) Get.Red($"BUFFER: {IConvert.ToString(buffer)} INDEX: {this.Keys[item].Index}");
                            //Get.Yellow($"FILE LENGTH: {stream.Length}");
                            stream.Write(buffer, 0, buffer.Length);
                            //Get.Wait();
                        }
                    }

                }

            }
        }
    }
