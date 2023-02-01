/*
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
    public class Get : Color
    {



        /// <summary>
        /// Loop the specified actionMethod forever
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
        /// Loop the specified actionMethod until the condition is meet.
        /// </summary>
        /// <param name="actionMethod">Action method.</param>
        /// <param name="untilConditionIsMeet">Until condition is meet.</param>
        public static void Loop(Action actionMethod, Func<bool> untilConditionIsMeet)
        {
            while (untilConditionIsMeet())
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
        /// This Creates a hash code based on the given input 
        /// be carefull using this as a security method since 
        /// this macanisim is too simple and it could be broken easely
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
        /// This has the same level of security of <see cref="QuickTools.QCore.Get.HashCode(string)"/>
        /// which measn that is not secure enough so if you need encription
        /// please refer to <see cref="QuickTools.QSecurity.Secure"/>
        /// </summary>
        /// <param name="text"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static double HashCode(string text,int length)
        {

            if (text == null || text.Length == 0) throw new ArgumentNullException("The Given text was not valid");
            if (length == 0) length = text.Length;
            //if (length )

            byte[] bytes = new byte[length];
            byte[] str = System.Text.Encoding.ASCII.GetBytes(text); ;
            double x = 0;
            double seed = 7;
            int max = str.Length;
            int indexer = 0; 
            //filling
            for(int f = 0; f <bytes.Length; f++)
            {
                if(indexer == max)
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

            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(text); 
            double x = 0;
            double seed = 7;

            for (int item = 0; item < bytes.Length; item++)
            {
                x += ((seed * bytes[item]) + item);
            }
            return x;
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
            catch (Exception)
            {
                //Get.Wrong(e);
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
            catch (Exception)
            {

            }


        }
        /// <summary>
        /// This does the same thing than WaitTime with param but it actually
        /// has a different name 
        /// </summary>
        /// <param name="sleepTime">Sleep time.</param>
        public static void _(int sleepTime)
        {
            if (sleepTime < 12000)
            {
                try
                {
                    Thread.Sleep(sleepTime);
                }
                catch (Exception)
                {
                    //Wrong(e);
                }
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
        public static string Path = Environment.CurrentDirectory + "/";
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

            string folder = Get.Path + "data/qt/";
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
        /// Create a data path if is not created and creates the directory given as a parameter
        /// </summary>
        /// <returns></returns>
        /// <param name="newDirectory"></param>
        public static string DataPath(string newDirectory)
        {


            string folder = Get.Path + "data/qt/" + newDirectory;
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
        private static string qtDir = "data/qt/keys/";
        private static string keyFile = qtDir + "secure.key";

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
        /// shurtcut for Console.Clear(); 
        /// </summary>
        public static void Clear()
        {
            Console.Clear();
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
            string simbol = "/";
            string underLine = "";
            for (int i = 0; i <= content.ToString().Length + 3; i++)
            {
                underLine += simbol;
            }

            Console.WriteLine(underLine);
            Console.WriteLine(simbol + " " + content + " " + simbol);
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
            Console.Write(simbol + " " + content + " " + simbol);
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
            Console.WriteLine("This" + ":=>>>> " + text);
            Console.ResetColor();
            //   Console.Write();
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
        }


        /// <summary>
        /// Gets an input without showing it on the screen
        /// </summary>
        /// <returns>The password.</returns>
        public static string Password()
        {
            string password = null;

            while (true)
            {
                // Get.Clear();                       
                Console.SetCursorPosition(0, Console.CursorTop);
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
        /// Similar to Console.WriteLine(object); 
        /// but add a box of color yellow saying alert
        /// and the fallowing text that is pass as an argument
        /// will be printed on yellow color 
        /// </summary>
        /// <param name="msg">Message Content</param>
        public static void Alert(object msg)
        {

            Console.ForegroundColor = ConsoleColor.Yellow;
            Box("Alert", "*", 0);
            Console.WriteLine(msg);
            Console.ResetColor();
            Console.Beep();
            //  Console.Write();
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
