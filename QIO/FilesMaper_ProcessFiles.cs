using System;
using QuickTools.QCore;
namespace QuickTools.QIO
{
    public partial class FilesMaper
    {
       private void ProcessFile(string path)
        {
           
            //  Get.Yellow(path);
            if (!this.IgnoreHiddenFiles)
            {
                if (this.AllowDebugger)
                {
                    Get.Yellow(path);
                }
                this.Files.Add(path);
            }
            if (this.IgnoreHiddenFiles)
            {
                bool hasHiddenFiles = this.ContainHiddenItems(path);
                if (hasHiddenFiles && this.AllowDebugger) Get.Red($"IGNORED HIDDEN FILES: [{path}]");
                if (!hasHiddenFiles)
                {
                    this.Files.Add(path);
                }
            }
        }
    }
}
