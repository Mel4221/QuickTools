using System;
using System.Text;
using System.Collections.Generic;
namespace QuickTools
{
     public class Encrypter
      {
            public static List<object> SecureData = new List<object>();
            public static int InitialLength = 0;

            public static void EncryptFile(object data, object pass)
            {
                  byte[] dataBytes = Encoding.ASCII.GetBytes(data.ToString());
                  double passHash = pass.GetHashCode();
                  InitialLength = dataBytes.Length;
                  // Get.Alert("initial " + InitialLength);
                  List<object> dataEncrypted = new List<object>();

                  for (int value = 0; value < dataBytes.Length; value++)
                  {
                        dataEncrypted.Add(dataBytes[value] * passHash);
                        //dataEncrypted[value] = Convert.ToInt32(dataEncrypted[value]) * value; // not working 
                        //Console.Write(dataEncrypted[value] + " ");
                  }

                  SecureData = dataEncrypted;
            }
      }
}