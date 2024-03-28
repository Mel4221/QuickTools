using System;
using QuickTools.QCore;

namespace QuickTools.QIO
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
                this.CurrentStatus = $"CHECKING PACKAGES INTEGRITY...";
                if (this.AllowDeubbuger) Get.Yellow(this.CurrentStatus);
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

                    try
                    {


                        if (check) this.CurrentStatus = $"FILE: [{name}] CHECK: [{status}]";
                        if (!check) this.CurrentStatus = $"FILE: [{name}] CHECK: [{status}] DUE TO DOES NOT MATCH THE HASH, EXPECTED: [{fhash}] CURRENT: [{dhash}]";
                        if (check && this.AllowDeubbuger) Get.Green(this.CurrentStatus);
                        if (!check && this.AllowDeubbuger) Get.Red(this.CurrentStatus);
                        Get.WaitTime(this.PrintDelay);
                    }
                    catch
                    {
                        this.CurrentStatus = $"[{name}] HAS FAIL THE INTEGRITY CHECK";
                        if (this.AllowDeubbuger) Get.Red(this.CurrentStatus);
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
