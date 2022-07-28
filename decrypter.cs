using System;
using System.Text;
using System.Collections.Generic;
namespace QuickTools
{
      public class Decrypter
      {

            private static List<string> GetList(string file)
            {

                  //title
                  Console.Title = "Decrypting Started Please Wait";
                  Get.WaitTime(); 
                  try
                  {
                        // where the data will be stored 
                        List<string> data = new List<string>();
                        // getting the encrypted text 
                        string RowText = LowDecrypt.DecryptFile(Reader.Read(file));
                        // where the text will be temporally stored
                        StringBuilder currentValue = new StringBuilder();
                        // looping to get each value from the array 
                        //title
                        Console.Title = "Working With Task A: Byte Size :"+RowText.Length;

                        for (int value = 0; value < RowText.Length; value++)
                        {



                              switch (Get.IsNumber(RowText[value]))
                              {
                                    case true:
                                          currentValue.Append(RowText[value]);
                                          //Get.Wrong(currentValue[value]); 
                                          break;

                                    case false:

                                          data.Add(currentValue.ToString());
                                          //Color.Green(currentValue[value]); 
                                          currentValue.Clear(); 

                                          // Get.Wait(data[Char]); 

                                          break;
                              }
                        }

                        Console.Title = "Working With Task A Completed";
                        Get.WaitTime(); 
                        return data;
                  }
                  catch
                  {
                        throw new InvalidOperationException("The File To Decrypt Was not founded");
                  }
            }


            // Decrypting 
            public static void DecryptFile(string fileToDecrypt,object filePassword)
            {
                  try
                  {
                        
                        // Writer.Write(fileToDecrypt, LowD.DecryptFile(fileToDecrypt));
                        //Reader.ReadArray(LowDecrypt.DecryptFile(fileToDecrypt));
                        List<string> data = GetList(fileToDecrypt);
                        double hash = filePassword.GetHashCode();
                        List<byte> RowData = new List<byte>();

                        for (int value = 0; value < data.Count; value++)
                        {
                              //title
                              Console.Title = "Working With Task B :"+ value; 

                              RowData.Add(Convert.ToByte(Convert.ToDouble(data[value]) / hash - value));
                        }

                        byte[] finalData = new byte[RowData.Count];
                        for (int val = 0; val < RowData.Count; val++)
                        {
                              //title
                              Console.Title = "Working With Task B :" + val;
                              finalData[val] = RowData[val];

                        }

                        //finally gave me an error 
                        //  Color.Yellow("This is supposed to be clear Text : \n"+Encoding.ASCII.GetString(finalData)); 
                        Writer.WriteFile(fileToDecrypt, Encoding.ASCII.GetString(finalData));
                  }
                  catch
                  {
                        Color.Yellow("Incorrect Password"); 

                  }
            } 



               
      }




}
