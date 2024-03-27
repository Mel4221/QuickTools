using System;
using QuickTools.QData; 
using System.Collections.Generic;

namespace QuickTools.QIO
{
    /// <summary>
    /// Bin downloader.
    /// </summary>
    public partial class BinDownloader : BinBuilder
    {
        /// <summary>
        /// The errors.
        /// </summary>
        public List<Error> Errors { get; set; } = new List<Error>();
        /// <summary>
        /// Gets or sets the print delay for each function called .
        /// </summary>
        /// <value>The print delay.</value>
        public int PrintDelay { get; set; } = 125;
        /// <summary>
        /// Gets or sets the out put path for the package downloaded.
        /// </summary>
        /// <value>The out put path.</value>
        public string OutPutPath { get; set; } = string.Empty;
        /// <summary>
        /// This is the source used when the method DownloadSource is called to doenload the sources available
        /// </summary>
        public string SourcesURL { get; set; } = "https://github.com/Mel4221/ClownShellSources/raw/main/ClownShell.sources";//"https://raw.githubusercontent.com/Mel4221/ClownShellSources/main/ClownShell.sources";

        private Package p = new Package();
    }
}
