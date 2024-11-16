
using System.IO;
using QuickTools.QCore;
using QuickTools.QConsole;
namespace QuickTools.QData.Bastard
{
    public partial class ClownManager
    {
        public void Load()
        {
            if (!File.Exists(this.FileName)) throw new FileNotFoundException(this.FileName);
            this.SoftLoad();
            if (this.Keys.Count <= 0) return;
            using (FileStream stream = new FileStream(this.FileName, FileMode.Open))
            {
                byte[] buffer;
                long current, goal;
                current = 0;
                goal = this.Keys.Count;
                QProgressBar bar = new QProgressBar();

                for (int item = 0; item < this.Keys.Count; item++)
                {
                    current = item;
                    if (this.AllowDebugger)
                    {
                        bar.Label = $"Loading Values...";
                        bar.Display(Get.Status(current, goal));
                    }
                    ClownKey clownKey = this.Keys[item];
                    buffer = new byte[clownKey.length];
                    stream.Seek(clownKey.Index, SeekOrigin.Begin);
                    BinaryReader reader = new BinaryReader(stream);
                    reader.Read(buffer, 0, buffer.Length);
                    switch (this.LoadAsBytes)
                    {
                        case true:
                            this.Keys[item].Buffer = buffer;
                            break;
                        case false:
                            this.Keys[item].Value = IConvert.ToString(buffer);
                            break;
                    }


                }
            }
        }
    }
}
