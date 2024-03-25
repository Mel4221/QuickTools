using System;
using System.IO; 
using System.Collections.Generic;
using QuickTools.QConsole;
using QuickTools.QCore;
using QuickTools.QData;
namespace QuickTools.QIO
{
    public partial class BinBuilder
    {

        /// <summary>
        /// Build the Sources.
        /// </summary>
        private Package Build(Package package)
        {
            if (!Directory.Exists(this.Source)) throw new DirectoryNotFoundException($"Source Path was not found: [{this.Source}]");
            this.CurrentStatus = $"Building in progress...";
            if (this.AllowDeubbuger) Get.Yellow(this.CurrentStatus);
            this.Maper = new FilesMaper(this.Source);
            this.Maper.AllowDebugger = this.AllowDeubbuger;
            this.Maper.IgnoreHiddenDirectorys = this.IgnoreHiddenDirectorys;
            this.Maper.IgnoreHiddenFiles = this.IgnoreHiddenFiles;
            if (this.FilterFilesExtentions) this.Maper.Map(this.AllowedFilesExtentions);
            if(!this.FilterFilesExtentions) this.Maper.Map();
            long length = 0;
            Func<List<Package.Files>> files;
            Func<List<Package.Directorys>> dirs;
            dirs = () =>
            {
                List<Package.Directorys> d = new List<Package.Directorys>();
                //adding the root direcotory or the sourcebuilder db name
                d.Add(new Package.Directorys() { Name = Get.GetDirOnly(this.Source) });
                //Get.Wait(Get.GetDirOnly(this.Source));
                this.Maper.Directories.ForEach((item) =>
                {
                     
                    //Get.Red($"DIR: [{_}]");
                    d.Add(new Package.Directorys()
                    {
                        Name = Get.GetSubPath(this.Source, item)
                    });
                });

                return d;
            };
            files = () =>
            {
                List<Package.Files> f = new List<Package.Files>();

                this.Maper.Files.ForEach((item) => {
                    long l = new FileStream(item, FileMode.Open, FileAccess.Read).Length;
                    length += l;

                    /*
                     string path = Get.GetSubPath("/home/mel/Documents/csharp/QuickTools/", "/home/mel/Documents/csharp/QuickTools/bin");
                    Get.Yellow($"Path: [{path}] Sub: [{path.Substring(path.IndexOf(Get.SlashChar())+1)}] " +
                    $"Root: [{path.Substring(0,path.IndexOf(Get.SlashChar()))}]");
            
                    */
                    //Get.Red($"FILE: [{_}]");
                    f.Add(new Package.Files()
                    {
                        Name = Get.GetSubPath(this.Source, item),//Get.GetSubPath(this.Source,item),
                        Hash = new Get().HashCodeFromFile(item, this.AllowDeubbuger).ToString(),
                        Size = Get.FileSize(item),
                        Length = l.ToString() 
                    });
                });
                return f;
            };

         
              Package p = new Package()
            {
                Name = package.Name,
                Creator = package.Creator,
                Date = package.Date,
                Source = package.Source,
                DependencyDirs = dirs(),
                DependencyFiles = files(),
                Size = Get.FileSize(length),
                Description = package.Description
            };
            this.CurrentStatus = $"Dependencys Build Sucessfully:\n{p.ToString()}";
            if (this.AllowDeubbuger) Get.Green(this.CurrentStatus);

            return p;
        }
    }
}