using QuickTools.QColors;
using QuickTools.QCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickTools.QConsole
{
    public partial class Options
    {
        public void _Display()
        {
            Get.Clear();
            // HERE IS THE REGULAR DISPLAY OF  THE OPTIONS
            Color.Yellow(Label);

            //for(int option = 0; option < )
            //for (int option = 0; option < OptionList.Count; option++)
            //{
            //    if (option == CurrentSelection)
            //    {

            //        Get.Label(SelectorL + OptionList[option] + SelectorR, this.LabelBackColor, this.LabelTextColor);
            //        Get.Write("\n");
            //        //this is just a work around the issue with the option list not showing 
            //        // the one that is currently selected due to how many options are in the list. 
            //        // posible fix is just to display until 10 options or as many as are supported on the screen

            //        Get.Title($">{OptionList[option]}");
            //    }
            //    else
            //    {
            //        Console.BackgroundColor = this.BackColor;
            //        Console.ForegroundColor = this.TextColor;
            //        Console.WriteLine(OptionList[option]);

            //    }
            //}

        }

    }
}
