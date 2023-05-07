//
// ${Melquiceded Balbi Villanueva}
//
// Author:
//       ${Melquiceded} <${melquiceded.balbi@gmail.com}>
//
// Copyright (c) ${2089} MIT
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using System.Text;
using QuickTools.QColors; 
using System.Collections.Generic;
using System.Threading;

namespace QuickTools.QCore
{

      /// <summary>
      /// IConvert provides a list of costums covertions methods 
      /// </summary>
      public class IConvert
      {



            /// <summary>
            /// This class convert some type of special methos that convert to  any type of a array to the same type of list 
            /// and the same backwards 
            /// </summary>
            public class ToType<Type>
            {

                  /// <summary>
                  /// This method mekes sure that there is no value that 
                  /// is returned that is empty 
                  /// </summary>
                  public static Func<Type[], Type[]> ArrayJutifyer = (arr) => {
                        Type[] clearArr;
                        List<Type> list = new List<Type>();
                        for (long i = 0; i < arr.Length; i++)
                        {
                              if (arr[i] != null)
                              {
                                    list.Add(arr[i]);
                              }
                        }

                        clearArr = new Type[list.Count];
                        for (int val = 0; val < list.Count; val++)
                        {
                              clearArr[val] = list[val];
                        }

                        return clearArr;

                  };



                  /// <summary>
                  ///Convert the given array type to a list with the same type 
                  /// </summary>
                  /// <returns>The to list.</returns>
                  /// <param name="array">Array.</param>
                  public List<Type> ArrayToList(Type[] array)
                  {
                        List<Type> data = new List<Type>();
                        if (array.Length > 0)
                        {
                              for (int value = 0; value < array.Length; value++)
                              {
                                    data.Add(array[value]);
                              }
                        }
                        return data;
                  }




                  /// <summary>
                  ///Convert the given array type to a list with the same type but this method is an static method 
                  /// </summary>
                  /// <returns>The list.</returns>
                  /// <param name="array">Array.</param>
                  public static List<Type> ToList(Type[] array)
                  {
                        List<Type> data = new List<Type>();
                        if (array.Length > 0)
                        {
                              for (int value = 0; value < array.Length; value++)
                              {
                                    data.Add(array[value]);
                              }
                        }

                        return data;
                  }

                  /// <summary>
                  /// 
                  /// </summary>
                  /// <returns></returns>
                  /// <param name="list"></param>
                  public Type[] ListToArray(List<Type> list)
                  {
                        Type[] array;

                        if (list.Count > 0)
                        {
                              array = new Type[list.Count];

                              for (int value = 0; value < list.Count; value++)
                              {
                                    array[value] = list[value];
                              }

                              return array;
                        }


                        return new Type[10];
                  }

                  /// <summary>
                  /// Tos the array.
                  /// </summary>
                  /// <returns>The array.</returns>
                  /// <param name="list">List.</param>
                  public static Type[] ToArray(List<Type> list)
                  {
                        Type[] array;

                        if (list.Count > 0)
                        {
                              array = new Type[list.Count];

                              for (int value = 0; value < list.Count; value++)
                              {
                                    array[value] = list[value];
                              }
                              return array;
                        }


                        return new Type[10];
                  }

                   
            }



            private static StringBuilder text = new StringBuilder();


            /// <summary>
            /// This takes an sring array which is verify if it has empty spaces and it returns it back without any empty spaces
            /// </summary> 
            public static Func<String[], String[]> ArrayJutifyer = (arr) => {
                  String[] clearArr;
                  List<string> list = new List<string>();
                  for (int i = 0; i < arr.Length; i++)
                  {
                        if (arr[i] != "" && arr[i] != null)
                        {
                              list.Add(arr[i]);
                        }
                  }

                  clearArr = new string[list.Count];
                  for (int val = 0; val < list.Count; val++)
                  {
                        clearArr[val] = list[val];
                  }

                  return clearArr;

            };
            /// <summary>
            /// Converts the Text to string array 
            /// </summary>
            /// <returns>The to array.</returns>
            /// <param name="words">Words.</param>
            public static string[] TextToArray(string words) => ArrayJutifyer(words.Split(' '));

        /// <summary>
        /// Creates a row string with space in between of words to devide each word from the array
        /// </summary>
        /// <param name="arrayOfWords"></param>
        /// <returns></returns>
        public static string ArrayToText(string[] arrayOfWords)
        {
            text = new StringBuilder();
            foreach(string word in arrayOfWords)
            {   
                text.Append(word + " ");
            }
            return text.ToString();
        }
            /*
            /// <summary>
            /// Creates a row string with space in between of words to devide each word from the array
            /// </summary>
            /// <param name="arrayOfWords"></param>
            /// <returns></returns>
                public static string ArrayToText(string[] arrayOfWords)
            {
                text = new StringBuilder();
                for(int word = 0; word < arrayOfWords.Length; word++)
                {
                    text.Append(arrayOfWords[word] + " "); 
                }
            }*/






            static int f;
            static int b; 
            /// <summary>
            /// Converts the bytes given to a row string of bytes but is slow 
            /// </summary>
            /// <returns>The to string.</returns>
            /// <param name="array">Array.</param>
            public static string BytesToString(byte[] array)
            {
                  try
                        {

                        Thread foward, back;
                        StringBuilder str1, str2;
                        int fw, bc, len, half;
                        bool trigerA, trigerB;
                        len = array.Length;
                        half = len / 2;
                        fw = 0;
                        bc = 0;
                        trigerA = false;
                        trigerB = false;
                        str1 = new StringBuilder();
                        str2 = new StringBuilder();
                        if(len != (half + half))
                              {
                              // Get.Ok();
                              fw = half + 1;
                              bc = len;

                              }
                        if(len == (half + half))
                              {
                              fw = half;
                              bc = len;
                              }
                        //Get.Wait();
                        foward = new Thread(() =>
                        {
                              for(int i = 0 ; i < fw ; i++)
                                    {
                                    //  Get.Green(i);
                                    f = i;
                                    str1.Append(array[i] + ",");

                                    }
                              trigerA = true;
                        });

                        back = new Thread(() =>
                        {
                              for(int i = half ; i < len ; i++)
                                    {
                                    //  Get.Red(i);
                                    b = i;
                                    str2.Append(array[i] + ",");

                                    }
                              trigerB = true;
                        });

                        foward.Start();
                        back.Start();


                        while(true)
                              {

                                   // Get.Green($"F: {f} B: {b} Size: {array.Length}  A:{Get.Status(f , b)} ");

                                    if(trigerA == true && trigerB == true)
                                    {
                                          return str1.ToString() + str2.ToString();
                                    //Writer.Write("test.txt" , str);
                                     }
                              //Thread.Sleep(5000);

                              }
                        }
                  catch(Exception ex)
                        {
                        Color.Yellow("It Looks like the array was empty and it can not be converted \n" + ex);
                        return null;
                        }


            }

            /// <summary>
            /// Converts the bytes given to a row string of bytes but is slow if showDebuger is equal to true it will print the status of the buffer to the console
            /// </summary>
            /// <returns>The to string.</returns>
            /// <param name="array">Array.</param>
            /// <param name="showDebuger">If set to <c>true</c> show debuger.</param>
            public static string BytesToString(byte[] array,bool showDebuger)
                  {
                  try
                        {

                        Thread foward, back;
                        StringBuilder str1, str2;
                        int fw, bc, len, half, breaker; 
                        bool trigerA, trigerB;
                        len = array.Length;
                        half = len / 2;
                        fw = 0;
                        bc = 0;
                        breaker = 0; 
                        trigerA = false;
                        trigerB = false;
                        str1 = new StringBuilder();
                        str2 = new StringBuilder();
                        if(len != (half + half))
                              {
                              // Get.Ok();
                              fw = half + 1;
                              bc = len;

                              }
                        if(len == (half + half))
                              {
                              fw = half;
                              bc = len;
                              }
                        //Get.Wait();
                        foward = new Thread(() =>
                        {
                              for(int i = 0 ; i < fw ; i++)
                                    {
                                    //  Get.Green(i);
                                    f = i;
                                    str1.Append(array[i] + ",");

                                    }
                              trigerA = true;
                        });

                        back = new Thread(() =>
                        {
                              for(int i = half ; i < len ; i++)
                                    {
                                    //  Get.Red(i);
                                    b = i;
                                    str2.Append(array[i] + ",");

                                    }
                              trigerB = true;
                        });

                        foward.Start();
                        back.Start();

                        
                        while(true)
                              {
                    if (showDebuger == true)
                    {
                        Get.Green($"Buffer Size: {Get.FileSize(array)} Status: {Get.Status(f, half)}");
                    }

                    if (trigerA == true && trigerB == true || breaker == len)
                                    {
                                        foward.Abort();
                                        back.Abort(); 
                                        if(showDebuger == true)
                                        {
                            Get.Yellow($"Killed Or Completed:  A:[{trigerA}] B:[{trigerB}] Breaker:[{breaker}] BreakerAprox:[{len}]");
                                        }
                                    break;

                                    //Writer.Write("test.txt" , str);
                                    }

                                breaker++; 

                              }
                        return str1.ToString() + str2.ToString();
                        }
                  catch(Exception ex)
                        {
                        if(showDebuger == true)
                {
                    Color.Yellow("It Looks like the array was empty and it can not be converted \n" + ex);

                }
                return null;
                        }



                  }




            /// <summary>
            /// Converts To the ASCII encuding
            /// </summary>
            /// <returns>The ASCII.</returns>
            /// <param name="content">Content.</param>
            public static byte[] ToASCII(object content) => Encoding.ASCII.GetBytes(content.ToString());

            /// <summary>
            /// Convert to string the given bytes 
            /// </summary>
            /// <returns>The string.</returns>
            /// <param name="content">Content.</param>
            public static string ToString(byte[] content) => Encoding.ASCII.GetString(content);


            /// <summary>
            /// Gets or sets the convertion status.
            /// </summary>
            /// <value>The convertion status.</value>
            protected static string ConvertionStatus { get; set; }
            /// <summary>
            ///  convert bytes to a char array 
            /// </summary>
            /// <returns>The char array.</returns>
            /// <param name="bytes">Bytes.</param>
            public static char[] ToCharArray(byte[] bytes)
            {
            try
            {

                char[] chars = new char[bytes.Length];
                for (int i = 0; i < bytes.Length; i++)
                {
                    chars[i] = Convert.ToChar(bytes[i]);
                    ConvertionStatus = Get.Status(i, bytes.Length);
                }


                return chars;
            }catch(Exception e)
            {
                throw e; 
            }
            }


            /// <summary>
            /// Strings to bytes array.
            /// </summary>
            /// <returns>The to bytes array.</returns>
            /// <param name="rowString">Row string.</param>
            public static byte[] StringToBytesArray(string rowString)
            {
                  string current = "";
                  List<string> temp = new List<string>();
                  try
                  {


                        for (int value = 0; value < rowString.Length; value++)
                        {
                              if (rowString[value] != ',')
                              {
                                    current += rowString[value];

                              }
                              if (rowString[value] == ',')
                              {
                                    temp.Add(current);
                                    current = "";
                              }
                        }
                        byte[] array = new byte[temp.Count];

                        for (int back = 0; back < temp.Count; back++)
                        {
                              array[back] = Convert.ToByte(temp[back]);
                        }

                        return array;
                  }
                  catch (Exception ex)
                  {
                        Color.Yellow("It Looks like the row string could not be converted to bytes \n" + ex);
                        throw ex;// new byte[100];// just to give it a value not really that it does anything special 
                  }

            }

      }
}
