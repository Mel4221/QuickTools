//
// printList.cs
//
// Author:
//       melquiceded balbi villanueva <mbv@projects.com>
//
// Copyright (c) 2022 MIT
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
using QuickTools.Colors; 
using System.Collections.Generic; 
namespace QuickTools
{
      /// <summary>
      /// Print print a list of the array that is passed through 
      /// and was created to avoid creatting forloops everywhere
      /// just because .
      /// </summary>
      public class Print
      {


            /// <summary>
            /// List the entire file array 
            /// </summary>
            /// <param name="array">Array.</param>
          public static void List(object[] array)
            {
                  for(int item = 0; item<array.Length; item++)
                  {
                        Color.Green($"{item+1}. "+array[item]); 
                  }
            }

            /// <summary>
            /// List the entire file array 
            /// </summary>
            /// <param name="list">Array.</param>
            public static void List(List<string> list)
            {
                  for (int item = 0; item < list.Count; item++)
                  {
                        Color.Green(list[item]);
                  }
            }
            /// <summary>
            /// List the entire file array 
            /// </summary>
            /// <param name="array">Array.</param>
            public static void List(int[] array)
            {
                  for (int item = 0; item < array.Length; item++)
                  {
                        Color.Green($"{item+1}. "+array[item]);
                  }
            }
            /// <summary>
            /// List the entire file array 
            /// </summary>
            /// <param name="array">Array.</param>
            public static void List(string[] array)
            {
                  for (int item = 0; item < array.Length; item++)
                  {
                        Color.Green($"{item+1}. "+array[item]);
                  }
            }
            /// <summary>
            /// List the entire file array 
            /// </summary>
            /// <param name="array">Array.</param>
            public static void List(byte[] array)
            {
                 
                  for (int item = 0; item < array.Length; item++)
                  {
                        Color.Green($"{item+1}. "+array[item]);
                  }
            }
            /// <summary>
            /// List the entire file array 
            /// </summary>
            /// <param name="array">Array.</param>
            public static void List(bool[] array)
            {
                  for (int item = 0; item < array.Length; item++)
                  {
                        Color.Green($"{item+1}. "+array[item]);
                  }
            }

            /// <summary>
            /// List the entire file array 
            /// </summary>
            /// <param name="array">Array.</param>
            public static void List(double[] array)
            {
                  for (int item = 0; item < array.Length; item++)
                  {
                        Color.Green($"{item+1}. "+array[item]);
                  }
            }
      }
}
