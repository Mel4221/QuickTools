using System;
using System.Collections.Generic;
using QuickTools.QConsole;
using QuickTools.QCore;
using QuickTools.QData;
namespace QuickTools.QDevelop
{
    public partial class BinBuilder
    {
      
        private void Save()
        {
            using (QKeyManager db = new QKeyManager(this.FileName))
            {
                db.Create();
                db.AllowDebugger = this.AllowDeubbuger;
                if (this.Packages.Count == 0)
                {
                    /*
                    Binary.Writer(this.FileName, 
                    
                        Get.Bytes(
                        $"QKEYID{db.DataManager.KeyAssingChar}" +
                    	$"{db.DataManager.QKeyId}" +
                		$"{db.DataManager.KeyTerminatorChar}"));
                    */
                    this.CurrentTextStatus = $"FAILED TO SAVE THE PCAKGES DUE TO SOURCES BEING EMPTY";
                    if (this.AllowDeubbuger) Get.Red(this.CurrentTextStatus); 
                    return;
                }


                foreach (Package package in this.Packages)
                {
                    if (!string.IsNullOrEmpty(package.Name) && 
                        !string.IsNullOrWhiteSpace(package.Name))
                    {
                        if (this.AllowDeubbuger) Get.Green(package.ToString()); 
                        db.AddKey("NAME", package.Name);
                        db.AddKey("ID", package.Id);
                        db.AddKey("SIZE", package.Size);
                        db.AddKey("CREATOR", package.Creator);
                        db.AddKey("DESCRIPTION", package.Description);
                        db.AddKey("DATE", package.Date);
                        db.AddKey("SOURCE", package.Source);
                        db.AddKey("BRANCH", package.Branch);
                        //Get.Wait($"{package.ToString()}");
                        if (package.DependencyDirs.Count > 0)
                        {
                            foreach (Package.Directorys dir in package.DependencyDirs)
                            {
                                db.AddKey("DEPENDENCY-DIR", dir.Name);
                                this.CurrentTextStatus = $"DEPENDENCY-DIR: [{dir.Name}]";
                                if (this.AllowDeubbuger) Get.Blue(this.CurrentTextStatus);
                            }
                        }
                        if (package.DependencyDirs.Count == 0)
                        {
                            db.AddKey("DEPENDENCY-DIR", "");
                        }
                        if (package.DependencyFiles.Count > 0)
                        {
                            foreach (Package.Files file in package.DependencyFiles)
                            {
                                db.AddKey("DEPENDENCY-FILE", file.Name);
                                db.AddKey("DEPENDENCY-HASH", file.Hash);
                                db.AddKey("DEPENDENCY-SIZE", file.Size);
                                db.AddKey("DEPENDENCY-LENGTH",file.Length);

                                this.CurrentTextStatus = $"DEPENDENCY-FILE: [{file.Name}]";
                                if (this.AllowDeubbuger) Get.Yellow(this.CurrentTextStatus);
                            }
                        }
                        if (package.DependencyFiles.Count == 0)
                        {
                            db.AddKey("DEPENDENCY-FILE", "");
                        }
                    }
                   
                }
                db.SaveKeys();
                this.Packages.Clear();
            }
        }
    }
}
