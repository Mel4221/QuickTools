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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickTools.QCore;

namespace QuickTools.QConsole
{

    /// <summary>
    /// Creates a shell and returns the input as a plain text 
    /// </summary>
    public class ShellInput
    {

        /// <summary>
        /// set the user name 
        /// </summary>
        public string UserName;

        /// <summary>
        /// set the program name 
        /// </summary>
        public string ProgramName = "QuickTools";

        /// <summary>
        /// set te computer name 
        /// </summary>
        public string ComputerName;


        /// <summary>
        /// SEt the current path 
        /// </summary>
        public string CurrentPath;

        /// <summary>
        /// the tag that stars before the text 
        /// </summary>
        public string TextSimbol = ">";

        /// <summary>
        /// the at simbol in between the name of the machine and the user 
        /// </summary>
        public string AtSimbol = "@";

        /// <summary>
        /// 
        /// </summary>
        public string Notifications = "#";

        /// <summary>
        /// background color from the user name 
        /// </summary>
        public ConsoleColor UserBackGrondColor;

        /// <summary>
        /// the text color of the user 
        /// </summary>
        public ConsoleColor UserTextColor;

        /// <summary>
        /// the color of the text for the path 
        /// </summary>
        public ConsoleColor PathTextColor;

        /// <summary>
        /// the back ground color for he path 
        /// </summary>
        public ConsoleColor PathBackGround;

        /// <summary>
        /// Provide  the back ground of the label that display the name of the program
        /// </summary>
        public ConsoleColor ProgramBBackGroundColor;

        /// <summary>
        /// Provides the color for the program label color  
        /// </summary>
        public ConsoleColor ProgramTextColor;

        /// <summary>
        /// the color for the simbol 
        /// </summary>
        public ConsoleColor SimbolBackGroundColor;

        /// <summary>
        /// the color for the text of the simbol 
        /// </summary>
        public ConsoleColor SimbolTextColor;

        /// <summary>
        /// the color 
        /// </summary>
        public ConsoleColor AtSimbolTextColor = ConsoleColor.Red;

        /// <summary>
        /// the background color 
        /// </summary>
        public ConsoleColor AtSimbolBackGroundColor = ConsoleColor.Black; 
       

        /// <summary>
        /// Start the shell mode 
        /// </summary>
        /// <returns></returns>
        public string StartInput()
        {
            string input;
            input = null;
            Console.WriteLine();
            Console.BackgroundColor = this.UserBackGrondColor;
            Console.ForegroundColor = this.UserTextColor;
            Console.Write($"{this.UserName}") ;
             
            Console.BackgroundColor = this.AtSimbolBackGroundColor;
            Console.ForegroundColor = this.AtSimbolTextColor;
            Console.Write(AtSimbol);

            Console.BackgroundColor = this.UserBackGrondColor;
            Console.ForegroundColor = this.UserTextColor;
            Console.Write($"{this.ComputerName}");
            Console.Write(" ");
            Get.Reset();
            Console.BackgroundColor = this.ProgramBBackGroundColor;
            Console.ForegroundColor = this.ProgramTextColor;
            Console.Write($"{this.ProgramName}");
            Get.Reset();
            Console.Write(" ");
            Console.BackgroundColor = this.PathBackGround;
            Console.ForegroundColor = this.PathTextColor;
            Console.Write(this.CurrentPath);
            Get.Reset();
            Console.Write(" ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($" ({this.Notifications}) ");
            Console.WriteLine(" ");
            Console.BackgroundColor = this.SimbolBackGroundColor;
            Console.ForegroundColor = this.SimbolTextColor;
            Console.Write($" {this.TextSimbol} ");
            Get.Reset();
            Console.Write(" ");
            input = Console.ReadLine();

            Get.Reset();
            return input;
        }


        /// <summary>
        /// Start the shell mode 
        /// </summary>
        /// <param name="inputFunctionType"></param>
        /// <returns></returns>
        public string StartInput(Func<string> inputFunctionType)
        {
            string input;
            input = null;
            Console.WriteLine();
            Console.BackgroundColor = this.UserBackGrondColor;
            Console.ForegroundColor = this.UserTextColor;
            Console.Write($"{this.UserName}");

            Console.BackgroundColor = this.AtSimbolBackGroundColor;
            Console.ForegroundColor = this.AtSimbolTextColor;
            Console.Write(AtSimbol);

            Console.BackgroundColor = this.UserBackGrondColor;
            Console.ForegroundColor = this.UserTextColor;
            Console.Write($"{this.ComputerName}");
            Console.Write(" ");
            Get.Reset();
            Console.BackgroundColor = this.ProgramBBackGroundColor;
            Console.ForegroundColor = this.ProgramTextColor;
            Console.Write($"{this.ProgramName}");
            Get.Reset();
            Console.Write(" ");
            Console.BackgroundColor = this.PathBackGround;
            Console.ForegroundColor = this.PathTextColor;
            Console.Write(this.CurrentPath);
            Get.Reset();
            Console.Write(" ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($" ({this.Notifications}) ");
            Console.WriteLine(" ");
            Console.BackgroundColor = this.SimbolBackGroundColor;
            Console.ForegroundColor = this.SimbolTextColor;
            Console.Write($" {this.TextSimbol} ");
            Get.Reset();
            Console.Write(" ");
            input = inputFunctionType();

            Get.Reset();
            return input;
        }


        /// <summary>
        /// please avoid using this verions 
        /// </summary>
        /// <param name="KeyPressCallBack"></param>
        /// <returns></returns>
        public string StartInput(Func<ConsoleKeyInfo> KeyPressCallBack)
        {
            string input;
            input = null;
            Console.WriteLine();
            Console.BackgroundColor = this.UserBackGrondColor;
            Console.ForegroundColor = this.UserTextColor;
            Console.Write($"{this.UserName}");

            Console.BackgroundColor = this.AtSimbolBackGroundColor;
            Console.ForegroundColor = this.AtSimbolTextColor;
            Console.Write(AtSimbol);

            Console.BackgroundColor = this.UserBackGrondColor;
            Console.ForegroundColor = this.UserTextColor;
            Console.Write($"{this.ComputerName}");
            Console.Write(" ");
            Get.Reset();
            Console.BackgroundColor = this.ProgramBBackGroundColor;
            Console.ForegroundColor = this.ProgramTextColor;
            Console.Write($"{this.ProgramName}");
            Get.Reset();
            Console.Write(" ");
            Console.BackgroundColor = this.PathBackGround;
            Console.ForegroundColor = this.PathTextColor;
            Console.Write(this.CurrentPath);
            Get.Reset();
            Console.Write(" ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($" ({this.Notifications}) ");
            Console.WriteLine(" ");
            Console.BackgroundColor = this.SimbolBackGroundColor;
            Console.ForegroundColor = this.SimbolTextColor;
            Console.Write($" {this.TextSimbol} ");
            Get.Reset();
            Console.Write(" ");
            List<char> chars = new List<char>();
            Get.Loop(() =>
            {
                ConsoleKeyInfo keyPress = KeyPressCallBack();

                if (keyPress.Key == ConsoleKey.Enter)
                {
                    Get.Break();
                }
                if (keyPress.Key == ConsoleKey.Backspace)
                {
                    if (chars.Count != 0)
                    {
                        chars.RemoveAt(chars.Count - 1);
                        //this number on chars.coun + 4 only applys to the version of the chell that im working on 
                        Console.SetCursorPosition(chars.Count +4, Console.CursorTop);
                        Get.Write(" "); 
                    }
                    return;
                }
                if(keyPress.Key == ConsoleKey.Spacebar)
                {
                    chars.Add(' ');
                    return;
                }
                if(keyPress.Key == ConsoleKey.Tab)
                {
                    chars.Add(' ');
                    chars.Add(' ');
                    chars.Add(' ');
                    return;
                }
                else
                {
                    chars.Add(keyPress.KeyChar); 
                }

            });
            StringBuilder text = new StringBuilder();
            foreach (char ch in chars) text.Append(ch);
            input = text.ToString();
            Get.Reset();
            return input;
        }

        /// <summary>
        /// Initialization from the class
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="machineName"></param>
        public ShellInput(string userName,string machineName)
        {
            this.UserName = userName;
            this.ComputerName = machineName;
            this.CurrentPath = Get.Path;
            this.UserBackGrondColor = ConsoleColor.Black;
            this.UserTextColor = ConsoleColor.Green;
            this.PathBackGround = ConsoleColor.Black;
            this.PathTextColor = ConsoleColor.Yellow;
            this.ProgramBBackGroundColor = ConsoleColor.Black;
            this.ProgramTextColor = ConsoleColor.Magenta;
            this.SimbolBackGroundColor = ConsoleColor.Magenta;
            this.SimbolTextColor = ConsoleColor.White;

        }
        
        /// <summary>
        ///Initialize the instance 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="machineName"></param>
        /// <param name="currentPath"></param>
        public ShellInput(string userName, string machineName,string currentPath)
        {
            this.UserName = userName;
            this.ComputerName = machineName;
            this.CurrentPath = currentPath;
            this.UserBackGrondColor = ConsoleColor.Black;
            this.UserTextColor = ConsoleColor.Green;
            this.PathBackGround = ConsoleColor.Black;
            this.PathTextColor = ConsoleColor.Yellow;
            this.ProgramBBackGroundColor = ConsoleColor.Black;
            this.ProgramTextColor = ConsoleColor.Magenta;
            this.SimbolBackGroundColor = ConsoleColor.Magenta;
            this.SimbolTextColor = ConsoleColor.White;

        }
    }
}