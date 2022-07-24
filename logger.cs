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
