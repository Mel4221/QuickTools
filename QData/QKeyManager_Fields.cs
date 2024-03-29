using System;
using System.Collections.Generic;
using QuickTools.QCore;

namespace QuickTools.QData
{
    public partial class QKeyManager : IDisposable
    {

    }

    public partial class QKeyManager : Key
    {
       
        //public string CurrentStatus { get; set; }

        /// <summary>
        /// Gets or sets the QKey version.
        /// </summary>
        /// <value>The QK ey version.</value>
        public int QKeyId { get; set; } = IRandom.RandomInt(2, 9999);

        private readonly string QKey_Id_Key = "QKEYID";

        /// <summary>
        /// This are the keys that are buffered when you the ReadKeys method is called/>
        /// </summary>
        /// <value>The keys.</value>
        public List<Key> Keys { get; set; } = new List<Key>();

        /// <summary>
        /// Gets or sets the errors.
        /// </summary>
        /// <value>The errors.</value>
        public List<Error> Errors { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:QuickTools.QData.KeyManager"/> allow debugger.
        /// </summary>
        /// <value><c>true</c> if allow debugger; otherwise, <c>false</c>.</value>
        public bool AllowDebugger { get; set; } = false;
        /// <summary>
        /// Gets or sets the current text status.
        /// </summary>
        /// <value>The current text status.</value>
        public string CurrentTextStatus { get; set; } = "NOT-STARTED";
        /// <summary>
        /// Gets or sets the current int status.
        /// </summary>
        /// <value>The current int status.</value>
        public int CurrentIntStatus { get; set; } = 0;
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:QuickTools.QData.KeyManager"/> check for not
        /// repeted keys.
        /// </summary>
        /// <value><c>true</c> if check for not repeted keys; otherwise, <c>false</c>.</value>
        public bool CheckForNotRepetedKeys { get; set; } = false;
    }
}