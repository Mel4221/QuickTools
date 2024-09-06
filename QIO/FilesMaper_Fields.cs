using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickTools.QIO
{
    public partial class FilesMaper:IDisposable
    {

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls
        /// <summary>
        /// Dispose the specified disposing.
        /// </summary>
        /// <param name="disposing">If set to <c>true</c> disposing.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }
        /// <summary>
        /// Releases all resource used by the <see cref="T:QuickTools.QIO.FilesMaper"/> object.
        /// </summary>
           public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion

    }
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
        /// Gets or sets a value indicating whether this <see cref="T:QuickTools.QIO.FilesMaper"/> ignore hidden files.
        /// </summary>
        /// <value><c>true</c> if ignore hidden files; otherwise, <c>false</c>.</value>
        public bool IgnoreHiddenFiles { get; set; } = false;
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:QuickTools.QIO.FilesMaper"/> ignore hidden directorys.
        /// </summary>
        /// <value><c>true</c> if ignore hidden directorys; otherwise, <c>false</c>.</value>
        public bool IgnoreHiddenDirectorys { get; set; } = false; 
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
