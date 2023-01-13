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
using System.IO; 
using System.Net;
using System.Text;

namespace QuickTools
{

      /// <summary>
      /// Provides a listener connection from out bound http request 
      /// </summary>
      public class Connector
      {
            /// <summary>
            /// Gets or sets the URL.
            /// </summary>
            /// <value>The URL.</value>
            public string URL { get; set; }
            /// <summary>
            /// Gets or sets the port.
            /// </summary>
            /// <value>The port.</value>
            public int Port { get; set; }
            /// <summary>
            /// The address.
            /// </summary>
            public readonly string Address;
            /// <summary>
            /// The protocol.
            /// </summary>
            public string[] Protocol = { "https://", "http://" };
            /// <summary>
            /// Gets or sets the response action.
            /// </summary>
            /// <value>The response action.</value>
            public Func<string> ResponseAction { get; set; }

            /// <summary>
            /// Start the specified condition.
            /// </summary>
            /// <param name="condition">If set to <c>true</c> condition.</param>
            public void Start(bool condition)
            {
                  while (condition)
                  {


                        HttpListener listener = new HttpListener();
                        listener.UnsafeConnectionNtlmAuthentication = SecureProtocol ? false : true; 
                        //listener.Prefixes.Add("http://127.0.0.1:4251/");
                        listener.Prefixes.Add(this.Address);
                        listener.Start();
                        // Note: The GetContext method blocks while waiting for a request.
                        HttpListenerContext context = listener.GetContext();
                        HttpListenerRequest request = context.Request;
                       //Get.Green($"RowUrl: {request.RawUrl}");
                        //Get.Green($"URL: {request.Url}");
                        // Obtain a response object.
                        HttpListenerResponse response = context.Response;
                        // Construct a response.
                        //WriteLine(request);
                        string responseString = ResponseAction(); 
                        /*@"<script>
                                                      console.log('working');
                                                      document.write('working');
                        </script>".Replace("'", '"'.ToString());
                        */
                        byte[] buffer = Encoding.UTF8.GetBytes(responseString);
                        // Get a response stream and write the response to it.
                        response.ContentLength64 = buffer.Length;
                        Stream output = response.OutputStream;
                        output.Write(buffer, 0, buffer.Length);
                        // You must close the output stream.
                        output.Close();
                        listener.Stop();
                  }
            }




            /// <summary>
            /// Gets or sets a value indicating whether this <see cref="T:QuickTools.Connector"/> secure protocol.
            /// </summary>
            /// <value><c>true</c> if secure protocol; otherwise, <c>false</c>.</value>
            public bool SecureProtocol { get; set; }
            /// <summary>
            /// Initializes a new instance of the <see cref="T:QuickTools.Connector"/> class.
            /// </summary>
            /// <param name="url">URL.</param>
            /// <param name="port">Port.</param>
            public Connector(string url, int port)
            {
                  this.Port = port;
                  this.URL = url; 
                  string protocol = SecureProtocol ? this.Protocol[0] : this.Protocol[1];
                  this.Address = $"{protocol}/{this.URL}:{this.Port}";
            }
            /// <summary>
            /// Initializes a new instance of the <see cref="T:QuickTools.Connector"/> class.
            /// </summary>
            public Connector()
            {
                  this.Port = 4252;
                  this.URL = "localhost";
                  string protocol = SecureProtocol ? this.Protocol[0] : this.Protocol[1];
                  this.Address = $"{protocol}/{this.URL}:{this.Port}";
            }
      }
}
