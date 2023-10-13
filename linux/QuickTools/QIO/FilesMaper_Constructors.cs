using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickTools.QIO
{
    public partial class FilesMaper
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="T:QuickTools.FilesMaper"/> class.
        /// </summary>
        public FilesMaper()
        {
            this.Files = new List<string>();
            this.Directories = new List<string>();
            this.DirectoryList = new List<string>();
            this.FileList = new List<string>();
            this.FileErrors = new List<string>();
            this.DirectoriesError = new List<string>();
            this.Path = null;
    }


        /// <summary>
        /// Initializes a new instance of the <see cref="T:QuickTools.FilesMaper"/> class.
        /// </summary>
        /// <param name="path"></param>
        public FilesMaper(string path)
        {
            this.Path = path;
            this.Files = new List<string>();
            this.Directories = new List<string>();
            this.FileErrors = new List<string>();
            this.DirectoriesError = new List<string>();
        }
    }
}
