using System;
namespace QuickTools.QColors
{
      public partial class Color
            {

                  /*
                     /////////////////////////////////////////////////////////////////////////////
                     //////////// THIS AREA CONTROLS CONSOLE COLOR AND STYLE /////////////////////
                     /////////////////////////////////////////////////////////////////////////////
                   */

                  // Cyan        
                  // Gray 

                  /// <summary>
                  /// Console the text using the name of the color 
                  /// </summary>
                  /// <param name="text">Text.</param>
                  public static void Gray(object text)
                  {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine(text);
                        Console.ResetColor();
                  }
                  /// <summary>
                  /// White the specified text.
                  /// </summary>
                  /// <param name="text">Text.</param>
                  public static void White(object text)
                  {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(text);
                        Console.ResetColor();
                  }

                  /// <summary>
                  /// <seealso cref="Gray(object)"/>
                  /// </summary>
                  /// <param name="text">Text.</param>
                  public static void Cyan(object text)
                  {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(text);
                        Console.ResetColor();
                  }
                  /// <summary>
                  /// <seealso cref="Gray(object)"/>
                  /// </summary>
                  /// <param name="text">Text.</param>
                  public static void Red(object text)
                  {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(text);
                        Console.ResetColor();
                  }
                  /// <summary>
                  /// Blue the specified text.
                  /// </summary>
                  /// <param name="text">Text.</param>
                  public static void Blue(object text)
                  {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(text);
                        Console.ResetColor();
                  }

                  /// <summary>
                  /// Green the specified text.
                  /// </summary>
                  /// <param name="text">Text.</param>

                  public static void Green(object text)
                  {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(text);
                        Console.ResetColor();
                  }
                  /// <summary>
                  /// Green the specified text and tabs.
                  /// </summary>
                  /// <param name="text">Text.</param>
                  /// <param name="tabs">Tabs.</param>
                  public static void Green(object text, int tabs)
                  {
                        Console.ForegroundColor = ConsoleColor.Green;
                        string spaces = "\t";
                        string tabSpaces = "";
                        for (int i = 0; i <= tabs; i++)
                        {
                              tabSpaces += spaces;
                        }

                        Console.WriteLine(tabSpaces + text);
                        Console.ResetColor();
                  }
                  /// <summary>
                  /// Black the specified text and tabs.
                  /// </summary>
                  /// <param name="text">Text.</param>
                  /// <param name="tabs">Tabs are refering to the \n char.</param>
                  public static void Black(object text, int tabs)
                  {
                        Console.ForegroundColor = ConsoleColor.Black;
                        string spaces = "\t";
                        string tabSpaces = "";
                        for (int i = 0; i <= tabs; i++)
                        {
                              tabSpaces += spaces;
                        }

                        Console.WriteLine(tabSpaces + text);
                        Console.ResetColor();
                  }
                  /// <summary>
                  /// Black the specified msg.
                  /// </summary>
                  /// <param name="msg">Message.</param>
                  public static void Black(object msg)
                  {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine(msg);
                        Console.ResetColor();
                  }


                  /// <summary>
                  /// Yellow the specified msg.
                  /// </summary>
                  /// <param name="msg">Message.</param>
                  public static void Yellow(object msg)
                  {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(msg);
                        Console.ResetColor();
                  }
                  /// <summary>
                  /// Yellow the specified text and tabs.
                  /// </summary>
                  /// <param name="text">Text.</param>
                  /// <param name="tabs">Tabs.</param>
                  public static void Yellow(object text, int tabs)
                  {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        string spaces = "\t";
                        string tabSpaces = "";
                        for (int i = 0; i <= tabs; i++)
                        {
                              tabSpaces += spaces;
                        }

                        Console.WriteLine(tabSpaces + text);
                        Console.ResetColor();
                  }

                  /// <summary>
                  /// Pink the specified text.
                  /// </summary>
                  /// <param name="text">Text.</param>
                  public static void Pink(object text)
                  {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine(text);
                        Console.ResetColor();
                  }
                  /// <summary>
                  /// Backs the yellow.
                  /// </summary>
                  /// <param name="text">Text.</param>
                  public static void Back_Yellow(object text)
                  {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(text);
                        Console.ResetColor();
                  }
                  /// <summary>
                  /// Backs the red.
                  /// </summary>
                  /// <param name="text">Text.</param>
                  public static void Back_Red(object text)
                  {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(text);
                        Console.ResetColor();
                  }
                  /// <summary>
                  /// Backs the blue.
                  /// </summary>
                  /// <param name="text">Text.</param>
                  public static void Back_Blue(object text)
                  {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(text);
                        Console.ResetColor();
                  }
                  /// <summary>
                  ///  Set the color of the background on pink or magenta 
                  /// </summary>
                  /// <param name="text">Text.</param>
                  public static void Back_Pink(object text)
                  {
                        Console.BackgroundColor = ConsoleColor.Magenta;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(text);
                        Console.ResetColor();
                  }
                  /// <summary>
                  /// Backs the green.
                  /// </summary>
                  /// <param name="text">Text.</param>
                  public static void Back_Green(object text)
                  {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(text);
                        Console.ResetColor();
                  }
                     /// <summary>
                     /// set the back color on white and the text on black 
                     /// </summary>
                     /// <param name="text">Text.</param>
                  public static void Back_White(object text)
                  {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine(text);
                        Console.ResetColor();
                  }
                  /// <summary>
                  /// Border the specified content.
                  /// </summary>
                  /// <param name="content">Content.</param>
                  public static void Border(object content)
                  {
                        string simbol = "*";
                        string underLine = "";
                        for (int i = 0; i <= content.ToString().Length + 3; i++)
                        {
                              Color.Yellow();
                              Console.Write(simbol);
                              underLine += simbol;
                        }

                        Console.WriteLine("");// this write an space
                        Console.Write(simbol); // this write a single char
                        Console.ResetColor();    // reset the color 
                        Console.Write(" " + content + " "); // write the content 
                        Color.Yellow(); // get the yellow color again 
                        Console.Write(simbol);
                        Console.WriteLine("");          // more space 
                        Console.WriteLine(underLine);
        }
                  /// <summary>
                  /// Border the specified content and simbol.
                  /// </summary>
                  /// <param name="content">Content.</param>
                  /// <param name="simbol">Simbol.</param>
                  public static void Border(object content, object simbol)
                  {

                        string underLine = "";
                        for (int i = 0; i <= content.ToString().Length + 3; i++)
                        {
                              Color.Yellow();
                              Console.Write(simbol);
                              underLine += simbol;
                        }
                        Console.WriteLine("");// this write an space
                        Console.Write(simbol); // this write a single char
                        Console.ResetColor();    // reset the color 
                        Console.Write(" " + content + " "); // write the content 
                        Color.Yellow(); // get the yellow color again 
                        Console.Write(simbol);
                        Console.WriteLine("");          // more space 
                        Console.WriteLine(underLine);
                  }
                  /// <summary>
                  /// Set the specified color of the content with the textColor and backgroundColor provided 
                  /// </summary>
                  /// <param name="content">Content.</param>
                  /// <param name="textColor">Text color.</param>
                  /// <param name="backgroundColor">Background color.</param>
                  public static void Set(object content, ConsoleColor textColor,ConsoleColor backgroundColor)
                  {
                        Console.BackgroundColor = backgroundColor;
                        Console.ForegroundColor = textColor;
                        Console.WriteLine(content);
                        Console.ResetColor();                        
                  }
                         
                         /// <summary>
                         /// Set the specified content, textColor and backgroundColor with the given input 
                         /// </summary>
                         /// <param name="content">Content.</param>
                         /// <param name="textColor">Text color.</param>
                         /// <param name="backgroundColor">Background color.</param>
                  public static void Set(object content, int textColor, int backgroundColor)
                  {
                        Console.ForegroundColor = (ConsoleColor)textColor;
                        Console.BackgroundColor = (ConsoleColor)backgroundColor;
                        Console.WriteLine(content);                        
                        Console.ResetColor();                        
                  }

            }
      }
