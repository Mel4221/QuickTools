using System;
using QuickTools.QData; 
using System.Collections.Generic;

namespace QuickTools.QIO
{
    public partial class BinDownloader : BinBuilder
    {
        /// <summary>
        /// The errors.
        /// </summary>
        public List<Error> Errors { get; set; } = new List<Error>();
        /// <summary>
        /// Gets or sets the print delay.
        /// </summary>
        /// <value>The print delay.</value>
        public int PrintDelay { get; set; } = 125;
        /// <summary>
        /// Gets or sets the out put path.
        /// </summary>
        /// <value>The out put path.</value>
        public string OutPutPath { get; set; } = string.Empty;
        /// <summary>
        /// The sources URL.
        /// </summary>
        public string SourcesURL { get; set; } = "https://github.com/Mel4221/ClownShellSources/raw/main/ClownShell.sources";//"https://raw.githubusercontent.com/Mel4221/ClownShellSources/main/ClownShell.sources";

        private Package p = new Package();
    }
}
