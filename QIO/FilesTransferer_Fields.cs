using System;
namespace QuickTools.QIO
{
    public partial class FilesTransferer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:FilesTransferer"/> class.
        /// </summary>
        public FilesTransferer() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:FilesTransferer"/> class.
        /// </summary>
        /// <param name="allowDebugger">If set to <c>true</c> allow debugger.</param>
        public FilesTransferer(bool allowDebugger) => this.AllowDebugger = allowDebugger;
        /// <summary>
        /// Initializes a new instance of the <see cref="T:FilesTransferer"/> class.
        /// </summary>
        /// <param name="chuckSize">Chuck size.</param>
        public FilesTransferer(int chuckSize) => this.ChuckSize = chuckSize;
        /// <summary>
        /// Initializes a new instance of the <see cref="T:FilesTransferer"/> class.
        /// </summary>
        /// <param name="allowDebugger">If set to <c>true</c> allow debugger.</param>
        /// <param name="chuckSize">Chuck size.</param>
        public FilesTransferer(bool allowDebugger, int chuckSize) { this.AllowDebugger = allowDebugger; this.ChuckSize = chuckSize; }

        /// <summary>
        /// Gets or sets the current status.
        /// </summary>
        /// <value>The current status.</value>
        public string CurrentStatus { get; set; } = "Not-Started";
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:FilesTransferer"/> allow debugger.
        /// </summary>
        /// <value><c>true</c> if allow debugger; otherwise, <c>false</c>.</value>
        public bool AllowDebugger { get; set; } = false;
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:QuickTools.QIO.FilesTransferer"/> check file integrity.
        /// </summary>
        /// <value><c>true</c> if check file integrity; otherwise, <c>false</c>.</value>
        public bool CheckFileIntegrity { get; set; } = false; 
        /// <summary>
        /// The size of the chuck and the default value is 1024 * 1024 * 64 = 670302208B or 64MB
        /// </summary>
        public int ChuckSize = 1024 * 1024 * 64;
        /// <summary>
        /// Gets or sets the buffer.
        /// </summary>
        /// <value>The buffer.</value>
        public byte[] Buffer { get; set; } = new byte[] { };
        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>The source.</value>
        public string Source { get; set; } = "Not-Set";
        /// <summary>
        /// Gets or sets the target.
        /// </summary>
        /// <value>The target.</value>
        public string Target { get; set; } = "Not-Set";

        /// <summary>
        /// Transfer this the file from the source to the given target directory.
        /// </summary>
        public void TransferFile() => this.TransferFile(this.Source, this.Target);


        private string Target_Hash { get; set; }


    }
}
