using System;
namespace QuickTools.QConsole
{
    public partial class ShellInput
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

    }
}
