using System;
namespace QuickTools.QIO
{
    /// <summary>
    /// Contains the Metadata object 
    /// </summary>
    public class QMetadata
    {
        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>The name of the file.</value>
        public string Name { get; set; } = String.Empty;
        /// <summary>
        /// Gets or sets the file hash.
        /// </summary>
        /// <value>The file hash.</value>
        public string Hash { get; set; } = String.Empty;
        /// <summary>
        /// Gets or sets from.
        /// </summary>
        /// <value>From.</value>
        public long From { get; set; } = 0;
        /// <summary>
        /// Gets or sets the until.
        /// </summary>
        /// <value>The until.</value>
        public long Until { get; set; } = 0;
        /// <summary>
        /// Gets or sets the length of the file.
        /// </summary>
        /// <value>The length of the file.</value>
        public long Length { get; set; } = 0;
        /// <summary>
        /// Gets or sets the size of the file.
        /// </summary>
        /// <value>The size of the file.</value>
        public string Size { get; set; } = String.Empty; 
        /// <summary>
        /// Gets or sets the size of the chuncks , by default is set to 10MB
        /// </summary>
        /// <value>The size of the chuncks.</value>
        public int ChuncksSize { get; set; } = 1024*1024*10;
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:QTester.FileChoper.Metadata"/> is encrypted.
        /// </summary>
        /// <value><c>true</c> if is encrypted; otherwise, <c>false</c>.</value>
        public bool IsEncrypted { get; set; } = false;
        /// <summary>
        /// Gets or sets the last modified.
        /// </summary>
        /// <value>The last modified.</value>
        public string LastModified { get; set; } = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss");

        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        /// <value>The comment.</value>
        public string Comment { get; set; } = String.Empty; 
        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:QTester.FileChoper.Metadata"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:QTester.FileChoper.Metadata"/>.</returns>
        public override string ToString()
        {
            return $"File Name: {this.Name}\n" +
                   $"File Hash: {this.Hash}\n" +
                   $"From: {this.From}\n" +
                   $"Until: {this.Until}\n" +
                   	$"File Length: {this.Length}\n" +
               		$"File Size: {this.Size}\n" +
                   $"Chunck Size: {this.ChuncksSize}\n" +
                   $"Is Encrypted: {this.IsEncrypted}\n" +
                   	$"Comment: {this.Comment}";
        }
    }
}
