﻿using System;
using QuickTools.QCore;
using QuickTools.QNet;

namespace QuickTools.QIO
{
    public partial class BinDownloader
    {
        /// <summary>
        /// Downloads the sources fronm github if there are any available
        /// the good thing is that if for some reason the source is not available in github
        /// it could also be used to download the source from another server or provider
        /// </summary>
        public void DownloadSources()
        {
            if (string.IsNullOrEmpty(this.SourcesURL) || string.IsNullOrWhiteSpace(this.SourcesURL)) throw new Exception($"The given sources URL is not valid [{this.SourcesURL}]");
            string path, file, size;

            path = Get.DataPath("sources");
            this.CurrentStatus = $"CREATTING SOURCES PATH: [{path}]";
            if (this.AllowDeubbuger) Get.Blue(this.CurrentStatus);
            file = $"{path}ClownShell.sources";
            Get.Green($"ATTEMPTING TO DOWNLOAD: [{this.SourcesURL}]");

            DownloadManager.Download(this.SourcesURL, file, this.AllowDeubbuger);
            size = Get.FileSize(file);
            if (size == "0B") throw new Exception($"SOMETHIG WENT WRONG WHILE TRYING TO DOWNLOAD: [{this.SourcesURL}] FILE SIZE: [{size}]");
            this.CurrentStatus = $"SOURCES FILE DOWNLOADED SUCESSFULLY FILE: [{file}] SIZE: {size}";
            if (this.AllowDeubbuger) Get.Green(this.CurrentStatus);
            this.FileName = file;
        }
    }
}
