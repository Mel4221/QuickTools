using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickTools.QConsole
{
    public partial class Options
    {


        /*
            case "Escape":
                                    case "Backspace":
         */

            /// <summary>
            /// Gets or sets the exit triger function.
            /// </summary>
            /// <value>The exit triger function.</value>
        public Func<string,bool> ExitTrigerFunction { get; set; } = (key) => key == "Enter" || key=="Backspace" || key == "Escape"? false:true;
        /// <summary>
        /// This Control the Right simbol from the selector and the default simbol is ">"
        /// </summary>
        public string SelectorR = " > ";
        /// <summary>
        /// This Control the Left simbol from the selector and the default simbol is ">"
        /// </summary>
        public string SelectorL = " < ";
        /// <summary>
        /// This contains the initial selection or default 
        /// </summary>
        public int CurrentSelection = 0;
        /// <summary>
        /// The label that will be in top of the options
        /// </summary>
        public object Label = null;

        /// <summary>
        /// Options List container 
        /// </summary>
        private List<string> OptionList = new List<string>();
        /// <summary>
        /// This provide the access to the OptionList count for verification porpuses 
        /// </summary>
        public int Count = 0;

        /// <summary>
        /// Gets the triguer.
        /// </summary>
        /// <value>The triguer.</value>
        public string Triguer { get; set; }
        /// <summary>
        /// Gets a value indicating whether this <see cref="T:QuickTools.Options"/> is triguered.
        /// </summary>
        /// <value><c>true</c> if triguered; otherwise, <c>false</c>.</value>
        public bool Triguered { get; set; }

        /// <summary>
        /// The color of the text.
        /// </summary>
        public ConsoleColor TextColor = ConsoleColor.White;

        /// <summary>
        /// The color of the back.
        /// </summary>
        public ConsoleColor BackColor = ConsoleColor.Black;

        /// <summary>
        /// The color of the label back.
        /// </summary>
        public ConsoleColor LabelBackColor = ConsoleColor.Magenta;

        /// <summary>
        /// The color of the label text.
        /// </summary>
        public ConsoleColor LabelTextColor = ConsoleColor.White;

        /// <summary>
        /// By default the value is Console.BufferHeight -1; 
        /// </summary>
        public int MaxItems { get; set; } = Console.BufferHeight -1;
        /// <summary>
        /// Current Selection
        /// </summary>
        public int Current { get; set; } = 0;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:QuickTools.QConsole.Options"/> is testing.
        /// </summary>
        /// <value><c>true</c> if testing; otherwise, <c>false</c>.</value>
        public bool Testing { get; set; } = false;

    }
}
