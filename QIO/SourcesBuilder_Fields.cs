using System;
using System.Collections.Generic;
using QuickTools.QCore;
using QuickTools.QData;

namespace QuickTools.QIO
{
    public partial class SourcesBuilder
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
        /// Gets or sets a value indicating whether this <see cref="T:QuickTools.QIO.SourcesBuilder"/> allow deubbuger.
        /// </summary>
        /// <value><c>true</c> if allow deubbuger; otherwise, <c>false</c>.</value>
        public bool AllowDeubbuger { get; set; } = false;
        /// <summary>
        /// Gets or sets the current status.
        /// </summary>
        /// <value>The current status.</value>
        public string CurrentStatus { get; set; } = String.Empty;
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:QuickTools.QIO.SourcesBuilder"/> delete previous.
        /// </summary>
        /// <value><c>true</c> if delete previous; otherwise, <c>false</c>.</value>
        public bool DeletePrevious { get; set; } = false;
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
        /// Gets or sets the maper.
        /// </summary>
        /// <value>The maper.</value>
        public FilesMaper Maper { get; set; } = new FilesMaper();
        /// <summary>
        /// Gets or sets the packages.
        /// </summary>
        /// <value>The packages.</value>
        public List<Package> Packages { get; set; } = new List<Package>();
    }
}
