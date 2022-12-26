/*
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
using QuickTools.Colors; 
using System.Collections.Generic;

namespace QuickTools
{

      /// <summary>
      /// The option class provide you an easy way to create a menu that can be used with the arrows up and down 
      /// on a console eviroment .s
      /// </summary>
      public class Options
      {


            /// <summary>
            /// This Control the Right simbol from the selector and the default simbol is ">"
            /// </summary>
            public static string SelectorR = " > ";
            /// <summary>
            /// This Control the Left simbol from the selector and the default simbol is ">"
            /// </summary>
            public static string SelectorL = " < ";
            /// <summary>
            /// This contains the initial selection or default 
            /// </summary>
            public static int CurrentSelection = 0;
            /// <summary>
            /// The label that will be in top of the options
            /// </summary>
            public static object Label = null;
        
                  /// <summary>
                  /// Options List container 
                  /// </summary>
            private static List<string> OptionList = new List<string>();
            /// <summary>
            /// This provide the access to the OptionList count for verification porpuses 
            /// </summary>
            public int Count = 0;

            /// <summary>
            /// Gets the triguer.
            /// </summary>
            /// <value>The triguer.</value>
            public static string Triguer { get; set;  }
            /// <summary>
            /// Gets a value indicating whether this <see cref="T:QuickTools.Options"/> is triguered.
            /// </summary>
            /// <value><c>true</c> if triguered; otherwise, <c>false</c>.</value>
            public static bool Triguered { get; set; }

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
            public static void Display()
            {
                  Get.Clear();
                  // HERE IS THE REGULAR DISPLAY OF  THE OPTIONS
                  Color.Yellow(Label);
                  for (int option = 0; option < OptionList.Count; option++)
                  {
                        if (option == CurrentSelection)
                        {

                              Get.Label(SelectorL + OptionList[option] + SelectorR);
                              Get.Write("\n"); 

                        }
                        else
                        {

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
            public virtual int Pick()
            {

                  if (OptionList.Count > 0)
                  {
                        // the first display 
                        Display(); 
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
                        Color.Yellow("http://www.mbvapps.xyz/QuickTools/");

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
                                          Options.Triguer = Get.Key;
                                          Options.Triguered = true; 

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
            public Options(string[] options,bool Simple)
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
                  if(Simple == false)
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
                  if(type == true)
                  {
                        string[] option = { "Yes","No" };
#pragma warning disable RECS0026 // Possible unassigned object created by 'new'
                        new Options(option);
#pragma warning restore RECS0026 // Possible unassigned object created by 'new'
                  }
            }


            /// <summary>
            /// Initializes a new instance of the <see cref="T:QuickTools.Options"/> class.
            /// </summary>
            /// <param name="options">Options.</param>
            /// <param name="typeOfOptions">Type of options.</param>
            public Options(string[] options,string typeOfOptions)
            {     
                  switch(typeOfOptions.ToLower())
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
