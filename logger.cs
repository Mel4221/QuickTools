/*
            This class is a very good example that sometimes you don't need a tone of code
            to have funtionality , and it can easily write up to 1G in written logs            
*/
using System;
using System.IO;
namespace QuickTools
{
      public class Log
      {
            private static string CreateLogDir()
            {
                  string logsDir = null;
                  logsDir = Get.DataPath() + "logs/";
                  Directory.CreateDirectory(logsDir); 
                 

                  return logsDir; 
            }
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
