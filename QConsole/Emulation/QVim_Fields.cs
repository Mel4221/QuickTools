using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace QuickTools.QConsole.Emulation
{
    public partial class QVim
    {
        public bool EscapeKeyPressed;
        public int Row;
        public int Column;
        public List<char> CharsList;
        public List<int> RowsList;
        public List<int> ColumnsList; 
        public struct CursorPosition
        {
            public static int X = 0;
            public static int Y = 0; 
        }
        
        

        /// <summary>
        /// Contains the ConsoleKeyInfo data 
        /// </summary>
        public class KeyInfo
        {

            /// <summary>
            /// Gets or sets the key.
            /// </summary>
            /// <value>The key.</value>
            public string Key { get; set; }

            /// <summary>
            /// Gets or sets the key char.
            /// </summary>
            /// <value>The key char.</value>
            public char KeyChar { get; set; }

            /// <summary>
            /// Gets or sets the modifiers.
            /// </summary>
            /// <value>The modifiers.</value>
            public string Modifiers { get; set; }

            /// <summary>
            /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:QuickTools.QInput.KeyInfo"/>.
            /// </summary>
            /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:QuickTools.QInput.KeyInfo"/>.</returns>
            public override string ToString()
            {
                return $"Key: {this.Key} Char: {this.KeyChar} Modifier: {this.Modifiers}";
            }
        }





    }
}
