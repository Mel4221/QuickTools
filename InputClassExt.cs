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
namespace QuickTools
{
           
                  public partial class Input
                  {


                        private int X;
                        //private int Y;
                        private void DisplayEditor()
                        {
                              string[] array = IConvert.ToType<string>.ToArray(this.ContentList);
                              for (int word = 0; word < array.Length; word++)
                              {

                                    Get.Green($"{Tabs(Margin)}{array[word]}{this.CursorSimbol}{Tabs(Margin)}");

                              }
                        }
                        private void ArrowsHandeler(string key)
                        {

                              switch (key)
                              {
                                    case "LeftArrow":

                                          break;
                                    case "RightArrow":

                                          break;
                                    case "UpArrow":

                                          break;
                                    case "DownArrow":

                                          break;
                              }
                        }
                  }



}
