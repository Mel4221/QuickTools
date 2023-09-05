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
          List<string> DirectoryList { get; set; }

        /// <summary>
        /// Contains the list of files founded 
        /// </summary>
          List<string> FileList { get; set; }
        /// <summary>
        /// Collect All The Current Files Error that are encountered by the maper 
        /// </summary>
        public List<string> FileErrors;

        /// <summary>
        /// Collect All The Current Files Error that are encountered by the maper 
        /// </summary>
        public List<string> DirectoriesError; 
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

        /// <summary>
        /// allows to print the status of the current file search 
        /// </summary>
        public bool AllowDebugger; 
    }
}
