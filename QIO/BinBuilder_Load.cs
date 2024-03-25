using System;
using System.Collections.Generic;
using QuickTools.QConsole;
using QuickTools.QCore;
using QuickTools.QData;
namespace QuickTools.QIO
{
    public partial class BinBuilder
    {

        /// <summary>
        /// Load this instance.
        /// </summary>
        public void Load()
        {
            this.CurrentStatus = $"LOADING...";
            if (this.AllowDeubbuger) Get.Yellow(this.CurrentStatus);
            using (MiniDB db = new MiniDB(this.FileName))
            {
                db.Create();
                db.Load();
                int sw = 0;
                this.Packages.Clear(); 
                Package package = new Package();
                Package.Files file = new Package.Files();
                QProgressBar bar = new QProgressBar();

                //List<string> files, dirs;

                //Get.Wait(db.DataBase.Count);
                for (int item = 0; item < db.DataBase.Count; item++)
                {
                    this.CurrentStatus = $"READING PACKAGES... {Get.Status(item, db.DataBase.Count)}";
                    if (this.AllowDeubbuger)
                    {
                        bar.Label = this.CurrentStatus;
                        bar.Display(Get.Status(item, db.DataBase.Count));
                    }
                    Get.Red($"[{sw}]");
                    Get.Yellow($"{package.ToString()}");

                    /*
                    db.AddKeyOnHot("NAME", package.Name, package.Id);
                    db.AddKeyOnHot("ID", package.Id, package.Name);
                    db.AddKeyOnHot("SIZE", package.Size, package.Id);
                    db.AddKeyOnHot("CREATOR", package.Creator, package.Id);
                    db.AddKeyOnHot("DESCRIPTION", package.Description, package.Id);
                    db.AddKeyOnHot("DATE", package.Date, package.Id);
                    db.AddKeyOnHot("SOURCE", package.Source, package.Id);
                    */
                    if (sw == 7 && db.DataBase[item].Key == "NAME")
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
                            package.Name = db.DataBase[item].Value; sw++;
                            break;
                        case 1:
                            package.Id = db.DataBase[item].Value; sw++;
                            break;
                        case 2:
                            package.Size = db.DataBase[item].Value; sw++;
                            break;
                        case 3:
                            package.Creator = db.DataBase[item].Value; sw++;
                            break;
                        case 4:
                            package.Description = db.DataBase[item].Value; sw++;
                            break;
                        case 5:
                            package.Date = db.DataBase[item].Value; sw++;
                            break;
                        case 6:
                            package.Source = db.DataBase[item].Value; sw++;
                            break;
                        default:
                            if (db.DataBase[item].Key == "DEPENDENCY-DIR" && db.DataBase[item].Value != "")
                            {
                                package.DependencyDirs.Add(new Package.Directorys(){Name=db.DataBase[item].Value });
                            }
                            /*
                                db.AddKeyOnHot("DEPENDENCY-FILE", file.Name, package.Id);
                                db.AddKeyOnHot("DEPENDENCY-HASH", file.Hash, file.Name);
                                db.AddKeyOnHot("DEPENDENCY-SIZE", file.Size, file.Name);
                                db.AddKeyOnHot("DEPENDENCY-LENGTH",file.Length, file.Name);
                            */
                            if (db.DataBase[item].Key == "DEPENDENCY-FILE" && db.DataBase[item].Value != "")
                            {
                                //file.Clear(); 
                                file = new Package.Files(); 
                                file.Name = db.DataBase[item].Value;
                            }
                            if (db.DataBase[item].Key == "DEPENDENCY-HASH")
                            {
                                file.Hash = db.DataBase[item].Value;
                            }
                            if (db.DataBase[item].Key == "DEPENDENCY-SIZE")
                            {
                                file.Size = db.DataBase[item].Value;
                                // file.Clear();
                            }if(db.DataBase[item].Key == "DEPENDENCY-LENGTH")
                            {
                                file.Length = db.DataBase[item].Value;
                                package.DependencyFiles.Add(file);
                            }
                            break;

                    }
                }
                //package.DependencyFiles = files.Count > 0 ? files.ToArray() : new string[] { };
                //package.DependencyDirs = dirs.Count > 0 ? dirs.ToArray() : new string[] { };
                //package.DependencyFiles.Add(file);
                if(this.AllowDeubbuger)Get.Yellow($"Before Adding:\n{package.ToString()}");
                //package.DependencyFiles.ForEach(item => Get.Yellow(item.ToString()));
                this.Packages.Add(package);
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
                this.CurrentStatus = $"DONE";
                if (this.AllowDeubbuger) Get.Green(this.CurrentStatus);
            }
        }
    }
}
