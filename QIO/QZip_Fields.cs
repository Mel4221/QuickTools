using System;
using System.Collections.Generic;

namespace QuickTools.QIO
{
    public partial class QZip
    {
        private string FileName;
        private string Prefix = ".zip";
        private readonly List<string> FileList;
        private void Check() { if (this.FileName.Length == 0) throw new Exception("The file was not provided "); }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:QuickTools.QIO.QZip"/> allow debugger.
        /// </summary>
        /// <value><c>true</c> if allow debugger; otherwise, <c>false</c>.</value>
        public bool AllowDebugger { get; set; } = false;

        /// <summary>
        /// Gets or sets the status of the current state of the Action either Zip or UnZip are suported
        /// </summary>
        /// <value>The status.</value>
        public string CurrentTextStatus { get; set; } = "not-started";
        /// <summary>
        /// Gets or sets the current int status.
        /// </summary>
        /// <value>The current int status.</value>
        public int CurrentIntStatus { get; set; }
    }
}
