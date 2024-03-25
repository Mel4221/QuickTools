using System;
using QuickTools.QCore;

namespace QuickTools.QIO
{
    public partial class BinDownloader
    {
        public void CheckPackageIntegrity(ref Package package)
        {
            this.CurrentStatus = $"CHECKING PACKAGES INTEGRITY...";
            if (this.AllowDeubbuger) Get.Yellow(this.CurrentStatus);
            for (int item = 0; item < package.DependencyFiles.Count; item++)
            {
                try
                {

                    string root, fhash, dhash, dfile, file, name;
                    root = package.Name;
                    fhash = package.DependencyFiles[item].Hash;
                    file = package.DependencyFiles[item].Name;
                    dfile = $"{this.OutPutPath}{root}{Get.SlashChar()}{file}";
                    name = Get.FileNameFromPath(file);
                    dhash = new Get().HashCodeFromFile(dfile, this.AllowDeubbuger).ToString();
                    bool check = dhash == fhash;
                    string status = check == true ? "PASS" : "FAIL";

                    if (check) this.CurrentStatus = $"FILE: [{name}] CHECK: [{status}]";
                    if (!check) this.CurrentStatus = $"FILE: [{name}] CHECK: [{status}] DUE TO DOES NOT MATCH THE HASH, EXPECTED: [{fhash}] CURRENT: [{dhash}]";
                    if (check && this.AllowDeubbuger) Get.Green(this.CurrentStatus);
                    if (!check && this.AllowDeubbuger) Get.Red(this.CurrentStatus);
                    Get.WaitTime(this.PrintDelay);
                }
                catch
                {
                    this.CurrentStatus = $"[{item.ToString()}] HAS FAIL THE INTEGRITY CHECK";
                    if (this.AllowDeubbuger) Get.Red(this.CurrentStatus);
                }
            }


        }
    }
}
