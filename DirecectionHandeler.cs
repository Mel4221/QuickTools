/*
This Contains all the shortcuts for the Alerts
and events of colors for the display of the 
text. 
important Date : today i have change the class name from "Do static class"
to "Get static class" due to some not sence ideas behing the idea of doing stuff
it is nothing related with the performance but more with relation with the 
action that it creates DATE OF UPDATE : 03/11/2022
*/
using System;
//using System.Security;            // has to be implemented 
using System.Threading;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
//using System.Security.Permissions;// it has to be implemented
namespace QuickTools
{
      /// <summary>
      /// This Class in sintended to improve the Options Class
      /// which seems to me  really anticated  and this one provides movements
      /// with all the arrow keys
      /// </summary>
            public class ArrowKey
            {
                        private static double X = 0; 
                        private static double Y = 0;
            /// <summary>
            /// This fields has direct acces but as it returns an array 
            /// the method GetLocation  can provide the number only in an object type 
            /// </summary>
                        public static double[] Location  = {X,Y};

                        private static void Up()
                        {
                            Y++; 
                        }
                        private static void Down()
                        {
                            Y--; 
                        }
                        private static void Left()
                        {
                            X--; 
                        }
                        private static void Right()
                        {   
                            X++; 
                        }

                        /// <summary>
                        /// This method Returns the actual position from the 
                        /// Fields X and Y 
                        /// </summary>
                        /// <returns>The location.</returns>
                        public static object GetLocation()
                         {
                              return Location[0] + " " + Location[1]; 
                         }
            /// <summary>
            /// This method is the one that is public to move the keys 
            /// </summary>
            public   static void Move()
                        {
                                while(Get.KeyInput().ToString() != "Enter")
                                {
                                    switch(Get.Key)
                                    {
                                        case "UpArrow":
                                            Up(); 
                                            
                                          //Color.Green(X+" "+Y); 
                                        break; 
                                        
                                        case "DownArrow":
                                            Down(); 
                                            //Color.Green(X+" "+Y); 
                                        break; 
                                        
                                        case "LeftArrow":
                                        Left(); 
                                         //Color.Green(X+" "+Y); 
                                        break; 
                                        
                                        case "RightArrow":
                                        Right(); 
                                        //Color.Green(X+" "+Y); 
                                        break; 
                                        default:
                                        
                                        break; 
                                        
                                    }
                                }
                        }
            /// <summary>
            /// This does the same thing as the regular Move but you can spesified the  condition 
            /// it has to be on type of string  remember that if your condition is a number it may not work 
            /// sucessfully since the numbers from the keyboard is readed as 4D4 0r 9D9 so be carefull with that 
            /// </summary>
            /// <param name="condition">Condition.</param>
            public static void Move(string condition)
            {
                  while (Get.KeyInput().ToString() != condition)
                  {
                        switch (Get.Key)
                        {
                              case "UpArrow":
                                    Up();

                                    //Color.Green(X + " " + Y);
                                    break;

                              case "DownArrow":
                                    Down();
                                    //Color.Green(X + " " + Y);
                                    break;

                              case "LeftArrow":
                                    Left();
                                    //Color.Green(X + " " + Y);
                                    break;

                              case "RightArrow":
                                    Right();
                                    //Color.Green(X + " " + Y);
                                    break;
                              default:

                                    break;

                        }
                  }
            }

      }
}