////
//// ${Melquiceded Balbi Villanueva}
////
//// Author:
////       ${Melquiceded} <${melquiceded.balbi@gmail.com}>
////
//// Copyright (c) ${2089} MIT
////
//// Permission is hereby granted, free of charge, to any person obtaining a copy
//// of this software and associated documentation files (the "Software"), to deal
//// in the Software without restriction, including without limitation the rights
//// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//// copies of the Software, and to permit persons to whom the Software is
//// furnished to do so, subject to the following conditions:
////
//// The above copyright notice and this permission notice shall be included in
//// all copies or substantial portions of the Software.
////
//// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//// THE SOFTWARE.
//using System;
//using static System.Console;
//using QuickTools.QCore;

//using System.Collections.Generic;

//namespace QuickTools.QConsole
//{
//      /// <summary>
//      /// Panel body.
//      /// </summary>
//      public class PanelBody
//      {
//            /// <summary>
//            /// The name.
//            /// </summary>
//            public string Name = "";
//            /// <summary>
//            /// The text.
//            /// </summary>
//            public string Text = "";
//            /// <summary>
//            /// The index.
//            /// </summary>
//            public int Index = 1;
//            /// <summary>
//            /// The length.
//            /// </summary>
//            public int Length = 0;
//            /// <summary>
//            /// The location x.
//            /// </summary>
//            public int LocationX = 1;
//            /// <summary>
//            /// The location y.
//            /// </summary>
//            public int LocationY = 1;
//            /// <summary>
//            /// The color.
//            /// </summary>
//            public string Color = "default";
//            /// <summary>
//            /// The y.
//            /// </summary>
//            public int Y = Console.BufferHeight;
//            /// <summary>
//            /// The x.
//            /// </summary>
//            public int X = Console.BufferWidth;


//            /// <summary>
//            /// Write the specified value, x and y.
//            /// </summary>
//            /// <param name="value">Value.</param>
//            /// <param name="x">The x coordinate.</param>
//            /// <param name="y">The y coordinate.</param>
//            public void Write(object value, int x, int y)
//            {
//                  Console.SetCursorPosition(LocationX, LocationY);
//                  Get.WL(value);
//            }
//      }
//      /// <summary>
//      /// Panel.
//      /// </summary>
//      public class Panel : PanelBody
//      {


//            List<PanelBody> Colection = new List<PanelBody>();


//            /// <summary>
//            /// Adds the item.
//            /// </summary>
//            /// <param name="name">Name.</param>
//            /// <param name="text">Text.</param>
//            public void AddItem(string name, string text)
//            {
//                  //var panel = new Panel();
//                  Name = name;
//                  Text = text;
//                  Length = text.Length;
//                  LocationX = X / 2;
//                  LocationY = Index + 1;
//                  Index++;
//                  WriteLine(Text);
//                  Console.ReadKey();

//                  //Colection.Add(Name);
//                  Display();


//            }
//            /// <summary>
//            /// Display this instance.
//            /// </summary>
//            public void Display()
//            {
//                  Console.ForegroundColor = ConsoleColor.Yellow;
//                  Console.SetCursorPosition(LocationX, LocationY);
//                  /*
//                    foreach(Panel property in Colection)
//                    {
//                        Console.WriteLine(property.Text); 
//                    }
//                    */
//            }
//            /// <summary>
//            /// Initializes a new instance of the <see cref="T:Tester.Panel"/> class.
//            /// </summary>
//            public Panel()
//            {

//            }
//            /// <summary>
//            /// Initializes a new instance of the <see cref="T:Tester.Panel"/> class.
//            /// </summary>
//            /// <param name="text">Text.</param>
//            public Panel(object text)
//            {
//                  this.Text = text.ToString();
//                  this.LocationX = X / 2;
//                  this.LocationY = 1;
//            }
//            /// <summary>
//            /// Initializes a new instance of the <see cref="T:Tester.Panel"/> class.
//            /// </summary>
//            /// <param name="text">Text.</param>
//            /// <param name="locationX">Location x.</param>
//            /// <param name="locationY">Location y.</param>
//            public Panel(object text, int locationX, int locationY)
//            {
//                  this.Text = text.ToString();
//                  this.LocationX = locationX;
//                  this.LocationY = locationY;
//            }

//      }
//}
