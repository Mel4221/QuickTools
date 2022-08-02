using System;
namespace QuickTools
{
      /// <summary>
      /// Color Class that contains an array of methods to give color to the console
      /// and they can be used like this Color.Red(object); 
      /// or just by initializing it  example : new Color("red"); .
      /// </summary>
      public partial class Color
      {

            /*
               /////////////////////////////////////////////////////////////////////////////
               //////////// THIS AREA CONTROLS CONSOLE COLOR AND STYLE /////////////////////
               /////////////////////////////////////////////////////////////////////////////
             */
             /// <summary>
             /// Initializes a new instance of the <see cref="T:QuickTools.Color"/> class.
             /// No Funtionalite are added to the Constructor without any parameters
             /// </summary>
             public Color()
            {
                  //i will leave it like that just in case                  
                 // throw new NotSupportedException(); 
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="T:QuickTools.Color"/> class.
            /// This contructor allows you to give the color whitout having to write more code
            /// by just calling new Color("colorName");  then the fallowing code will be 
            /// the one passed through it.
            /// </summary>
            /// <param name="color">Color.</param>
            public Color(string color)
            {
                  switch (color.ToLower())
                  {
                        case "gray":
                              Gray();
                              break;
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
                              Yellow("Incorrect Color Selection , That Color is not implemented yet : " + color);
                              break;
                  }
            }
            ///<summary>
            /// This constructor allows you to pass contect when is initialize and give the color that
            /// is passed  to it 
            /// 
            /// </summary>  
            /// <param name="color">Color</param> <param name="content">Text or object</param>         
            public Color(string color, object content)
            {
                  switch (color.ToLower())
                  {
                        case "gray":
                              Gray();
                              break;
                        case "cyan":
                              Cyan(content);
                              break;
                        case "red":
                              Red(content);
                              break;
                        case "black":
                              Black(content);
                              break;
                        case "blue":
                              Blue(content);
                              break;
                        case "green":
                              Green(content);
                              break;
                        case "yellow":
                              Yellow(content);
                              break;
                        case "pink":
                              Pink(content);
                              break;
                        default:
                              Yellow("Incorrect Color Selection , That Color is not implemented yet : " + color);
                              break;
                  }
            }



            // Cyan        
            // Gray
            ///<summary>
            /// This Method color the entired text gray 
            /// </summary>   
            public static void Gray()
            {
                  Console.ForegroundColor = ConsoleColor.Gray;
            }

            ///<summary>
            /// This Method color the entired text Cyan 
            /// </summary>   
            public static void Cyan()
            {
                  Console.ForegroundColor = ConsoleColor.Cyan;
            }

            ///<summary>
            /// This Method color the entired text Red 
            /// </summary>              
            public static void Red()
            {
                  Console.ForegroundColor = ConsoleColor.Red;


            }

            ///<summary>
            /// This Method color the entired text Black 
            /// </summary>              
            public static void Black()
            {
                  Console.ForegroundColor = ConsoleColor.Black;


            }
            ///<summary>
            /// This Method color the entired text Blue 
            /// </summary>   
            public static void Blue()
            {
                  Console.ForegroundColor = ConsoleColor.Blue;

            }
            ///<summary>
            /// This Method color the entired text Green 
            /// </summary>              
            public static void Green()
            {
                  Console.ForegroundColor = ConsoleColor.Green;
            }
            ///<summary>
            /// This Method color the entired text Yellow 
            /// </summary>   
            public static void Yellow()
            {
                  Console.ForegroundColor = ConsoleColor.Yellow;
            }
            ///<summary>
            /// This Method color the entired text Magenta or what i call pink 
            /// </summary>              
            public static void Pink()
            {
                  Console.ForegroundColor = ConsoleColor.Magenta;
            }


            /*
               From here on i will add the others that does not require an object to be pass throug
             */
            ///<summary>
            /// Color the background of the Yellow Color
            /// </summary>   
            public static void Back_Yellow()
            {
                  Console.BackgroundColor = ConsoleColor.Yellow;
                  Console.ForegroundColor = ConsoleColor.White;

            }
            ///<summary>
            /// Color the background of the Yellow Red
            /// </summary> 
            public static void Back_Red()
            {
                  Console.BackgroundColor = ConsoleColor.Red;
                  Console.ForegroundColor = ConsoleColor.White;

            }
            ///<summary>
            /// Color the background of the Yellow Blue
            /// </summary> 
            public static void Back_Blue()
            {
                  Console.BackgroundColor = ConsoleColor.Blue;
                  Console.ForegroundColor = ConsoleColor.White;

            }
            ///<summary>
            /// Color the background of the Yellow Pink or Magenta
            /// </summary> 
            public static void Back_Pink()
            {
                  Console.BackgroundColor = ConsoleColor.Magenta;
                  Console.ForegroundColor = ConsoleColor.White;

            }
            ///<summary>
            /// Color the background of the Yellow Green
            /// </summary> 
            public static void Back_Green()
            {
                  Console.BackgroundColor = ConsoleColor.Green;
                  Console.ForegroundColor = ConsoleColor.White;

            }


      }
}
