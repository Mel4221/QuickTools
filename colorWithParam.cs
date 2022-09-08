using System;
namespace QuickTools
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
    public static void Gray (object text)
    {
      Console.ForegroundColor = ConsoleColor.Gray;
      Console.WriteLine (text);
      Get.Reset ();
    }
   /// <summary>
   /// <seealso cref="Gray(object)"/>
   /// </summary>
   /// <param name="text">Text.</param>
    public static void Cyan (object text)
    {
      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.WriteLine (text);
      Get.Reset ();
    }
            /// <summary>
            /// <seealso cref="Gray(object)"/>
            /// </summary>
            /// <param name="text">Text.</param>
            public static void Red (object text)
    {
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine (text);
      Get.Reset ();
    }
    /// <summary>
    /// Blue the specified text.
    /// </summary>
    /// <param name="text">Text.</param>
    public static void Blue (object text)
    {
      Console.ForegroundColor = ConsoleColor.Blue;
      Console.WriteLine (text);
      Get.Reset ();
    }

   /// <summary>
   /// Green the specified text.
   /// </summary>
   /// <param name="text">Text.</param>

    public static void Green (object text)
    {
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine (text);
      Get.Reset ();
    }
                   /// <summary>
                   /// Green the specified text and tabs.
                   /// </summary>
                   /// <param name="text">Text.</param>
                   /// <param name="tabs">Tabs.</param>
    public static void Green (object text, int tabs)
    {
      Console.ForegroundColor = ConsoleColor.Green;
      string spaces = "\t";
      string tabSpaces = "";
      for (int i = 0; i <= tabs; i++)
	{
	  tabSpaces += spaces;
	}

      Console.WriteLine (tabSpaces + text);
      Get.Reset ();
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

      Console.WriteLine (tabSpaces + text);
      Get.Reset ();
    }
              /// <summary>
              /// Black the specified msg.
              /// </summary>
              /// <param name="msg">Message.</param>
        public static void Black (object msg)
    {
      Console.ForegroundColor = ConsoleColor.Black;
      Console.WriteLine (msg);
      Console.ResetColor ();
    }
    
    
            /// <summary>
            /// Yellow the specified msg.
            /// </summary>
            /// <param name="msg">Message.</param>
    public static void Yellow (object msg)
    {
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.WriteLine (msg);
      Console.ResetColor ();
    }
            /// <summary>
            /// Yellow the specified text and tabs.
            /// </summary>
            /// <param name="text">Text.</param>
            /// <param name="tabs">Tabs.</param>
    public static void Yellow (object text, int tabs)
    {
      Console.ForegroundColor = ConsoleColor.Yellow;
      string spaces = "\t";
      string tabSpaces = "";
      for (int i = 0; i <= tabs; i++)
	{
	  tabSpaces += spaces;
	}

      Console.WriteLine (tabSpaces + text);
      Get.Reset ();
    }

    /// <summary>
    /// Pink the specified text.
    /// </summary>
    /// <param name="text">Text.</param>
    public static void Pink (object text)
    {
      Console.ForegroundColor = ConsoleColor.Magenta;
      Console.WriteLine (text);
      Get.Reset ();
    }
            /// <summary>
            /// Backs the yellow.
            /// </summary>
            /// <param name="text">Text.</param>
    public static void Back_Yellow (object text)
    {
      Console.BackgroundColor = ConsoleColor.Yellow;
      Console.ForegroundColor = ConsoleColor.White;
      Console.WriteLine (text);
      Get.Reset ();
    }
            /// <summary>
            /// Backs the red.
            /// </summary>
            /// <param name="text">Text.</param>
    public static void Back_Red (object text)
    {
      Console.BackgroundColor = ConsoleColor.Red;
      Console.ForegroundColor = ConsoleColor.White;
      Console.WriteLine (text);
      Get.Reset ();
    }
            /// <summary>
            /// Backs the blue.
            /// </summary>
            /// <param name="text">Text.</param>
    public static void Back_Blue (object text)
    {
      Console.BackgroundColor = ConsoleColor.Blue;
      Console.ForegroundColor = ConsoleColor.White;
      Console.WriteLine (text);
      Get.Reset ();
    }
            /// <summary>
            /// Backs the pink.
            /// </summary>
            /// <param name="text">Text.</param>
    public static void Back_Pink (object text)
    {
      Console.BackgroundColor = ConsoleColor.Magenta;
      Console.ForegroundColor = ConsoleColor.White;
      Console.WriteLine (text);
      Get.Reset ();
    }
            /// <summary>
            /// Backs the green.
            /// </summary>
            /// <param name="text">Text.</param>
    public static void Back_Green (object text)
    {
      Console.BackgroundColor = ConsoleColor.Green;
      Console.ForegroundColor = ConsoleColor.White;
      Console.WriteLine (text);
      Get.Reset ();
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
                        C.Write(simbol);
                        underLine += simbol;
                  }

                  Get.W("");// this write an space
                  C.Write(simbol); // this write a single char
                  Get.Reset();    // reset the color 
                  C.Write(" " + content + " "); // write the content 
                  Color.Yellow(); // get the yellow color again 
                  C.Write(simbol);
                  Get.W("");          // more space 
                  Get.W(underLine);
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
                        C.Write(simbol);
                        underLine += simbol;
                  }
                  Get.W("");// this write an space
                  C.Write(simbol); // this write a single char
                  Get.Reset();    // reset the color 
                  C.Write(" " + content + " "); // write the content 
                  Color.Yellow(); // get the yellow color again 
                  C.Write(simbol);
                  Get.W("");          // more space 
                  Get.W(underLine);
            }
      }
}
