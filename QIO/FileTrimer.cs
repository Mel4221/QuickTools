using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickTools.QIO
{
    public class FileTrimer
    {
        private string _fileName { get; set; } = null;
        private int _start { get; set; } = 0;
        private int _end { get; set; } = 0;
        public string NewFileLabel { get; set; } = $"Trimed_";
        public string NewFileName { get; set; } = null; 
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
        public void Trim(int start,int end)
        {
            this.Trim(this._fileName, start, end); 
        }
        public void Trim(string fileName)
        {
            this.Trim(this._fileName, this._start, this._end); 
        }
        public FileTrimer()
        {

        }
        public FileTrimer(string file)
        {
            this._fileName = file;
        }
        public FileTrimer(string file,int start , int end)
        {
            this._fileName = file;
            this._start = start;
            this._end = end; 
        }
    }
}
