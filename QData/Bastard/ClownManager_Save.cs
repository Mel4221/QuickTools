using System;
using System.IO;
using QuickTools.QCore;
using System.Linq;
namespace QuickTools.QData.Bastard
{
    public partial class ClownManager
    {
        public void Save()
        {

            if (this.Keys.Count == 0) throw new InvalidOperationException("The list of keys is empty please add some keys...");
            byte[] buffer;
            long current, goal;
            current = 0;
            goal = this.Keys.Count;
            using (FileStream stream = new FileStream(this.FileName, FileMode.Append))
            {
                for (int item = 0; item < this.Keys.Count; item++)
                {
                    ClownKey key = this.Keys[item];
                    switch (this.SaveAsBytes)
                    {
                        case true:
                            byte[] meta = Get.Bytes($"{key.Name}[{key.Buffer.Length}]");
                            byte[] end = Get.Bytes("\n");
                            buffer = meta.Concat(key.Buffer).Concat(end).ToArray();
                            stream.Write(buffer, 0, buffer.Length);
                            break;
                        case false:
                            buffer = Get.Bytes($"{key.Name}[{key.Value.Length}]{key.Value}\n");
                            stream.Write(buffer, 0, buffer.Length);
                            break;
                    }

                }

            }
        }
    }
}
