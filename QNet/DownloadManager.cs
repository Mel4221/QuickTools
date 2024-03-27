//
// ${Melquiceded Balbi Villanueva}
//
// Author:
//       ${Melquiceded} <${melquiceded.balbi@gmail.com}>
//
// Copyright (c) ${2089} MIT
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using System.Net;
using QuickTools.QConsole;
using QuickTools.QCore;
using System.ComponentModel;

using System.IO;
using System.Security.Policy;

namespace QuickTools.QNet
{
   
    /// <summary>
    /// Download manager.
    /// </summary>
    public class DownloadManager
      {


        /*
		public void MyDownloadFile(string webUrl, string outputFilePath)
		{
            Uri url = new Uri(webUrl); 
			const int BUFFER_SIZE = 16 * 1024;
			using (var outputFileStream = File.Create(outputFilePath, BUFFER_SIZE))
			{
				var req = WebRequest.Create(url);
				using (var response = req.GetResponse())
				{
					using (var responseStream = response.GetResponseStream())
					{
						var buffer = new byte[BUFFER_SIZE];
						int bytesRead;
						do
						{
							bytesRead = responseStream.Read(buffer, 0, BUFFER_SIZE);
							outputFileStream.Write(buffer, 0, bytesRead);
						} while (bytesRead > 0);
					}
				}
			}
		}
        */

        /// <summary>
        /// Download the specified url, file, length and allowDebugger.
        /// </summary>
        /// <param name="url">URL.</param>
        /// <param name="file">File.</param>
        /// <param name="length">Length.</param>
        /// <param name="allowDebugger">If set to <c>true</c> allow debugger.</param>
        public static void Download(string url, string file, int length, bool allowDebugger)
        {
            int bufferSize = length;
            string filePath = file;

            if (File.Exists(filePath))
                File.Delete(filePath);
            int totalBytes = 0;
            HttpWebRequest webRequest =
                (HttpWebRequest)
                HttpWebRequest.Create(url);
            long contentLength = webRequest.GetResponse().ContentLength;
            Console.WriteLine(totalBytes);

            using (WebResponse webResponse = webRequest.GetResponse())
            using (Stream reader = webResponse.GetResponseStream())
            using (BinaryWriter fileWriter = new BinaryWriter(File.Create(filePath)))
            {
                int bytesRead = 0;
                byte[] buffer = new byte[bufferSize];
                do
                {
                    bytesRead = reader.Read(buffer, 0, buffer.Length);
                    totalBytes += bytesRead;
                    fileWriter.Write(buffer, 0, bytesRead);
                    if (allowDebugger)
                    {
                        // Console.WriteLine("BytesRead: " + bytesRead + " -- TotalBytes: " + totalBytes);
                        Get.Green($"DOWNLOADING [{Get.Status(totalBytes, length)}] [{url}]");
                    }

                } while (bytesRead > 0);
            }
        }

        /// <summary>
        /// Download the specified url, file and length.
        /// </summary>
        /// <param name="url">URL.</param>
        /// <param name="file">File.</param>
        /// <param name="length">Length.</param>
        public static void Download(string url, string file, int length)
        {
            int bufferSize = length;
            string filePath = file;

            if (File.Exists(filePath))
                File.Delete(filePath);
            int totalBytes = 0;
            HttpWebRequest webRequest =
                (HttpWebRequest)
                HttpWebRequest.Create(url);
            long contentLength = webRequest.GetResponse().ContentLength;
            Console.WriteLine(totalBytes);

            using (WebResponse webResponse = webRequest.GetResponse())
            using (Stream reader = webResponse.GetResponseStream())
            using (BinaryWriter fileWriter = new BinaryWriter(File.Create(filePath)))
            {
                int bytesRead = 0;
                byte[] buffer = new byte[bufferSize];
                do
                {
                    bytesRead = reader.Read(buffer, 0, buffer.Length);
                    totalBytes += bytesRead;
                    fileWriter.Write(buffer, 0, bytesRead);
                    Console.WriteLine("BytesRead: " + bytesRead + " -- TotalBytes: " + totalBytes);

                } while (bytesRead > 0);
            }
        }
        private volatile bool _completed;
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:QuickTools.QNet.DownloadManager"/> allow debugger.
        /// </summary>
        /// <value><c>true</c> if allow debugger; otherwise, <c>false</c>.</value>
        public bool AllowDebugger { get; set; } = false; 
        /// <summary>
        /// Downloads the file.
        /// </summary>
        /// <param name="address">Address.</param>
        /// <param name="fileName">Location.</param>
        public void DownloadFile(string address, string fileName)
            {

            using (WebClient client = new WebClient())
            {
                client.UseDefaultCredentials = true;

                Uri Uri = new Uri(address);
                _completed = false;
                                                    
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgress);

                client.DownloadFileAsync(Uri, fileName);
                while (client.IsBusy) { }
            }

            }
        /// <summary>
        /// Download the specified address, fileName and debugger.
        /// </summary>
        /// <param name="address">Address.</param>
        /// <param name="fileName">File name.</param>
        /// <param name="debugger">If set to <c>true</c> debugger.</param>
        public static void Download(string address , string fileName, bool debugger)
        {
            using (WebClient client = new WebClient())
            {
                DownloadManager manager = new DownloadManager();
                 client.UseDefaultCredentials = true;

                Uri Uri = new Uri(address);
                manager._completed = false;

                client.DownloadFileCompleted += new AsyncCompletedEventHandler(manager.Completed);
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(manager.DownloadProgress);

                client.DownloadFileAsync(Uri, fileName);
                while (client.IsBusy) { }
            }
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="T:QuickTools.DownloadManager"/> download completed.
        /// </summary>
        /// <value><c>true</c> if download completed; otherwise, <c>false</c>.</value>
        public bool DownloadCompleted { get { return _completed; } }

        QProgressBar ProgressBar = new QProgressBar(); 

         /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public string Status { get; set; } = "not-started"; 
        private void DownloadProgress(object sender, DownloadProgressChangedEventArgs e)
        {
            this.Status = e.ProgressPercentage.ToString(); 
            if (this.AllowDebugger)
            {
                this.ProgressBar.Display(Get.Status(e.ProgressPercentage, 100));
                this.Status =e.ProgressPercentage.ToString();
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
            /// Gets or sets the address for the file that wish to download
            /// </summary>
            /// <value>The address.</value>
            public string Address { get; set; }
            /// <summary>
            /// Gets or sets the name of the file for the file downloaded
            /// </summary>
            /// <value>The name of the file.</value>
            public string FileName { get; set; }
            /// <summary>
            /// Downloads the file.
            /// </summary>
            public void DownloadFile()
            {
            this.DownloadFile(this.Address, this.FileName);
            /*
                  if (address == "" || location == "")
                  {
                        throw new ArgumentException("Incorrect Arguments Were provided  or JUST NOT PROVIDED AT ALL ");
                  }
                  WebClient client = new WebClient();
            client.UseDefaultCredentials = true;

            Uri Uri = new Uri(address);
                  _completed = false;

                  client.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                  client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgress);
                  client.DownloadFileAsync(Uri, location);
                */
            }

            /*
            public void DownloadFile(bool waitToFinish)
        {
            if (address == "" || location == "")
            {
                throw new ArgumentException("Incorrect Arguments Were provided  or JUST NOT PROVIDED AT ALL ");
            }
            WebClient client = new WebClient();
            client.UseDefaultCredentials = true; 
            Uri Uri = new Uri(address);
            _completed = false;

            client.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgress);
            client.DownloadFileAsync(Uri, location);
            if (waitToFinish)
            {
                while (!this.DownloadCompleted)
                {

                }
            }
        }

        */


        /// <summary>
        /// Initializes a new instance of the <see cref="T:QuickTools.DownloadManager"/> class.
        /// </summary>
        public DownloadManager()
            {

            }
          
            /// <summary>
            /// Initializes a new instance of the <see cref="T:QuickTools.DownloadManager"/> class.
            /// </summary>
            /// <param name="url">URL.</param>
            /// <param name="fileName">File name.</param>
            public DownloadManager(string url, string fileName)
            {
                  this.Address = url;
                  this.FileName = fileName; 
            }
      }
}
