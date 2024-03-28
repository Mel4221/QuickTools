using System;
using System.Collections.Generic;
using System.IO;
using QuickTools.QConsole;
using QuickTools.QCore;
using QuickTools.QData;
namespace QuickTools.QIO
{
    /// <summary>
    /// Sources builder.
    /// </summary>
    public partial class BinBuilder
    {
         
        /// <summary>
        /// Add the specified package.
        /// </summary>
        /// <param name="package">Package.</param>
        public void Add(Package package)
        {
            if (this.DeletePrevious)
            {
                if (File.Exists(this.FileName)) File.Delete(this.FileName);
            }
            this.CurrentStatus = $"ADDING PACKAGE: [{package.ToString()}]";
            if (this.AllowDeubbuger) Get.Yellow(this.CurrentStatus);
            Check check = new Check();
            check.Start();
            this.Load();
            //Get.Wait($"Before Build: [{package.ToString()}]");
            Package p = this.Build(package);
            //Get.Wait($"After Build: [{p.ToString()}]");
            this.Packages.Add(p);
            this.Save();
            this.CurrentStatus = $"The package has been added Sucessfully prcoess time: [{check.Stop()}]";
            if (this.AllowDeubbuger) Get.Green(this.CurrentStatus);
        }

    }
}

/*
                    if (this.AllowDeubbuger) Get.Red(this.CurrentStatus); 
                    Get.WaitTime(100);
                    this.Save();

    */
