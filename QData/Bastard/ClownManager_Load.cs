
using System.IO;
using QuickTools.QCore;
using QuickTools.QConsole;
namespace QuickTools.QData.Bastard
{
    public partial class ClownManager
    {
        /// <summary>
        /// Load this instance.
        /// </summary>
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
                    this.TextStatus = $"{Get.Status(current, goal)}";
                    if (this.AllowDebugger)
                    {
                        bar.Label = $"Loading Values...";
                        bar.Display(this.TextStatus);

                    }
                    ClownKey clownKey = this.Keys[item];
                    buffer = new byte[clownKey.Length];
                    stream.Seek(clownKey.Index, SeekOrigin.Begin);
                    BinaryReader reader = new BinaryReader(stream);
                    reader.Read(buffer, 0, buffer.Length);
                    bool isBinary = this.Keys[item].Name[0]=='@';
                    if (isBinary)
                    {
                        this.Keys[item].Buffer = buffer;
                    }if(!isBinary)
                    {
                        this.Keys[item].Value = IConvert.ToString(buffer);
                    }

                }
            }
            this.TextStatus = $"Loading values Completed!!!";
            if (this.AllowDebugger) Get.Yellow(this.TextStatus);
        }
    }
}
