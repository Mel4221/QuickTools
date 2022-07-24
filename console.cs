/*
      missing The Faker logger 
      to make sure that      

*/


using System;
namespace QuickTools
{

      /// <summary>
      /// this was created entrily for fun 
      ///  but it could be usful if you hate to write Consol.WriteLine("content"); 
      /// they are basycally many language added but sadly there are some that only works 
      /// with a costructor example : new echo("content"); 
      /// </summary>

      public class C
      {     
                  public static void Log(object input)
            {
                  Console.WriteLine(input);
            }

            public static void W(object input)
            {
                  Console.Write(input);
            }
            public static void Write(object input)
            {
                  Console.Write(input);
            }
      }
      public class console
      {
            public static void log(object input)
            {
                  Console.WriteLine(input); 
            }
      }
      public class echo
      {
            public echo(object input)
            {
                  Console.WriteLine(input); 
            }

      }
      //c 
      public class printf
      {
            public printf(object input)
            {
                  Console.WriteLine(input);
            }

      }
      //java
      public class System
      {
            public static class Out
            {
                  public static void println(object input)
                  {
                        Console.WriteLine(input);
                  }
            }
      }
      //python && perl && R
      public class print
      {
            public print(object input)
            {
                  Console.WriteLine(input);
            }
      }
      //ruby
      public class puts
      {
            public puts(object input)
            {
                  Console.WriteLine(input);
            }
      }
      //pascal 
      public class writeln
      {
            public writeln(object input)
            {
                  Console.WriteLine(input);
            }
      }

      public class print_string
      {
            public print_string(object input)
            {
                  Console.WriteLine(input);
            }
      }
}
