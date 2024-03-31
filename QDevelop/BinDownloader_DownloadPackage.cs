using System;
using QuickTools.QData;
using QuickTools.QNet;
using QuickTools.QCore;
using QuickTools.QConsole;
using System.Collections.Generic;

namespace QuickTools.QDevelop
{
    public partial class BinDownloader
    {
        /// <summary>
        /// Downloads the package from the given source listed , remember that 
        /// if the FileName is not given you should call first DownloadSource to make sure
        /// that you get a source to be able to download the package with 
        /// </summary>
        /// <param name="package">Package.</param>
        /// <exception cref="Exception">Package not found exeption</exception>
        public void DownloadPackage(string package)
        {

            if (this.Packages.Count == 0) throw new Exception($"THE PACKAGE DATABASE DID NOT LOAD ANY PACKAGE");

            p = this.GetPackage(package);

            string url;
            url = p.Source;
            this.CurrentTextStatus = $"Source: [{url}]";
            if (this.AllowDeubbuger) Get.Green(this.CurrentTextStatus);
            url = this.GetLink(ref p,url); //this.ToRaw(url);
            this.CurrentTextStatus = $"Creatting Directorys...";
            if (this.AllowDeubbuger) Get.Yellow(this.CurrentTextStatus);
            this.CreateDirectorys(ref p);
            //Get.Blue(blob);

            QProgressBar bar = new QProgressBar();
            this.Errors = new List<Error>();
            //downloadManager.AllowDebugger = this.AllowDeubbuger;

            for (int item = 0; item < p.DependencyFiles.Count; item++)
            {
                try
                {
                    string file, link, dfile;
                    file = p.DependencyFiles[item].Name;
                    link = url + file;
                    dfile = $"{this.OutPutPath}{file}";
                    if (this.AllowDeubbuger)
                    {
                        Get.Yellow($"FILE: [{Get.FileNameFromPath(file)}]");
                        Get.Blue($"LINK: [{link}]");
                    }
                    this.CurrentIntStatus = Get.StatusNumber(item, p.DependencyFiles.Count);
                    this.CurrentTextStatus = $"DOWNLOADING [%{this.CurrentIntStatus}] [{Get.FileNameFromPath(dfile)}]";
                    DownloadManager.Download(link, dfile, int.Parse(p.DependencyFiles[item].Length), this.AllowDeubbuger);
                    //bar.Label = $"DOWNLOAD IN PROGRESS: [{url + file}] STATUS: [{Get.Status(item, p.DependencyFiles.Count)}]";
                    //bar.Display(Get.Status(item, p.DependencyFiles.Count));

                    //bar.Display(item, p.DependencyFiles.Count - 1);
                    //Get.Reset();
                    //Get.Red($"\n{url}/bin/Integrated/ClownShell.exe");
                    //Ehh.Download($"{url}/bin/Integrated/ClownShell.exe","ClownShell.exe",1024*1024*2);
                    //Ehh.Download(url+fileName, fileName,int.Parse(p.DependencyFiles[item].Length)); 
                    //Ehh.Download(url, fileName); 
                    Get.WaitTime(this.PrintDelay);
                }
                catch (Exception ex)
                {
                    this.Errors.Add(new Error()
                    {
                        Message = ex.Message,
                        Type = $"FAILED TO DOWNLOAD THE FALLOWING PACKAGE: [{p.DependencyFiles[item].ToString()}]"
                    });
                }

            }

            if (this.Errors.Count > 0)
            {
                this.CurrentTextStatus = $"SOME PACKAGES HAS FAILED TO BE DOWNLOADED. TOTAL FAIL: [{this.Errors.Count}]";
                this.Errors.ForEach((error) =>
                {
                    this.CurrentTextStatus += $"\n{error.ToString()}";
                    if (this.AllowDeubbuger) Get.Red(error.ToString());
                });
            }
            this.CheckPackageIntegrity(ref p);

            //Get.Title($"Dowloading... [{url}]");
            //downloadManager.DownloadFile(url, Get.FileNameFromPath(url));
            //downloadManager.DownloadFile("https://github.com/Mel4221/QuickTools/blob/testing/bin/Integrated/ClownShell.ErrorHandelers.dll", $"ClownShell.ErrorHandelers.dll");
            //Get.WaitTime(800);
        }
    }
}
