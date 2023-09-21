﻿//
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

namespace QuickTools.QNet
{
      /// <summary>
      /// Download manager.
      /// </summary>
      public class DownloadManager
      {
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
             
                  WebClient client = new WebClient();
            client.UseDefaultCredentials = true;

            Uri Uri = new Uri(address);
                  _completed = false;

                  client.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                  client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgress);
                  client.DownloadFileAsync(Uri,fileName);

            }

            /// <summary>
            /// Gets a value indicating whether this <see cref="T:QuickTools.DownloadManager"/> download completed.
            /// </summary>
            /// <value><c>true</c> if download completed; otherwise, <c>false</c>.</value>
            public bool DownloadCompleted { get { return _completed; } }

            /// <summary>
            /// The progress bar.
            /// </summary>
            public QProgressBar ProgressBar;
            /// <summary>
            /// Gets or sets the status.
            /// </summary>
            /// <value>The status.</value>
            public string Status { get; set; }
        private void DownloadProgress(object sender, DownloadProgressChangedEventArgs e)
        {
            this.Status = e.ProgressPercentage.ToString(); 
            if (this.AllowDebugger)
            {
                this.ProgressBar = new QProgressBar();
                ProgressBar.Display(e.ProgressPercentage, 100);

            }

        }

            private void Completed(object sender, AsyncCompletedEventArgs e)
            {
                  if (e.Cancelled == true)
                  {
                        if(this.AllowDebugger)Console.WriteLine("Download has been canceled.");
                        return; 
                  }
                  if(this.AllowDebugger)Console.WriteLine("Download completed!");
                 

                  _completed = true;
            }




            private string address { get; set; }
            private string location { get; set; }
            /// <summary>
            /// Downloads the file.
            /// </summary>
            public void DownloadFile()
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
                
            }


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
                  this.address = url;
                  this.location = fileName; 
            }
      }
}
