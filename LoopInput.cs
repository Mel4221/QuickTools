using System;
using System.Text;
using System.Collections.Generic;



namespace QuickTools
{
      /// <summary>
      ///LoopInput allows you to keep getting an imput constantly in a Console Application
      ///and callect the entired input and return it in a single string or it can be access aswell
      /// by calling the LoopInput.Data.
      /// </summary>
      public class LoopInput
  {     
      /// <summary>
      /// The Return Data will have to be provided by a method due to 
      /// lack of simplicity
      /// </summary>
      private  List<string> Data = new List<string> ();
     
             
            /// <summary>
            ///  this can not be cause is handled only by the Start Method .
            /// </summary>
     private  void PrintList()
     {
                  Get.Clear();

                  /*
                        this is a very simple logic to add a line 
                        if the text ends in "."
                        it actually adds 2 but who cares .
                  */
                  for (int value = 0; value<Data.Count; value++)
                   {
                        if (Data[value].LastIndexOf('.') == Data[value].Length - 1)
                        {
                              Color.Green(Data[value] + Environment.NewLine + Environment.NewLine);
                        }
                        else
                        {
                              Color.Green(Data[value]); 
                        }
                       
                   }
     }

            /// <summary>
            /// Start is basically a while loop that contains the Get.TextInput to collect
            /// the input and the loop just repeat it until the key period "."  is entered or if the 
            /// text input equal to the fallowing "done", "exit","done","d"
            /// </summary>
            /// <returns>The InputData or rowdata callected by the Input.</returns>
            public  string Start()
            {

                  while (Get.TextInput() != ".")
                  {
                        if (Get.Text.ToLower() != "exit"&&
                            Get.Text.ToLower() != "done"&& 
                            Get.Text.ToLower() != "out" &&
                            Get.Text.ToLower() != "d")
                        { 
                              //here is the text that is added
                              // to the list and 
                              //call the PrintList()//method
                              Data.Add(Get.Text+" ");
                              PrintList();
                        }
                        else
                        {
                              break; 
                        }
                  }

                  return RowData(); 
            }

            /// <summary>
            /// RowData method is a method that callects
            /// all the data in the List and it return into a row string
            /// </summary>
            /// <returns>The data.</returns>
            public  string RowData()
            {
                  StringBuilder data = new StringBuilder();//where the date that will ber returned is stored 
                  /*
      this is a very simple logic to add a line 
      if the text ends in "."
      it actually adds 2 but who cares .
*/
                  for (int value =0; value<Data.Count; value++) {
                        if (Data[value].LastIndexOf('.') == Data[value].Length-1)
                        {
                              data.Append(Data[value]+Environment.NewLine+Environment.NewLine);
                        }
                        else
                        {
                              data.Append(Data[value]);
                        }
                  }

                  return data.ToString();  
            }


            /// <summary>
            /// This Return each lines of the Loop Input that was captured 
            /// </summary>
            /// <returns>The lines.</returns>
            public  string[] Lines()
            {
                  string[] data = new string[Data.Count]; 
                  for (int value = 0; value < Data.Count; value++)
                  {

                        data[value] = Data[value]; 

                        /*
                        if (Data[value].LastIndexOf('.') == Data[value].Length - 1)
                        {
                          //   data.Append(Data[value] + Environment.NewLine + Environment.NewLine);
                              
                        }
                        else
                        {
                           //  data.Append(Data[value]);
                        }
  */
                    }


                  return data; 
            }


      }
}

