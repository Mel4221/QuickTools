using System;
using System.Text;
using System.Collections.Generic;
namespace QuickTools
{

      /// <summary>
      /// This class basically dencrypt the files and contaings 
      /// 2 Methods 1  that read the encrypted that from the file
      /// then it will decrypt the data and will write it back to the file
      /// </summary>
      public class Decrypter
      {

            /// <summary>
            /// This Member Can not be Accest to due to 
            /// it main funtionality is only to read the data from
            /// the file and converted in a way that it can be 
            /// desencrypted.
            /// </summary>
            /// <returns>The list.</returns>
            /// <param name="file">File.</param>
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
                        //Console.Title = "Working With Task A: Byte Size :"+RowText.Length;

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


            /// <summary>
            /// This method basically works by passing the fileto it 
            /// as the first argument then the password wich would end up
            /// being written to the file passed in first place after desencrypting 
            /// the file. 
            /// </summary>
            /// <param name="fileToDecrypt">File to decrypt.</param>
            /// <param name="FilePassword">File password.</param>
            public static void DecryptFile(string fileToDecrypt,object FilePassword)
            {

                  string filePassword = FilePassword.ToString(); 
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
                             // Console.Title = "Working With Task B :"+ value; 

                              RowData.Add(Convert.ToByte(Convert.ToDouble(data[value]) / hash));
                        }

                        byte[] finalData = new byte[RowData.Count];
                        for (int val = 0; val < RowData.Count; val++)
                        {
                              //title
                            //  Console.Title = "Working With Task B :" + val;
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
