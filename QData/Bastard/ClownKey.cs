using System;
using QuickTools.QCore;

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
        public long Length { get; set; }
        //    public long Length { get => GetLength(); private set => internalLength = value; }
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
        public bool HasBinaryData()
        {
            return this.Buffer != null && this.Buffer.Length > 0;
        }

        /// <summary>
        /// Gets the length.
        /// </summary>
        /// <returns>The length.</returns>
        public long GetLength()
        {
            //checks if is using string value
            if(!string.IsNullOrEmpty(this.Value) &&
                !string.IsNullOrWhiteSpace(this.Value))
            {
                return this.Value.Length;
            }//check if is using binary value
            if(this.HasBinaryData())
            {
                return this.Buffer.LongLength;
            }
            else
            {
                return 0; 
            }
        }
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <returns>The value.</returns>
        public string GetValue()
        {
            //checks if is using string value

            if (!string.IsNullOrEmpty(this.Value) ||
          !string.IsNullOrWhiteSpace(this.Value))
            {
                return this.Value;
            }
            //check if is using binary value

            if (this.HasBinaryData())
            {
                return $"Buffer[{Get.FileSize(this.Buffer)}]";
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// Gets the size.
        /// </summary>
        /// <returns>The size.</returns>
        public long GetSize()
        {
            long key_length, data_length, number_length;
            int separator, new_line;
            key_length = this.Name.Length;
            separator = 2;
            data_length = this.GetLength();
            number_length = data_length.ToString().Length;
            new_line = Environment.NewLine.Length;
            /*
                this is trying to calculate the fallowing style 
                key_name[value_length]value\n               
            */
            return key_length + 
                    separator +
                  data_length +
                number_length + 
                     new_line;
        }
        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:QuickTools.QData.Bastard.ClownKey"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:QuickTools.QData.Bastard.ClownKey"/>.</returns>
        public override string ToString()
        { 
            return $"NAME: {this.Name} VALUE: {(string.IsNullOrEmpty(this.GetValue())?"NOT-LOADED":this.GetValue())} INDEX: {this.Index} LENGTH: {this.GetLength()} SIZE: {this.GetSize()}";
        }
    }

}
