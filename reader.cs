using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
namespace QuickTools
{
      /// <summary>
      /// This class Read Files content
      /// </summary>
      public class Reader
      {
            /// <summary>
            /// This class save the Data from the Reader
            /// </summary>
            public static class Stored
            {
                  /// <summary>
                  /// This Contain the Row Data into an stringBuilder
                  /// </summary>
                 public static StringBuilder RowData = new StringBuilder();
                  /// <summary>
                  /// contain The list data.
                  /// </summary>
                  public static List<string> ListData = new List<string>();
                  /// <summary>
                  /// The bytes data.
                  /// </summary>
                  public static byte[] BytesData;
            }

            /*
                This only provides the Bytes thar were
                stored in a string file 
            */
            /// <summary>
            /// Contains the row data readed 
            /// </summary>
            public static StringBuilder RowData = new StringBuilder();
            /// <summary>
            /// The empty spaces count in a file
            /// </summary>
            public static double EmptySpacesCount = 0;


            /// <summary>
            /// Reads bytes stored into a file and return it 
            /// </summary>
            /// <returns>The stored bytes.</returns>
            /// <param name="file">the files that contains the bytes.</param>
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

                  /// <summary>
                  /// Read and array that is listed on a file and retursn a Generic.List 
                  /// </summary>
                  /// <returns>The array.</returns>
                  /// <param name="file">File.</param>
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
            /// <summary>
            /// Read the entired file and returns the text from it 
            /// </summary>
            /// <returns>The file.</returns>
            /// <param name="file">File.</param>
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


            /// <summary>
            /// Contais the length of the file that is being readed 
            /// this uses the FileStream and is an astraction that has the FileMode.Open , and FileAccess.Read
            /// </summary>
            public static double ReadLength = 0000; 
           /// <summary>
           /// Read a file and return the string data listed in it 
           /// </summary>
           /// <returns>The read.</returns>
           /// <param name="file">File.</param>
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