using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QuickTools;
namespace Tester
{
      /// <summary>
      /// This handles an imput handler that execute a function while is reading input
      /// </summary>
      public class Input
      {
            /// <summary>
            /// The key .
            /// </summary>
            public string Key = null;
            /// <summary>
            /// The key char.
            /// </summary>
            public string KeyChar = null;
            /// <summary>
            /// The input list.
            /// </summary>
            public LinkedList<string> InputList = new LinkedList<string>();


            /// <summary>
            /// Read this The Input letter by letter.
            /// </summary>
            public static void Read(Action functionToCheck)
            {
                  var input = new Input();

                  while (input.Key != "Enter")
                  {


                        var key = Console.ReadKey();
                        Get.Clear();
                        input.Key = key.Key.ToString();
                        input.KeyChar = key.KeyChar.ToString();

                        // Get.Wait(Key);
                        // if is backspace well you should delete the last one 
                        if (input.Key == "Backspace")
                        {
                              input.InputList.RemoveLast();
                              //InputList.Remove(KeyChar);
                              // Get.Red(KeyChar); 

                        }
                        if (input.Key != "Backspace")
                        {
                              input.InputList.AddLast(input.KeyChar);
                        }
                        //Color.Green(Key + " " + KeyChar);
                        functionToCheck();
                  }
            }


            /// <summary>
            /// Read this The Input letter by letter.
            /// </summary>
            public void Read()
            {


                  while (this.Key != "Enter")
                  {


                        var key = Console.ReadKey();
                        Get.Clear();
                        this.Key = key.Key.ToString();
                        this.KeyChar = key.KeyChar.ToString();

                        // Get.Wait(Key);
                        // if is backspace well you should delete the last one 
                        if (this.Key == "Backspace")
                        {
                              InputList.RemoveLast();
                              //InputList.Remove(KeyChar);
                              // Get.Red(KeyChar); 

                        }
                        if (Key != "Backspace")
                        {
                              InputList.AddLast(KeyChar);
                        }
                        //Color.Green(Key + " " + KeyChar);
                        FunctionToCheck();
                  }
            }


            private Action FunctionToCheck;

            /// <summary>
            /// Initializes a new instance of the <see cref="T:Tester.Input"/> class.
            /// </summary>
            public Input()
            {

            }
            /// <summary>
            /// Initializes a new instance of the <see cref="T:Tester.Input"/> class.
            /// </summary>
            public Input(Action functionToCheck)
            {
                  FunctionToCheck = functionToCheck;
            }

      }
}