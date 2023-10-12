using QuickTools.QIO;
using QuickTools.QCore; 
namespace QuickTools.QData
{
    public partial class FileChoper
    {
        /// <summary>
        /// Gets or sets the binary object.
        /// </summary>
        /// <value>The binary.</value>
        public Binary BinaryObj { get; set; } = new Binary();

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:QTester.Program6.FileChoper"/> allow debuger.
        /// </summary>
        /// <value><c>true</c> if allow debuger; otherwise, <c>false</c>.</value>
        public bool AllowDebuger { get; set; } = false;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:QTester.Program6.FileChoper"/> encrypt chunks.
        /// </summary>
        /// <value><c>true</c> if encrypt chunks; otherwise, <c>false</c>.</value>
        public bool EncryptChunks { get; set; } = false;

        /// <summary>
        /// Gets or sets the password for the chunks
        /// </summary>
        /// <value>The password.</value>
        public string Password { get; set; } = null;

        /// <summary>
        /// Gets or sets the current status.
        /// </summary>
        /// <value>The current status.</value>
        public string CurrentStatus { get; set; } = "not-started";
        /// <summary>
        /// Gets or sets the output path and by default is set to row/
        /// </summary>
        /// <value>The output path.</value>
        public string OutputPath { get; set; } = $"chunks{Get.Slash()}";

        /// <summary>
        /// Gets or sets the chop file which contains the information about how to read
        /// the file and how to rebuild it or Join it again 
        /// </summary>
        /// <value>The chop file.</value>
        public string ChopFileExtention { get; set; } = ".join";

        /// <summary>
        /// Gets or sets the file extention and by default is set to .chunck
        /// </summary>
        /// <value>The file extention.</value>
        public string FileExtention { get; set; } = ".chunck";


        /// <summary>
        /// Contains the Metadata object 
        /// </summary>
        public class Metadata
        {
            /// <summary>
            /// Gets or sets the name of the file.
            /// </summary>
            /// <value>The name of the file.</value>
            public string FileName { get; set; } = null;
            /// <summary>
            /// Gets or sets the file hash.
            /// </summary>
            /// <value>The file hash.</value>
            public string FileHash { get; set; } = null;
            /// <summary>
            /// Gets or sets from.
            /// </summary>
            /// <value>From.</value>
            public int From { get; set; } = 0;
            /// <summary>
            /// Gets or sets the until.
            /// </summary>
            /// <value>The until.</value>
            public int Until { get; set; } = 0;
            /// <summary>
            /// Gets or sets the size of the chuncks.
            /// </summary>
            /// <value>The size of the chuncks.</value>
            public string ChuncksSize { get; set; } = null;
            /// <summary>
            /// Gets or sets the created.
            /// </summary>
            /// <value>The created.</value>
            public string Created { get; set; } = null;
            /// <summary>
            /// Gets or sets a value indicating whether this <see cref="T:QTester.FileChoper.Metadata"/> is encrypted.
            /// </summary>
            /// <value><c>true</c> if is encrypted; otherwise, <c>false</c>.</value>
            public bool IsEncrypted { get; set; } = false;
            /// <summary>
            /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:QTester.FileChoper.Metadata"/>.
            /// </summary>
            /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:QTester.FileChoper.Metadata"/>.</returns>
            public override string ToString()
            {
                return $"File Name: {this.FileName}\n" +
                    $"File Hash: {this.FileHash}\n" +
                        $"From: {this.From}\n" +
                    $"Until: {this.Until}\n" +
                        $"ChunckSize: {this.ChuncksSize}\n" +
                        $"Created: {this.Created}\n" +
                    $"Is Encrypted: {this.IsEncrypted}";
            }
        }
    }
}
