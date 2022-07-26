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

    
    public static void Gray (object text)
    {
      Console.ForegroundColor = ConsoleColor.Gray;
      Console.WriteLine (text);
      Get.Reset ();
    }
   
    public static void Cyan (object text)
    {
      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.WriteLine (text);
      Get.Reset ();
    }
  
    public static void Red (object text)
    {
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine (text);
      Get.Reset ();
    }
    
    public static void Blue (object text)
    {
      Console.ForegroundColor = ConsoleColor.Blue;
      Console.WriteLine (text);
      Get.Reset ();
    }

   

    public static void Green (object text)
    {
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine (text);
      Get.Reset ();
    }

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
        public static void Black (object msg)
    {
      Console.ForegroundColor = ConsoleColor.Black;
      Console.WriteLine (msg);
      Console.ResetColor ();
    }
    
    

    public static void Yellow (object msg)
    {
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.WriteLine (msg);
      Console.ResetColor ();
    }

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

    
    public static void Pink (object text)
    {
      Console.ForegroundColor = ConsoleColor.Magenta;
      Console.WriteLine (text);
      Get.Reset ();
    }

    public static void Back_Yellow (object text)
    {
      Console.BackgroundColor = ConsoleColor.Yellow;
      Console.ForegroundColor = ConsoleColor.White;
      Console.WriteLine (text);
      Get.Reset ();
    }

    public static void Back_Red (object text)
    {
      Console.BackgroundColor = ConsoleColor.Red;
      Console.ForegroundColor = ConsoleColor.White;
      Console.WriteLine (text);
      Get.Reset ();
    }

    public static void Back_Blue (object text)
    {
      Console.BackgroundColor = ConsoleColor.Blue;
      Console.ForegroundColor = ConsoleColor.White;
      Console.WriteLine (text);
      Get.Reset ();
    }

    public static void Back_Pink (object text)
    {
      Console.BackgroundColor = ConsoleColor.Magenta;
      Console.ForegroundColor = ConsoleColor.White;
      Console.WriteLine (text);
      Get.Reset ();
    }

    public static void Back_Green (object text)
    {
      Console.BackgroundColor = ConsoleColor.Green;
      Console.ForegroundColor = ConsoleColor.White;
      Console.WriteLine (text);
      Get.Reset ();
    }


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
