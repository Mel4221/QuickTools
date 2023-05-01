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


/*
This Contains all the shortcuts for the Alerts
and events of colors for the display of the 
text. 
important Date : today i have change the class name from "Do static class"
to "Get static class" due to some not sence ideas behing the idea of doing stuff
it is nothing related with the performance but more with relation with the 
action that it creates DATE OF UPDATE : 03/11/2022
*/

using System;
using QuickTools.QCore;
//using System.Security;            // has to be implemented 
//using System.Security.Permissions;// it has to be implemented
namespace QuickTools.QConsole
      {
      /// <summary>
      /// This Class in sintended to improve the Options Class
      /// which seems to me  really anticated  and this one provides movements
      /// with all the arrow keys
      /// </summary>
      public class ArrowsKey
            {
            /// <summary>
            /// The x.
            /// </summary>
            public int X = 0;
            /// <summary>
            /// The y.
            /// </summary>
            public int Y = 0;
            /// <summary>
            /// This fields has direct acces but as it returns an array 
            /// the method GetLocation  can provide the number only in an object type 
            /// </summary>
            //public  int[] Location = { this.X, this.Y };

            private void Up()
                  {
                  Y++;
                  }
            private void Down()
                  {
                  Y--;
                  }
            private void Left()
                  {
                  X--;
                  }
            private void Right()
                  {
                  X++;
                  }

            /// <summary>
            /// Capture the specified condition.
            /// </summary>
            /// <param name="condition">Condition.</param>
            public void Capture(string condition)
                  {

                  //  X = Console.BufferWidth - 1;
                  //  Y = Console.BufferHeight - 1;

                  while(Get.Key != condition)
                        {
                        //     Console.Title = $"X: {X}  Y: {Y}";
                        //    Console.SetCursorPosition(X, Y);
                        //    Console.WriteLine("X");


                        var app = Console.ReadKey();
                        Get.Key = app.Key.ToString();
                        switch(app.Key.ToString())
                              {
                              case "UpArrow":
                                    //Up();
                                    Y--;
                                    //Color.Green(X+" "+Y); 
                                    break;

                              case "DownArrow":
                                    // Down();
                                    //Color.Green(X+" "+Y); 
                                    Y++;
                                    break;

                              case "LeftArrow":
                                    //  Left();
                                    X--;
                                    //Color.Green(X+" "+Y); 
                                    break;

                              case "RightArrow":
                                    X++;
                                    // Right();
                                    //Color.Green(X+" "+Y); 
                                    break;



                              }

                        //Console.Title = $"X: {X}  Y: {Y}";

                        //    Console.SetCursorPosition(X, Y);
                        //    Console.WriteLine("X");


                        }
                  }

            /// <summary>
            /// Capture the specified condition and triguer an action 
            /// </summary>
            /// <param name="condition">Condition.</param>
            /// <param name="triguer">Triguer.</param>
            public void Capture(string condition , Action triguer)
                  {

                  //  X = Console.BufferWidth - 1;
                  //  Y = Console.BufferHeight - 1;

                  while(Get.Key != condition)
                        {
                        //     Console.Title = $"X: {X}  Y: {Y}";
                        //    Console.SetCursorPosition(X, Y);
                        //    Console.WriteLine("X");


                        var app = Console.ReadKey();
                        Get.Key = app.Key.ToString();
                        switch(app.Key.ToString())
                              {
                              case "UpArrow":
                                    //Up();
                                    Y--;
                                    triguer();
                                    //Color.Green(X+" "+Y); 
                                    break;

                              case "DownArrow":
                                    // Down();
                                    //Color.Green(X+" "+Y); 
                                    Y++;
                                    triguer();

                                    break;

                              case "LeftArrow":
                                    //  Left();
                                    X--;
                                    triguer();

                                    //Color.Green(X+" "+Y); 
                                    break;

                              case "RightArrow":
                                    X++;
                                    triguer();
                                    // Right();
                                    //Color.Green(X+" "+Y); 
                                    break;



                              }

                        //Console.Title = $"X: {X}  Y: {Y}";

                        //    Console.SetCursorPosition(X, Y);
                        //    Console.WriteLine("X");


                        }
                  }
            /// <summary>
            /// Capture the specified condition, triguer and callBack.
            /// </summary>
            /// <param name="condition">Condition.</param>
            /// <param name="triguer">Triguer.</param>
            /// <param name="callBack">Call back.</param>
            public void Capture(string condition , Action triguer , Action callBack)
                  {

                  //  X = Console.BufferWidth - 1;
                  //  Y = Console.BufferHeight - 1;

                  while(Get.Key != condition)
                        {

                        //     Console.Title = $"X: {X}  Y: {Y}";
                        //    Console.SetCursorPosition(X, Y);
                        //    Console.WriteLine("X");


                        var app = Console.ReadKey();
                        Get.Key = app.Key.ToString();
                        switch(app.Key.ToString())
                              {
                              case "UpArrow":
                                    //Up();
                                    Y--;
                                    triguer();
                                    //Color.Green(X+" "+Y); 
                                    break;

                              case "DownArrow":
                                    // Down();
                                    //Color.Green(X+" "+Y); 
                                    Y++;
                                    triguer();

                                    break;

                              case "LeftArrow":
                                    //  Left();
                                    X--;
                                    triguer();

                                    //Color.Green(X+" "+Y); 
                                    break;

                              case "RightArrow":
                                    X++;
                                    triguer();
                                    // Right();
                                    //Color.Green(X+" "+Y); 
                                    break;



                              }

                        //Console.Title = $"X: {X}  Y: {Y}";

                        //    Console.SetCursorPosition(X, Y);
                        //    Console.WriteLine("X");


                        }
                  callBack();
                  }

            /// <summary>
            /// Capture the specified condition, triguer, callBack, limitX and limitY.
            /// </summary>
            /// <param name="condition">Condition.</param>
            /// <param name="triguer">Triguer.</param>
            /// <param name="callBack">Call back.</param>
            /// <param name="limitX">Limit x.</param>
            /// <param name="limitY">Limit y.</param>
            public void Capture(string condition , Action triguer , Action callBack , int[] limitX , int[] limitY)
                  {

                  //  X = Console.BufferWidth - 1;
                  //  Y = Console.BufferHeight - 1;


                  while(Get.Key != condition)
                        {

                        //     Console.Title = $"X: {X}  Y: {Y}";
                        //    Console.SetCursorPosition(X, Y);
                        //    Console.WriteLine("X");


                        var app = Console.ReadKey();
                        Get.Key = app.Key.ToString();

                        // Get.Yellow($"X: {this.X} Y: {this.Y} Xmin: {limitX[0]} Xmax: {limitX[1]} Ymin: {limitY[0]} Ymax: {limitY[1]}");

                        switch(app.Key.ToString())
                              {
                              case "UpArrow":
                                    //Up();
                                    if(Y > limitY[0])
                                          {
                                          Y--;
                                          }
                                    triguer();
                                    //Color.Green(X+" "+Y); 
                                    break;
                              case "DownArrow":
                                    // Down();
                                    //Color.Green(X+" "+Y); 

                                    if(Y < limitY[1])
                                          {
                                          Y++;
                                          }
                                    triguer();
                                    break;
                              case "LeftArrow":
                                    //  Left();
                                    if(X > limitX[0])
                                          {
                                          X--;
                                          }
                                    triguer();
                                    //Color.Green(X+" "+Y); 
                                    break;

                              case "RightArrow":
                                    if(X < limitX[1])
                                          {
                                          X++;
                                          }
                                    triguer();
                                    // Right();
                                    //Color.Green(X+" "+Y); 
                                    break;



                              }

                        //Console.Title = $"X: {X}  Y: {Y}";

                        //    Console.SetCursorPosition(X, Y);
                        //    Console.WriteLine("X");


                        }

                  callBack();
                  }

            /// <summary>
            /// Initializes a new instance of the <see cref="T:QuickTools.ArrowsKey"/> class.
            /// </summary>
            public ArrowsKey()
                  {

                  }
            /// <summary>
            /// Initializes a new instance of the <see cref="T:QuickTools.ArrowsKey"/> class.
            /// </summary>
            /// <param name="intitialX">Intitial x.</param>
            /// <param name="initialY">Initial y.</param>
            public ArrowsKey(int intitialX , int initialY)
                  {
                  X = intitialX;
                  Y = initialY;
                  }
            /// <summary>
            /// Initializes a new instance of the <see cref="T:QuickTools.ArrowsKey"/> class.
            /// </summary>
            /// <param name="intitialX">Intitial x.</param>
            /// <param name="initialY">Initial y.</param>
            /// <param name="SwitchUpDown">If set to <c>true</c> switch up down.</param>
            public ArrowsKey(int intitialX , int initialY , bool SwitchUpDown)
                  {
                  X = intitialX;
                  Y = initialY;

                  }
            }
      }