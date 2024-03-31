using System;
using System.Collections.Generic;
using QuickTools.QCore;
using QuickTools.QData;
using QuickTools.QIO;

namespace QuickTools.QDevelop
{
    public partial class BinBuilder
    {

        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>The name of the file.</value>
        public string FileName { get; set; } = String.Empty;
        /// <summary>
        /// Gets or sets the source path.
        /// </summary>
        /// <value>The source path.</value>
        public string Source { get; set; } = String.Empty;
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:QuickTools.QIO.BinBuilder"/> allow deubbuger.
        /// </summary>
        /// <value><c>true</c> if allow deubbuger; otherwise, <c>false</c>.</value>
        public bool AllowDeubbuger { get; set; } = false;
        /// <summary>
        /// Gets or sets the current status.
        /// </summary>
        /// <value>The current status.</value>
        public string CurrentTextStatus { get; set; } = $"NOT-STARTED";
        /// <summary>
        /// Gets or sets the current int status.
        /// </summary>
        /// <value>The current int status.</value>
        public int CurrentIntStatus { get; set; } = 0; 
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:QuickTools.QIO.FilesMaper"/> ignore hidden files.
        /// </summary>
        /// <value><c>true</c> if ignore hidden files; otherwise, <c>false</c>.</value>
        public bool IgnoreHiddenFiles { get; set; } = true;
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:QuickTools.QIO.FilesMaper"/> ignore hidden directorys.
        /// </summary>
        /// <value><c>true</c> if ignore hidden directorys; otherwise, <c>false</c>.</value>
        public bool IgnoreHiddenDirectorys { get; set; } = true;
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:QuickTools.QIO.BinBuilder"/> filter files extentions.
        /// </summary>
        /// <value><c>true</c> if filter files extentions; otherwise, <c>false</c>.</value>
        public bool FilterFilesExtentions { get; set; } = true;
        /// <summary>
        /// Gets or sets the allowed files extentions.
        /// By default the only suported files are the fallowing: "txt","xml","dll","exe","clown","ico","html","js","css"
        /// </summary>
        /// <value>The allowed files extentions.</value>
        public string[] AllowedFilesExtentions { get; set; } = new string[] {"txt","xml","dll","exe","clown","ico","html","js","css"};
        /// <summary>
        /// Gets or sets the maper.
        /// </summary>
        /// <value>The maper.</value>
        public FilesMaper Maper { get; set; } = new FilesMaper();
        /// <summary>
        /// Gets or sets the packages.
        /// </summary>
        /// <value>The packages.</value>
        public List<Package> Packages { get; set; } = new List<Package>();
        /// <summary>
        /// Gets or sets the type of the source.
        /// </summary>
        /// <value>The type of the source.</value>
        public Sourcetype SourceType { get; set; } = Sourcetype.Github;
        /// <summary>
        /// Sources.
        /// </summary>
        public enum Sourcetype
        {
            /// <summary>
            /// From the regular github page
            /// </summary>
            Github,
            /// <summary>
            /// From a regular server.
            /// </summary>
            Server
        }
    }
}
