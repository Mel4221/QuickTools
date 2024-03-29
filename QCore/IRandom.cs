﻿/*
This Contains all the shortcuts for the Alerts
and events of colors for the display of the 
text. 
important Date : today i have change the class name from "Do static class"
to "Get static class" due to some not sence ideas behing the idea of doing stuff
it is nothing related with the performance but more with relation with the 
action that it creates DATE OF UPDATE : 03/11/2022


*/


/*
    how to use it , please falow the examples below.
              
              ________________________________________________________________________
              Get.Green("This is a secrure passwor of 16 digits "+Password.Secure(16));
              Get.Yellow("This is a Default Password of 9 digits "+Password.Secure());
              Get.Green("This is a Secure Pin of 16 digits  "+Password.Pin(16));
              Get.Yellow("This is a Secure Pin of 4 digits  "+Password.Pin());
              ________________________________________________________________________  
    
    
    
*/
using System;
using System.Text;
using System.Threading;
using QuickTools.QColors;
namespace QuickTools.QCore
{






    /*

    */

    /// <summary>
    /// The class new it is the one who will containe multiple methodthat will handle new random data 
    /// The name was changed due to making more sence if is called like 
    /// and you know what i will create  another class just because 
    /// that could be called on the same maner 
    /// </summary>
    public class IRandom
    {



        /// <summary>
        /// Contains the password Generated 
        /// </summary>
        public static string Generated = null;


        /// <summary>
        /// Array Of Words LowerCase
        /// </summary>
        public static readonly char[] LowerCase =
  { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
'n',
      'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'
      };

        /// <summary>
        /// Array Of Words Upercase
        /// </summary>
        public static readonly char[] UpperCase =
  { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
'N',
      'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
      };
        /// <summary>
        /// Array Of Symbols
        /// </summary>
        public static readonly char[] Symbols =
        { '!', '@', '%', '^', '&', '*', '=', '?', '.', ')', '(', '_', '+',
'-', '*', '/',
      '+','`','~'
      };

        /// <summary>
        /// Contains all the chars from Uppoercase ,lowercases and symbols 
        /// </summary>
        public static readonly Char[] Chars = {'!', '@', '%', '^', '&', '*', '=', '?', '.', ')', '(', '_', '+',
'-', '*', '/',
      '+','`','~','0', '1', '2', '3','4','5','6','7','8','9','A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
'N',
      'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z','a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
'n',
      'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'
      };



        /// <summary>
        /// Returns a Random char it could be anything from a letter , number or a symbol
        /// </summary>
        /// <value>The random char.</value>
        public static Char RandomChar => IRandom.Chars[IRandom.RandomInt(0, IRandom.Chars.Length)]; 

        /// <summary>
        /// Contains an array of all the numbers allwed on the  IRandom
        /// </summary>
        public static readonly int[] Numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        /*
           //Lower 26
           //UpperCase 26
           //Symbols 14
           // Numbers 10 
         */

        // this is the random selector 
   
        /// <summary>
        /// Generate a Random Passord with a max 9 digits
        /// </summary>
        /// <returns>The password.</returns>
        public static string Password()
        {                        // this one will generate a minimum passowrd of 9 digits 
            StringBuilder password = new StringBuilder();
          

            // this will change the order of the password

            for (int PassWordLengh = 0; PassWordLengh < 9; PassWordLengh++)
            {
                if (!RandomOpen)
                {
                    rand = new Random();
                    RandomOpen = true;
                }
                int order = rand.Next(0, 4);
                switch (order)
                {
                    case 0:
                        password.Append(LowerCase[rand.Next(0, LowerCase.Length)]);
                        break;
                    case 1:
                        password.Append(UpperCase[rand.Next(0, UpperCase.Length)]);
                        break;
                    case 2:
                        password.Append(Symbols[rand.Next(0, Symbols.Length)]);
                        break;
                    case 3:
                        password.Append(Numbers[rand.Next(0, Numbers.Length)]);
                        break;
                    default:
                        password.Append(Numbers[rand.Next(0, Numbers.Length)]);
                        break;

                }
            }
            Generated = password.ToString().Replace(" ", "");
            return password.ToString().Replace(" ", "");
        }




        /// <summary>
        /// Password the specified passwordLenght and noSpecialSimbols.
        /// </summary>
        /// <returns>The password.</returns>
        /// <param name="passwordLenght">Password lenght.</param>
        /// <param name="noSpecialSimbols">If set to <c>true</c> no special simbols.</param>
        public static string Password(int passwordLenght, bool noSpecialSimbols)
        {                       // this one will generate a minimum passowrd of 9 digits 

            if (noSpecialSimbols == false)
            {
                return Password(passwordLenght);
            }


            string password = "";
            

            // this will change the order of the password

            for (int PassWordLengh = 0; PassWordLengh < passwordLenght; PassWordLengh++)
            {
                int order = rand.Next(0, 4);

                switch (order)
                {
                    case 0:
                        password += LowerCase[rand.Next(0, 26)];

                        break;
                    case 1:
                        password += UpperCase[rand.Next(0, 26)];
                        break;
                    case 2:
                        // password += Symbols[symbol.Next (0, 14)];
                        break;
                    case 3:
                        password += Numbers[rand.Next(0, 10)];
                        break;
                    default:
                        password += Numbers[rand.Next(0, 10)];
                        break;

                }
            }
            Generated = password.Replace(" ", "");
            return password.Replace(" ", "");
        }

        
        /// <summary>
        /// The random text counter.
        /// </summary>
        public static double RandomTextCounter = 0;
        /// <summary>
        /// Generat Randoms text completly chunked together useful to create random passwords or anything that requires a long string of text.
        /// </summary>
        /// <returns>The text.</returns>
        /// <param name="textLength">Text length.</param>
        public static string RandomText(double textLength)
        {                       // this one will generate a minimum passowrd of 9 digits 

            RandomTextCounter = 0;
            double passwordLenght = textLength;
            if (textLength <= 0)
            {
                textLength = 4;
            }

            StringBuilder password = new StringBuilder();
        

            // this will change the order of the password

            for (int PassWordLengh = 0; PassWordLengh < passwordLenght; PassWordLengh++)
            {
                int order = rand.Next(0, 4);

                if (!RandomOpen)
                {
                    rand = new Random();
                    RandomOpen = true;
                }
                switch (order)
                {
                    case 0:
                        password.Append(LowerCase[rand.Next(0, 26)]);

                        break;
                    case 1:
                        password.Append(UpperCase[rand.Next(0, 26)]);
                        break;
                    case 2:
                        // password += Symbols[symbol.Next (0, 14)];
                        break;
                    case 3:
                        password.Append(Numbers[rand.Next(0, 10)]);
                        break;
                    default:
                        password.Append(Numbers[rand.Next(0, 10)]);
                        break;

                }

                RandomTextCounter++;

                //double porcentage = (RandomTextCounter / textLength) * 1000;
                //Console.Title = $"Processing: {porcentage}%";
            }
            Generated = password.Replace(" ", "").ToString();
            return password.Replace(" ", "").ToString();
        }


        /// <summary>
        /// Randoms the text.
        /// </summary>
        /// <returns>The text.</returns>
        /// <param name="textLength">Text length.</param>
        /// <param name="callBack">Call back.</param>
        public static string RandomText(double textLength, Action callBack)
        {                       // this one will generate a minimum passowrd of 9 digits 

            RandomTextCounter = 0;
            double passwordLenght = textLength;
            if (textLength <= 0)
            {
                textLength = 4;
            }

            StringBuilder password = new StringBuilder();

            

            // this will change the order of the password

            for (int PassWordLengh = 0; PassWordLengh < passwordLenght; PassWordLengh++)
            {
                int order = rand.Next(0, 4);
                if (!RandomOpen)
                {
                    rand = new Random();
                    RandomOpen = true;
                }
                switch (order)
                {
                    case 0:
                        password.Append(LowerCase[rand.Next(0, 26)]);

                        break;
                    case 1:
                        password.Append(UpperCase[rand.Next(0, 26)]);
                        break;
                    case 2:
                        // password += Symbols[symbol.Next (0, 14)];
                        break;
                    case 3:
                        password.Append(Numbers[rand.Next(0, 10)]);
                        break;
                    default:
                        password.Append(Numbers[rand.Next(0, 10)]);
                        break;

                }

                RandomTextCounter++;
                callBack();
                //double porcentage = (RandomTextCounter / textLength) * 1000;
                //Console.Title = $"Processing: {porcentage}%";
            }
            Generated = password.Replace(" ", "").ToString();
            return password.Replace(" ", "").ToString();
        }


        /// <summary>
        /// Password the specified passwordLenght.
        /// </summary>
        /// <returns>The password.</returns>
        /// <param name="passwordLenght">Password lenght.</param>
        public static string Password(int passwordLenght)
        {                       // this one will generate a minimum passowrd of 9 digits 

            string password = "";
           

            // this will change the order of the password

            for (int PassWordLengh = 0; PassWordLengh < passwordLenght; PassWordLengh++)
            {
                if (!RandomOpen)
                {
                    rand = new Random();
                    RandomOpen = true;
                }
                int order = rand.Next(0, 4);

                switch (order)
                {
                    case 0:
                        password += LowerCase[rand.Next(0, 26)];

                        break;
                    case 1:
                        password += UpperCase[rand.Next(0, 26)];
                        break;
                    case 2:
                        password += Symbols[rand.Next(0, 14)];
                        break;
                    case 3:
                        password += Numbers[rand.Next(0, 10)];
                        break;
                    default:
                        password += Numbers[rand.Next(0, 10)];
                        break;

                }
            }
            Generated = password.Replace(" ", "");
            return password.Replace(" ", "");
        }



        /// <summary>
        /// The pin generated
        /// </summary>
        public static int pin;
        /// <summary>
        /// This Method create a random pin of 4 digits and return it 
        /// </summary>
        /// <returns>The pin.</returns>
        public static int Pin()
        {
            string password = "".Replace(" ", "");

            // this will change the order of the password

            for (int pin = 0; pin < 4; pin++)
            {
                if (!RandomOpen)
                {
                    rand = new Random();
                    RandomOpen = true;
                }
                password += Numbers[rand.Next(0, 9)];
            }
            pin = int.Parse(password);

            return int.Parse(password);
        }
        /// <summary>
        /// Create a pin of the specified length.
        /// </summary>
        /// <returns>The pin.</returns>
        /// <param name="Level">Level.</param>
        public static string Pin(int Level)
        {
            if (Level <= 0)
            {

                return "Invalid pin length";
            }
            if (!RandomOpen)
            {
                rand = new Random();
                RandomOpen = true;
            }
            string password = "".Replace(" ", "");

            // this will change the order of the password

            for (int pin = 0; pin < Level; pin++)
            {
                if (!RandomOpen)
                {
                    rand = new Random();
                    RandomOpen = true;
                }

                password += Numbers[rand.Next(0, 9)];
            }

            return password;
        }







        // public static string RowBytes = null;// dismmissed due to being extremedly slow 
        private static StringBuilder RowBytes = new StringBuilder();
        /// <summary>
        /// Create a Random Byte Array of the specified length 
        /// and return it back on a byte array 
        /// </summary>
        /// <returns>The byte array.</returns>
        /// <param name="arrayLength">Array length.</param>
        static public byte[] RandomByteArray(int arrayLength)
        {

            // initialize an array to store the bytes later 
            byte[] array = new byte[arrayLength];
            //RowBytes = ""; //making sure that the RowBytes are empty 
            // loop to full the array based on the Length
            for (int value = 0; value < array.Length; value++)
            {
                if (!RandomOpen)
                {
                    rand = new Random();
                    RandomOpen = true;
                }

                int min = 0;
                int max = 250;
                // create a random number based on the 
                // size allowed for a byte 
                int number = rand.Next(min, max);
                // converting the number to bytes 
                byte finalNumber = Convert.ToByte(number);
                // adding the bytes 
                array[value] = finalNumber;
                //RowBytes.Append(array[value] + ",");
                //RowBytes += array[value]+","; 
            }
            return array;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="arrayLength"></param>
        /// <param name="printStatus"></param>
        /// <returns></returns>
        static public byte[] RandomByteArray(int arrayLength, bool printStatus)
        {

            // initialize an array to store the bytes later 
            byte[] array = new byte[arrayLength];
            //RowBytes = ""; //making sure that the RowBytes are empty 
            // loop to full the array based on the Length
            Thread a, b;
            int half, total, goal;
            string sta, sta2; 
            
            total = arrayLength; 
            half = total / 2;
            goal = total;
           // current = 0;
            sta = null;
            sta2 = null;
            a = new Thread(() => {

                for (int value = 0; value < half; value++)
                {
                    if (!RandomOpen)
                    {
                        rand = new Random();
                        RandomOpen = true;
                    }
                    int min = 0;
                    int max = 250;
                    // create a random number based on the 
                    // size allowed for a byte 
                    int number = rand.Next(min, max);
                    // converting the number to bytes 
                    byte finalNumber = Convert.ToByte(number);
                    // adding the bytes 
                    array[value] = finalNumber;
                    RowBytes.Append(array[value] + ",");
                    //RowBytes += array[value]+","; 
                    if (printStatus == true)
                    {
                        sta = Get.Status(value, arrayLength);
                    }
                }
            });
            b = new Thread(() => {
                for (int value = half; value < total; value++)
                {
                    if (!RandomOpen)
                    {
                        rand = new Random();
                        RandomOpen = true;
                    }
                    int min = 0;
                    int max = 250;
                    // create a random number based on the 
                    // size allowed for a byte 
                    int number = rand.Next(min, max);
                    // converting the number to bytes 
                    byte finalNumber = Convert.ToByte(number);
                    // adding the bytes 
                    array[value] = finalNumber;
                    //RowBytes.Append(array[value] + ",");
                    //RowBytes += array[value]+","; 
                    if (printStatus == true)
                    {
                        sta2 = Get.Status(value, arrayLength);
                    }
                }
               
            });
            a.Start();
            b.Start();
            while (a.IsAlive && b.IsAlive)
            {
                if (printStatus == true) Get.Green($"Status:   Thread A: {sta} Thread B: {sta2}");
                Thread.Sleep(1000); 
            }
            return array;
        }

        /*
            this fallows the same comsept from the one in the top
            the only diffrents are that 
            3 of the properties are injected or pass as a parameters
            arrayLength
            minimumRange
            maximumRange
            which change the size of the array wanted and also 
            the range of each digits 
        */

        /// <summary>
        /// Create a random byte array and allow you to costumice the limits of the random numbers
        /// that will be into it 
        /// </summary>
        /// <returns>The byte array.</returns>
        /// <param name="arrayLength">Array length.</param>
        /// <param name="minimumRange">Minimum range.</param>
        /// <param name="maximumRange">Maximum range.</param>
        static public byte[] RandomByteArray(int arrayLength, int minimumRange, int maximumRange)
        {
            byte[] array = new byte[arrayLength];
            // RowBytes = ""; //making sure that the RowBytes are empty 



            for (int value = 0; value < array.Length; value++)
            {
                if (!RandomOpen)
                {
                    rand = new Random();
                    RandomOpen = true;
                }
                int min = minimumRange;
                int max = maximumRange;

                int number = rand.Next(min, max);
                byte finalNumber = Convert.ToByte(number);

                array[value] = finalNumber;
                // RowBytes += array[value]+","; 
            }

            return array;
        }



        private static bool RandomOpen = false;
        private static Random rand;

        /// <summary>
        /// Create a random number based on the rules that are passed 
        /// and retun it 
        /// </summary>
        /// <returns>int value</returns>
        /// <param name="from">From.</param>
        /// <param name="until">Until.</param>
        public static int RandomInt(int from, int until)
        {
            if (from  >  until)
            {
                 throw new Exception("Imposible Operation \n\n" + $"The Values MUST BE ON THE FALLOWING StartValue < EndValue AND RESPECTING THE MAXIMUM VALUE OF INTENGER VALUE");
            }

            // string password = "".Replace(" ", "");
            if(RandomOpen == false)
            {
                RandomOpen = true;
                rand = new Random();
            }

            int number = rand.Next(from, until);


            return number;
        }



        // this generate a random byte 
        // between 0 to 250 
        // which could be use to create a 
        // key 

        /// <summary>
        /// it generate a random byte from 0 to 250
        /// and it uses the Random.Next(min,max)
        /// under it for it to work 
        /// </summary>
        /// <returns>Single Byte</returns>
        static public byte RandomByte()
        {
            if (!RandomOpen)
            {
                 rand = new Random();
                 RandomOpen = true; 
            }
            int min = 0;
            int max = 250;

            int number = rand.Next(min, max);
            byte finalNumber = Convert.ToByte(number);
            return finalNumber;

        }
        /// <summary>
        /// This  hold the key of 16 bits already generated
        /// by the RandomByteKey() generator 
        /// </summary>
        public static byte[] KeyGenerated = IRandom.RandomByteKey();

        /*
              This method generate a 16 bits
              key and it is sored either in the array 
              or is stored in a keys.secure file 
        */
        /// <summary>
        /// Randoms the byte key generate a random byte key 
        /// that could be used for encrypting and it has a 16 bits length
        /// </summary>
        /// <returns>The byte key.</returns>
        public static byte[] RandomByteKey()
        {
            byte[] key = new byte[16];

            for (int index = 0; index < key.Length; index++)
            {
                key[index] = RandomByte();
            }
            KeyGenerated = key;
            return key;
        }
        /// <summary>
        /// Randoms the byte key this works on the same way than RandomByteKey()
        /// but if it is passed as argument true like RandomByteKey(true)
        /// it will create a file and it will save it under the data/qt/secure.key
        /// and on this version it DOES NOT ENCRYPT IT  so it has to be manually 
        /// encrypted .
        /// </summary>
        /// <returns>byte[] array </returns>
        /// <param name="autoSave">If set to <c>true</c> auto save.</param>
         static byte[] RandomByteKey(bool autoSave)
        {
            // if is not added the bool type will just return 
            // a full of 0 byes
            byte[] key = new byte[16];

            //fill the keys with a random byte
            for (int index = 0; index < key.Length; index++)
            {
                key[index] = RandomByte();
            }
            KeyGenerated = key;

            //if autosave == true save the key 
            // location data/qt/secure.key
            if (autoSave == true)
            {
                //Get.SaveKey();

            }

            // return the key 
            return key;
        }
        /*
        SaveKey 
        basically is incharge of 
        making sure that the thata is saved 
        inside QuickTools data folder 
        so if is not created 
        it will create one to make sure that is saved
        properly 

              */








    }
}

