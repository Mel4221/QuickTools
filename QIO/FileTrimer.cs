using System;
using System.IO;


namespace QuickTools.QIO
{
    /// <summary>
    /// File trimer.
    /// </summary>
    public class FileTrimer
    {
        private string _fileName { get; set; } = null;
        private int _start { get; set; } = 0;
        private int _end { get; set; } = 0;
        /// <summary>
        /// Gets or sets the new file label.
        /// </summary>
        /// <value>The new file label.</value>
        public string NewFileLabel { get; set; } = $"Trimed_";
        /// <summary>
        /// Gets or sets the new name of the file.
        /// </summary>
        /// <value>The new name of the file.</value>
        public string NewFileName { get; set; } = null; 
        /// <summary>
        /// Trim the specified file, start and end.
        /// </summary>
        /// <param name="file">File.</param>
        /// <param name="start">Start.</param>
        /// <param name="end">End.</param>
        public void Trim(string file,int start,int end)
        {
            if (file == null) throw new ArgumentNullException("File Name Not Provided");
            if (start > end) throw new ArgumentOutOfRangeException("Wrong Order of numbers");
            if (!System.IO.File.Exists(file)) throw new FileNotFoundException("File Not Founded");
            byte[] bytes, trimed;
            string newFileName; 
            bytes = Binary.Reader(file);
            trimed = new byte[end]; 
            for(int b = start; b<end; b++)
            {
                trimed[b] = bytes[b]; 
            }


            GC.Collect();
            newFileName = this.NewFileName == null ?  $"{this.NewFileLabel}{file}" : this.NewFileName;
            Binary.Writer(newFileName, trimed);
            GC.Collect();

        }
        /// <summary>
        /// Trim the specified start and end.
        /// </summary>
        /// <param name="start">Start.</param>
        /// <param name="end">End.</param>
        public void Trim(int start,int end)
        {
            this.Trim(this._fileName, start, end); 
        }
        /// <summary>
        /// Trim the specified fileName.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public void Trim(string fileName)
        {
            this.Trim(this._fileName, this._start, this._end); 
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:QuickTools.QIO.FileTrimer"/> class.
        /// </summary>
        public FileTrimer()
        {

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:QuickTools.QIO.FileTrimer"/> class.
        /// </summary>
        /// <param name="file">File.</param>
        public FileTrimer(string file)
        {
            this._fileName = file;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:QuickTools.QIO.FileTrimer"/> class.
        /// </summary>
        /// <param name="file">File.</param>
        /// <param name="start">Start.</param>
        /// <param name="end">End.</param>
        public FileTrimer(string file,int start , int end)
        {
            this._fileName = file;
            this._start = start;
            this._end = end; 
        }
    }
}
