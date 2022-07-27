using System;
using System.Text;
using System.Collections.Generic;
namespace QuickTools
{
     public class Encrypter
      {
            //public static List<object> SecureData = new List<object>();
            //public static int InitialLength = 0;// why do we need an initialLengeth ??? i mean it is nonsence 
            //public static StringBuilder RowData = new StringBuilder(); 
            //public static List<double> RowData = new List<double>(); 
            public static void EncryptFile(string fileToEncrypt, object filePassword)
            {
                  /*
                        basically this works on the current way 
                        it gets 2 parameters , the file that will 
                        be enprited and then the password 
                        and if the password fail the process will not be completed                        

                  */
                  byte[] dataBytes = Encoding.ASCII.GetBytes(Reader.Read(fileToEncrypt));
                  double hash = filePassword.GetHashCode();
                  List<double> dataEncrypted = new List<double>(); 
                  for (int value =0; value<dataBytes.Length; value++)
                  {
                        dataEncrypted.Add(dataBytes[value] * hash);
                         
                  }
                  StringBuilder str = new StringBuilder(); 
                  foreach(double val in dataEncrypted)
                  {
                        //RowData.Add(val);
                        str.Append(val + ",");
                  }
                  Writer.Write(fileToEncrypt,str.ToString());
            }
      }
}