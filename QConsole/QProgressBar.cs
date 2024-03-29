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
  using System.Text;
using System;
      using QuickTools.QCore;
  namespace QuickTools.QConsole
{



    /// <summary>
    /// Creates a ProgressBar that is used on console application
    /// </summary>
    public class QProgressBar
      {
            StringBuilder dots = new StringBuilder();
            /// <summary>
            /// The type of the dots.
            /// </summary>
            public string DotsType = ".";

            /// <summary>
            /// The dots count that will be displaid
            /// </summary>
            public int DotsCount = 10; 
            
            /// <summary>
            /// Contains the Text in which the Display will be printed
            /// </summary>
            /// <value>The label.</value>
            public string Label { get; set; } = " ";
            
            /// <summary>
            /// Gets or sets the x value in which the <see cref="System.Console.SetCursorPosition(int, int)"/> will be printing the text 
            /// </summary>
            /// <value>The x.</value>
            public int X { get; set; } = 1;
            /// <summary>
            /// Gets or sets the y value in which the <see cref="System.Console.SetCursorPosition(int, int)"/> will be printing the text 
            /// </summary>
            /// <value>The y.</value>
            public int Y { get; set; } = Console.CursorTop;
            /// <summary>
            /// Gets or sets the back ground color for label.
            /// </summary>
            /// <value>The back ground color for label.</value>
            public ConsoleColor BackGroundColorForLabel { get; set; } = ConsoleColor.Black;
            /// <summary>
            /// Gets or sets the back ground color for dots.
            /// </summary>
            /// <value>The back ground color for dots.</value>
            public ConsoleColor BackGroundColorForDots { get; set; } = ConsoleColor.Black;
            /// <summary>
            /// Gets or sets the fore color for label.
            /// </summary>
            /// <value>The fore color for label.</value>
            public ConsoleColor ForeColorForLabel { get; set; } = ConsoleColor.White;
            /// <summary>
            /// Gets or sets the fore color for dots.
            /// </summary>
            /// <value>The fore color for dots.</value>
            public ConsoleColor ForeColorForDots { get; set; } = ConsoleColor.Green;

            
            private string Status { get; set; } = " ";
            private string StrDots { get; set; } = "";
            private bool Started { get; set; } = false;
            private string currentPorcent;
            private bool completed { get; set; } = false;

        /// <summary>
        /// Reset the StartDots , Label , Status.
        /// </summary>
        public void Reset()
        {
            this.StrDots = "";
            this.Label = " ";
            this.Status = " ";
            this.currentPorcent = "";
        }

        /// <summary>
        /// Clear this instance.
        /// </summary>
        public void Clear()
        {
            for (int x = 1; x < Console.BufferWidth; x++)
            {
                Console.SetCursorPosition(x, this.Y);
                Get.Write(" ");
            }
        }


        /// <summary>
        /// Display the specified status with dots
        /// </summary>
        /// <param name="status">Status.</param>
        public void Display(string status)
        {
            try
            {
                /*
                if (!this.Started)
                {
                    Console.BackgroundColor = this.BackGroundColorForLabel;
                    Console.ForegroundColor = this.ForeColorForLabel;
                    Console.Write($"{this.Label} ");
                    Get.Reset();
                    Console.Write('[');
                    this.X = Console.CursorLeft;
                }
                */
                // Get.Wait($"{status} {Get.Number}");
                //if (completed) { this.Clear(); this.completed = false; }
                this.Started = true;
              
                if (this.Status != status)
                {
                   
                    Console.SetCursorPosition(1, this.Y);
                    Console.BackgroundColor = this.BackGroundColorForLabel;
                    Console.ForegroundColor = this.ForeColorForLabel;
                    Console.Write($"{this.Label} ");
                    Get.Reset();
                    Console.Write('[');
                    this.X = Console.CursorLeft;
                    Get.Title(status);



                    Console.SetCursorPosition(this.X, this.Y);
                    if (this.Status[0] != status[0])
                    {
                        StrDots += this.DotsType;
                    }

                    Console.BackgroundColor = this.BackGroundColorForDots;
                    Console.ForegroundColor = this.ForeColorForDots;
                    Console.Write(StrDots);
                    this.Status = status;

                    if (status == "100%")
                    {
                        Get.Reset();
                        Console.Write(']');
                        Console.Write(Environment.NewLine);
                        this.completed = true;
                       

                    }
                }
            }catch
            {
                Get.Clear();
                Get.Box($"The Screen is Too Small");
                Console.Beep();
            }

        }
        /// <summary>
        /// Display the specified current and goal.
        /// </summary>
        /// <param name="current">Current.</param>
        /// <param name="goal">Goal.</param>
        public void Display(int current , int goal)
                  {

                  //Console.SetCursorPosition(0, 0); 
                   
                       
                        
                        string status = Get.Status(current , goal);
                        if(this.currentPorcent == status)
                        {
                              return;
                        }
                        if(this.currentPorcent != status)
                        {
                              this.currentPorcent = status;
                              Get.Clear();
                        }
                              Get.Label(status);
                              Get.Write("[");
                              Get.Green();
                              Get.Write(dots);
                              Get.Reset();
                              if(current == goal)
                                    {
                                    Get.Write("]\n");
                                    }

                              Dots(status);
  

        }


      
        /// <summary>
        /// Display the specified current, goal and consoleTitle.
        /// </summary>
        /// <param name="current">Current.</param>
        /// <param name="goal">Goal.</param>
        /// <param name="consoleTitle">Console title.</param>
        public void Display(int current, int goal,string consoleTitle)
        {

            //Console.SetCursorPosition(0, 0); 


            Get.Title(consoleTitle); 
            string status = Get.Status(current, goal);
            if (this.currentPorcent == status)
            {
                return;
            }
            if (this.currentPorcent != status)
            {
                this.currentPorcent = status;
                Get.Clear();
            }
            Get.Label(status);
            Get.Write("[");
            Get.Green();
            Get.Write(dots);
            Get.Reset();
            if (current == goal)
            {
                Get.Write("]\n");
            }

            Dots(status);



        }
        void Dots(string status)
            {
                  int porcent = int.Parse(status.Replace("%", "")) / this.DotsCount;
                  dots.Clear();
                  for (int dot = 0; dot < porcent; dot++)
                  {
                        dots.Append(DotsType);
                  }

            }

        /*
            /// <summary>
            /// Display the specified current, goal and dots.
            /// </summary>
            /// <param name="current">Current.</param>
            /// <param name="goal">Goal.</param>
            /// <param name="dots">Dots.</param>
            public void Display(int current, int goal,string dots)
            {


                  Get.Clear();
                  string status = Get.Status(current, goal);
                  Get.Label(status);
                  Get.Write("[");
                  Get.Green();
                  Get.Write(dots);
                  Get.Reset();
                  if (current == goal - 1)
                  {
                        Get.Write("]\n");
                  }
                  this.DotsType = dots; 
                  this.Dots(status);
            }
            */
            /// <summary>
            /// Display the specified current, goal, dots and label.
            /// </summary>
            /// <param name="current">Current.</param>
            /// <param name="goal">Goal.</param>
            /// <param name="dots">Dots.</param>
            /// <param name="label">Label.</param>
            public void Display(int current, int goal, string dots,string label)
            {


                  Get.Clear();
                  string status = Get.Status(current, goal);
                  Get.Label($"{label} {status}");
                  Get.Write("[");
                  Get.Green();
                  Get.Write(dots);
                  Get.Reset();
                  if (current == goal - 1)
                  {
                        Get.Write("]\n");
                  }
                  this.DotsType = dots;
                  this.Dots(status);
            }

            /// <summary>
            /// Display the specified current, goal, dots, label and noStatusPorcent.
            /// </summary>
            /// <param name="current">Current.</param>
            /// <param name="goal">Goal.</param>
            /// <param name="dots">Dots.</param>
            /// <param name="label">Label.</param>
            /// <param name="noStatusPorcent">If set to <c>true</c> no status porcent.</param>
            public void Display(int current, int goal, string dots, string label,bool noStatusPorcent)
            {


                  Get.Clear();
                  string status = null; 
                  if(noStatusPorcent == true)
                  {
                        status = " "+Get.Status(current, goal);
                  }
                  Get.Label($"{label}{status}"); 
                  Get.Write("[");
                  Get.Green();
                  Get.Write(dots);
                  Get.Reset();
                  if (current == goal - 1)
                  {
                        Get.Write("]\n");
                  }
                  this.DotsType = dots;
                  this.Dots(status);
            }

      }
}
