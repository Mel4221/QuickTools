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
using System.Collections.Generic;
using System.IO; 
using System.Net;
using System.Text;
using System.Threading;
using QuickTools.QCore;


   namespace QuickTools.QNet
      {


    /// <summary>
    /// Provides a listener connection from out bound http request
    /// sadly currently it only support text and pictures , for some reason currently im not able to set up a mode for it to be able to support
    /// videos nor music properly  
    /// </summary>
    public partial class QServer : IDisposable
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
        /// Gets or sets a value indicating whether this <see cref="T:QuickTools.QServer"/> secure protocol.
        /// </summary>
        /// <value><c>true</c> if secure protocol; otherwise, <c>false</c>.</value>
        public bool SecureProtocol = false;

        /// <summary>
        /// Gets or sets the request URL.
        /// </summary>
        /// <value>The request URL.</value>
        public string RequestUrl { get; set; }

        /// <summary>
        /// The response function.
        /// </summary>
        public Func<HttpListenerRequest, byte[]> ResponseFunction = (item) => { return new byte[0]; };


        /// <summary>
        /// Converts to html.
        /// </summary>
        /// <returns>The to html.</returns>
        /// <param name="htmlContent">Html content.</param>
        public byte[] ConvertToHtml(string htmlContent)
        {
            string html = $"<!DOCTYPE html>" +
                          $"<html>" +
                          $"{htmlContent}" +
                          "</html>";
            return Encoding.ASCII.GetBytes(html);
        }
        /// <summary>
        /// This Convert to bytes the html and javascript given 
        /// </summary>
        /// <param name="htmlContenst"></param>
        /// <param name="javascriptContent"></param>
        /// <returns></returns>
        public byte[] ConvertToHtml(string htmlContenst, string javascriptContent)
        {
            string html =
                  $"<!DOCTYPE html>" +
                  $"<html>" +
                  $"{htmlContenst}" +
                  $"<script>" +
                  $"{javascriptContent}" +
                  $"</script>" +
                  "</html>";
            return Encoding.ASCII.GetBytes(html);
        }


            /// <summary>
            /// This allows you to add the 3 main components from a HtmlDocument
            /// </summary>
            /// <param name="htmlContent"></param>
            /// <param name="cssContent"></param>
            /// <param name="javascriptContent"></param>
            /// <returns></returns>
            public byte[] ConvertToHtml(string htmlContent, string cssContent, string javascriptContent)
        {
            string html =
                  $"<!DOCTYPE html>" +
                  $"<html>" +
                  $"<style>" +
                  $"{cssContent}" +
                  $"</style>" +
                  $"{htmlContent}" +
                  $"<script>" +
                  $"{javascriptContent}" +
                  $"</script>" +
                  "</html>";
            return Encoding.ASCII.GetBytes(html);
        }

                  /// <summary>
                  /// Loads the files.
                  /// </summary>
                  /// <returns>The files.</returns>
                  /// <param name="htmlFile">Html file.</param>
                  /// <param name="cssFile">Css file.</param>
                  /// <param name="javascriptFile">Javascript file.</param>
                  public byte[] LoadFiles(string htmlFile,string cssFile,string javascriptFile)
                  {
                       if(!File.Exists(htmlFile) || !File.Exists(cssFile) || !File.Exists(javascriptFile))
                        {
                              throw new FileNotFoundException(); 
                        }
                  return ConvertToHtml(File.ReadAllText(htmlFile) , File.ReadAllText(cssFile) , File.ReadAllText(javascriptFile)); 
                  }


            /// <summary>
            /// Converts to row string 
            /// </summary>
            /// <returns>The to row.</returns>
            /// <param name="stringContent">String content.</param>
            public byte[] ConvertToRow(string stringContent)
        {
            return Encoding.ASCII.GetBytes(stringContent);
        }

            /// <summary>
            /// Response header.
            /// </summary>
        public class ResponseHeader
        {
                   /// <summary>
                  /// The key.
                  /// </summary>
            public string Key;
            /// <summary>
            /// The value.
            /// </summary>
            public string Value;
        }
            /// <summary>
            /// The response headers.
            /// </summary>
        public List<ResponseHeader> ResponseHeaders= new List<ResponseHeader>();
        
            /// <summary>
            /// 
            /// </summary>
        public Func<List<ResponseHeader>> SetResponseHeadersList = () => { return new List<ResponseHeader>(); }; 

                  

                  /// <summary>
                  /// Listen for a request and return the string clear request  
                  /// </summary>
                  /// <returns>The listen.</returns>
                  public HttpListenerRequest Listen()
                  {
                        

                        Get.Green($"Listening At: {this.Address}");
                        HttpListener listener = new HttpListener();
                        listener.UnsafeConnectionNtlmAuthentication = SecureProtocol == false ? false : true;
                        listener.Prefixes.Add(this.Address);
                        listener.Start();
                        HttpListenerContext context = listener.GetContext();
                        HttpListenerRequest request = context.Request;
                        HttpListenerResponse response = context.Response;
                        List<ResponseHeader> headers = SetResponseHeadersList();
                        if (headers.Count > 0)
                        {
                            foreach (var header in headers)
                            {
                                response.Headers.Add(header.Key, header.Value);
                            }
                        }

                        this.RequestUrl = request.RawUrl.Substring(1);
                  byte[] buffer = ResponseFunction(request);
                  response.ContentLength64 = buffer.Length;

                  var thread = new Thread(() =>
                  {
                        Stream output = response.OutputStream;
                        output.Write(buffer , 0 , buffer.Length);
                        output.Close();
                        listener.Stop();
                  });
                  thread.Start(); 
                        while(true)
                        {
                              if(thread.IsAlive == false)
                              {
                                    break; 
                              }
                        }

                  return request; 
                  }



                  /// <summary>
                  /// Initializes a new instance of the <see cref="T:QuickTools.Connector"/> class.
                  /// </summary>
                  /// <param name="url">URL.</param>
                  /// <param name="port">Port.</param>
                  /// <param name="secureProtocol">If set to <c>true</c> secure protocol.</param>
                  public QServer(string url, int port, bool secureProtocol)
                  {


                        this.Port = port;
                        this.URL = url;
                        this.SecureProtocol = secureProtocol;
                        string protocol = SecureProtocol == true ? this.Protocol[0] : this.Protocol[1];
                        this.Address = $"{protocol}{this.URL}:{this.Port}/";
                        //Get.Wait(Address); 
                  }

                  /// <summary>
                  /// Initializes a new instance of the <see cref="T:QuickTools.Connector"/> class.
                  /// </summary>
                  /// <param name="url">URL.</param>
                  /// <param name="port">Port.</param>
                  public QServer(string url, int port)
                  {

                        this.Port = port;
                        this.URL = url;
                        string protocol = SecureProtocol == true ? this.Protocol[0] : this.Protocol[1];
                        this.Address = $"{protocol}{this.URL}:{this.Port}/";
                  }


                  /// <summary>
                  /// Initializes a new instance of the <see cref="T:QuickTools.Connector"/> class.
                  /// </summary>
                  /// <param name="url">URL.</param>
                  public QServer(string url)
                  {

                        this.Port = 4251;
                        this.URL = url;
                        string protocol = this.SecureProtocol == true ? this.Protocol[0] : this.Protocol[1];
                        this.Address = $"{protocol}{this.URL}:{this.Port}/";
                        //Get.Yellow($"{this.SecureProtocol} : {this.Protocol[0]} : {this.Protocol[1]}");
                        //Get.Wait(this.Address);
                  }
                  /// <summary>
                  /// Initializes a new instance of the <see cref="T:QuickTools.Connector"/> class.
                  /// </summary>
                  public QServer()
                  {

                        this.Port = 4251;
                        this.URL = "localhost";
                        string protocol = this.SecureProtocol == true ? this.Protocol[0] : this.Protocol[1];
                        this.Address = $"{protocol}{this.URL}:{this.Port}/";
                        
                        //Get.Yellow($"{this.SecureProtocol} : {this.Protocol[0]} : {this.Protocol[1]}");
                        //Get.Wait(this.Address);


                  }

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
                   /// Releases all resource used by the <see cref="T:QuickTools.Net.Connector"/> object.
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
      }






/*



            /// <summary>
            /// Initializes a new instance of the <see cref="T:QuickTools.Connector"/> class.
            /// </summary>
            /// <param name="url">URL.</param>
            /// <param name="port">Port.</param>
            /// <param name="secureProtocol">If set to <c>true</c> secure protocol.</param>
            /// <param name="F">F.</param>
            public Connector(string url, int port, bool secureProtocol, Func<string,string> F)
            {
         
                  this.ResponseAction = F;
                  this.Port = port;
                  this.URL = url;
                  this.SecureProtocol = secureProtocol;
                  string protocol = SecureProtocol == true ? this.Protocol[0] : this.Protocol[1];
                  this.Address = $"{protocol}{this.URL}:{this.Port}/";
                  //Get.Wait(Address); 
            }
            /// <summary>
            /// Initializes a new instance of the <see cref="T:QuickTools.Connector"/> class.
            /// </summary>
            /// <param name="url">URL.</param>
            /// <param name="port">Port.</param>
            /// <param name="secureProtocol">If set to <c>true</c> secure protocol.</param>
            public Connector(string url, int port,bool secureProtocol)
            {
                  Func<string,string> F = (item) => {
                        Get.Yellow("Not Request handeler set up ");
                        return null;
                  };
                  this.ResponseAction = F;
                  this.RequestAction = F; 
                  this.Port = port;
                  this.URL = url;
                  this.SecureProtocol = secureProtocol; 
                  string protocol = SecureProtocol==true? this.Protocol[0] : this.Protocol[1];
                  this.Address = $"{protocol}{this.URL}:{this.Port}/";
                  //Get.Wait(Address); 
            }
            /// <summary>
            /// Initializes a new instance of the <see cref="T:QuickTools.Connector"/> class.
            /// </summary>
            /// <param name="url">URL.</param>
            /// <param name="port">Port.</param>
            public Connector(string url, int port)
            {
                  Func<string, string> F = (item) => {
                        Get.Yellow("Not Request handeler set up ");
                        return null;
                  };
                  this.ResponseAction = F;
                  this.RequestAction = F;
                  this.Port = port;
                  this.URL = url; 
                  string protocol = SecureProtocol==true? this.Protocol[0] : this.Protocol[1];
                  this.Address = $"{protocol}{this.URL}:{this.Port}/";
            }


            /// <summary>
            /// Initializes a new instance of the <see cref="T:QuickTools.Connector"/> class.
            /// </summary>
            /// <param name="url">URL.</param>
            public Connector(string url)
            {
                  Func<string, string> F = (item) => {
                        Get.Yellow("Not Request handeler set up ");
                        return null;
                  };
                  this.ResponseAction = F;
                  this.RequestAction = F;
                  this.Port = 4251;
                  this.URL = url;
                  string protocol = this.SecureProtocol == true ? this.Protocol[0] : this.Protocol[1];
                  this.Address = $"{protocol}{this.URL}:{this.Port}/";
                  //Get.Yellow($"{this.SecureProtocol} : {this.Protocol[0]} : {this.Protocol[1]}");
                  //Get.Wait(this.Address);
            }
            /// <summary>
            /// Initializes a new instance of the <see cref="T:QuickTools.Connector"/> class.
            /// </summary>
            public Connector()
            {
                  Func<string, string> F = (item) => {
                        Get.Yellow("Not Request handeler set up ");
                        return null;
                  };
                  this.ResponseAction = F;
                  this.RequestAction = F;
                  this.Port = 4251;
                  this.URL = "localhost";
                  string protocol = this.SecureProtocol==true? this.Protocol[0] : this.Protocol[1];
                  this.Address = $"{protocol}{this.URL}:{this.Port}/";
                  //Get.Yellow($"{this.SecureProtocol} : {this.Protocol[0]} : {this.Protocol[1]}");
                  //Get.Wait(this.Address);


            }
      
            
      */
