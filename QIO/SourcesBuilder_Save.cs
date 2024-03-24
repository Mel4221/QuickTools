using System;
using System.Collections.Generic;
using QuickTools.QConsole;
using QuickTools.QCore;
using QuickTools.QData;
namespace QuickTools.QIO
{
    public partial class SourcesBuilder
    {
      
        private void Save()
        {
            using (MiniDB db = new MiniDB(this.FileName))
            {
                db.Create();
                db.AllowDebugger = true;
                foreach (Package package in this.Packages)
                {
                    if (package.Name != "")
                    {
                        db.AddKeyOnHot("NAME", package.Name, package.Id);
                        db.AddKeyOnHot("ID", package.Id, package.Name);
                        db.AddKeyOnHot("SIZE", package.Size, package.Id);
                        db.AddKeyOnHot("CREATOR", package.Creator, package.Id);
                        db.AddKeyOnHot("DESCRIPTION", package.Description, package.Id);
                        db.AddKeyOnHot("DATE", package.Date, package.Id);
                        db.AddKeyOnHot("SOURCE", package.Source, package.Id);
                        //Get.Wait($"{package.ToString()}");
                        if (package.DependencyDirs.Count > 0)
                        {
                            foreach (Package.Directorys dir in package.DependencyDirs)
                            {
                                db.AddKeyOnHot("DEPENDENCY-DIR", dir.Name, package.Id);
                                this.CurrentStatus = $"DEPENDENCY-DIR: [{dir.Name}]";
                                if (this.AllowDeubbuger) Get.Blue(this.CurrentStatus);
                            }
                        }
                        if (package.DependencyDirs.Count == 0)
                        {
                            db.AddKeyOnHot("DEPENDENCY-DIR", "", package.Id);
                        }
                        if (package.DependencyFiles.Count > 0)
                        {
                            foreach (Package.Files file in package.DependencyFiles)
                            {
                                db.AddKeyOnHot("DEPENDENCY-FILE", file.Name, package.Id);
                                db.AddKeyOnHot("DEPENDENCY-HASH", file.Hash, file.Name);
                                db.AddKeyOnHot("DEPENDENCY-SIZE", file.Size, file.Name);

                                this.CurrentStatus = $"DEPENDENCY-FILE: [{file.Name}]";
                                if (this.AllowDeubbuger) Get.Yellow(this.CurrentStatus);
                            }
                        }
                        if (package.DependencyFiles.Count == 0)
                        {
                            db.AddKeyOnHot("DEPENDENCY-FILE", "", package.Id);
                        }
                    }
                   
                }
                db.SaveChanges();
                this.Packages.Clear();
            }
        }
    }
}
