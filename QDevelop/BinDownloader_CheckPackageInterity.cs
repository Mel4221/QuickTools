using System;
using QuickTools.QCore;

namespace QuickTools.QDevelop
{
    public partial class BinDownloader
    {

        /// <summary>
        /// Checks the package integrity one by one but if it fails it does not mean that 
        /// the package is currpted it just means that the package is not matching on the hash 
        /// and it could be due to a recent update so if the current version of QuickTools in the testing version
        /// or any other file has recent commits just disregard the red flag
        /// </summary>
        /// <param name="package">Package.</param>
        public void CheckPackageIntegrity(ref Package package)
        {
            try
            {
                this.CurrentTextStatus = $"CHECKING PACKAGES INTEGRITY...";
                if (this.AllowDeubbuger) Get.Yellow(this.CurrentTextStatus);
                for (int item = 0; item < package.DependencyFiles.Count; item++)
                {
                    string fhash, dhash, dfile, file, name;
                    fhash = package.DependencyFiles[item].Hash;
                    file = package.DependencyFiles[item].Name;
                    dfile = $"{this.OutPutPath}{file}";
                    name = Get.FileNameFromPath(dfile);
                    dhash = new Get().HashCodeFromFile(dfile, this.AllowDeubbuger).ToString();
                    bool check = dhash == fhash;
                    string status = check == true ? "PASS" : "FAIL";
                    this.CurrentIntStatus = Get.StatusNumber(item, package.DependencyFiles.Count);
                    try
                    {


                        if (check) this.CurrentTextStatus = $"FILE: [{name}] CHECK: [{status}]";
                        if (!check) this.CurrentTextStatus = $"FILE: [{name}] CHECK: [{status}] DUE TO DOES NOT MATCH THE HASH, EXPECTED: [{fhash}] CURRENT: [{dhash}]";
                        if (check && this.AllowDeubbuger) Get.Green(this.CurrentTextStatus);
                        if (!check && this.AllowDeubbuger) Get.Red(this.CurrentTextStatus);
                        Get.WaitTime(this.PrintDelay);
                    }
                    catch
                    {
                        this.CurrentTextStatus = $"[{name}] HAS FAIL THE INTEGRITY CHECK";
                        if (this.AllowDeubbuger) Get.Red(this.CurrentTextStatus);
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }



        }
    }
}
