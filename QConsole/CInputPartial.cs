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
using QuickTools.QCore;

namespace QuickTools.QConsole
{

      public partial class CInput
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
                              int index = 0;
                              string temp = null;
                              switch (key)
                              {
                                    case "LeftArrow":
                                    
                                    ArrayWalker.Array = IConvert.ToType<string>.ToArray(this.ContentList);
                                    index = ArrayWalker.Walk();
                                    if (this.ContentList.Count >= index) temp = this.ContentList[index]; 
                                    Get.Blue($"Index: {index} Content List Reference: {temp}");

                                    this.ContentList = IConvert.ToType<string>.ToList(this.ArrayWalker.Array);
                                    Get.Wait($"Arrows Current X: {ArrayWalker.Arrows.X} Converted To List: {this.ContentList[index]} Length: {this.ContentList.Count}");
                                    //this.ArrayWalker = new ArrayWalker(); 

                                          break;
                                    case "RightArrow":

                                    ArrayWalker.Array = IConvert.ToType<string>.ToArray(this.ContentList);
                                    index = ArrayWalker.Walk();
                                    if (this.ContentList.Count >= index) temp = this.ContentList[index];
                                    Get.Wait($"Index: {index} Content List Reference: {temp}");
                                    //this.ArrayWalker = new ArrayWalker();
                                          break;

                                    case "UpArrow":

                                          break;
                                    case "DownArrow":

                                          break;
                              }
                        }
                  }



}
