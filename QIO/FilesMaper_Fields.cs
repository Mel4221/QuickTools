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
        /// Contains the list of directoys founded 
        /// </summary>
        public List<string> DirectoryList { get; set; }

        /// <summary>
        /// Contains the list of files founded 
        /// </summary>
        public List<string> FileList { get; set; }

        /// <summary>
        /// gets or set the path where the map will start 
        /// </summary>
        public string Path;

        /// <summary>
        /// ccontains the lsit of files 
        /// </summary>
        public List<string> Files;

        /// <summary>
        /// constins the list of Directories
        /// </summary>
        public List<string> Directories;
    }
}
