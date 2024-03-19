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
        /// Converts the bytes given to a row string of bytes but is slow 
        /// </summary>
        /// <returns>The to string.</returns>
        /// <param name="array">Array.</param>
        public static string BytesToString(byte[] array)
        {
            return BytesToString(array, false);
        }

        /// <summary>
        /// Converts the bytes given to a row string of bytes but is slow if showDebuger is equal to true it will print the status of the buffer to the console
        /// </summary>
        /// <returns>The to string.</returns>
        /// <param name="array">Array.</param>
        /// <param name="showDebuger">If set to <c>true</c> show debuger.</param>
        public static string BytesToString(byte[] array, bool showDebuger)
        {
            try
            {

                Thread foward, back;
                StringBuilder str1, str2;
                int fw, bc, len, half, breaker, bcurrent;
                bool trigerA, trigerB, isNotHalf;
                string status;
                len = array.Length;
                half = len / 2;
                fw = 0;
                bc = 0;
                breaker = 0;
                trigerA = false;
                trigerB = false;
                isNotHalf = false;
                status = null;
                str1 = new StringBuilder();
                str2 = new StringBuilder();

                if (len != (half + half))
                {
                    // Get.Ok();
                    fw = half + 1;
                    bc = len;
                    isNotHalf = true;

                }
                if (len == (half + half))
                {
                    fw = half;
                    bc = len;
                }
                //Get.Wait();
                foward = new Thread(() =>
                {
                    for (int i = 0; i < fw; i++)
                    {
                        //  Get.Green(i);
                        f = i;
                        str1.Append(array[i] + ",");

                    }
                    trigerA = true;
                });
                bcurrent = 0; 
                back = new Thread(() =>
                {
                    // this was the fix that i came up with to solve the issue with 
                    // the bytes overlapping with the one that was moving from 0 to the half of the array 
                    if (isNotHalf)
                    {
                        half++;
                    }
                    for (int i = half; i < len; i++)
                    {
                        //  Get.Red(i);
                        b = i;
                        str2.Append(array[i] + ",");
                        bcurrent++;
                    }
                    trigerB = true;
                });

                foward.Start();

                back.Start();

                string str = "";
                while (true)
                {
                    status = $"Buffer Size: {Get.FileSize(array)} Status: A: [{Get.Status(f,half)}] B: [{Get.Status(bcurrent,half)}]";
                    if (showDebuger == true && str != status)
                    {
                        str = status;
                        Get.Green(status);
                    }
                    IConvert.OpartionStatus = status;

                    if (trigerA == true && trigerB == true || breaker == len)
                    {
                        foward.Abort();
                        back.Abort();
                        status = $"Completed:  Thread A:[{trigerA}] Thread B:[{trigerB}] Breaker:[{breaker}] Length:[{len}]";
                        if (showDebuger == true)
                        {
                            Get.Yellow(status);
                        }
                        break;

                        //Writer.Write("test.txt" , str);
                    }

                    //breaker++;

                }
                GC.Collect();
                return str1.ToString() + str2.ToString();
            }
            catch (Exception ex)
            {
                if (showDebuger == true)
                {
                    Color.Yellow("It Looks like the array was too Big and you ran out of memory \n" + ex);

                }
                return null;
            }



        }

    }

}
