/* 
 * 
 * The low encrypter and decrypter are still not to the level that i would say
 * hey this  would be a chanlenge for sombody to hack in because it is just switcing order
 * and Elevating to the power of a number which is not enoguth for security porpuses.
*/


using System;
using System.Collections.Generic;
using System.Text;
namespace QuickTools
{
      /// <summary>
      /// This file slighly encrypt a file by confusing the bytes in it and later on it write the file with  those confused files 
      /// </summary>
      public class LowEncrypt
      {

            /*
                  All this was completly usless 
            */
            // public static List<int> Data = new List<int>();
            // public static byte[] DataBytes;
            //public static int DataLength = 0000;
            //public static int DataHash = 0000;
            /// <summary>
            /// RowData is a field that contains the data in a entried string 
            /// </summary>
            public static string RowData = null; 

            /// <summary>
            /// Encrypts the text that is passed as a string
            /// </summary>
            /// <returns>The file.</returns>
            /// <param name="onlyText">text file or string text </param>
            public static string EncryptFile(string onlyText)
            {


                  byte[] dataBytes = Encoding.ASCII.GetBytes(onlyText);// getting the bytes to work with the file 

                  byte[] switching = new byte[dataBytes.Length];// creatting a new array to swich the order of the itmes

                //  DataLength = dataBytes.Length; // saving the length of the Encoding

                  int back = dataBytes.Length; // back will be the variable used to index the back order 




                  // this will change the order from front to the back
                  // then it will be elevated to the power of 2
                  for (int value = 0; value < dataBytes.Length; value++)
                  {

                        switching[value] = dataBytes[back - 1];// this will switch the order of the bytes
                        switching[value] = Convert.ToByte((switching[value] ^ 16));// thiw will elveate it to the power of 2

                        back--;// decrementing the value of back to change the order of the bytes 
                  }




                  // foreach(int values in finalData) 
                  //  Console.Write(values+","); 
                  //DataBytes = new byte[DataLength]; // initialaize the bytes
                  //DataBytes = switching; // passing the values to a global variable
                                         //Console.WriteLine(Encoding.ASCII.GetString(switching)); //testing
                                         //Encrypter.Data = finalData;


                  /*
                  ///<summary>
                  /// this is the final result of the exponantial process of each bytes elevated to the power x 
                  // without any type of password this is done Only one time for now until im able to learn how to make 
                  // it for multiple times more effitiatly 
                  /// </summary>
                  */
                  string finalData = Encoding.ASCII.GetString(switching);
                  RowData = finalData;
                  return finalData; 
            }

      }

}