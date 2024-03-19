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
    public partial class IConvert
    {
        /// <summary>
        /// Finds the comma.
        /// </summary>
        /// <returns>The the comma.</returns>
        /// <param name="rowString">Row string.</param>
        /// <param name="aproxIndex">Aprox index.</param>
        public static int FindTheComma(ref string rowString , int aproxIndex)
        {
            if (string.IsNullOrEmpty(rowString)) return 0;
            if (aproxIndex > rowString.Length) throw new ArgumentException($"Why the aproxIndex is bigger than the rowString {aproxIndex} it does not make any sence!!!");
            int index = 0;
            for(int ch = aproxIndex - 1; ch > 0; ch--)
            {
                if(rowString[ch] == ',')
                {
                    index = ch;
                    return index;
                }
            }
            return index; 
        }

        /// <summary>
        /// Gets the vectors.
        /// </summary>
        /// <returns>The vectors.</returns>
        /// <param name="rowString">Row string.</param>
        public static string[] GetVectors(string rowString)
        {
            if (string.IsNullOrEmpty(rowString))
            {
                return new string[] { rowString };
            }//too smalle to work with
            if (rowString.Length < 1024*1024 * 2)
            {
                return new string[] { rowString };
            }
            else
            {
                string[] vectors = new string[] { };
                int length, quater; 
                length = rowString.Length;




                return vectors;
            }

        }
        /// <summary>
        /// Strings to bytes array.
        /// </summary>
        /// <returns>The to bytes array.</returns>
        /// <param name="rowString">Row string.</param>
        /// <param name="allowDebugger">If set to <c>true</c> allow debugger.</param>
        public static byte[] StringToBytesArray(string rowString, bool allowDebugger)
        {
            string current = "";
            List<byte> temp = new List<byte>();

            //Thread F;
            //Thread B;
            //ref string a = ref rowString.Substring(row;
            try
            {
                //go around to the current bug that it has if it starts
                //with , it will regect the format
                if (rowString[0] == ',')
                {
                    rowString = rowString.Substring(1);
                }
                //this is a go around to the current bug that it has if it starts
                //with , it will regect the format
                if (rowString[rowString.Length - 1] != ',')
                {
                    rowString += ",";
                }
                //maknig sure that there is not spaces in it 
                rowString = rowString.Replace(" ", "");
                string status, str;
                str = "";
                status = "";

                for (int value = 0; value < rowString.Length; value++)
                {
                    status = $"Converting to Binary Format: [{Get.Status(value, rowString.Length)}]";
                    if (allowDebugger && str != status)
                    {
                        str = status;
                        Get.Green(status);
                    }
                    if (rowString[value] != ',')
                    {
                        current += rowString[value];

                    }
                    if (rowString[value] == ',')
                    {
                        try
                        {
                            temp.Add(Convert.ToByte(current));
                        }
                        catch (Exception ex)
                        {
                            Color.Yellow("It Looks like the row string could not be converted to bytes \n" + ex);
                            throw;
                        }

                        current = "";

                    }
                }
                //byte[] array = new byte[temp.Count];
                /*
                for (int back = 0; back < temp.Count; back++)
                {
                    array[back] = Convert.ToByte(temp[back]);
                }
                */
                GC.Collect();
                return temp.ToArray();
            }
            catch (Exception ex)
            {
                Color.Yellow("It Looks like the row string could not be converted to bytes \n" + ex);
                throw ex;// new byte[100];// just to give it a value not really that it does anything special 
            }

        }
        /// <summary>
        /// Strings to bytes array.
        /// </summary>
        /// <returns>The to bytes array.</returns>
        /// <param name="rowString">Row string.</param>
        public static byte[] StringToBytesArray(string rowString)
        {
            return StringToBytesArray(rowString, false);
        }
    }
}
