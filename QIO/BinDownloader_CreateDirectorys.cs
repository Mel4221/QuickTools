using System;
using System.IO;
using QuickTools.QCore;

namespace QuickTools.QIO
{
    public partial class BinDownloader
    {
        private void CreateDirectorys(ref Package package)
        {
            bool exist;
            string path;
            //if the output don't exist just make it 
            if (this.OutPutPath != string.Empty)
            {
                /*
                    if (this.OutPutPath[this.OutPutPath.Length - 1] != Get.SlashChar())
                    {
                        this.OutPutPath = $"{this.OutPutPath}{Get.SlashChar()}";
                    }
                */
                this.OutPutPath = Get.EndingSlash(this.OutPutPath);

                if (!Directory.Exists(this.OutPutPath))
                    Directory.CreateDirectory(this.OutPutPath);
            }

            this.OutPutPath = Get.EndingSlash($"{this.OutPutPath}{package.Name}");

            if (!Directory.Exists(this.OutPutPath)) Directory.CreateDirectory(this.OutPutPath);

            for (int item = 0; item < package.DependencyDirs.Count; item++)
            {

                path = $"{this.OutPutPath}{package.DependencyDirs[item].Name}";
                exist = Directory.Exists(path);
                if (!exist)
                {
                    GC.Collect();
                    this.CurrentStatus = $"CREATING DEPENDECY DIR: [{path}]";
                    if (this.AllowDeubbuger) Get.Blue(this.CurrentStatus);
                    Directory.CreateDirectory(path);
                    Get.WaitTime(this.PrintDelay);
                }
                if (exist)
                {
                    this.CurrentStatus = $"OMITTED ALREADY CREATED: [{path}]";
                    if (this.AllowDeubbuger) Get.Blue();
                    Get.WaitTime(this.PrintDelay);

                }
            }
        }
    }
}
