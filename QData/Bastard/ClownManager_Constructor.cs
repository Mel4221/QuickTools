using System;

namespace QuickTools.QData.Bastard
{
    public class ClownKey : Key
    {
        /// <summary>
        /// Gets or sets the index.
        /// </summary>
        /// <value>The index.</value>
        public long Index { get; set; }
        /// <summary>
        /// Gets or sets the length.
        /// </summary>
        /// <value>The length.</value>
        public long length { get; set; }
        /// <summary>
        /// Gets or sets the buffer , since
        /// there could be the need to allow 
        /// binary data inside the db file
        /// which i don't even think should be
        /// done but what ever , who cares...
        /// </summary>
        /// <value>The buffer.</value>
        public byte[] Buffer { get; set; } = new byte[0];

        public bool HasBytes()
        {
            return this.Buffer != null && this.Buffer.Length > 0;
        }


        public override string ToString()
        {
            return $"NAME: {this.Name} VALUE: {(this.Value == null ? "NOT-LOADED" : this.Value)} INDEX: {this.Index} LENGTH: {this.length}";
        }
    }
}
