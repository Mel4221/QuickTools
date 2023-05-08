using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickTools.QCore;

namespace QuickTools.QConsole
{
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
        /// Start the shell mode 
        /// </summary>
        /// <returns></returns>
        public string StartInput()
        {
            string input;
            input = null;
            Console.BackgroundColor = this.UserBackGrondColor;
            Console.ForegroundColor = this.UserTextColor;
            Console.Write($"{this.UserName}@{this.ComputerName}");
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
            Console.WriteLine(" ");
            Console.Write(" > ");
            input = Console.ReadLine();

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
        
        }
    }
}