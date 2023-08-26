using QuickTools.QColors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickTools.QConsole
{
    public partial class Options
    {
        /// <summary>
        /// This initialization does not contains any implementation
        /// Initializes a new instance of the <see cref="T:QuickTools.Options"/> class.
        /// </summary>
        public Options()
        {
            ClearOptions();
        }


        /// <summary>
        /// Create the List of options by passing an array 
        /// Initializes a new instance of the <see cref="T:QuickTools.Options"/> class.
        /// </summary>
        /// <param name="options">Options.</param>
        public Options(string[] options)
        {
            ClearOptions();
            Count = options.Length;
            Color.Yellow(Label);
            foreach (string option in options)
            {
                OptionList.Add(option);
            }

            // HERE IS THE REGULAR DISPLAY OF  THE OPTIONS
            /*for (int opt = 0; opt < OptionList.Count; opt++)
            {
                  if (opt == CurrentSelection)
                  {
                        Get.Label(" < " + OptionList[opt] + " > ");
                  }
                  else
                  {
                        Get.Write(OptionList[opt]);
                  }
            }*/
        }
        /// <summary>
        /// This Options love simplicity so it shouses automatically and take out 
        /// the simbols on the side 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="Simple"></param>
        public Options(string[] options, bool Simple)
        {

            ClearOptions();

            if (Simple == true)
            {
                SelectorL = "";
                SelectorR = "";
                Color.Yellow(Label);
                foreach (string option in options)
                {
                    OptionList.Add(option);
                }
                var opt = new Options();
                opt.Pick();
            }
            if (Simple == false)
            {
#pragma warning disable RECS0026 // Possible unassigned object created by 'new'
                new Options(options);
#pragma warning restore RECS0026 // Possible unassigned object created by 'new'
            }

            // HERE IS THE REGULAR DISPLAY OF  THE OPTIONS
            /*for (int opt = 0; opt < OptionList.Count; opt++)
            {
                  if (opt == CurrentSelection)
                  {
                        Get.Label(" < " + OptionList[opt] + " > ");
                  }
                  else
                  {
                        Get.Write(OptionList[opt]);
                  }
            }*/
        }
        /// <summary>
        /// Create a list of options by passing a generic list 
        /// Initializes a new instance of the <see cref="T:QuickTools.Options"/> class.
        /// </summary>
        /// <param name="options">Options.</param>
        public Options(List<object> options)
        {

            ClearOptions();
            Color.Yellow(Label);
            Count = options.Count;

            foreach (string option in options)
            {
                OptionList.Add(option);
            }

            // HERE IS THE REGULAR DISPLAY OF  THE OPTIONS

            /*  for (int opt = 0; opt < OptionList.Count; opt++)
            {
                  if (opt == CurrentSelection)
                  {
                        Get.Label(" < " + OptionList[opt] + " > ");
                  }
                  else
                  {
                        Get.Write(OptionList[opt]);
                  }
            }*/
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:QuickTools.Options"/> class.
        /// If you would like to get basically an answer were the first shoudl be answer should be 
        /// NO you shoudl just type new Options(true); other wise the order would be back wards
        /// remember that the return type will be always the same location in the array 
        /// so it you select now if you select the yes it will return 0 which is the position of in the array 
        /// </summary>
        /// <param name="type">If set to <c>true</c> type.</param>
        public Options(bool type)
        {

            ClearOptions();

            if (type == false)
            {
                string[] option = { "No", "Yes" };
#pragma warning disable RECS0026 // Possible unassigned object created by 'new'
                new Options(option);
#pragma warning restore RECS0026 // Possible unassigned object created by 'new'
            }
            if (type == true)
            {
                string[] option = { "Yes", "No" };
#pragma warning disable RECS0026 // Possible unassigned object created by 'new'
                new Options(option);
#pragma warning restore RECS0026 // Possible unassigned object created by 'new'
            }
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="T:QuickTools.Options"/> 
        /// so far the only type listed is list 
        /// </summary>
        /// <param name="options">Options.</param>
        /// <param name="typeOfOptions">Type of options.</param>
        public Options(string[] options, string typeOfOptions)
        {
            switch (typeOfOptions.ToLower())
            {
                case "list":
                    ClearOptions();
                    SelectorL = "";
                    SelectorR = "";
                    Color.Yellow(Label);
                    foreach (string option in options)
                    {
                        OptionList.Add(option);
                    }

                    break;
            }

        }



        /// <summary>
        /// Allows to set all the values for the Class
        /// </summary>
        /// <param name="exitTrigerFunction"></param>
        /// <param name="selectorR"></param>
        /// <param name="selectorL"></param>
        /// <param name="label"></param>
        /// <param name="optionList"></param>
        /// <param name="textColor"></param>
        /// <param name="backColor"></param>
        /// <param name="labelBackColor"></param>
        /// <param name="labelTextColor"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public Options(Func<string, bool> exitTrigerFunction, string selectorR, string selectorL, object label, List<string> optionList, ConsoleColor textColor, ConsoleColor backColor, ConsoleColor labelBackColor, ConsoleColor labelTextColor)
        {
            ExitTrigerFunction=exitTrigerFunction??throw new ArgumentNullException(nameof(exitTrigerFunction));
            SelectorR=selectorR??throw new ArgumentNullException(nameof(selectorR));
            SelectorL=selectorL??throw new ArgumentNullException(nameof(selectorL));
            Label=label??throw new ArgumentNullException(nameof(label));
            OptionList=optionList??throw new ArgumentNullException(nameof(optionList));
            TextColor=textColor;
            BackColor=backColor;
            LabelBackColor=labelBackColor;
            LabelTextColor=labelTextColor;
        }
    }
}
