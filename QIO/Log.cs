using System;
using System.IO;
using QuickTools.QIO;
using QuickTools.QCore;
using QuickTools.QColors;
using QuickTools.QData;
using QuickTools.QNet;
using QuickTools.QSecurity;
using QuickTools.QConsole;
namespace QuickTools.QIO
{
    /// <summary>
    /// This class create a quick way of writting logs inside QuickTools
    /// </summary>
    public class Log
    {


        private static string CreateLogDir()
        {
            string logsDir = null;
            logsDir = Get.DataPath("logs");
            return logsDir;
        }


        /// <summary>
        /// Delete's all the logs 
        /// </summary>
        public static void ClearLogs()
        {
            string path = CreateLogDir();
            string[] logs = new FilesMaper().GetFiles(path);
            foreach (string log in logs)
            {
                if (File.Exists(log))
                {
                    File.Delete(log);
                }
            }
        }
        /// <summary>
        /// Create a file tha will containe the event of the specified name and matter.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="matter">Matter.</param>
        public static void Event(string name, object matter)
        {



            string path = CreateLogDir();
            string file = path + name + ".xml";
            using (MiniDB db = new MiniDB(file))
            {
                if (!File.Exists(file))
                {
                    db.Create();
                }
                db.Load();


                db.AddKey("log", matter, DateTime.Now);



            }


            /* not working properly 
              using (FileStream stream = new FileStream(file, FileMode.Append,FileAccess.Write))
              {
                    byte[] bytes = System.Text.Encoding.ASCII.GetBytes(message);
                    using (BinaryWriter writer = new BinaryWriter(stream))
                    {
                          writer.Write(bytes, 0, bytes.Length); 
                    }
              }
              */


        }

        /// <summary>
        /// Log Text the specified matter on the file .
        /// </summary>
        /// <param name="nameOfThefile">Name of thefile.</param>
        /// <param name="matter">Matter.</param>
        public static void Text(string nameOfThefile, object matter)
        {
            // string time = $"|*** Date Of The Event :{DateTime.Now} ***|\n\n\n";




            string path = CreateLogDir();
            string file = path + nameOfThefile + ".log";

            using (FileStream stream = new FileStream(file, FileMode.Append, FileAccess.Write))
            {
                byte[] bytes = System.Text.Encoding.ASCII.GetBytes(matter.ToString());
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    writer.Write(bytes, 0, bytes.Length);
                }
            }

        }
        /// <summary>
        /// Logs the given message to the given file 
        /// </summary>
        /// <param name="logFile">Log file.</param>
        /// <param name="message">Message.</param>
        public static void Message(string logFile, string message) => Event(logFile, message);
    }
}