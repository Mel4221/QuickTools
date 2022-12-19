//
// OptionExt.cs
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
/*

            This class is still not completed 
            and it will be an extention on the functionality 
            from the Options class  , but it will basically just read
            only the arrow keys from a keayboard            

*/


using System;
namespace QuickTools
{
       class Key
      {

            private static int Position = 0;
            // private static int Depth = 0; 
            private static int ArrayLength = 0;
            private static void DisplayArray()
            {

                  int[] a = { 1, 2, 3, 4, 5 };

                  /*
                   * 
                  int[] a = { 0, 1, 2, 3, 4 };
                  int[] b = { 5, 6, 7, 8, 9 };           
                  int[] c = {-1, 0, 1, 2, 3 };
                  int[] d = {-2, -1, 0, 1,2};
                  int[] e = { -3,-2,-1,0,1 };
                  int[] f = { -4,-3, -2,-1,0}; 
                  */
                  ArrayLength = a.Length;
                  Get.Write("[");
                  for (int i = 0; i < a.Length; i++)
                  {

                        string comma = i < a.Length - 1 ? "," : "";

                        if (a[i] == Position)
                        {
                              Get.LabelSingle(a[i] + comma);
                        }
                        else
                        {
                              Get.Write(a[i] + comma);

                        }


                  }
                  Get.Write("]");

            }

            public static int Read()
            {
                  int x = 0;


                  //Get.Alert("Text");

                  /*
                      Escape
                      UpArrow
                      DownArrow
                      RightArrow               
                      LeftArrow
                  */

                  DisplayArray(); // show the array 
                  while (Get.KeyInput().ToString() != "Enter")
                  {
                        switch (Get.Key)
                        {

                              case "LeftArrow":
                                    if (Position == 0)
                                    {
                                          Position = ArrayLength;
                                    }
                                    else
                                    {
                                          Position--;
                                    }
                                    DisplayArray();

                                    break;
                              case "RightArrow":
                                    if (Position == ArrayLength)
                                    {
                                          Position = 0;
                                    }
                                    else
                                    {
                                          Position++;
                                    }
                                    DisplayArray();
                                    break;
                              default:

                                    Get.Title("To Exit Press Escape");
                                    break;
                        }
                  }





                  return x; 
            }
      }
}
