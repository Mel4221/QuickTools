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
     public Color()
            {
                             
            }


            public  Color(string color)
   {
          switch(color.ToLower())
          {
            case "gray":
            Gray();                              
              break ;
                        case "cyan":
                              Cyan();
                              break;
                        case "red":
                              Red();
                              break;
                        case "black":
                              Black();
                              break;
                        case "blue":
                              Blue();
                              break;
                        case "green":
                              Green();
                              break;
                        case "yellow":
                              Yellow();
                              break;
                        case "pink":
                              Pink();
                              break;
                        default:
              Yellow("Incorrect Color Selection , That Color is not implemented yet : "+color); 
              break; 
          }
   }

    // Cyan        
    // Gray
 public static void Gray()
    {
      Console.ForegroundColor = ConsoleColor.Gray;
    }

    public static void Cyan ()
    {
      Console.ForegroundColor = ConsoleColor.Cyan;
    }

    public static void Red ()
    {
      Console.ForegroundColor = ConsoleColor.Red;

    
    }
    
       public static void Black ()
    {
      Console.ForegroundColor = ConsoleColor.Black;

    
    }

    public static void Blue ()
    {
      Console.ForegroundColor = ConsoleColor.Blue;

    }
    public static void Green ()
    {
      Console.ForegroundColor = ConsoleColor.Green;
    }
         
            public static void Yellow ()
    {
      Console.ForegroundColor = ConsoleColor.Yellow;
    }
    public static void Pink ()
    {
      Console.ForegroundColor = ConsoleColor.Magenta;
    }


    /*
       From here on i will add the others that does not require an object to be pass throug
     */
    public static void Back_Yellow ()
    {
      Console.BackgroundColor = ConsoleColor.Yellow;
      Console.ForegroundColor = ConsoleColor.White;

    }

    public static void Back_Red ()
    {
      Console.BackgroundColor = ConsoleColor.Red;
      Console.ForegroundColor = ConsoleColor.White;

    }

    public static void Back_Blue ()
    {
      Console.BackgroundColor = ConsoleColor.Blue;
      Console.ForegroundColor = ConsoleColor.White;

    }

    public static void Back_Pink ()
    {
      Console.BackgroundColor = ConsoleColor.Magenta;
      Console.ForegroundColor = ConsoleColor.White;

    }
    public static void Back_Green ()
    {
      Console.BackgroundColor = ConsoleColor.Green;
      Console.ForegroundColor = ConsoleColor.White;

    }


  }
}
