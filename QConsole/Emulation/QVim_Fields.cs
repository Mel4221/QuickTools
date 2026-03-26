using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace QuickTools.QConsole.Emulation
{
    public partial class QVim
    {
        /// <summary>
        /// The escape key pressed.
        /// </summary>
        public bool EscapeKeyPressed;
        /// <summary>
        /// The row.
        /// </summary>
        public int Row;
        /// <summary>
        /// The column.
        /// </summary>
        public int Column;
        /// <summary>
        /// The chars list.
        /// </summary>
        public List<char> CharsList;
        /// <summary>
        /// The rows list.
        /// </summary>
        public List<int> RowsList;
        /// <summary>
        /// The columns list.
        /// </summary>
        public List<int> ColumnsList; 
        /// <summary>
        /// Cursor position.
        /// </summary>
        public struct CursorPosition
        {
            /// <summary>
            /// The x.
            /// </summary>
            public static int X = 0;
            /// <summary>
            /// The y.
            /// </summary>
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
