using System;
namespace QuickTools.QSecurity
{
    public partial class Secure 
    {
        /// <summary>
        /// Allows to print information about the setatus of the 
        /// methods in use
        /// </summary>
        public bool AllowDebugger { get; set; } = false;
        /// <summary>
        /// display the current status of the function
        /// </summary>
        public string CurrentStatus { get; set; } = null;
        /// <summary>
        /// Gets or sets the out file.
        /// </summary>
        /// <value>The out file.</value>
        public string OutFile { get; set; } = null;
        /// <summary>
        /// Gets or sets the clear text.
        /// </summary>
        /// <value>The clear text.</value>
        public string ClearText { get; set; } = null;
        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>The key.</value>
        public byte[] Key { get; set; } = new byte[] { };
        /// <summary>
        /// Gets or sets the iv.
        /// </summary>
        /// <value>The iv.</value>
        public byte[] IV { get; set; } = new byte[] { };

    }
}
