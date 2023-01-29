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
  using System.Text;
      using QuickTools.QCore;
  namespace QuickTools.QConsole
{

      /// <summary>
      /// Creates a ProgressBar that is used on console application
      /// </summary>
       public class CProgressBar
      {
            StringBuilder dots = new StringBuilder();
            /// <summary>
            /// The type of the dots.
            /// </summary>
            public string DotsType = ".";
            /// <summary>
            /// Display the specified current and goal.
            /// </summary>
            /// <param name="current">Current.</param>
            /// <param name="goal">Goal.</param>
            public void Display(int current, int goal)
            {

                  //Console.SetCursorPosition(0, 0); 
                  Get.Clear(); 
                  Get.Black();

                        string status = Get.Status(current, goal);
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
                  int porcent = int.Parse(status.Replace("%", "")) / 10;
                  dots.Clear();
                  for (int dot = 0; dot < porcent; dot++)
                  {
                        dots.Append(DotsType);
                  }

            }


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
