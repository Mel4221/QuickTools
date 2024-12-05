using System;

namespace QuickTools.QData.Bastard
{
    /// <summary>
    /// Clown manager.
    /// </summary>
    public partial class ClownManager
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:QuickTools.QData.Bastard.ClownManager"/> class.
        /// </summary>
        public ClownManager() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:QuickTools.QData.Bastard.ClownManager"/> class.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public ClownManager(string fileName) { this.FileName = fileName; }
        /// <summary>
        /// Softs the load.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public void SoftLoad(string fileName) { this.FileName = fileName; }

    }
}
