using System;
using QuickTools.QCore; 
namespace QuickTools.QConsole
{
    public partial class ShellInput
    {
        /// <summary>
        /// Initialization from the class
        ///System.Environment.UserName System.Environment.MachineName
        /// </summary>
        /// <param name="userName">System.Environment.UserName</param>
        /// <param name="machineName">System.Environment.MachineName</param>
        public ShellInput(string userName, string machineName)
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
        ///System.Environment.UserName System.Environment.MachineName
        /// </summary>
        /// <param name="userName">System.Environment.UserName</param>
        /// <param name="machineName">System.Environment.MachineName</param>
        /// <param name="currentPath">CurrentPath</param>
        public ShellInput(string userName, string machineName, string currentPath)
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
