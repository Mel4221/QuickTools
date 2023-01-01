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
using QuickTools.Colors; 
using System.Collections.Generic; 
namespace QuickTools
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
            /// Byteses to string.
            /// </summary>
            /// <returns>The to string.</returns>
            /// <param name="array">Array.</param>
            public static string BytesToString(byte[] array)
            {
                  try
                  {
                        for (int value = 0; value < array.Length; value++)
                        {
                              text.Append(array[value] + ",");
                        }

                        return text.ToString();
                  }
                  catch (Exception ex)
                  {
                        Color.Yellow("It Looks like the array was empty and it can not be converted \n" + ex);
                        return null;
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
                        return new byte[100];// just to give it a value not really that it does anything special 
                  }

            }

      }
}
