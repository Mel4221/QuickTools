using System;
using System.Collections.Generic;
using System.IO;
using QuickTools.QConsole;
using QuickTools.QCore;
using QuickTools.QData;
namespace QuickTools.QIO
{
    public partial class BinBuilder
    {
        /// <summary>
        /// Delete the specified packageName.
        /// </summary>
        /// <param name="packageName">Package name.</param>
        public void Delete(string packageName)
        {
            this.Load();
            if (this.Packages.Count == 0)
            {
                this.CurrentStatus = $"FAILED TO DELETE THE PACKAGE EITHER BECAUSE THE SOURCE GIVEN IS EMPTY OR BECAUSE IT WAS NOT ABLE TO LOAD ANY PACKAGES FROM IT";
                if (this.AllowDeubbuger) Get.Red(this.CurrentStatus); 
                return;
            }
            List<Package> packages = new List<Package>();

            for (int item = 0; item < this.Packages.Count; item++)
            {
                if (this.Packages[item].Name != packageName)
                {
                    this.CurrentStatus = $"SAVING PACKAGE: [{this.Packages[item].ToString()}]";
                    if (this.AllowDeubbuger) Get.Green(this.CurrentStatus);
                    Package p = new Package();
                    p = this.Packages[item];
                    packages.Add(p);
                }
            }
            this.Packages = packages;
            Get.WaitTime(100);
            this.Save();
        }
    }
}
