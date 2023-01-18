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

namespace QuickTools
{
   
      namespace QNet
      {
                   
            /// <summary>
            /// Get Request Method
            /// </summary>
                  public class QHttp:IDisposable
                  {
                              /// <summary>
                              /// Header.
                              /// </summary>
                                 public  class Header
                              {
                                          /// <summary>
                                          /// Gets or sets the key.
                                          /// </summary>
                                          /// <value>The key.</value>
                                    public string Key { get; set; }
                                          /// <summary>
                                          /// Gets or sets the value.
                                          /// </summary>
                                          /// <value>The value.</value>
                                    public string Value { get; set; }
                              }
                        
                        /// <summary>
                        /// Gets or sets the URL.
                        /// </summary>
                        /// <value>The URL.</value>
                        public string Url { get; set; }
                        
                        /// <summary>
                        /// Gets or sets a value indicating whether this <see cref="T:QuickTools.Net.QHttp"/> notify status.
                        /// </summary>
                        /// <value><c>true</c> if notify status; otherwise, <c>false</c>.</value>
                        public bool NotifyStatus { get; set; }
                        
                        /// <summary>
                        /// Gets or sets a value indicating whether this <see cref="T:QuickTools.Net.QHttp"/> require
                        /// server certicate.
                        /// </summary>
                        /// <value><c>true</c> if require server certicate; otherwise, <c>false</c>.</value>
                        public bool RequireServerCerticate { get; set; }
                        
                        /// <summary>
                        /// Gets or sets the response.
                        /// </summary>
                        /// <value>The response.</value>
                        public HttpWebResponse Response { get; set; }
                        
                        /// <summary>
                        /// Gets or sets the headers.
                        /// </summary>
                        /// <value>The headers.</value>
                        public List<Header> Headers { get; set; }

               


                              /// <summary>
                              /// Makes a Get request method to the given and returns the string response 
                              /// </summary>
                              /// <returns>The get.</returns>
                              public string Get()
                              {

                        //string context = "context=Data Source=data1.cwzysvw0mxjn.us-east-2.rds.amazonaws.com;Initial Catalog=ManSys;Persist Security Info=True;User ID=admin;Password=Dmelqui20181";
                        try
                        {
                              Uri link = new Uri(Url);



                              if (NotifyStatus == true) Console.Title = "Stablishing Connection...";
                              // string connection = null;

                              WebRequest request = WebRequest.Create(link);
                              if (this.Headers.Count > 0)
                              {
                                    foreach (Header header in Headers)
                                    {
                                          request.Headers[header.Key] = header.Value;
                                    }
                              }


                              request.Method = "GET";

                              if (RequireServerCerticate == false) ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                              HttpWebResponse response = null;

                              response = (HttpWebResponse)request.GetResponse();

                              string result = null;
                              using (Stream stream = response.GetResponseStream())
                              {
                                    StreamReader reader = new StreamReader(stream);
                                    result = reader.ReadToEnd();
                              }
                              return result;

                        }
                        catch (WebException e)
                        {
                              return $"It looks like something went wrong more info: \n {e.Message}";
                        }
                        catch(UriFormatException e)
                        {
                              return $"The URL provided is not valid \n {e.Message}"; 
                        }
                        catch (Exception e)
                        {
                              return $"There Was an error processing the request and it could not be process , please verify your internet and try again later more info: \n {e.Message}"; 
                        }

                  }


                  /// <summary>
                  /// Get the specified url.
                  /// </summary>
                  /// <returns>The get.</returns>
                  /// <param name="url">URL.</param>
                  public string Get(string url)
                  {

                        //string context = "context=Data Source=data1.cwzysvw0mxjn.us-east-2.rds.amazonaws.com;Initial Catalog=ManSys;Persist Security Info=True;User ID=admin;Password=Dmelqui20181";
                        try
                        {
                              Uri link = new Uri(url);



                              if (NotifyStatus == true) Console.Title = "Stablishing Connection...";
                              // string connection = null;

                              WebRequest request = WebRequest.Create(link);
                              if (this.Headers.Count > 0)
                              {
                                    foreach (Header header in Headers)
                                    {
                                          request.Headers[header.Key] = header.Value;
                                    }
                              }


                              request.Method = "GET";

                              if (RequireServerCerticate == false) ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                              HttpWebResponse response = null;

                              response = (HttpWebResponse)request.GetResponse();

                              string result = null;
                              using (Stream stream = response.GetResponseStream())
                              {
                                    StreamReader reader = new StreamReader(stream);
                                    result = reader.ReadToEnd();
                              }
                              return result;

                        }
                        catch (WebException e)
                        {
                              return $"It looks like something went wrong more info: \n {e.Message}";
                        }
                        catch (UriFormatException e)
                        {
                              return $"The URL provided is not valid \n {e.Message}";
                        }
                        catch (Exception e)
                        {
                              return $"There Was an error processing the request and it could not be process , please verify your internet and try again later more info: \n {e.Message}";
                        }

                  }

                  /// <summary>
                  /// Get the specified url and callBackFunction.
                  /// </summary>
                  /// <returns>The get.</returns>
                  /// <param name="url">URL.</param>
                  /// <param name="callBackFunction">Call back function.</param>
                  public string Get(string url,Func<string,byte[]> callBackFunction)
                  {

                        //string context = "context=Data Source=data1.cwzysvw0mxjn.us-east-2.rds.amazonaws.com;Initial Catalog=ManSys;Persist Security Info=True;User ID=admin;Password=Dmelqui20181";
                        try
                        {
                              Uri link = new Uri(url);



                              if (NotifyStatus == true) Console.Title = "Stablishing Connection...";
                              // string connection = null;

                              WebRequest request = WebRequest.Create(link);
                              if (this.Headers.Count > 0)
                              {
                                    foreach (Header header in Headers)
                                    {
                                          request.Headers[header.Key] = header.Value;
                                    }
                              }


                              request.Method = "GET";

                              if (RequireServerCerticate == false) ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                              HttpWebResponse response = null;

                              response = (HttpWebResponse)request.GetResponse();

                              string result = null;
                              using (Stream stream = response.GetResponseStream())
                              {
                                    StreamReader reader = new StreamReader(stream);
                                    result = reader.ReadToEnd();
                              }
                              if(!callBackFunction.Equals(null))
                              {
                                    callBackFunction(result); 
                              }
                              return result;

                        }
                        catch (WebException e)
                        {
                              return $"It looks like something went wrong more info: \n {e.Message}";
                        }
                        catch (UriFormatException e)
                        {
                              return $"The URL provided is not valid \n {e.Message}";
                        }
                        catch (Exception e)
                        {
                              return $"There Was an error processing the request and it could not be process , please verify your internet and try again later more info: \n {e.Message}";
                        }

                  }

                  /// <summary>
                  /// Initializes a new instance of the <see cref="T:QuickTools.Net.QHttp"/> class.
                  /// </summary>
                  public QHttp()
                        {
                              Headers = new List<Header>(); 
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
                  /// Releases all resource used by the <see cref="T:QuickTools.Net.QHttp"/> object.
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
}