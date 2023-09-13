using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickTools.QConsole.Emulation
{
    public partial class QVim
    {
        public QVim()
        {   //Window win = new Window();
            this.CharsList = new List<char>();
            this.RowsList = new List<int>();
            this.ColumnsList = new List<int>();
        }
    }
}
