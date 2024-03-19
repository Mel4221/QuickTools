
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
using System.Collections.Generic;
using System.Text;
using System.Threading;
using QuickTools.QColors;

namespace QuickTools.QCore
{

    /// <summary>
    /// IConvert provides a list of costums covertions methods 
    /// </summary>
    public partial class IConvert
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
            public static Func<Type[], Type[]> ArrayJutifyer = (arr) =>
            {
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
            /// Returns an array on the given List  with the given type
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
        public static Func<String[], String[]> ArrayJutifyer = (arr) =>
        {
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
            try
            {
                text = new StringBuilder();
                foreach (string word in arrayOfWords)
                {
                    text.Append(word + " ");
                }
                return text.ToString();
            }
            catch
            {
                return null;
            }
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




        /// <summary>
        /// Converts the text format to the type of size B,KB,MB,GB
        /// </summary>
        /// <returns>The data size.</returns>
        /// <param name="size">Size.</param>
        public static int ToDataSize(string size)
        {
            /*
                10mb
                1gb
                55555b
            */
            if (Get.IsNumber(size))
            {
                return int.Parse(size);
            }
            string numbers, chars;
            int n = 0;
            numbers = "";
            chars = "";
            foreach (char ch in size)
            {
                switch (Get.IsNumber(ch))
                {
                    case true:
                        numbers += ch;
                        break;
                    case false:
                        if (ch != '.' && ch != ',') chars += ch;
                        break;
                }
            }
            chars = chars.ToLower();
            n = int.Parse(numbers);
            //Get.Yellow($"Numbers: [{numbers}] Chars: [{chars}]");
            //Get.Green($"Clear Numbers: {n} Clear Chars: [{chars}]");

            switch (chars)
            {
                case "b":
                    return n;
                case "kb":
                    return n * 1024;
                case "mb":
                    return n * 1024 * 1024;
                case "gb":
                    if (n >= 2) return int.MaxValue;
                    return n * 1024 * 1024 * 1024;
                default:
                    throw new Exception($"NOT SUPPORTED FORMAT [{chars}]");

            }

        }



        // public static StringToBytes

        static int f;
        static int b;

        /// <summary>
        /// Provides's the access to the current status of the given opeartion 
        /// not all the methods returns an operation status . 
        /// </summary>
        public static string OpartionStatus;
 



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
        /// Gets a text arrray  like 200,2,4,5,0 and convert it into it's equivalent in text 
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static string ToText(string array)
        {
            List<byte> bytes = new List<byte>();
            int current, goal;
            string text, ch;
            text = null;
            goal = array.Length;
            ch = "";
            for (current = 0; current < goal; current++)
            {
                switch (Get.IsNumber(array[current]))
                {
                    case true:
                        ch += array[current];
                        break;
                    case false:
                        if (ch != "")
                        {
                            bytes.Add(byte.Parse(int.Parse(ch).ToString()));
                            ch = "";
                        }
                        break;
                }

            }
            text = IConvert.ToString(IConvert.ToType<byte>.ToArray(bytes));
            return text;

        }



        /// <summary>
        /// Gets a text arrray  like 200,2,4,5,0 and convert it into it's equivalent in text 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="debugger"></param>
        /// <returns></returns>
        public static string ToText(string array, bool debugger)
        {
            List<byte> bytes = new List<byte>();
            int current, goal;
            string text, ch;
            text = null;
            goal = array.Length;
            ch = "";
            for (current = 0; current < goal; current++)
            {
                switch (Get.IsNumber(array[current]))
                {
                    case true:
                        ch += array[current];
                        break;
                    case false:
                        if (ch != "")
                        {
                            bytes.Add(byte.Parse(int.Parse(ch).ToString()));

                            if (debugger)
                            {
                                Get.Yellow(ch);
                            }
                            ch = "";
                        }
                        break;
                }
                if (debugger)
                {
                    Get.Green(Get.Status(current, goal));
                }

            }
            if (debugger)
            {
                Get.Yellow($"Array: {array}");
            }
            text = IConvert.ToString(IConvert.ToType<byte>.ToArray(bytes));
            return text;

        }



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
            }
            catch (Exception e)
            {
                throw e;
            }
        }

            
    }
}