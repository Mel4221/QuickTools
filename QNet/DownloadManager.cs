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

namespace QuickTools.QNet
{
      /// <summary>
      /// Download manager.
      /// </summary>
      public class DownloadManager
      {
            private volatile bool _completed;
     
            /// <summary>
            /// Downloads the file.
            /// </summary>
            /// <param name="address">Address.</param>
            /// <param name="location">Location.</param>
            public void DownloadFile(string address, string location)
            {
             
                  WebClient client = new WebClient();
                  Uri Uri = new Uri(address);
                  _completed = false;

                  client.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                  client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgress);
                  client.DownloadFileAsync(Uri, location);

            }

            /// <summary>
            /// Gets a value indicating whether this <see cref="T:QuickTools.DownloadManager"/> download completed.
            /// </summary>
            /// <value><c>true</c> if download completed; otherwise, <c>false</c>.</value>
            public bool DownloadCompleted { get { return _completed; } }

            private CProgressBar ProgressBar = new CProgressBar();

            private void DownloadProgress(object sender, DownloadProgressChangedEventArgs e)
            {
                  ProgressBar.Display(e.ProgressPercentage, 100);
            }

            private void Completed(object sender, AsyncCompletedEventArgs e)
            {
                  if (e.Cancelled == true)
                  {
                        Console.WriteLine("Download has been canceled.");
                  }
                  else
                  {
                        Console.WriteLine("Download completed!");
                  }

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
                  Uri Uri = new Uri(address);
                  _completed = false;

                  client.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                  client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgress);
                  client.DownloadFileAsync(Uri, location);

                  Get.Wait(); 
                  Environment.Exit(0); 
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
