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
                  logsDir = Get.Path + "data/qt/logs/";
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
                  string time = $"|*** Date Of The Event :{DateTime.Now} ***|\n\n\n";




                  string path = CreateLogDir();
                  string file = path + name+"log"; 

                  if(File.Exists(file) == false)
                  {
                        Writer.Write(file, time+matter);
                        return;
                  }
                  else
                  {
                        // get the text from the file
                        string previusContent = Reader.Read(file);
                        // write the old text first then the new text 
                        string newContent = time+matter + previusContent;
                        Writer.Write(file,newContent);
                  }


            }
      }
}
