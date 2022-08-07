/*
            This class is a very good example that sometimes you don't need a tone of code
            to have funtionality , and it can easily write up to 1G in written logs            
*/
using System;
using System.IO;
namespace QuickTools
{
      /// <summary>
      /// This class create a quick way of writting logs inside QuickTools
      /// </summary>
      public class Log
      {
            private static string CreateLogDir()
            {
                  string logsDir = null;
                  logsDir = Get.DataPath() + "logs/";
                  Directory.CreateDirectory(logsDir); 
                 

                  return logsDir; 
            }
            /// <summary>
            /// Create a file tha will containe the event of the specified name and matter.
            /// </summary>
            /// <param name="name">Name.</param>
            /// <param name="matter">Matter.</param>
            public static void Event(string name ,object matter)
            {
                  string logsDir = Get.DataPath() + "logs/"; 
                     if (Directory.Exists(logsDir) == true)
                  {
                        string file = logsDir + name; 
                        using (var fs = File.AppendText(file))
                        {
                              fs.WriteLine(matter);
                        }

                  }
                  else
                  {
                        // string file = CreateLogDir() + name;
                        string file = logsDir + name;

                        using (var fs = File.AppendText(file))
                        {


                                    fs.WriteLine(matter);

                        }
                  }

            }
      }
}
