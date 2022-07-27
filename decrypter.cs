using System;
using System.Text;
using System.Collections.Generic;
namespace QuickTools
{
      public class Decrypter
      {
            // Decrypting 
            public static void DecryptFile(string fileToDecrypt,object filePassword)
            {

                // Writer.Write(fileToDecrypt, LowD.DecryptFile(fileToDecrypt));
                  Reader.ReadArray(fileToDecrypt);
                  List<string> data = Reader.Stored.ListData;  
                  double hash = filePassword.GetHashCode();
                  List<byte> RowData = new List<byte>(); 
                  for(int value=0; value<data.Count; value++)
                  {
                        RowData.Add(Convert.ToByte(Convert.ToDouble(data[value]) / hash)); 
                  }

                  byte[] finalData = new byte[RowData.Count]; 
                  for(int val = 0; val<RowData.Count; val++)
                  {
                        finalData[val] = RowData[val]; 
                  }
                // Get.Wait(Encoding.ASCII.GetString(finalData)); 
                  Writer.Write(fileToDecrypt, Encoding.ASCII.GetString(finalData)); 
                  

            }     
      }

}
