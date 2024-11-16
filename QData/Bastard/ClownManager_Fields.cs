
using System.Collections.Generic;

namespace QuickTools.QData.Bastard
{
    public partial class ClownManager
    {
        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>The name of the file.</value>
        public string FileName { get; set; }
        /// <summary>
        /// The keys.
        /// </summary>
        public List<ClownKey> Keys = new List<ClownKey>();
        /// <summary>
        /// Gets or sets the length of the buffer.
        /// </summary>
        /// <value>The length of the buffer.</value>
        public int BufferLength { get; set; } = 1024 * 1024 * 10;//10MB
        /// <summary>
        /// Gets or sets the length of the stream.
        /// </summary>
        /// <value>The length of the stream.</value>
        public long StreamLength { get; set; }
        /// <summary>
        /// Gets or sets the fail safe.
        /// </summary>
        /// <value>The fail safe.</value>
        public long FailSafe { get; set; } = 0;
        /// <summary>
        /// Gets or sets the max attemps.
        /// </summary>
        /// <value>The max attemps.</value>
        public long MaxAttemps { get; set; } = 5;
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:QuickTools.QData.Bastard.ClownManager"/> allow debugger.
        /// </summary>
        /// <value><c>true</c> if allow debugger; otherwise, <c>false</c>.</value>
        public bool AllowDebugger { get; set; } = false;
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:QuickTools.QData.Bastard.ClownManager"/> load as bytes.
        /// </summary>
        /// <value><c>true</c> if load as bytes; otherwise, <c>false</c>.</value>
        public bool LoadAsBytes { get; set; } = false;
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:QuickTools.QData.Bastard.ClownManager"/> save as bytes.
        /// </summary>
        /// <value><c>true</c> if save as bytes; otherwise, <c>false</c>.</value>
        public bool SaveAsBytes { get; set; } = false;
        /// <summary>
        /// Gets or sets the text status.
        /// </summary>
        /// <value>The text status.</value>
        public string TextStatus { get; set; } = "not-started";
        /// <summary>
        /// Gets or sets the progress status.
        /// </summary>
        /// <value>The progress status.</value>
        public int ProgressStatus { get; set; } = 0;
    }
}
