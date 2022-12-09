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
using System.Threading; 
using System.Collections.Generic; 
namespace QuickTools
{

      /// <summary>
      /// Cache handeler.
      /// </summary>
      public partial class CacheHandeler: Cache 
      {


            /// <summary>
            /// The cache bank.
            /// </summary>
            public List<Cache> CacheBank = new List<Cache>();


            /// <summary>
            /// The cache thread.
            /// </summary>
            public static Thread CacheThread;

            /// <summary>
            /// The is active.
            /// </summary>
            public static bool IsActive = false; 


            /// <summary>
            /// Get the specified Id.
            /// </summary>
            /// <returns>The get.</returns>
            /// <param name="Id">Identifier.</param>
            public Cache Get(int Id)
            {
                  foreach(var cache in CacheBank)
                  {
                        if(cache.ID == Id)
                        {
                              return cache; 
                        }
                  }

                  return default(Cache); 
            }

            /// <summary>
            /// Remove the specified Id.
            /// </summary>
            /// <param name="Id">Identifier.</param>
            public void Remove(int Id)
            {
                  CacheBank.Remove(this.Get(Id));
                
            }

            /// <summary>
            /// Set the specified cache.
            /// </summary>
            /// <param name="cache">Cache.</param>
            public void Set(Cache cache)
            {
                  CacheBank.Add(cache);

            }


            /// <summary>
            /// Autos the refresh.
            /// </summary>
            public void AutoRefresh()
            {
                  CacheThread  = new Thread(Refresher);
                  CacheThread.Name = "CacheRefresher";
                  CacheThread.Priority = ThreadPriority.BelowNormal;
                  CacheThread.Start(); 
            }

            private  static void Refresher()
            {
                  while (true)
                  {
                        Console.Title = $"Running... {IRandom.RandomInt(1000,9999)}"; 
                  }
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="T:QuickTools.CacheHandeler"/> class.
            /// </summary>
            public CacheHandeler()
            {
                  AutoRefresh();
            }
          /// <summary>
          /// Initializes a new instance of the <see cref="T:QuickTools.CacheHandeler"/> class.
          /// </summary>
          /// <param name="autoInit">If set to <c>true</c> auto init.</param>
            public CacheHandeler(bool autoInit)
            {
                  CacheHandeler.IsActive = autoInit; 
                  AutoRefresh();
            }
      }



      /// <summary>
      /// Cache.
      /// </summary>
      public class Cache
      {

            /// <summary>
            /// Gets or sets the name.
            /// </summary>
            /// <value>The name.</value>
            public string Name { get; set; }
            /// <summary>
            /// Gets or sets the identifier.
            /// </summary>
            /// <value>The identifier.</value>
            public int ID { get; set;  }
            /// <summary>
            /// Gets or sets the type.
            /// </summary>
            /// <value>The type.</value>
            public string Type { get; set; }
            /// <summary>
            /// Gets or sets the content.
            /// </summary>
            /// <value>The content.</value>
            public string Content { get; set; }
            /// <summary>
            /// Gets or sets the path.
            /// </summary>
            /// <value>The path.</value>
            public string Path { get; set;  }
            /// <summary>
            /// Initializes a new instance of the <see cref="T:QuickTools.Cache"/> class.
            /// </summary>
            public Cache()
            {

            }
      }
}
