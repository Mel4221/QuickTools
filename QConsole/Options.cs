﻿/*
 *
 *	This is a quick way to create simple menu on a console aplication 
 *	by just adding the options like : 
 *	string[] options = {"Red","Blue","Pink"};
 *
 *	var Options option = new Option(options); 
 *	
 *	switch(option.Pick())
 *	{
 *		case 0:
 *				Color.Red("I like that one"); 
 *		break; 
 *
 *		case 1:
 *				Color.Blue("i like that one too"); 
 *		break ; 
 *
 *		case 2: 
 *				Color.Pink("That one is my favorite"); 
 *		break ; 
 *	} 
 *	
 *
 *
 *	I hope this can help on how it works 
 *
 *
        //this is an updated version of QuickTools Last Update : 03/10/2022
        //Get.Version();
    
        //this is the example on how this Class should be used 
       
       
            string[] optionsList = {"Messages","Contacs","Login","Logout"};
            new Options(optionsList);  
            Options.Select();
-----------------------------------------------------------------------------------
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
using QuickTools.QColors; 
using System.Collections.Generic;
using QuickTools.QCore;

namespace QuickTools.QConsole
{

      /// <summary>
      /// The option class provide you an easy way to create a menu that can be used with the arrows up and down 
      /// on a console eviroment .s
      /// </summary>
      public partial class Options
      {

            /// <summary>
            /// Clears All the options.
            /// </summary>
            public void ClearOptions()
            {
                  OptionList.Clear(); 
            }
            /// <summary>
            /// Display the Options listed in the OptionsList 
            /// </summary>
            public void Display()
            {
            if (this.Testing)
            {
                _Display();
                return;
            }
                  Get.Clear();
                  // HERE IS THE REGULAR DISPLAY OF  THE OPTIONS
                  Color.Yellow(Label);
                  for (int option = 0; option < OptionList.Count; option++)
                  {
                        if (option == CurrentSelection)
                        {
                               
                              Get.Label(SelectorL + OptionList[option] + SelectorR,this.LabelBackColor, this.LabelTextColor);
                              Get.Write("\n");
                                //this is just a work around the issue with the option list not showing 
                                // the one that is currently selected due to how many options are in the list. 
                                // posible fix is just to display until 10 options or as many as are supported on the screen

                              Get.Title($">{OptionList[option]}");
                        }
                        else
                        {
                              Console.BackgroundColor = this.BackColor;
                              Console.ForegroundColor = this.TextColor; 
                              Console.WriteLine(OptionList[option]);

                        }
                  }
            }
            /// <summary>
            /// Select  the options listed and returns the number of the selection
            /// This instance is the one that start the 
            /// Selection process so even thouth you may call
            /// the Constructor you may need to also start the Selction 
            /// with Select example
            /// var app = new Options(string[] list||List<object/>||bool true || false);
            /// app.Select(); 
            /// </summary>
            /// <returns>The select.</returns>
            public int Pick()
            {
                

                  if (OptionList.Count > 0)
                  {
                        // the first display 
                        Display(); 
                        // HERE WILL BE THE SELECTION METHOD ITSELF
                        
                        while (ExitTrigerFunction(Get.KeyInput().ToString()))
                        {

                              switch (Get.Key)
                              {
                                    case "UpArrow":
                                    case "e":
                                    case "E":

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
                                    case "R":
                                    case "r":
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
                        case "Escape":
                        case "Backspace":
                            this.Triguer = Get.Key;
                            this.Triguered = true;
                            //Get.Break();
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
                                                 //     Get.Alert("Not yet supporeted numbers nor letters to navegate just up and down plus enter to comfirm  ");
                                                      Display();
                                                      break;

                                                case false:
                                                  //    Get.Alert("Not yet supporeted numbers nor letters to navegate just up and down plus enter to comfirm  ");
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
                        Color.Yellow("https://github.com/Mel4221/QuickTools.git");

                  }

                  return CurrentSelection;
            }

            /// <summary>
            /// Pick the specified allowLateral.
            /// </summary>
            /// <returns>The pick.</returns>
            /// <param name="allowLateral">If set to <c>true</c> allow lateral.</param>
            public virtual int Pick(bool allowLateral)
            {

                  if (OptionList.Count > 0)
                  {
                        // the first display 
                        Display();
                // HERE WILL BE THE SELECTION METHOD ITSELF
                while (ExitTrigerFunction(Get.KeyInput().ToString()))
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
                                    case "RightArrow":
                                          return int.MaxValue;
#pragma warning disable CS0162 // Unreachable code detected
                                          break;
#pragma warning restore CS0162 // Unreachable code detected
                                    case "LeftArrow":
                                          return int.MinValue;
#pragma warning disable CS0162 // Unreachable code detected
                                          break;
#pragma warning restore CS0162 // Unreachable code detected
                                    case "Escape":
                                    case "Backspace":
                                          this.Triguer = Get.Key;
                                          this.Triguered = true;
                            //Get.Break();
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
                                                      //     Get.Alert("Not yet supporeted numbers nor letters to navegate just up and down plus enter to comfirm  ");
                                                      Display();
                                                      break;

                                                case false:
                                                      //    Get.Alert("Not yet supporeted numbers nor letters to navegate just up and down plus enter to comfirm  ");
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



            private void PrintList()
            {
                  for (int option = 0; option < OptionList.Count; option++)
                  {
                        Get.Write($"{option+1}. "+OptionList[option]);
                  }
            }
            /// <summary>
            /// Select The Option from the OptionList.
            /// </summary>
            /// <returns>The select.</returns>
            public int Select()
            {
                  int selection = 0;
                  PrintList(); // display options 
                  selection = Get.NumberInput()-1; 

                  return selection; 
            }


      }
}
