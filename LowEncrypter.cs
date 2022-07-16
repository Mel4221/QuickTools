using System;
using System.Collections.Generic;
using System.Text;
namespace QuickTools
{

    public class LowEncrypter
    {
        public static List<int> Data = new List<int>();
        public static byte[] DataBytes; 
        public static int DataLength = 0000;
        public static int DataHash = 0000;
        public static string EncryptFile(string onlyText)
        {
            // this are the main variables needed 
           // int password = passwordInput.GetHashCode();
            //DataHash = data.GetHashCode(); // thiw will leave the hash cod exposused for other uses 
            //int salt = DataHash * password; // this will add some securyty features 
                                            //Get.Yellow(salt); 
            byte[] dataBytes = Encoding.ASCII.GetBytes(onlyText);
            byte[] switching = new byte[dataBytes.Length];
            DataLength = dataBytes.Length;
            int back = DataLength;//this will be used to switch the order
            List<double> finalData = new List<double>(); // list of data encrypted 

            // this will change the order from front to the back
            // then it will be elevated to the power of 2
            for (int value = 0; value < dataBytes.Length; value++)
            {

                switching[value] = dataBytes[back - 1];// this will switch the order of the bytes
                switching[value] = Convert.ToByte(switching[value]^8);// thiw will elveate it to the power of 2
                back--;// decrementing the value of back to change the order of the bytes 
            }


        
            foreach(double text in finalData)
            {
                Console.WriteLine(text); 
            }



            // foreach(int values in finalData) 
            //  Console.Write(values+","); 
            DataBytes = new byte[DataLength]; // initialaize the bytes
            DataBytes = switching; // passing the values to a global variable
            //Console.WriteLine(Encoding.ASCII.GetString(switching)); //testing
            //Encrypter.Data = finalData;

            return Encoding.ASCII.GetString(switching); 
        }

    }

}