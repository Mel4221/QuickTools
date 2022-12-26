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
using System.Diagnostics;
using System.Net;
using QuickTools;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Reflection;
namespace QuickTools
{

      /// <summary>
      /// Checks for an updatae and also downaloads it 
      /// </summary>
      public class Updater:DownloadManager
      {
            WebClient webClient = new WebClient(); 

            /// <summary>
            /// Gets or sets the file version.
            /// </summary>
            /// <value>The file version.</value>
            public string FileVersion { get; set; }

            /// <summary>
            /// Gets or sets the remote file URL.
            /// </summary>
            /// <value>The remote file URL.</value>
            public string RemoteFileUrl { get; set; }

            /// <summary>
            /// /
            /// </summary>
            /// <value>The download loaction.</value>
            public string DownloadLoaction { get; set; }

            /// <summary>
            /// Gets or sets the remote version.
            /// </summary>
            /// <value>The remote version.</value>
            public int RemoteVersion { get; set; }

            /// <summary>
            /// The assembly info.
            /// </summary>
            public Assembly AssemblyInfo; 

                  
            /// <summary>
            /// Gets the version file;
            /// </summary>
            /// <returns>Returns the number version from the file</returns>
            public int GetVersionFile()
            {
                
                        var fileVersion = this.webClient.DownloadString(this.FileVersion);
                        return int.Parse(fileVersion);
             
            }


            /// <summary>
            /// Initializes a new instance of the <see cref="T:QuickTools.Updater"/> class.
            /// </summary>
            public Updater()
            {
            }
            /// <summary>
            /// Initializes a new instance of the <see cref="T:QuickTools.Updater"/> class.
            /// </summary>
            /// <param name="urlFromVertionFile">URL from vertion file.</param>
            /// <param name="downloadLocation">Download location.</param>
            public Updater(string urlFromVertionFile,string downloadLocation)
            {
                  this.FileVersion = urlFromVertionFile;
                  this.DownloadLoaction = downloadLocation;
            }

      }
}
