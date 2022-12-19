/*

            This class is still not completed 
            and it will be an extention on the functionality 
            from the Options class  , but it will basically just read
            only the arrow keys from a keayboard            

*/


using System;
using System.Collections.Generic; 
namespace QuickTools
{
      /// <summary>
      /// 
      /// </summary>
       public class List
      {
            /// <summary>
            /// No Implementation ________
            /// Initializes a new instance of the <see cref="T:QuickTools.List"/> class.
            /// 
            /// </summary>
            public List()
            {

            }
            /// <summary>
            /// Initializes a new instance of the <see cref="T:QuickTools.List"/> class.
            /// </summary>
            /// <param name="rowList">Row list.</param>
            public List(string rowList)
            {

            }
            /// <summary>
            /// Add the list to the Selection List __________
            /// Initializes a new instance of the <see cref="T:QuickTools.List"/> class.
            /// </summary>
            /// <param name="list">List.</param>
            public List(string[] list)
            {
                  foreach (string item in list)
                  {
                        SelectionList.Add(item);
                  }
            }
            /// <summary>
            /// Add the list to the Selection List __________
            /// Initializes a new instance of the <see cref="T:QuickTools.List"/> class.
            /// </summary>
            /// <param name="list">List.</param>
            public List(List<string> list)
            {
                  SelectionList = list; 
            }

            private static int Position = 0;
            private static int Location = 0; 
            // private static int Depth = 0;
            /// <summary>
            /// Contains the selection list 
            /// </summary>
            public static List<string> SelectionList = new List<string>();
            /// <summary>
            /// Contains the Row String that needs to be parsed into multiple pices 
            /// </summary>
            public string RowSelection = null; 
           // private static int ArrayLength = 0;
            private static void DisplayArray()
            {

               //   int[] a = { 1, 2, 3, 4, 5 };

                  /*
                   * 
                  int[] a = { 0, 1, 2, 3, 4 };
                  int[] b = { 5, 6, 7, 8, 9 };           
                  int[] c = {-1, 0, 1, 2, 3 };
                  int[] d = {-2, -1, 0, 1,2};
                  int[] e = { -3,-2,-1,0,1 };
                  int[] f = { -4,-3, -2,-1,0}; 
                  */
              //   ArrayLength = SelectionList.Count;
                  Get.W("[");
                  for (int i = 0; i < SelectionList.Count; i++)
                  {

                              
                             
                              Get.LabelSingle(SelectionList[Position]+",");

                            
                     


                  }
                  Get.W("]");

            }
            /// <summary>
            /// Pick the string in the array or list. 
            /// </summary>
            /// <returns>The List selection.</returns>
            public static int Pick()
            {
                  int x = 0;


                  //Get.Alert("Text");

                  /*
                      Escape
                      UpArrow
                      DownArrow
                      RightArrow               
                      LeftArrow
                  */

                  DisplayArray(); // show the array 
                  while (Get.KeyInput().ToString() != "Enter")
                  {
                        switch (Get.Key)
                        {

                              case "LeftArrow":
                                    if (Position == 0)
                                    {
                                          Position = SelectionList.Count;
                                           Location = Position; 
                                    }
                                    else
                                    {
                                          Position--;
                                          Location--; 
                                    }
                                    DisplayArray();

                                    break;
                              case "RightArrow":
                                    if (Position == SelectionList.Count)
                                    {
                                          Position = 0;
                                          Location = 0; 
                                    }
                                    else
                                    {
                                          Position++;
                                          Location++; 
                                    }
                                    DisplayArray();
                                    break;
                              default:
                                    
                                    Get.Title("To Exit Press Escape");
                                    DisplayArray(); 
                                    break;
                        }
                  }





                  return x; 
            }
      }
}
