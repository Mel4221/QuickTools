/*
        //this is an updated version of QuickTools Last Update : 03/10/2022
        //Get.Version();
    
        //this is the example on how this Class should be used 
       
       
            string[] optionsList = {"Messages","Contacs","Login","Logout"};
            new Options(optionsList);  
            Options.Select();
 

*/
/*
_____________________________________
This code has been reviewed today 7/1/2022 
and i have founded a bug due to the simple fact that
when there are too many options , this class my not work properly
so the posible solutions are: 
>> i have comfirmed that 20 is ok any other number after that will
create on expexted behavior << 

1: Create a limit of 10 options to be display at the time
2: change the aprouch on how is printed every single option
3: i notice that we call every time to Display ,
 so we could just set a limit on the Display function
 and there fore it will only print the last or first 20 
_____________________________________
*/
using System;
using System.Collections.Generic;

namespace QuickTools
{


      public class Options
      {



            public static string SelectorR = " > ";
            public static string SelectorL = " < ";
            public static int CurrentSelection = 0;
            public static object Label = null;
            public static int More;
            public static List<string> OptionList = new List<string>();




            public static void Display()
            {
                  Get.Clear();
                  // HERE IS THE REGULAR DISPLAY OF  THE OPTIONS
                  Get.Yellow(Label);
                  for (int option = 0; option < OptionList.Count; option++)
                  {
                        if (option == CurrentSelection)
                        {

                              Get.Label(SelectorL + OptionList[option] + SelectorR);

                        }
                        else
                        {

                              Get.Write(OptionList[option]);

                        }
                  }
            }
            /// <summary>
            /// Select this instance.
            /// This instance is the one that start the 
            /// Selection process so even thouth you may call
            /// the Constructor you may need to also start the Selction 
            /// with Select example
            /// var app = new Options(string[] list||List<object/>||bool true || false);
            /// app.Select(); 
            /// </summary>
            /// <returns>The select.</returns>
            public virtual int Select()
            {

                  if (OptionList.Count > 0)
                  {
                        // HERE WILL BE THE SELECTION METHOD ITSELF 
                        while (Get.KeyInput().ToString() != "Enter")
                        {

                              switch (Get.Key)
                              {
                                    case "UpArrow":
                                          // Up 
                                          //    Get.Write("Up");
                                          if (CurrentSelection == 0)
                                          {
                                                // go to the button 
                                                // if you are at the top 
                                                // bring me to the end of the 
                                                // list if i keep going up 
                                                CurrentSelection = OptionList.Count - 1;

                                                Display();
                                          }
                                          else
                                          {
                                                CurrentSelection--;

                                                Display();
                                          }
                                          break;

                                    case "DownArrow":
                                          // Down
                                          //   Get.Write("Down");
                                          if (CurrentSelection == OptionList.Count - 1)
                                          {
                                                //this should bring me to the top 
                                                CurrentSelection = 0;
                                                Display();


                                          }
                                          else
                                          {
                                                CurrentSelection++;

                                                Display();
                                          }

                                          break;
                                    default:
                                          /*
                                          // in here it has to be added a switch that could 
                                          //handle the process on a better way with
                                          // the number handling since it seems a kind of crazy
                                          // that you can not press numbers to give a command 
                                          // in the order of the selection
                                          */

                                          // this implementation is not completed yet 
                                          switch (Get.IsNumber(Get.Key))
                                          {
                                                case true:
                                                      // here it shoudl go to the option pressed by it self 
                                                      Get.Alert("Not yet supporeted numbers nor letters to navegate just up and down plus enter to comfirm  ");
                                                      Display();
                                                      break;

                                                case false:
                                                      Get.Alert("Not yet supporeted numbers nor letters to navegate just up and down plus enter to comfirm  ");
                                                      Display();
                                                      break;
                                          }


                                          break;

                              }
                        }



                        Get.Box(OptionList[CurrentSelection]);
                  }
                  else
                  {
                        Color.Yellow("Either No more options or not set up yet ");
                        Color.Green("For more help please visit: ");
                        Color.Yellow("https://www.mbvapps.xyz/QuickTools/");

                  }

                  return CurrentSelection;
            }


            public Options(string[] options)
            {
                  Get.Yellow(Label);
                  foreach (string option in options)
                  {
                        OptionList.Add(option);
                  }

                  // HERE IS THE REGULAR DISPLAY OF  THE OPTIONS
                  for (int opt = 0; opt < OptionList.Count; opt++)
                  {
                        if (opt == CurrentSelection)
                        {
                              Get.Label(" < " + OptionList[opt] + " > ");
                        }
                        else
                        {
                              Get.Write(OptionList[opt]);
                        }
                  }
            }


            public Options(List<object> options)
            {

                  Get.Yellow(Label);
                  foreach (string option in options)
                  {
                        OptionList.Add(option);
                  }

                  // HERE IS THE REGULAR DISPLAY OF  THE OPTIONS
                  for (int opt = 0; opt < OptionList.Count; opt++)
                  {
                        if (opt == CurrentSelection)
                        {
                              Get.Label(" < " + OptionList[opt] + " > ");
                        }
                        else
                        {
                              Get.Write(OptionList[opt]);
                        }
                  }
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
                  if (type == true)
                  {
                        string[] option = { "No", "Yes" };
                        new Options(option);
                  }
                  else
                  {
                        string[] option = { "Yes","No" };
                        new Options(option);
                  }
            }




      }
}