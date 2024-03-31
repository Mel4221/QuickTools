using System;
using System.Collections.Generic;
using QuickTools.QConsole;
using QuickTools.QCore;
using QuickTools.QData;
namespace QuickTools.QDevelop
{
    public partial class BinBuilder
    {

        /// <summary>
        /// Load this instance.
        /// </summary>
        public void Load()
        {
            this.CurrentTextStatus = $"LOADING...";
            if (this.AllowDeubbuger) Get.Yellow(this.CurrentTextStatus);
            using (QKeyManager db = new QKeyManager(this.FileName))
            {
                db.AllowDebugger = this.AllowDeubbuger;
                db.Create();
                db.ReadKeys();
                if(db.Keys.Count == 0)
                {
                    this.CurrentTextStatus = $"FAILED TO LOAD ANY PCKAGES";
                    if (this.AllowDeubbuger) Get.Red(this.CurrentTextStatus); 
                    return;
                }

                int sw = 0;
                this.Packages.Clear(); 
                Package package = new Package();
                Package.Files file = new Package.Files();
                QProgressBar bar = new QProgressBar();

                //List<string> files, dirs;

                //Get.Wait(db.DataBase.Count);
                for (int item = 0; item < db.Keys.Count; item++)
                {
                    this.CurrentTextStatus = $"READING PACKAGES... {Get.Status(item, db.Keys.Count)}";
                    this.CurrentIntStatus = Get.StatusNumber(item, db.Keys.Count);
                    if (this.AllowDeubbuger)
                    {
                        bar.Label = this.CurrentTextStatus;
                        bar.Display(Get.Status(item, db.Keys.Count));
                    }
                    //Get.Red($"[{sw}]");
                    //Get.Yellow($"{package.ToString()}");

                    /*
                    db.AddKeyOnHot("NAME", package.Name, package.Id);
                    db.AddKeyOnHot("ID", package.Id, package.Name);
                    db.AddKeyOnHot("SIZE", package.Size, package.Id);
                    db.AddKeyOnHot("CREATOR", package.Creator, package.Id);
                    db.AddKeyOnHot("DESCRIPTION", package.Description, package.Id);
                    db.AddKeyOnHot("DATE", package.Date, package.Id);
                    db.AddKeyOnHot("SOURCE", package.Source, package.Id);
                    */
                    if (sw == 8 && db.Keys[item].Name == "NAME")
                    {
                        //package.DependencyFiles = files.Count > 0 ? files.ToArray() : new string[] { };
                        //package.DependencyDirs = dirs.Count > 0 ? dirs.ToArray() : new string[] { };
                        //package.DependencyFiles.Add(file);
                        this.Packages.Add(package);
                        package = new Package(); 
                        //file.Clear();
                        //files.Clear();
                        //dirs.Clear();
                        sw = 0;
                    }
                    switch (sw)
                    {
                        case 0:
                            package.Name = db.Keys[item].Value; sw++;
                            break;
                        case 1:
                            package.Id = db.Keys[item].Value; sw++;
                            break;
                        case 2:
                            package.Size = db.Keys[item].Value; sw++;
                            break;
                        case 3:
                            package.Creator = db.Keys[item].Value; sw++;
                            break;
                        case 4:
                            package.Description = db.Keys[item].Value; sw++;
                            break;
                        case 5:
                            package.Date = db.Keys[item].Value; sw++;
                            break;
                        case 6:
                            package.Source = db.Keys[item].Value; sw++;
                            break;
                        case 7:
                            package.Branch = db.Keys[item].Value; sw++;
                            break;
                        default:
                            if (db.Keys[item].Name == "DEPENDENCY-DIR" && db.Keys[item].Value != "")
                            {
                                package.DependencyDirs.Add(new Package.Directorys(){Name=db.Keys[item].Value });
                            }
                            /*
                                db.AddKeyOnHot("DEPENDENCY-FILE", file.Name, package.Id);
                                db.AddKeyOnHot("DEPENDENCY-HASH", file.Hash, file.Name);
                                db.AddKeyOnHot("DEPENDENCY-SIZE", file.Size, file.Name);
                                db.AddKeyOnHot("DEPENDENCY-LENGTH",file.Length, file.Name);
                            */
                            if (db.Keys[item].Name == "DEPENDENCY-FILE" && db.Keys[item].Value != "")
                            {
                                //file.Clear(); 
                                file = new Package.Files(); 
                                file.Name = db.Keys[item].Value;
                            }
                            if (db.Keys[item].Name == "DEPENDENCY-HASH")
                            {
                                file.Hash = db.Keys[item].Value;
                            }
                            if (db.Keys[item].Name == "DEPENDENCY-SIZE")
                            {
                                file.Size = db.Keys[item].Value;
                                // file.Clear();
                            }if(db.Keys[item].Name == "DEPENDENCY-LENGTH")
                            {
                                file.Length = db.Keys[item].Value;
                                package.DependencyFiles.Add(file);
                            }
                            break;

                    }
                    //package.DependencyFiles = files.Count > 0 ? files.ToArray() : new string[] { };
                }
                //package.DependencyFiles.Add(file);
                //package.DependencyDirs = dirs.Count > 0 ? dirs.ToArray() : new string[] { };
                //if(this.AllowDeubbuger)Get.Yellow($"Before Adding:\n{package.ToString()}");
                //package.DependencyFiles.ForEach(item => Get.Yellow(item.ToString()));
                this.Packages.Add(package);
                if (this.AllowDeubbuger) this.Packages.ForEach((item) => {
                    Get.Yellow($"\n{item.ToString()}");
                });
                //Get.Wait(package.ToString()); 
                /*
                this.Packages.Add(new Package() 
                { 
                    Name = package.Name,
                    Id = package.Id,
                    Size = package.Size,
                    Source = package.Source,
                    Date = package.Date,
                    Description = package.Description,
                    DependencyDirs = package.DependencyDirs,
                    DependencyFiles = package.DependencyFiles
                });
                */
                //package.Clear();
                //file.Clear();
                //files.Clear();
                //dirs.Clear();
                this.CurrentTextStatus = $"DONE";
                if (this.AllowDeubbuger) Get.Green(this.CurrentTextStatus);
            }
        }
    }
}
