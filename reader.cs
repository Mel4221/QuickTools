using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
namespace QuickTools
{

      public class Reader
      {

            public static class Stored
            {
                  public static StringBuilder RowData = new StringBuilder();
                  public static List<string> ListData = new List<string>();
                  public static byte[] BytesData;
            }

            /*
                This only provides the Bytes thar were
                stored in a string file 
            */

            public static StringBuilder RowData = new StringBuilder();
            public static double EmptySpacesCount = 0;



            public static byte[] ReadStoredBytes(string file)
            {




                  List<object> dataList = new List<object>();
                  byte[] dataBytes;
                  Stored.RowData.Clear();

                  EmptySpacesCount = 0;
                  if (file.Length <= 0)
                  {

                        try
                        {
                              // just to try to throw an exception
                        }
                        finally
                        {
                              throw new ArgumentException();
                        }

                  }
                  using (var reader = new StreamReader(file))
                  {
                        /*
                            // this is supposed to reade 
                            // either an array of data 
                            // or  any data in number decimal 
                            // format and it has to return it in 
                            // an array format aswell
                        */
                        //bool isNext = false;//
                        string line;
                        string currentValue = "";
                        while (reader.Peek() >= 0)
                        {
                              line = reader.ReadLine();
                              //Get.Wait(line);// for testing only  
                              //this will loop over the entired line
                              //to make sure that it takes only the
                              // numbers from it 
                              for (int Char = 0; Char < line.Length; Char++)
                              {
                                    switch (Get.IsNumber(line[Char]))
                                    {
                                          case true:
                                                currentValue += line[Char];
                                                break;

                                          case false:
                                                if (currentValue != "")
                                                {
                                                      EmptySpacesCount++;
                                                      dataList.Add(currentValue);

                                                      // Stored.RowData.Append(currentValue);  
                                                      currentValue = "";

                                                      // Get.Wait(data[Char]); 
                                                }
                                                break;
                                    }
                                    //Get.Green(data[Char]); 
                              }

                              // Get.Green(data[0]); 
                        }


                  }

                  dataBytes = new byte[dataList.Count];
                  // pass all the values to the dataBytes array 
                  try
                  {
                        for (int indexer = 0; indexer < dataBytes.Length; indexer++)
                        {
                              dataBytes[indexer] = Convert.ToByte(dataList[indexer]);
                              Stored.RowData.Append(dataList[indexer] + ",");
                        }
                  }
                  catch (Exception e)
                  {
                        Color.Yellow("The Bytes where not on the correct format, more details :{ " + e + " }");
                  }
                  // passing values from the bytes readed                 
                  Stored.BytesData = dataBytes;
                  if (dataList.Count <= 0)
                  {
                        Color.Yellow("Not Valid bytes to read where found");
                  }
                  return dataBytes;


            }


                  /*
                   Array Reader 
                  */


            public static List<string> ReadArray(string file)
            {




                  List<string> dataList = new List<string>();
                        
                  Stored.RowData.Clear();
                  EmptySpacesCount = 0;
                  if (file.Length <= 0)
                  {

                        try
                        {
                              // just to try to throw an exception
                        }
                        finally
                        {
                              throw new ArgumentException();
                        }

                  }
                  using (var reader = new StreamReader(file))
                  {
                        /*
                            // this is supposed to reade 
                            // either an array of data 
                            // or  any data in number decimal 
                            // format and it has to return it in 
                            // an array format aswell
                        */
                        //bool isNext = false;//
                        string line;
                        string currentValue = "";
                        while (reader.Peek() >= 0)
                        {
                              line = reader.ReadLine();
                              //Get.Wait(line);// for testing only  
                              //this will loop over the entired line
                              //to make sure that it takes only the
                              // numbers from it 
                              for (int Char = 0; Char < line.Length; Char++)
                              {
                                    switch (Get.IsNumber(line[Char]))
                                    {
                                          case true:
                                                currentValue += line[Char];
                                                break;

                                          case false:
                                                if (currentValue != "")
                                                {
                                                      EmptySpacesCount++;
                                                      dataList.Add(currentValue);
                                                      Stored.RowData.Append(currentValue);
                                                      Stored.ListData.Add(currentValue); 
                                                      // Stored.RowData.Append(currentValue);  
                                                      currentValue = "";

                                                      // Get.Wait(data[Char]); 
                                                }
                                                break;
                                    }
                                    //Get.Green(data[Char]); 
                              }

                              // Get.Green(data[0]); 
                        }


                  }

         
                  return dataList;


            }

            public static string ReadFile(string file)
            {
                  string data = null;
                  using (StreamReader reader = new StreamReader(file))
                  {
                        data = reader.ReadToEnd();
                        Stored.RowData.Append(data);

                  }

                  return data;
            }



            public static double ReadLength = 0000; 
            public static string Read(string file)
            {
                  string data = null;
                  using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
                  {
                        if(fs.CanRead)
                        {
                              byte[] buffer = new byte[fs.Length];
                              int bufferData = fs.Read(buffer, 0, buffer.Length);
                              data = Encoding.ASCII.GetString(buffer,0,bufferData);
                        }
                  }


                  ReadLength = data.Length; 
                  return data; 
            }

      }
}