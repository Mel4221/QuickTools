using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickTools.QConsole.Emulation
{
    public partial class QVim
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:QuickTools.QConsole.Emulation.QVim"/> class.
        /// </summary>
        public QVim()
        {   //Window win = new Window();
            this.CharsList = new List<char>();
            this.RowsList = new List<int>();
            this.ColumnsList = new List<int>();
        }
    }
}
