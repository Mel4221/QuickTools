using System;
using System.ComponentModel;
using System.Net;
using QuickTools.QConsole;
using QuickTools.QCore;

namespace QuickTools.QNet
{
    public class UploadManager
    {

        /// <summary>
        /// Gets or sets the address for the file to be uploaded
        /// </summary>
        /// <value>The address.</value>
        public string Address { get; set; } = null;

        /// <summary>
        /// Gets or sets the name of the file for the file that wish to be uploaded
        /// </summary>
        /// <value>The name of the file.</value>
        public string FileName { get; set; } = null;
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:QuickTools.QNet.UploadManager"/> allow debugger.
        /// </summary>
        /// <value><c>true</c> if allow debugger; otherwise, <c>false</c>.</value>
        public bool AllowDebugger { get; set; } = false;



        private volatile bool _completed;

        /// <summary>
        /// Uploads the file.
        /// </summary>
        /// <param name="address">Address.</param>
        /// <param name="fileName">File name.</param>
        public void UploadFile(string address, string fileName)
        {

            using (WebClient client = new WebClient())
            {
                client.UseDefaultCredentials = true;

                Uri Uri = new Uri(address);
                _completed = false;
                //AsyncCompletedEventHandler
                client.UploadFileCompleted += new UploadFileCompletedEventHandler(Completed);
                client.UploadProgressChanged += new UploadProgressChangedEventHandler(UploadProgressChanged);
                client.UploadFileAsync(Uri, fileName);
                while (client.IsBusy) { }
            }

        }
        QProgressBar ProgressBar = new QProgressBar();

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public string Status { get; set; } = "not-started";

        private void UploadProgressChanged(object sender, UploadProgressChangedEventArgs e)
        {
            this.Status = e.ProgressPercentage.ToString();
            if (this.AllowDebugger)
            {
                this.ProgressBar.Display(Get.Status(e.ProgressPercentage, 100));
                this.Status = e.ProgressPercentage.ToString();
            }

        }
        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                //if(this.AllowDebugger)Console.WriteLine("Download has been canceled.");
                return;
            }
            //if(this.AllowDebugger)Console.WriteLine("Download completed!");


            _completed = true;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:QuickTools.QNet.UploadManager"/> class.
        /// </summary>
        public UploadManager()
        {

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:QuickTools.QNet.UploadManager"/> class.
        /// </summary>
        /// <param name="addresss">Addresss.</param>
        /// <param name="fileName">File name.</param>
        public UploadManager(string addresss,string fileName)
        {
            this.Address = addresss;
            this.FileName = fileName;
        }
    }
}
