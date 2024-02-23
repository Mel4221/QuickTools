/*

    ///////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////
    /////////////////*this is were the Class Get Starts *//////
    ///////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////

﻿/*
This Contains all the shortcuts for the Alerts
and events of colors for the display of the 
text. 
important Date : today i have change the class name from "Do static class"
to "Get static class" due to some not sence ideas behing the idea of doing stuff
it is nothing related with the performance but more with relation with the 
action that it creates DATE OF UPDATE : 03/11/2022
*/
using System;
//using System.Security;            // has to be implemented 
using System.Threading;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using QuickTools.QIO;
using QuickTools.QColors;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Collections;
using QuickTools.QConsole;

//using System.Security.Permissions;// it has to be implemented

namespace QuickTools.QCore
{



    ///////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////
    /////////////////*this is were the Class Get Starts *//////
    ///////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////

    /// <summary>
    /// Get The bigest class In Quicktools
    /// does multiple stuff and contains must of the 
    /// tools that started this Project.
    /// </summary>
    public partial class Get : Color
    {


        /// <summary>
        /// Prints the text on multi colors as Red,Green,Blue,Cyan,Pink,Yellow,Gray 
        /// acording to the numbers from 0 to 6
        /// </summary>
        /// <param name="text">Text.</param>
        public static void PrintMultiColors(string text)
        {
            int color = 0; 
            foreach (char t in text)
            {
                switch (color)
                {
                    case 0:
                        Color.Red();
                        Get.Write(t);
                        color = 1;
                        break;
                    case 1:
                        Color.Green();
                        Get.Write(t);
                        color = 2;
                        break;
                    case 2:
                        Color.Blue();
                        Get.Write(t);
                        color = 3;
                        break;
                    case 3:
                        Color.Cyan();
                        Get.Write(t);
                        color = 4;
                        break;
                    case 4:
                        Color.Pink();
                        Get.Write(t);
                        color = 5;
                        break;
                    case 5:
                        Color.Yellow();
                        Get.Write(t);
                        color = 6;
                        break;
                    case 6:
                        Color.Gray();
                        Get.Write(t);
                        color = 0;
                        break;
                }
            }
        }


        /// <summary>
        /// Prints the text using the 3 colors of the RGB  
        /// Depending on the 
        /// so if CurrentColorSelection is from 0 to 2 it will 
        /// set the color as such 0 = Red 1 = Green  2 Blue
        /// </summary>
        /// <param name="text">Text.</param>
        public static void PrintRGB(string text)
        {
            int color = 0;
            foreach (char t in text)
            {
                switch (color)
                {
                    case 0:
                        Get.Red();
                        Get.Write(t);
                        color = 1;
                        break;
                    case 1:
                        Get.Green();
                        Get.Write(t);
                        color = 2;
                        break;
                    case 2:
                        Get.Blue();
                        Get.Write(t);
                        color = 0;
                        break;
                  
                }
            }

        }

        /// <summary>
        /// Gets estimated time on compleation 
        /// Based on a solution from StackOverflow Entirely
        /// http://stackoverflow.com/questions/473355/calculate-time-remaining/473369#473369
        /// </summary>
        /// <param name="sw"></param>
        /// <param name="counter"></param>
        /// <param name="counterGoal"></param>
        /// <returns></returns>
        public static TimeSpan ETA(Stopwatch sw, long counter, long counterGoal)
        {
            /* Copied Direcly from StackOverflow
             * 
             * this is based off of:
             * (TimeTaken / linesProcessed) * linesLeft=timeLeft
             * so we have
             * (10/100) * 200 = 20 Seconds now 10 seconds go past
             * (20/100) * 200 = 40 Seconds left now 10 more seconds and we process 100 more lines
             * (30/200) * 100 = 15 Seconds and now we all see why the copy file dialog jumps from 3 hours to 30 minutes :-)
             * 
             * pulled from http://stackoverflow.com/questions/473355/calculate-time-remaining/473369#473369
             */
            if (counter == 0) return TimeSpan.Zero;
            float elapsedMin = ((float)sw.ElapsedMilliseconds / 1000) / 60;
            float minLeft = (elapsedMin / counter) * (counterGoal - counter); //see comment a
            TimeSpan ret = TimeSpan.FromMinutes(minLeft);
            return ret;
        }


        /// <summary>
        /// Open a file 
        /// </summary>
        /// <param name="file"></param>
        public static void Open(string file)
        {
            ProcessStartInfo info = new ProcessStartInfo()
            {
                FileName = file
            };
            Process.Start(info);
        }

        /// <summary>
        /// Open a file with the given arguments
        /// </summary>
        /// <param name="file"></param>
        /// <param name="arguments"></param>
        public static void Open(string file, string arguments)
        {

            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = file;
            info.Arguments = arguments;
            Process.Start(info);
        }

        /// <summary>
        /// Open a file
        /// </summary>
        /// <param name="file"></param>
        /// <param name="arguments"></param>
        /// <param name="waitForExit"></param>
        public static void Open(string file, string arguments, bool waitForExit)
        {
            if (arguments == "" || arguments == " ") arguments = null;
            ProcessStartInfo info = new ProcessStartInfo();
            Process process = new Process();
            info.FileName = file;
            info.Arguments = arguments;
            process.StartInfo = info;

            process.Start();

            if (waitForExit)
            {
                process.WaitForExit();
            }

        }

        /// <summary>
        /// Returns an array of the given input
        /// </summary>
        /// <param name="label"></param>
        /// <returns></returns>
        public static string[] LoopInput(string label)
        {
            string line = null;
            List<string> text = new List<string>();
            while (true)
            {
                line = Get.Input(label).Text;
                if (line != "")
                {
                    text.Add(line);
                }
                if (line == "")
                {
                    break;
                }
            }
            if (text.Count > 0)
            {
                return IConvert.ToType<string>.ToArray(text);
            }
            else
            {
                return null;
            }

        }
        /// <summary>
        /// Gets a value printed with it's key 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void Print(object key, object value)
        {
            Get.WriteL("");
            Get.Green();
            Get.Write($" {key} ");
            Get.Reset();
            Get.Write("=");
            Get.Yellow();
            Get.Write($" {value} ");
            Get.WriteL("");
        }

        /// <summary>
        /// Print the specified key,  and value with a separator
        /// </summary>
        /// <param name="key">Key.</param>
        /// <param name="separator">Separator.</param>
        /// <param name="value">Value.</param>
        public static void Print(object key,object separator,object value)
        {
            Get.WriteL("");
            Get.Green();
            Get.Write($" {key} ");
            Get.Reset();
            Get.Write(separator);
            Get.Yellow();
            Get.Write($" {value} ");
            Get.WriteL("");
        }


        /// <summary>
        /// Prints the system variables given to it 
        /// </summary>
        /// <param name="variables"></param>
        public static void PrintSystemVars(IDictionary variables)
        {
            foreach (DictionaryEntry item in variables)
            {
                Print(item.Key, item.Value);
            }
        }

        /// <summary>
        /// Prints the system variables given to it and save them on a given file
        /// </summary>
        /// <param name="variables"></param>
        /// <param name="fileToSaveThem"></param>
        public static void PrintSystemVars(IDictionary variables, string fileToSaveThem)
        {
            string SystemInfo = null;
            foreach (DictionaryEntry item in variables)
            {
                Print(item.Key, item.Value);
                SystemInfo += $"{item.Key} = {item.Value}\n\n";

            }
            if (fileToSaveThem == "" || fileToSaveThem == null)
            {
                fileToSaveThem = $"{Get.Path}SystemInfo.txt";
            }
            Writer.Write(fileToSaveThem, SystemInfo);

        }


        /*
                 string SystemInfo = null;
            SystemInfo += $"{item.Key} = {item.Value}\n\n";
            // Get.Green($"Variable: {v.Keys} Value: {v.Values}");
            Writer.Write($"{Get.Path}SystemInfo.txt", SystemInfo);
         */


        /// <summary>
        /// Very Slow method that only allows chars  to be print
        /// </summary>
        /// <returns>The chars.</returns>
        /// <param name="word">Word.</param>
        public static string FilterOnlyChars(string word)
        {
            string str = null;
            for (int ch = 0; ch < word.Length; ch++)
            {
                foreach (var w in IRandom.LowerCase)
                {
                    if (w == word[ch])
                    {
                        str += word[ch];
                        break;
                    }
                }
                foreach (var w in IRandom.UpperCase)
                {
                    if (w == word[ch])
                    {
                        str += word[ch];
                        break;
                    }
                }
                foreach (var w in IRandom.Symbols)
                {
                    if (w == word[ch])
                    {
                        str += word[ch];
                        break;
                    }
                }
                foreach (var w in IRandom.Numbers)
                {
                    if (w == word[ch])
                    {
                        str += word[ch];
                        break;
                    }
                }
            }
            return str;
        }



        /// <summary>
        /// Breaks any given loop by throwing an exception that if is not handled could throw an exception saying that the task failed sucessfully LOL
        /// <see cref="System.Exception()"/>
        /// </summary>
        public static void Break()
        {
            throw new Exception("Task Completed");
        }

        /// <summary>
        /// Breaks any given loop by throwing an exception that if is not handled could throw an exception saying that the task failed sucessfully LOL
        /// <see cref="System.Exception()"/>
        /// </summary>
        /// <param name="message">Message.</param>
        public static void Break(object message)
        {
            throw new Exception(message.ToString());
        }
        /// <summary>
        /// Loop the specified actionMethod forever or until an exception happens usually 
        /// could be also ended when forced by <see cref="Get.Break()"/>
        /// </summary>
        /// <param name="actionMethod">Action method.</param>
        public static void Loop(Action actionMethod)
        {

            while (true)
            {
                actionMethod();
            }
        }




        /// <summary>
        /// Get the porcenrage status of the provided current time and goal 
        /// </summary>
        /// <returns>The status.</returns>
        /// <param name="current">Current.</param>
        /// <param name="goal">Goal.</param>
        public static string Status(object current, object goal)
        {
            string status = null;
            double c = Convert.ToDouble(current);
            double g = Convert.ToDouble(goal);
            double s = Math.Round(c / g, 2) * 100;
            status = $"{s}%";
            return status;

        }

        /// <summary>
        /// Get the porcenrage status of the provided current time and goal 
        /// </summary>
        /// <param name="current"></param>
        /// <param name="goal"></param>
        /// <returns></returns>
        public static double StatusNumber(object current, object goal)
        {
            double c = Convert.ToDouble(current);
            double g = Convert.ToDouble(goal);
            double s = Math.Round(c / g, 2) * 100;

            return s;

        }
        /*
         Console.BufferHeight
         Console.BufferWidth                 
        */

        /// <summary>
        /// Returns a line divition using the Enviroment.NewLine command. 
        /// </summary>
        /// <returns>The corresponding line for the console</returns>
        static string Line()
        {
            return Environment.NewLine;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:QuickTools.QCore.Get"/> allow debugger.
        /// </summary>
        /// <value><c>true</c> if allow debugger; otherwise, <c>false</c>.</value>
        public static bool AllowDebugger { get; set; } = false;

        /// <summary>
        /// Gets or sets the current status.
        /// </summary>
        /// <value>The current status.</value>
        public static string CurrentStatus { get; set; } = "Nothing-Started"; 


        /// <summary>
        /// Hashs the code from file.
        /// </summary>
        /// <returns>The code from file.</returns>
        /// <param name="fileName">File name.</param>
        /// <param name="allowDebugger">If set to <c>true</c> allow debugger.</param>
        public double HashCodeFromFile(string fileName,bool allowDebugger)
        {
            if (fileName == null || fileName == "") throw new ArgumentException("No File Name provided");
            if (!File.Exists(fileName)) throw new FileNotFoundException($"The File could not be found: {fileName}");
            double hash = 0;


            using (FileStream streamOpen = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {

                BinaryReader binaryReader = new BinaryReader(streamOpen);
                Stopwatch sw = new Stopwatch();
                Check check = new Check();
                QProgressBar bar = new QProgressBar();
                TimeSpan time;
                check.Start();
                // this.ChuckSize = this.ChuckSize > streamOpen.Length ? int.Parse(streamOpen.Length.ToString()) : this.ChuckSize;
                sw.Start();
                long current, goal;
                int chunck;
                string status, eta;
                byte[] buffer;
                goal = streamOpen.Length;
                current = 0;
                chunck = 1024 * 1024 * 64;
                if (chunck > streamOpen.Length)
                {
                    chunck = int.Parse(streamOpen.Length.ToString());
                }
               // Get.Wait(CurrentStatus ,() => { 
                while (current < goal)
                {

                    time = Get.ETA(sw, current, goal - 1);
                    eta = time.Hours == 0 ? "" : $"{time.Hours}h ";
                    eta += time.Minutes == 0 ? "" : $"{time.Minutes}m";
                    eta += time.Seconds == 0 ? "" : $" {time.Seconds}s";
                    status = $"Reading... {fileName.Substring(fileName.LastIndexOf(Get.Slash()))} [{Get.FileSize(current)} / {Get.FileSize(goal)}]  Status: [{Get.Status(current, goal + 2)}] ETA: [{eta}] Hash: [{hash}]";
                    CurrentStatus = status;

                    if (allowDebugger == true)
                    {

                        bar.Label = status;
                        //bar.Clear();
                        bar.Display(Get.Status(current, goal ));
                        //bar.Display(int.Parse(current.ToString()), int.Parse(goal.ToString()));
                        //Get.Green(status);
                    }

                    streamOpen.Seek(current, SeekOrigin.Begin);

                    buffer = new byte[chunck];
                    binaryReader.Read(buffer, 0, buffer.Length);


                    // streamWrite.Seek(current, SeekOrigin.Begin);
                    //binaryWriter = new BinaryWriter(streamWrite);
                    //binaryWriter.Write(this.Buffer, 0, this.Buffer.Length);
                    hash += Get.HashCode(buffer);
                    current += chunck;
                    // Get.Yellow(current); 


                }
               // });
                /*
                status = $"Done!!! {target}";
                if (this.AllowDebugger)
                {
                    Get.Print($"{source}", "->", $"{target}");
                    Get.Green($"Done!!!");
                    Get.Yellow($"Transfer Time: {check.Stop()}");
                    if (WaitToAcknolegeTransfer)
                    {
                        Get.Wait();
                    }
                }
                */
            }




            return hash;
        }

        /// <summary>
        /// Gets a hash code from a file no matter the size
        /// </summary>
        /// <returns>The code from file.</returns>
        /// <param name="fileName">File name.</param>
        public static double HashCodeFromFile(string fileName)
        {
            if (fileName == null || fileName == "") throw new ArgumentException("No File Name provided");
            if (!File.Exists(fileName)) throw new FileNotFoundException($"The File could not be found: {fileName}");
            double hash = 0;


            using (FileStream streamOpen = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {

                    BinaryReader binaryReader = new BinaryReader(streamOpen);
                    Stopwatch sw = new Stopwatch();
                    Check check = new Check();
                    QProgressBar bar = new QProgressBar();
                    TimeSpan time;
                    check.Start();
                   // this.ChuckSize = this.ChuckSize > streamOpen.Length ? int.Parse(streamOpen.Length.ToString()) : this.ChuckSize;
                    sw.Start();
                    long current, goal;
                    int chunck; 
                    string status, eta;
                    byte[] buffer;
                    goal = streamOpen.Length;
                    current = 0;
                    chunck = 1024 * 1024 * 64; 
                    if(chunck > streamOpen.Length)
                    {
                        chunck = int.Parse(streamOpen.Length.ToString());
                    }
                    while (current < goal)
                    {

                        time = Get.ETA(sw, current, goal - 1);
                        eta = time.Hours == 0 ? "" : $"{time.Hours}h ";
                        eta += time.Minutes == 0 ? "" : $"{time.Minutes}m";
                        eta += time.Seconds == 0 ? "" : $" {time.Seconds}s";
                        status = $"Reading... {fileName} [{Get.FileSize(current)} / {Get.FileSize(goal)}]  Status: [{Get.Status(current, goal+2)}] ChuckSize: [{Get.FileSize(chunck)}] ETA: [{eta}] Computing Hash: [{hash}]";
                        CurrentStatus = status;
                        /*
                        if (AllowDebugger == true)
                        {

                            bar.Label = status;
                            bar.Display(Get.Status(current, goal+2 ));
                            
                        //Get.Green(status);
                        }
                        */

                        streamOpen.Seek(current, SeekOrigin.Begin);

                        buffer  = new byte[chunck];
                        binaryReader.Read(buffer, 0, buffer.Length);


                        // streamWrite.Seek(current, SeekOrigin.Begin);
                        //binaryWriter = new BinaryWriter(streamWrite);
                        //binaryWriter.Write(this.Buffer, 0, this.Buffer.Length);
                         hash += Get.HashCode(buffer);  
                         current += chunck;
                        // Get.Yellow(current); 


                    }
                    /*
                    status = $"Done!!! {target}";
                    if (this.AllowDebugger)
                    {
                        Get.Print($"{source}", "->", $"{target}");
                        Get.Green($"Done!!!");
                        Get.Yellow($"Transfer Time: {check.Stop()}");
                        if (WaitToAcknolegeTransfer)
                        {
                            Get.Wait();
                        }
                    }
                    */
                }




            return hash;
        }


        /*
        public static double HashCodeFromFile(string fileName, bool smallFiles)
        {
            return  HashCodeFromFile(fileName); 
            /*
                        if (fileName == null || fileName == "") throw new ArgumentException("No File Name provided");
            if (!File.Exists(fileName)) throw new FileNotFoundException($"The File could not be found: {fileName}");
            if (int.Parse(Get.FileSize(fileName, SizeType.IntConvertible)) >= int.MaxValue)
            {
                FileStream stream = new FileStream(fileName, FileMode.Open);
                BinaryReader binary = new BinaryReader(stream);
                byte[] bytes = new byte[102400];
                for (int b = 0; b < 102400; b++)
                {
                    bytes[b] = binary.ReadByte();
                }
                return long.Parse(Get.HashCode(bytes).ToString());
            }
            return long.Parse(Get.HashCode(Binary.Reader(fileName)).ToString());


        }
        */


        /// <summary>
        /// This Creates a hash code based on the given input 
        /// be carefull using this as a security method since 
        /// this macanisim is too simple and it could be broken easely
        /// The method is taking X and the seed and multiplying it by each
        /// byte of the array like on the fallowing way X += seed * bytes[i] + item
        /// </summary>
        /// <returns>The code.</returns>
        /// <param name="bytes">Bytes.</param>
        public static double HashCode(byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0) throw new ArgumentNullException("The Given Bytes was not a valid Bytes array");

            double x = 0;
            double seed = 7;

            for (int item = 0; item < bytes.Length; item++)
            {
                x += ((seed * bytes[item]) + item);
            }
            return x;

        }


        /// <summary>
        /// Hashs the code256.
        /// </summary>
        /// <returns>The code256.</returns>
        /// <param name="bytes">Bytes.</param>
        public static string HashCode256(byte[] bytes)
        {
            string strHash = null;
            using (SHA256 sha = SHA256.Create())
            {
                byte[] hash = sha.ComputeHash(bytes);
                foreach (var ch in hash)
                {
                    strHash += ch;
                }
            }
            return strHash;
        }

        /// <summary>
        /// Hashs the code256.
        /// </summary>
        /// <returns>The code256.</returns>
        /// <param name="content">Content.</param>
        public static string HashCode256(object content)
        {
            string strHash = null;
            byte[] bytes = IConvert.ToASCII(content);
            using (SHA256 sha = SHA256.Create())
            {
                byte[] hash = sha.ComputeHash(bytes);
                foreach (var ch in hash)
                {
                    strHash += ch;
                }
            }
            return strHash;
        }
        /// <summary>
        /// This has the same level of security of <see cref="QuickTools.QCore.Get.HashCode(string)"/>
        /// which measn that is not secure enough so if you need encription
        /// please refer to <see cref="QuickTools.QSecurity.Secure"/>
        /// </summary>
        /// <param name="text"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static double HashCode(string text, int length)
        {

            if (text == null || text.Length == 0) throw new ArgumentNullException("The Given text was not valid");
            if (length == 0) length = text.Length;
            //if (length )
            //System.Text.UnicodeEncoding.ASCII.GetBytes(text)
            byte[] bytes = new byte[length];
            byte[] str = System.Text.Encoding.ASCII.GetBytes(text); ;
            double x = 0;
            double seed = 7;
            int max = str.Length;
            int indexer = 0;
            //filling
            for (int f = 0; f <bytes.Length; f++)
            {
                if (indexer == max)
                {
                    indexer = 0;
                }
                bytes[f] = str[indexer];
                indexer++;
            }

            //creating hash
            for (int item = 0; item < bytes.Length; item++)
            {
                x += ((seed * bytes[item]) + item);
            }
            return x;
        }
        /// <summary>   
        /// This Creates a hash code based on the given input 
        /// be carefull using this as a security method since 
        /// this macanisim is too simple and it could be broken easely
        /// </summary>
        /// <returns>The code.</returns>
        /// <param name="text">Text.</param>
        public static double HashCode(string text)
        {
            if (text == null || text.Length == 0) throw new ArgumentNullException("The Given text was not valid");

           return HashCode(System.Text.Encoding.ASCII.GetBytes(text));
        }

        /// <summary>
        /// WaitTime basically is an abstraction of 
        /// System.Threading.Sleep(<paramref name="milliSecondsOrseconds"/>);
        /// and it basically wait the time in it , it also 
        /// contains a try catch just in case if something fails
        /// </summary>
        /// <param name="milliSecondsOrseconds">Sleep time.</param>
        public static void WaitTime(int milliSecondsOrseconds)
        {



            try
            {

                Thread.Sleep(milliSecondsOrseconds);

            }
            catch (Exception e)
            {
                Get.Wrong(e);
            }

        }

        /// <summary>
        /// Does the same than the waittime with no param 
        /// but this only wait or sleep 1000 milliseconds 
        /// </summary>
        public static void WaitTime()
        {

            try
            {
                Thread.Sleep(1000);

            }
            catch (Exception e)
            {
                Get.Wrong(e);
            }


        }

        /// <summary>
        /// This does the same thing than WaitTime with param but it actually
        /// has a different name 
        /// </summary>
        /// <param name="sleepTime">Sleep time.</param>
        public static void _(int sleepTime)
        {

            try
            {
                Thread.Sleep(sleepTime);
            }
            catch (Exception e)
            {
                Get.Wrong(e);
            }
        }


        /// <summary>
        /// This method Returns the current path from the application
        /// </summary>
        /// <returns>Returns the current path</returns>
        public static string CurrentPath()
        {
            return Path;
        }

        /// <summary>
        /// Abstraction for Directory.GetCurrentDirectory(); 
        /// returns the current string path 
        /// </summary>
        public static string Path = Environment.CurrentDirectory +Slash();
        /// <summary>
        /// This method Create a folder inside the root of the program
        /// and create a folder that can be use for the program 
        /// it work like this ProgramRoot/data/qt/...
        /// also if the program has a folder that is already called data
        /// it will not override it 
        /// </summary>
        /// <returns>string path </returns>
        public static string DataPath()
        {
            string folder = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}{Slash()}qt{Slash()}";
            if (Directory.Exists(folder) == true)
            {
                return folder;
            }
            else
            {
                Directory.CreateDirectory(folder);

                return folder;
            }

        }

        /// <summary>
        /// Wait the specified  action to finish and prints this label while waits and a wating simbol 
        /// </summary>
        /// <param name="action">Action.</param>
        public static void Wait(Action action) => Get.Wait("Plase Wait", action);

        private static char _Char = '-';


        private static int[] Vector = new int[] { };
        /// <summary>
        /// This version of Get.Wait is designed to be inside a loop 
        /// and be updated as the loop goes through it 
        /// </summary>
        /// <param name="label"></param>
        /// <param name="ignored"></param>
        public static void Wait(string label,bool ignored)
        {
            int x, y;
            x = 0;
            y = 0; 
            if(Vector.Length == 2)
            {
                x = Vector[0];
                y = Vector[1]; 
            }if(Vector.Length == 0)
            {
                Vector = new int[] { Console.CursorLeft, Console.CursorTop };
                x = Vector[0];
                y = Vector[1];
            }
            char ch = _Char; 
                switch (ch)
                {
                    case '-':
                        ch = '\\';
                        break;
                    case '\\':
                        ch = '|';
                        break;
                    case '|':
                        ch = '/';
                        break;
                    case '/':
                        ch = '-';
                        break;
                }
            _Char = ch;
            Get.WaitTime(100);
            Console.SetCursorPosition(x, y);
            Console.Write($"{label} [{ch}]");
        }

        /// <summary>
        /// Wait the specified  action to finish and prints this label while waits and a wating simbol 
        /// </summary>
        /// <param name="label">Label.</param>
        /// <param name="action">Action.</param>
        public static void Wait(string label, Action action)
        {
            int x, y;
            x = Console.CursorLeft;
            y = Console.CursorTop;
            char ch = '-';

            Thread work = new Thread(() => { action(); });
            work.Start();
            while (work.IsAlive)
            {
                switch (ch)
                {
                    case '-':
                        ch = '\\';
                        break;
                    case '\\':
                        ch = '|';
                        break;
                    case '|':
                        ch = '/';
                        break;
                    case '/':
                        ch = '-';
                        break;
                }
                Get.WaitTime(100);
                Console.SetCursorPosition(x, y);
                Console.Write($"{label} [{ch}]");
            }
            Get.WriteL("\nDone");
        }


        /// <summary>
        /// Removes the file name extention.
        /// </summary>
        /// <returns>The file name extention.</returns>
        /// <param name="fileName">File name.</param>
        public static string RemoveFileNameExtention(string fileName)
            {
                  return fileName.Substring(0, fileName.IndexOf('.'));
            }

            /// <summary>
            /// Gets the Files  name from the path.
            /// </summary>
            /// <returns>The name from path.</returns>
            /// <param name="path">Path.</param>
            public static string FileNameFromPath(string path)
            {
                  if (!path.Contains('/') && !Path.Contains('\\')) return path; 
                  return path.Substring(path.LastIndexOf(Get.Slash()) + 1);
            }

        /// <summary>
        /// Gets the file extention and returns it back
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string FileExention(string file) => file.Substring(file.LastIndexOf(".") + 1);

        /// <summary>
        /// makes the console to beep 
        /// </summary>
        public static void Beep() => Console.Beep();
        /// <summary>
        /// Gets the path from the given file 
        /// </summary>
        /// <returns>The from path.</returns>
        /// <param name="path">Path.</param>
        public static string FolderFromPath(string path)
        {
            if(path[path.Length-1] == Get.Slash()[0])
            {
                return path;
            }
            if (System.IO.Path.HasExtension(path))
            {
                return path.Substring(0 ,path.LastIndexOf(Get.Slash()[0]));
            }
            else
            {
                return path + Get.Slash(); 
            }
         }

        /// <summary>
        /// Prints the disks.
        /// </summary>
        public static void PrintDisks()
        {

            DriveInfo[] drives = DriveInfo.GetDrives();
            string name, label;
            string free, used, total, format, error;
            error = null;
            foreach (DriveInfo drive in drives)
            {
                try
                {
                    name = drive.Name;
                    label = drive.VolumeLabel;
                    total = Get.FileSize(drive.TotalSize);
                    used = Get.FileSize(drive.TotalSize - drive.AvailableFreeSpace);
                    free = Get.FileSize(drive.AvailableFreeSpace);
                    format = drive.DriveFormat;

                    Get.WriteL("");

                    Get.Green();
                    Get.Write($"{name} ");
                    Get.Yellow();
                    Get.Write($"{label} ");
                    Get.Green();
                    Get.Write($"Size: {total} ");
                    Get.Red();
                    Get.Write($"Used: {used} ");
                    Get.Green();
                    Get.Write($"Free Space: {free} ");
                    Get.Pink();
                    Get.Write($"Format: {format} ");

                    Get.WriteL("");
                    // Get.Green($"{drive.VolumeLabel} {drive.Name} {drive.VolumeLabel} {drive.AvailableFreeSpace} {drive.TotalSize}");
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                }

            }

            if (error != null)
            {

                Get.Red($"\n Not all devises are listed due to: {error}");
            }

        }
        /// <summary>
        /// Gets the relative path from the given path by taking your current path in consideration
        /// </summary>
        /// <param name="path"></param>
        /// <returns>the relative path string </returns>
        public static string RelativePath(string path)
        {
            string relative, currentPath, slash, fullPath, newPath;
            int pLength, cLenght;
            bool refersToDisk = false;
            currentPath = Get.Path;
            pLength = path.Length;
            cLenght = currentPath.Length;
            relative = null;
            newPath = null;
            fullPath = null;
            slash = "";
            if (IsDriveChar(path))
            {
                pLength = cLenght;
                newPath = path;
                path = currentPath;
                refersToDisk = true;
            }
            for (int ch = 0; ch < pLength; ch++)
            {
                if (path[ch].ToString() == Get.Slash())
                {
                    slash += $"..{Get.Slash()}";
                }
            }
            if (!refersToDisk)
            {
                fullPath = $"{currentPath}{slash}{path.Substring(path.IndexOf(Get.Slash()) + 1)}";

            }
            if (refersToDisk)
            {
                fullPath = $"{currentPath}{slash}";
            }
            relative = fullPath;
           // Get.Red(fullPath);
            return relative;
        }

        /// <summary>
        /// Checks if the path given looks like a drive letter on windwos 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool IsDriveChar(string path)
        {
            bool isChar = false;
            if (path.Length >= 2)
            {
                if (path[1] == ':')
                {
                    isChar = true;
                }
            }
            return isChar;
        }



        /// <summary>
        /// Gets the relative path from the given path by taking your current path in consideration
        /// </summary>
        /// <returns>The path.</returns>
        /// <param name="path">Path.</param>
        /// <param name="currentPath">Current path.</param>
        public static string RelativePath(string path ,string currentPath)
        {
            string relative, slash, fullPath, newPath;
            int pLength, cLenght;
            bool refersToDisk = false;
            //currentPath = Get.Path;
            pLength = path.Length;
            cLenght = currentPath.Length;
            relative = null;
            newPath = null;
            fullPath = null;
            slash = "";
            if (IsDriveChar(path))
            {
                pLength = cLenght;
                newPath = path;
                path = currentPath;
                refersToDisk = true;
            }
            for (int ch = 0; ch < pLength; ch++)
            {
                if (path[ch].ToString() == Get.Slash())
                {
                    slash += $"..{Get.Slash()}";
                }
            }
            if (!refersToDisk)
            {
                fullPath = $"{currentPath}{slash}{path.Substring(path.IndexOf(Get.Slash()) + 1)}";

            }
            if (refersToDisk)
            {
                fullPath = $"{currentPath}{slash}";
            }
            relative = fullPath;
           // Get.Red(fullPath);
            return relative;
        }
        /// <summary>
        /// This method allows you to get the clear path fixed tto the operating system that you 
        /// are working with in this case windows and linux are the only one  that this has being tested 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string FixPath(string path) => Get.IsWindow() == true ? path.Replace("/", Get.Slash()) : path.Replace(@"\", Get.Slash()); 
       

        
        /// <summary>
        /// Ises the window.
        /// </summary>
        /// <returns><c>true</c>, if window was ised, <c>false</c> otherwise.</returns>
        public static bool IsWindow()
        {

            string[] info = IConvert.TextToArray(System.Environment.OSVersion.ToString());
            //Microsoft Windows NT 6.2.9200.0
            if (info[0][0] == 'M')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

            /// <summary>
            /// Create a data path if is not created and creates the directory given as a parameter
            /// </summary>
            /// <returns></returns>
            /// <param name="newDirectory"></param>
            public static string DataPath(string newDirectory)
        {
            string bar = Slash();
            string folder = $"{DataPath()}{newDirectory}{Slash()}";
            if (Directory.Exists(folder) == true)
            {
                return folder;
            }
            else
            {
                Directory.CreateDirectory(folder);

                return folder;
            }

        }

        //   private static string path = Get.Path;
        private static string qtDir =$"{DataPath()}qt{Slash()}keys{Slash()}";
        private static string keyFile = qtDir + "secure.key";


        /// <summary>
        /// Returns the Slash '/' apropiet for the current OS in use
        /// </summary>
        /// <returns>The slash.</returns>
        public static string Slash()
        {
            string path = null;
            switch (IsWindow())
            {
                case true:
                    path = @"\";
                    break;
                case false:
                    path = "/";
                    break; 
            }
            return path;
        }
        /// <summary>
        /// This method can used manually
        /// or automatically 
        /// by calling directly the RandomByteKey(true); 
        /// and adding the parameter the bool true 
        /// for it to auto save the key 
        /// </summary>
        public static void SaveKey()
        {
            //string path, keyFile, qtDir;

            if (Directory.Exists(qtDir) == false)
            {
                Directory.CreateDirectory(qtDir);
                SaveKey();
            }
            else
            {


                using (FileStream file = File.Create(keyFile))
                {

                    using (StreamWriter writer = new StreamWriter(file))
                    {
                        foreach (byte key in IRandom.KeyGenerated)
                        {
                            writer.Write(key + ",");
                        }
                    }
                }


            }


        }

        /// <summary>
        /// Save the key Generated on the given path 
        /// </summary>
        /// <param name="pathToSaveTheKey">Path to save the key.</param>
        public static void SaveKey(string pathToSaveTheKey)
        {
            //string path, keyFile, qtDir;

            if (Directory.Exists(pathToSaveTheKey) == false)
            {
                Directory.CreateDirectory(pathToSaveTheKey);
                SaveKey();
            }
            else
            {


                using (FileStream file = File.Create(keyFile))
                {

                    using (StreamWriter writer = new StreamWriter(file))
                    {
                        foreach (byte key in IRandom.KeyGenerated)
                        {
                            writer.Write(key + ",");
                        }
                    }
                }


            }


        }

        /// <summary>
        /// This Method gets the key bytes that were saved before by using the method 
        /// before that was the method save key 
        /// </summary>
        /// <returns>The bytes saved.</returns>
        public static byte[] KeyBytesSaved()
        {
            try
            {

                byte[] keyBytes = null;

                keyBytes = Reader.ReadStoredBytes(keyFile);


                return keyBytes;

            }
            catch (Exception)
            {

                Get.Alert("Either the key was not founded or there is not such a key ");
                return null;
            }

        }

        /// <summary>
        /// Read the string bytes stored in a file 
        /// </summary>
        /// <returns>The bytes saved.</returns>
        /// <param name="path">Path.</param>
        public static byte[] KeyBytesSaved(string path)
        {
            try
            {

                byte[] keyBytes = null;

                keyBytes = Reader.ReadStoredBytes(path);


                return keyBytes;

            }
            catch (Exception)
            {

                Get.Alert("Either the key was not founded or there is not such a key ");
                return null;
            }

        }











        /*
this check will veryfi if a name has an invalid
character in order for it to return a valid name 

*/
        /*
/////////////////////////////////////////////////////////////////////////////
////////////     THIS AREA CONTROLS CONSOLE VALIDATION  /////////////////////
/////////////////////////////////////////////////////////////////////////////
*/

        /// <summary>
        ///  This basically just check if a name could be a valid
        /// name for a file in windows mainly and it 
        /// returns true if the check it is correct 
        /// </summary>
        /// <returns>True or False</returns>
        public static bool Check()
        {
            // Regex rueles for the allowed name types 
            var rules = new Regex("^[a-zA-Z0-9_]*$");
            //conditions with an input 
            // this basically just get the return 
            // from the  the input and it convers it to 
            // text to validate if it match the rules 


            // if the name is blank is not a valid name actually 
            if (rules.IsMatch(Get.Input().ToString()) && Get.input.ToString().Length > 0)
            {
                //Valid Name


                return true;
            }
            else
            {
                // invalid Name 
                return false;
            }
        }


        /*
/////////////////////////////////////////////////////////////////////////////
//////////// THIS AREA CONTROLS CONSOLE Profile  /////////////////////////////
/////////////////////////////////////////////////////////////////////////////
*/

        /*
  /// <summary>
  /// This method has builded in it 
  /// a very simple login user
  /// ask for the login name
  /// and password it also trys to 
  /// hide the password but it is not super
  /// secure
  /// </summary>
  /// <returns>string[] array name and password</returns>
  public static string[] Login()
  {
        string name, password;
        Back_Green("Login");
        Yellow("Type Your Information Please.",1);
        Green("Name");
        name = Get.TextInput();
        Green("Password");
        Red("Hidden For Privacy and Security");
        Get.Hide();
        password = Console.ReadLine();
        Get.Reset();
        if (name == "" || password == "")
        {
             Console.WriterongIn("Name or password empty");
              Get.Clear();
              Login();
        }
#pragma warning disable RECS0026 // Possible unassigned object created by 'new'
        new User(name, password);
        string[] userData = { name, password };
        return userData;
#pragma warning restore RECS0026 // Possible unassigned object created by 'new'
  }

    public static string[] SingUp()
  {
        string name, lastName, password, dob, phone, email,repeated;
        Back_Green("Singup");
        Yellow("Type Your Information Please.",1);
        Green("Name");
        name = Get.Input().ToString();
        Green("Last Name");
        lastName = Get.Input().ToString();
        Green("Date of Birth");
        //Red("Hidden For Privacy and Security");
        //Get.Hide();
        dob = Get.Input().ToString();
        //Get.Reset();
        Green("Phone Number");
        phone = Get.Input().ToString();
        Green("Email Address");
        email = Get.Input().ToString();
        Green("Password");
        Red("Hidden For Privacy and Security");
        Get.Hide();
        password = Console.ReadLine();
        Get.Reset();
        Yellow("Repeat Password");
        Get.Hide();
        repeated = Console.ReadLine();
        Get.Reset();
        if (repeated == password)
        {
#pragma warning disable RECS0026 // Possible unassigned object created by 'new'
              new User(name, lastName, password, dob, phone, email);
#pragma warning restore RECS0026 // Possible unassigned object created by 'new'

        }
        if (repeated != password)
        {
              Yellow("Invalid Information , either missing or the password did not match");                       
             Wait();
              SingUp();                        
        }

        // Console.Write(name+" "+lastName + " " +password + " " +dob + " " +phone + " " +email);
        string[] userData = { name, lastName, password, dob, phone, email };
        return userData;
  }
  */

        /*
/////////////////////////////////////////////////////////////////////////////
//////////// THIS AREA CONTROLS CONSOLE INPUT   /////////////////////////////
/////////////////////////////////////////////////////////////////////////////
*/


        /// <summary>
        /// Return the text taken by any of the fallowing 
        /// Get.Input()
        /// Get.InputText(); 
        /// </summary>
        public static string Text = "";
        /// <summary>
        /// Returns the Number taken by the fallowing
        /// Get.Input();
        /// Get.NumberInput(); 
        /// </summary>
        public static int Number = 0;
        /// <summary>
        /// Holds the value of long numbers for operations that require long operations 
        /// such as <see cref="Get.FileSize(string)"/>
        /// </summary>
        public static long LongNumber { get; set; }
        ///<summary>
        /// Returns the text taken by
        /// Get.Input();
        /// </summary>           
        public static object input = "";
        // this is the Input method which will retrun a number or text and 
        // it just need to be treated as such 
        ///<summary>
        /// Returns the Key from  the Get.KeyInput()
        /// method 
        ///</summary>           
        public static string Key = "";

        /// <summary>
        /// Gets or sets the char.
        /// </summary>
        /// <value>The char.</value>
        public static string Char { get; set; }

        /// <summary>
        /// Gets or sets the modifier.
        /// </summary>
        /// <value>The modifier.</value>
        public static string Modifier { get; set; }


        /// <summary>
        /// Keies the input.
        /// </summary>
        /// <returns>The input.</returns>
        public static string KeyInput()
        {
            //    Get.LabelSide(">"); // just looks better damme it 
            //    Console.Write(" ");
            // it just did not make as much sence on 
            //why would i want something that is pointing to 
            // nothing because is just wating for a key to be pressed
            var InputKey = Console.ReadKey();
            //Get.Clear();
            // this will return a type of number or key 
            // with the information from it like 1D1
            string inputValue = InputKey.Key.ToString();
            Key = inputValue;
            Char = InputKey.KeyChar.ToString();
            Modifier = InputKey.Modifiers.ToString();
            return inputValue;
        }



        /// <summary>
        /// Get the Input as an array the array.
        /// </summary>
        /// <returns>The array.</returns>
        public static string[] InputArray()
        {


            string[] input = Get.Input().Text.Split(' ');

            //Print.List(input);

            Func<String[], String[]> F = (arr) => {
                String[] clearArr;
                List<string> list = new List<string>();
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] != "" && arr[i] != null)
                    {
                        list.Add(arr[i]);
                    }
                }

                clearArr = new string[list.Count];
                for (int val = 0; val < list.Count; val++)
                {
                    clearArr[val] = list[val];
                }

                return clearArr;

            };

            return F(input);
            //For testing Print.List(F(input));
        }

        /// <summary>
        /// Get the Input as an array the array.
        /// </summary>
        /// <returns>The array.</returns>
        /// <param name="label">Label.</param>
        public static string[] InputArray(object label)
        {


            string[] inputValue = Get.Input(label.ToString()).Text.Split(' ');

            // Print.List(input);

            Func<String[], String[]> F = (arr) => {
                String[] clearArr;
                List<string> list = new List<string>();
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] != "" && arr[i] != null)
                    {
                        list.Add(arr[i]);
                    }
                }

                clearArr = new string[list.Count];
                for (int val = 0; val < list.Count; val++)
                {
                    clearArr[val] = list[val];
                }

                return clearArr;

            };

            return F(inputValue);
            //For testing Print.List(F(input));
        }



        /// <summary>
        /// This is the char that is located at the biggining of the 
        /// Get.Input() method and it has to be added a method where
        /// it will save the char if is changed
        /// </summary>
        public static string InputChar = ">";





        /// <summary>
        /// Input type.
        /// </summary>
        public class InputType
        {
            /// <summary>
            /// Gets or sets the text.
            /// </summary>
            /// <value>The text.</value>
            public string Text { get; set; }
            /// <summary>
            /// Gets or sets the number.
            /// </summary>
            /// <value>The number.</value>
            public int Number { get; set; }
            /// <summary>
            /// Gets or sets a value indicating whether this <see cref="T:QuickTools.Get.InputType"/> is bool.
            /// </summary>
            /// <value><c>true</c> if bool; otherwise, <c>false</c>.</value>
            public bool Bool { get; set; }
            /// <summary>
            /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:QuickTools.Get.InputType"/>.
            /// </summary>
            /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:QuickTools.Get.InputType"/>.</returns>
            public override string ToString()
            {
                return this.Text;
            }

        }


        /// <summary>
        /// This Method Get the input from the keyboard
        /// and it returns an object and is an implementation 
        /// </summary>
        /// <returns>The input.</returns>
        public static InputType Input()
        {

            Get.LabelSide(InputChar);
            Get.Reset();
            Console.Write(" ");
            bool isnumber;
            string inputValue = Console.ReadLine();
            int number;



            isnumber = int.TryParse(inputValue, out number);

            if (isnumber)
            {
                Number = number;
                Get.input = number;

                return new InputType()
                {
                    Number = number,
                    Text = number.ToString()
                };
            }
            else
            {
                Get.input = inputValue;
                Get.Text = inputValue;
                return new InputType()
                {
                    Text = inputValue
                };
            }
        }





        /// <summary>
        /// This Method does the same as Input() without any 
        /// arguments but with the only diference that the char
        /// on the side at the bigging could be edited 
        /// like Get.Input("Write Your Name");.
        /// </summary>
        /// <returns>The input.</returns>
        /// <param name="display">Display.</param>
        public static InputType Input(string display)
        {

            Console.Write("");
            Get.LabelSide(display);
            Get.Reset();
            Console.Write(" ");
            bool isnumber;
            string inputValue = Console.ReadLine();
            int number;

            isnumber = int.TryParse(inputValue, out number);

            if (isnumber)
            {
                Number = number;
                Get.input = number;

                return new InputType()
                {
                    Number = number,
                    Text = number.ToString()
                };
            }
            else
            {
                Get.input = inputValue;
                Get.Text = inputValue;
                return new InputType()
                {
                    Text = inputValue
                };
            }
        }
        /// <summary>
        /// This is a very generic Number Checker
        /// that veryfied if the input passed as an argument
        /// could be a number or not and it returns
        /// true or false if is or not a number
        /// </summary>
        /// <returns>Retursn True or False if is number : True if is not a number returns: false</returns>
        /// <param name="input">Input.</param>
        public static bool IsNumber(object input)
        {
            string textInput = input.ToString();
            double number = 0;
            bool isNumber = false;

            isNumber = double.TryParse(textInput.Replace("D", ""), out number);



            if (isNumber == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Get the Number from the input introduced 
        /// </summary>
        /// <returns>The input.</returns>
        public static int NumberInput()
        {

            Get.LabelSide(">");
            Console.Write(" ");
            bool isnumber = false;
#pragma warning disable RECS0117 // Local variable has the same name as a member and hides it
            string input = Console.ReadLine();
#pragma warning restore RECS0117 // Local variable has the same name as a member and hides it
            int number;
            isnumber = int.TryParse(input, out number);
            if (isnumber)
            {
                Number = number;
                return number;
            }
            else
            {
                Yellow("Incorrect imput ,  ONLY numbers expected , and not maximum to " + int.MaxValue + " nor smallert than " + int.MinValue);
                //throw new Inva\lidDataException(); 
                return int.MinValue;
            }

        }



        /// <summary>
        /// Get a number in put and returns a double 
        /// </summary>
        /// <returns>The input.</returns>
        /// <param name="BigNumber">If set to <c>true</c> big number.</param>
        public static double NumberInput(bool BigNumber)
        {

            Get.LabelSide(">");
            Console.Write(" ");
            //bool isnumber = false;
#pragma warning disable RECS0117 // Local variable has the same name as a member and hides it
            string input = Console.ReadLine();
#pragma warning restore RECS0117 // Local variable has the same name as a member and hides it
            double number = Convert.ToDouble(input);

            return number;
            // Yellow("Incorrect imput"); 

        }


        /// <summary>
        /// Shortcut for Console.Reset(); 
        /// </summary>
        public static void Reset()
        {
            Console.ResetColor();
        }



            /// <summary>
            /// Clear the console
            /// </summary>
            public static void Clear()
            {
                  Console.Clear();                 
            }


            static int X;
            static int Y;
        public static void Clear(bool everything)
        {
            if (!everything) return;         
            int x, y;
            x = Console.BufferWidth;
            y = Console.BufferHeight;
            for (int xx = 0; xx < x; xx++)
            {
                for (int yy = 0; yy < y; yy++)
                {
                    Console.SetCursorPosition(xx, yy);
                    Get.Write(" ");
                }
            }
            Console.SetCursorPosition(1, 1);           
        }


        /// <summary>
        /// Clears the after the content given 
        /// </summary>
        /// <param name="content">Content.</param>
        static void ClearAfter(object content)
            {
                string message = content.ToString(); 
                throw new NotImplementedException("This Method is currently not mantained");
                  /*
                  Console.SetCursorPosition(0, 0);
                  //Console.Write(new CInput().Tabs(message.Length));
                  Console.SetCursorPosition(0, 0);
                  Console.Write(content); 
                  */
            }
                       

            /// <summary>
            /// Label the specified msg, backColor and foreColor.
            /// </summary>
            /// <param name="msg">Message.</param>
            /// <param name="backColor">Back color.</param>
            /// <param name="foreColor">Fore color.</param>
            public static void Label(object msg,ConsoleColor backColor,ConsoleColor foreColor)
                  {
                        Console.BackgroundColor = backColor;
                        Console.ForegroundColor = foreColor;
                        Console.Write(" " + msg + " ");
                        Console.Write("");
                        Get.Reset();
                  }
            /// <summary>
            /// Write text with background color in color magentaand some space around it 
            /// and seems like a type of a label and takes an argument of an object to avoid casting
            /// </summary>
            /// <param name="msg">Message.</param>
            public static void Label(object msg)
        {
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" " + msg + " ");
            Console.Write("");
            Get.Reset();
        }
        /// <summary>
        /// simmilar to Console.Write
        /// but prints to the console a text on magenta
        /// </summary>
        /// <param name="msg">Message content</param>
        public static void LabelSide(object msg)
        {
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n" + msg + " ");
            Get.Reset();
        }


        /// <summary>
        /// Print Text on the side of the console using Console.Write
        /// and gives it a Magenta color 
        /// </summary>
        /// <param name="msg">Message.</param>
        public static void LabelSingle(object msg)
        {
            Get.Reset();
            Color.Pink();
            Console.Write(msg);
            Get.Reset();
        }
        /// <summary>
        /// Console.Title implementation 
        /// </summary>
        /// <param name="msg">Message.</param>
        public static void Title(object msg)
        {
            Console.Title = msg.ToString();
        }

        // this gives you the avility to 
        // deside how many tabs you want to include
        // in the title 

        /// <summary>
        /// Console.WriteLine(object) implementation with \n to give the text more space
        /// to the right 
        /// </summary>
        /// <param name="msg">Message.</param>
        /// <param name="tabs">Tabs.</param>
        public static void Title(object msg, int tabs)
        {
            string spaces = "\t";
            string tabSpaces = "";
            for (int i = 0; i <= tabs; i++)
            {
                tabSpaces += spaces;
            }

            Console.WriteLine(tabSpaces + msg);
        }

        // Default box 

        /// <summary>
        /// Box the specified content.
        /// </summary>
        /// <param name="content">Content.</param>
        public static void Box(object content)
        {
            string simbol = "*";
            string underLine = "";
            for (int i = 0; i <= content.ToString().Length + 3; i++)
            {
                underLine += simbol;
            }

            Console.WriteLine(underLine);
            Console.Write(simbol + " " + content + " " + simbol+"\n");
            Console.WriteLine(underLine);
        }
        /// <summary>
        /// Box the specified content and simbol.
        /// </summary>
        /// <param name="content">Content.</param>
        /// <param name="simbol">Simbol.</param>
        public static void Box(object content, object simbol)
        {

            string underLine = "";
            for (int i = 0; i <= content.ToString().Length + 3; i++)
            {
                underLine += simbol;
            }

            Console.WriteLine(underLine);
            Console.Write(simbol + " " + content + " " + simbol + "\n");
            Console.WriteLine(underLine);
        }

        /// <summary>
        /// Box the specified content and tabs.
        /// </summary>
        /// <param name="content">Content.</param>
        /// <param name="tabs">Tabs.</param>
        public static void Box(object content, int tabs)
        {
            string spaces = "\t";
            string tabSpaces = "";
            for (int i = 0; i <= tabs; i++)
            {
                tabSpaces += spaces;
            }

            string simbol = "/";
            string underLine = "";
            for (int i = 0; i <= content.ToString().Length + 3; i++)
            {
                underLine += simbol;
            }

            Console.WriteLine(tabSpaces + underLine);
            Console.Write(tabSpaces + simbol + " " + content + " " + simbol);
            Console.WriteLine(tabSpaces + underLine);
        }

        // custom box 

        /// <summary>
        /// Box the specified content, simbol and tabs.
        /// </summary>
        /// <param name="content">Content.</param>
        /// <param name="simbol">Simbol.</param>
        /// <param name="tabs">Tabs.</param>
        public static void Box(object content, string simbol, int tabs)
        {
            string spaces = "\t";
            string tabSpaces = "";
            for (int i = 0; i <= tabs; i++)
            { // you just want to add tabs 
              // if there is tabs added 
                if (tabs > 0)
                {
                    tabSpaces += spaces;
                }
            }

            string underLine = "";
            for (int i = 0; i <= content.ToString().Length + 3; i++)
            {
                underLine += simbol;
            }

            Console.Write(tabSpaces + underLine);
            Console.Write(tabSpaces + simbol + " " + content + " " + simbol);
            Console.Write(tabSpaces + underLine);
        }





        /// <summary>
        /// Write Text with Console.WriteLine add red color and wait for a key to be pressed 
        /// </summary>
        /// <param name="text">Text.</param>
        public static void Wrong(object text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Something Went Really Wrong!!!");
            Get.Yellow();
            Console.WriteLine("This" + ":=>>>> " + text);
            Console.ResetColor();
            Get.Wait();
        }


        /// <summary>
        /// Write Text with Console.WriteLine add red color and wait for a key to be pressed 
        /// </summary>
        /// <param name="msg">Message.</param>
        public static void WrongIn(object msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" Wrong Input!!!, this is not a valid input: '{0}' ", msg);
            Console.ResetColor();
            //  Console.Write();
            Get.Wait();
        }
        /// <summary>
        /// Write Text with Console.WriteLine add red color and wait for a key to be pressed 
        /// </summary>
        /// <param name="msg">Message.</param>
        public static void WrongInput(object msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" Wrong Input!!!, this is not a valid input: '{0}' ", msg);
            Console.ResetColor();
            //  Console.Write();
            Get.Wait();
        }


        /// <summary>
        /// Gets an input without showing it on the screen
        /// </summary>
        /// <returns>The password.</returns>
        public static string Password() => Get.Password(""); 


        /// <summary>
        /// gets the input of a passwords and check to make sure that is the same 2 times
        /// </summary>
        /// <param name="label"></param>
        /// <param name="repeat"></param>
        /// <returns></returns>
        public static string Password(string label,bool repeat)
        {
            if (!repeat) return Get.Password(label);
            string password; 
            while (true)
            {
                password = Get.Password(label); 
                if(password == Get.Password($"{label} Again"))
                {
                    return password; 
                }
                else
                {
                    Get.Red($"The passwords does not match!!!");
                }
            }
        }

        /// <summary>
        /// Gets the input of a private password and return it 
        /// </summary>
        /// <param name="label"></param>
        /// <returns></returns>
        public static string Password(string label)
        {
            string password = null;
            Get.White(label); 
            while (true)
            {
                // Get.Clear();

                Console.CursorVisible = false;
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Black;
                var word = Console.ReadKey();
                password += word.KeyChar.ToString();

                if (word.Key.ToString() == "Enter")
                {

                    break;
                }
            }

            Get.Reset();
            return password;
        }
        /// <summary>
        /// Alert Not found write the file that was not founded and print it on color red
        /// </summary>
        /// <param name="msg">Message.</param>
        public static void NotFound(object msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("This File Was Not Founded '{0}' ", msg);
            Console.ResetColor();
            //     Console.Write();
        }



        /// <summary>
        /// Wait for a key to be pressed 
        /// </summary>
        public static void Wait()
        {
            Console.Write("Type any key to continue");
            Console.ReadKey();
        }

        /// <summary>
        /// Very similar to Console.ReadKey
        /// but it has some content added to display
        /// the Text from it and is basically used
        /// to display the text witout closing the console
        /// in some cases the console will close to quickly 
        /// </summary>
        /// <param name="Caller">Text Needed to be printed</param>
        public static void Wait(object Caller)
        {
            //Console.Write("Type any key to continue");
            //Get.Yellow("This Called me =>  '" + Caller + "'");
            Console.WriteLine("Info");
            Get.Yellow(Caller);
                  Get.White("Type any key to continue");                 
            Console.ReadKey();
        }

        /// <summary>
        /// Literally Print a line saying ok 
        /// on color green 
        /// </summary>
        public static void Ok()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("OK");
            Console.ResetColor();
            Console.Write("");
        }
        /// <summary>
        /// This is just used when you need to see if some logic is working as spected
        /// so each ok number provide a different color and each of them are from 0 to 4 
        /// and the colors available are (Green 0, Yellow 1, Blue 2,  Red 3, Cyan 4)
        /// </summary>
        /// <param name="colorNumber">Color number.</param>
        public static void Ok(int colorNumber)
        {


            switch (colorNumber)
            {
                case 0:
                    Color.Green("OK");
                    break;

                case 1:
                    Color.Yellow("OK");
                    break;
                case 2:
                    Color.Blue("OK");
                    break;
                case 3:
                    Color.Red("OK");
                    break;
                case 4:
                    Color.Cyan("OK");
                    break;
                default:
                    // var get = new Get();                              
                    Alert("Not Implemented a number for this method please only from 0 to 4 \n" +
                    "Colors Availables are {Green , Yellow , Blue , Red , Cyan }");
                    break;
            }

            //   Console.Write();
        }




                        /// <summary>
                        /// gets the Bytes of the specified Object.
                        /// </summary>
                        /// <returns>The bytes.</returns>
                        /// <param name="Object">Object.</param>
                  public static byte[] Bytes(object Object)
                  {
                        return System.Text.Encoding.ASCII.GetBytes(Object.ToString());                  
                  }
            /// <summary>
            /// Similar to Console.WriteLine(object); 
            /// but add a box of color yellow saying alert
            /// and the fallowing text that is pass as an argument
            /// will be printed on yellow color 
            /// </summary>
            /// <param name="msg">Message Content</param>
            public static void Alert(object msg)
        {
            Get.Yellow();                  
            Console.WriteLine(msg);
            Console.Beep();
            Get.Wait(); 
        }
        /// <summary>
        /// this is a very smallintent of  trying to hide the password
        /// while is being pressed 
        /// </summary>
        public static void Hide()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Black;
        }
        /// <summary>
        /// This try to hide the text
        /// </summary>
        public static void HideText()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        /*
/////////////////////////////////////////////////////////////////////////////
//////////// THIS AREA CONTROLS CONSOLE OUTPUT  /////////////////////////////
/////////////////////////////////////////////////////////////////////////////
*/
        // quick WriteLine just as a quick method while im using an online editor 


        /// <summary>
        /// Console.WriteLine(object) shurtcut
        /// </summary>
        /// <param name="text">Text.</param>
        public static void W(object text)
        {
            Console.Write(text);
        }

        /// <summary>
        /// Write to the console the given text
        /// </summary>
        /// <param name="text">Text.</param>
        public static void WL(object text)
        {
            Console.WriteLine(text);
        }

        /// <summary>
        /// Writes the line
        /// </summary>
        /// <param name="text">Text.</param>
        public static void WriteL(object text)
        {
            Console.WriteLine(text);
        }
        /// <summary>
        /// Write the specified text and tabs.
        /// </summary>
        /// <param name="text">Text.</param>
        /// <param name="tabs">Tabs.</param>
        public static void Write(object text, int tabs)
        {
            string spaces = "\t";
            string tabSpaces = "";
            for (int i = 0; i <= tabs; i++)
            {
                tabSpaces += spaces;
            }

            Console.WriteLine(tabSpaces + text);
        }

        /// <summary>
        /// Write the specified value.
        /// </summary>
        /// <param name="value">Value.</param>
        public static void Write(object value)
        {
            Console.Write(value);
        }



        /*
 here im just going to add some shortcuts for the console colors
 sadly it will be for type string only 
*/
        /*
/////////////////////////////////////////////////////////////////////////////
//////////// THIS AREA CONTROLS CONSOLE JUST DOCUMENT INFOMATION ////////////
/////////////////////////////////////////////////////////////////////////////
*/
        ///    public static string Version = "A032022";
        ///    private static string lastModified = "03/23/2022";
        /// 


        /// <summary>
        /// This Print QuickTools logo to the console , not really useful , but looks cool . 
        /// </summary>
        public static void About()
        {

            Green();
            Console.WriteLine(@"                                                

                                                                                                                                                                                        
                                                                                                                                                                                        
     QQQQQQQQQ                          iiii                      kkkkkkkk           TTTTTTTTTTTTTTTTTTTTTTT                                                   lllllll                  
   QQ:::::::::QQ                       i::::i                     k::::::k           T:::::::::::::::::::::T                                                   l:::::l                  
 QQ:::::::::::::QQ                      iiii                      k::::::k           T:::::::::::::::::::::T                                                   l:::::l                  
Q:::::::QQQ:::::::Q                                               k::::::k           T:::::TT:::::::TT:::::T                                                   l:::::l                  
Q::::::O   Q::::::Q uuuuuu    uuuuuu  iiiiiii     cccccccccccccccc k:::::k    kkkkkkkTTTTTT  T:::::T  TTTTTT   ooooooooooo      ooooooooooo      ooooooooooo    l::::l     ssssssssss   
Q:::::O     Q:::::Q u::::u    u::::u  i:::::i   cc:::::::::::::::c k:::::k   k:::::k         T:::::T         oo:::::::::::oo  oo:::::::::::oo  oo:::::::::::oo  l::::l   ss::::::::::s  
Q:::::O     Q:::::Q u::::u    u::::u   i::::i  c:::::::::::::::::c k:::::k  k:::::k          T:::::T        o:::::::::::::::oo:::::::::::::::oo:::::::::::::::o l::::l ss:::::::::::::s 
Q:::::O     Q:::::Q u::::u    u::::u   i::::i c:::::::cccccc:::::c k:::::k k:::::k           T:::::T        o:::::ooooo:::::oo:::::ooooo:::::oo:::::ooooo:::::o l::::l s::::::ssss:::::s
Q:::::O     Q:::::Q u::::u    u::::u   i::::i c::::::c     ccccccc k::::::k:::::k            T:::::T        o::::o     o::::oo::::o     o::::oo::::o     o::::o l::::l  s:::::s  ssssss 
Q:::::O     Q:::::Q u::::u    u::::u   i::::i c:::::c              k:::::::::::k             T:::::T        o::::o     o::::oo::::o     o::::oo::::o     o::::o l::::l    s::::::s      
Q:::::O  QQQQ:::::Q u::::u    u::::u   i::::i c:::::c              k:::::::::::k             T:::::T        o::::o     o::::oo::::o     o::::oo::::o     o::::o l::::l       s::::::s   
Q::::::O Q::::::::Q u:::::uuuu:::::u   i::::i c::::::c     ccccccc k::::::k:::::k            T:::::T        o::::o     o::::oo::::o     o::::oo::::o     o::::o l::::l ssssss   s:::::s 
Q:::::::QQ::::::::Q u:::::::::::::::uui::::::ic:::::::cccccc:::::ck::::::k k:::::k         TT:::::::TT      o:::::ooooo:::::oo:::::ooooo:::::oo:::::ooooo:::::ol::::::ls:::::ssss::::::s
 QQ::::::::::::::Q   u:::::::::::::::ui::::::i c:::::::::::::::::ck::::::k  k:::::k        T:::::::::T      o:::::::::::::::oo:::::::::::::::oo:::::::::::::::ol::::::ls::::::::::::::s 
   QQ:::::::::::Q     uu::::::::uu:::ui::::::i  cc:::::::::::::::ck::::::k   k:::::k       T:::::::::T       oo:::::::::::oo  oo:::::::::::oo  oo:::::::::::oo l::::::l s:::::::::::ss  
     QQQQQQQQ::::QQ     uuuuuuuu  uuuuiiiiiiii    cccccccccccccccckkkkkkkk    kkkkkkk      TTTTTTTTTTT         ooooooooooo      ooooooooooo      ooooooooooo   llllllll  sssssssssss    
             Q:::::Q                                                                                                                                                                    
              QQQQQQ                                                                                                                                                                    
                                                                                                                                                                                        
                                                                                                                                                                                        
                                                                                                                                                                                        


");

            //    Get.Label("QuickTools Version: " + version);
            Color.Green("Created By MBV");
            //  Console.Write("Last Update: " + lastModified);
            //Console.Write();
            // LastChanges();
        }

        private static void LastChanges()
        {
            /*       
             * Not longer needed 
                  List<string> changes = new List<string>();
                  changes.Add("3/21/2022 update the nulls value that was required to remove them.");
                  changes.Add("updates on the colors and sides functions 'LabelSide added which will give a color and will have an space on the top.'");
                  changes.Add("3/23/2022 Today i will add the profile method and also the Designe of the pink color of the inputs");
                  changes.Add("5/23/2022 Today i will be retaking the project and deviding the system into lyers for it to be esier to grow ");
                  for (int change = 0; change < changes.Count; change++)
                  {
                        int number = change + 1;
                        Get.Yellow(number + ". " + changes[change]);
                  }

                 Console.Write();

            */
        }
    }

    /// <summary>
    /// Extention Of Get Due to Old Programs using this abstraction
    /// </summary>
    public class Do : Get
    {

    }
}
