using System;
using System.Collections.Generic;
using System.IO;
using QuickTools.QConsole;
using QuickTools.QCore;
using QuickTools.QData;
using QuickTools.QIO;
namespace QuickTools.QDevelop
{
    /// <summary>
    /// Sources builder is a class that contains an array of methods
    /// that will create a source file which contains all the
    /// information related with a package for it's later to be use 
    /// as a database for other packages.
    /// </summary>
    public partial class BinBuilder
    {
         
        /*
        public bool Exist(string packageName)
        {
            if(this.Packages.Count == 0)
            {
                this.Load(); 
            }
            foreach(Package p in this.Packages)
            {
                if (p.Name == packageName) return true;
            }
            return false; 
        }
        */

            /// <summary>
            /// Clear this instance.
            /// </summary>
        public void Clear()
        {
            Writer.Write(this.FileName, "");
        }

        /// <summary>
        /// Exist the specified package.
        /// </summary>
        /// <returns>The exist.</returns>
        /// <param name="package">Package.</param>
        public bool Exist(ref Package package)
        {
            if (this.Packages.Count == 0) return false; 
             for(int item = 0; item < this.Packages.Count; item++)
            {
                if(this.Packages[item].Name == package.Name)
                {
                    return true; 
                }
            }
            return false; 
        }
        /// <summary>
        /// Add the specified package.
        /// </summary>
        /// <param name="package">Package.</param>
        public void Add(Package package)
        {
      
            this.CurrentTextStatus = $"ADDING PACKAGE: [{package.ToString()}]";
            if (this.AllowDeubbuger) Get.Yellow(this.CurrentTextStatus);
            Check check = new Check();
            check.Start();
            if(this.Packages.Count == 0)
            {
                this.Load();
            }
            if (this.Exist(ref package))
            {
                this.CurrentTextStatus = $"THE PACKAGE FAILED TO BE ADDED DUE TO THE PACKAGE ALREADY EXIST";
                if (this.AllowDeubbuger) Get.Red(this.CurrentIntStatus);
                return;
            }


            //Get.Wait($"Before Build: [{package.ToString()}]");
            Package p = this.Build(package);
            //Get.Wait($"After Build: [{p.ToString()}]");
            this.Packages.Add(p);
            this.Save();
            this.CurrentTextStatus = $"THE PACKAGE: [{package.Name}] WAS ADDED TO: [{this.FileName}] SUCESSFULLY TIME: [{check.Stop()}]";
            if (this.AllowDeubbuger) Get.Green(this.CurrentTextStatus);
        }

    }
}

/*
                    if (this.AllowDeubbuger) Get.Red(this.CurrentStatus); 
                    Get.WaitTime(100);
                    this.Save();

    */
