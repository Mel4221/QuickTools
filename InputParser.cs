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
using System.Threading;
using QuickTools.Colors; 
namespace QuickTools
{
      /// <summary>
      /// Input parser.
      /// </summary>
      public partial class InputParser
      {

            /// <summary>
            /// Gets or sets the type of the return.
            /// </summary>
            /// <value>The type of the return.</value>
            public Get.InputType ReturnType { get; set; }
            private string[] Commands;

            /// <summary>
            /// The QTC ommand.
            /// </summary>
            public string QTCommand = "$qt"; 

            /// <summary>
            /// Hases the commands.
            /// </summary>
            /// <returns><c>true</c>, if commands was hased, <c>false</c> otherwise.</returns>
            /// <param name="input">Input.</param>
            public bool HasCommands(string input)
            {
                
                  int qtl = this.QTCommand.Length; 

                  bool has = false;
                  if(input.IndexOf(this.QTCommand[0]) == 0)
                  {
                        //Get.Ok(); 
                        //$qt 
                        if (input.Length > qtl)
                        {
                              // Get.Ok(1);
                              if (input.Substring(0, qtl) == this.QTCommand)
                              {
                                    has = true;
                                    this.Commands = IConvert.TextToArray(input.Substring(qtl));
                                    //Get.Ok(2); 
                                    //Get.Blue($"{input.Substring(qtl)}");
                                    //foreach (string str in this.Commands) Get.Blue(str); 
                                    return has;

                              }
                        }
                  }


                  return has; 
            }

            private string ReadCommands(int from)
            {
                  StringBuilder text = new StringBuilder();
                  for (int i = from; i < Commands.Length; i++)
                  {
                        text.Append(Commands[i] + " ");
                        //Get.Blue(this.Commands[i]); 
                  }
                  return text.ToString(); 
            }

            /// <summary>
            /// Parse this instance.
            /// </summary>
            public void Parse()
            {
                  //foreach (var q in Commands) Get.Blue(q); 
                  if(this.Commands.Length >= 3)
                  {
                        string action, type, arg, param;

                              action = Commands[0].ToLower();
                              type = Commands[1].ToLower();
                              arg = Commands[2].ToLower();
                              param = ""; 
                              if(this.Commands.Length > 3) param = Commands[3].ToLower();


                        switch (action)
                        {
                              case "random":
                              case "rand":
                                          
                                    break; 
                              case "get":

                                    switch (type) 
                                    {
                                             case "clear":
                                      
                                                Get.Clear(); 
                                                break; 
                                          case "box":
                                                //foreach (string str in this.Commands) Get.Yellow(str); 

                                                Get.Box(this.ReadCommands(2)); 
                                                break;
                                          case "F":
                                                switch(arg)
                                                {
                   

                                                      default:
                                                            Color.Red($"Invalid Argument Command: {arg} at: {action} > {type} > '{arg}'");
                                                            break; 
                                                }
                                                break; 
                                          default:
                                                Color.Red($"Invalid Type : {type} at: {action} > '{type}' > {arg}");
                                                break; 
                                    }
                                    break;

                              default:
                                    Color.Red($"Invalid Action Command: {action} at: '{action}' > {type} > {arg}"); 
                                    break; 
                        }
                  }
            

            }


            /// <summary>
            /// Creads a Terminal mode where you could type the commands to get the actions from QuickTools
            /// </summary>
            public class Terminal
            {
                  /// <summary>
                  /// Start this Terminal.
                  /// </summary>
                  /// <returns>The start.</returns>
                  public int Start()
                  {
                        int status = 0;

                        try
                        {
                              InputParser inputParser = new InputParser(); 

                              while (true)
                              {
                                    string input = $"{inputParser.QTCommand} {Get.Input().Text}"; 
                                    if(input == $"{inputParser.QTCommand} exit")
                                    {
                                          break; 
                                    }
                                    //Get.Wait(input); 
                                    if(inputParser.HasCommands(input))
                                    {
                                          inputParser.Parse(); 
                                    }
                                    //Get.Wait(input); 
                                    //foreach (string str in inputParser.Commands) Get.Blue(str); 
                              }

                              return status; 
                        }catch(Exception e)
                        {
                              Get.Wrong($"There was an error while running the terminal mode more information: \n{e.Message}");
                              status = 1;
                              return status; 
                        }
                  }

                  /// <summary>
                  /// Initializes a new instance of the <see cref="T:QuickTools.InputParser.Terminal"/> class.
                  /// </summary>
                  public Terminal()
                  {

                  }
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="T:QuickTools.InputParser"/> class.
            /// </summary>
            public InputParser()
            {

            }
            /// <summary>
            /// Initializes a new instance of the <see cref="T:QuickTools.InputParser"/> class.
            /// </summary>
            /// <param name="commands">Commands.</param>
            public InputParser(string[] commands)
            {
                  this.Commands = commands; 
            }
      }
}

/*
                                          switch (type) 
                                    {
                                          case "":
                                                switch(arg)
                                                {
                                                      case "":

                                                            break;

                                                      default:
                                                            Color.Red($"Invalid Argument Command: {arg} at: {action} > {type} > '{arg}'");
                                                            break; 
                                                }
                                                break; 
                                          default:
                                                Color.Red($"Invalid Type Command: {type} at: {action} > '{type}' > {arg}");
                                                break; 
                                    }
*/
