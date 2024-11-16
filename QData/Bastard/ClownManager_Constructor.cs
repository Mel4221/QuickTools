using System;

namespace QuickTools.QData.Bastard
{
    /// <summary>
    /// Clown key.
    /// </summary>
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
        /// <summary>
        /// Hases the bytes.
        /// </summary>
        /// <returns><c>true</c>, if bytes was hased, <c>false</c> otherwise.</returns>
        public bool HasBytes()
        {
            return this.Buffer != null && this.Buffer.Length > 0;
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:QuickTools.QData.Bastard.ClownKey"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:QuickTools.QData.Bastard.ClownKey"/>.</returns>
        public override string ToString()
        {
            return $"NAME: {this.Name} VALUE: {(this.Value == null ? "NOT-LOADED" : this.Value)} INDEX: {this.Index} LENGTH: {this.length}";
        }
    }
}
