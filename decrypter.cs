using System;
using System.Text;
using System.Collections.Generic;
namespace QuickTools
{
      public class Decrypter
      {
            // Decrypting 
            public static void DeComplex(List<object> data, object password,int initialLength)
            {
                  //  pass = "SecurePaSecurePass1234SecurePass1234SecurePass1234SecurePass1234SecurePass1234SecurePass1234SecurePass1234ss1234"; 
                  double hashPass = password.GetHashCode();
                  byte[] dataDecrypted = new byte[initialLength];


                  // Get.Alert(dataDecrypted.Length); 
                  for (int value = 0; value < dataDecrypted.Length; value++)
                  {
                        dataDecrypted[value] = Convert.ToByte(Convert.ToDouble(data[value].ToString()) / hashPass);

                  }
                  Color.Yellow(Encoding.ASCII.GetString(dataDecrypted));
            }
      }

}
