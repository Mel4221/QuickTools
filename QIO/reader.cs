using System;
using System.IO;
using System.Text;
using QuickTools.QColors; 
using System.Collections.Generic;
using QuickTools.QCore;

namespace QuickTools.QIO
{
      /// <summary>
      /// This class Read Files content
      /// </summary>
      public class Reader:IDisposable
      {
       

            /// <summary>
            /// Holds the empty values in an array 
            /// </summary>
            public static double EmptySpacesCount = 0;

            /// <summary>
            /// Holds a row list of the string text readed by the reader
            /// </summary>
            public static StringBuilder RowData = new StringBuilder();

            /// <summary>
            /// Holds a list of the data readed by the reader 
            /// </summary>
            public static List<string> ListData = new List<string>();


            /// <summary>
            /// Holds the bytes readed by the reader 
            /// </summary>
            public static byte[] BytesData;

            /// <summary>
            /// The current opration.
            /// </summary>
            public static int CurrentOpration;
            /// <summary>
            /// The current goal.
            /// </summary>
            public static int CurrentGoal;

            /// <summary>
            /// Reads bytes what could be considered a row array debided by semicollon that is saved on a file
            /// for example if you get a list of numbers written on a file such as {1,2,3,4} you could get the value from the file 
            /// stright to a byte[] array   
            /// </summary>
            /// <returns>The stored bytes.</returns>
            /// <param name="file">the files that contains the bytes.</param>
            public static byte[] ReadStoredBytes(string file)
            {


                  if (file == null || file == "")
                  {
                        throw new Exception($"Invalid file input ");
                  }

                  if (!File.Exists(file))
                  {
                        throw new Exception($"The file {file} does not exsit or it was not founded");
                  }



             

                  List<object> dataList = new List<object>();
                  byte[] dataBytes;
                  RowData.Clear();
                  EmptySpacesCount = 0;
           


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

                              CurrentGoal = line.Length;
                              //Get.Wait(line);// for testing only  
                              //this will loop over the entired line
                              //to make sure that it takes only the
                              // numbers from it 
                              for (int Char = 0; Char < line.Length; Char++)
                              {
                                    CurrentOpration = Char; 
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

                                                      // RowData.Append(currentValue);  
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
                              RowData.Append(dataList[indexer] + ",");
                        }
                  }
                  catch (Exception e)
                  {
                        Color.Yellow("The Bytes where not on the correct format, more details :{ " + e + " }");
                  }
                  // passing values from the bytes readed                 
                  BytesData = dataBytes;
                  if (dataList.Count <= 0)
                  {
                        Color.Yellow("Not Valid bytes to read where found");
                  }
                  return dataBytes;


            }


            /// <summary>
            /// Files to byte array.
            /// </summary>
            /// <returns>The to byte array.</returns>
            /// <param name="fileName">File name.</param>
            public static byte[] FileToByteArray(string fileName)
            {
                  byte[] fileData = null;

                  using (FileStream fs = File.OpenRead(fileName))
                  {
                        using (BinaryReader binaryReader = new BinaryReader(fs))
                        {
                              fileData = binaryReader.ReadBytes((int)fs.Length);
                        }
                  }
                  return fileData;
            }


            /// <summary>
            /// Holds The buffer from IRead Method 
            /// </summary>
            public static byte[] Buffer;


           
            
            /// <summary>
            /// Read and array that is listed on a file and retursn a Generic.List 
            /// </summary>
            /// <returns>The array.</returns>
            /// <param name="file">File.</param>
            public static List<string> ReadArray(string file)
            {


                  if (file == null || file == "")
                  {
                        throw new Exception($"Invalid file input ");
                  }

                  if (!File.Exists(file))
                  {
                        throw new Exception($"The file {file} does not exsit or it was not founded");
                  }

                  List<string> dataList = new List<string>();
                  RowData.Clear();
                  EmptySpacesCount = 0;
           
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
                              CurrentGoal = line.Length;
                              for (int Char = 0; Char < line.Length; Char++)
                              {
                                    CurrentOpration = Char; 
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
                                                      RowData.Append(currentValue);
                                                      ListData.Add(currentValue); 
                                                      // RowData.Append(currentValue);  
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
        /// Read and array that is listed on a file and retursn a Generic.List 
        /// </summary>
        /// <param name="file"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string[] ReadArray(string file, char separator)
        {


            if (!File.Exists(file))
            {
                throw new Exception($"The file {file} does not exsit or it was not founded");
            }
            List<string> list = new List<string>();
            string text = Reader.Read(file);
            string temp = " ";
              
            for (int ch = 0; ch < text.Length; ch++)
            {


                if (text[ch] == separator)
                {
                    //Get.Wait(temp);
                    list.Add(temp);
                    temp = "";
                }
                if (text[ch] != separator)
                {

                 //   if (temp[temp.Length-1].ToString() !=  )
                    temp += text[ch];

                }

            }
            // removing extra spaces 
            

            return IConvert.ToType<string>.ToArray(list);

        }

        /// <summary>
        /// Read the entired file and returns the text from it 
        /// </summary>
        /// <returns>The file.</returns>
        /// <param name="file">File.</param>
        public static string ReadFile(string file)
            {
                  if(file == null || file == "")
                  {
                        throw new Exception($"Invalid file input "); 
                  }

                  if (!File.Exists(file))
                  {
                        throw new Exception($"The file {file} does not exsit or it was not founded"); 
                  }

                  string data = null;
                  using (StreamReader reader = new StreamReader(file))
                  {
                        data = reader.ReadToEnd();
                        RowData.Append(data);

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
                 
                  if (!File.Exists(file))
                  {
                        throw new Exception($"The file {file} does not exsit or it was not founded");
                  }

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

            private string file;
            private bool fileExist = false;
            /// <summary>
            /// Initializes a new instance of the <see cref="T:QuickTools.Reader"/> class.
            /// </summary>
            /// <param name="fileName">File name.</param>
            public Reader(object fileName)
            {

                  if (File.Exists(fileName.ToString()))
                  {
                        this.file = fileName.ToString();
                        fileExist = true;
                        return;
                  }
            }

            /// <summary>
            /// Read the file that has been spesified by the Constructur from Reader
            /// and returns the string from it 
            /// </summary>
            /// <returns>The read.</returns>
            public string Read()
            {
                  if(fileExist)
                  {
                        return Reader.Read(this.file); 
                  }
                  return null; 
            }

            #region IDisposable Support
            private bool disposedValue = false; // To detect redundant calls
            /// <summary>
            /// 
            /// </summary>
            /// <param name="disposing"></param>
            protected virtual void Dispose(bool disposing)
            {
                  if (!disposedValue)
                  {
                        if (disposing)
                        {
                              // TODO: dispose managed state (managed objects).
                        }

                        // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                        // TODO: set large fields to null.

                        disposedValue = true;
                  }
            }

            // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
            // ~Reader() {
            //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            //   Dispose(false);
            // }

                  /// <summary>
                  /// Releases all resource used by the <see cref="T:QuickTools.Reader"/> object.
                  /// </summary>
                  /// <see cref="T:QuickTools.Reader"/> so the garbage collector can reclaim the memory that the
            public void Dispose()
            {
                  // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
                  Dispose(true);
                  // TODO: uncomment the following line if the finalizer is overridden above.
                  // GC.SuppressFinalize(this);
            }
            #endregion


      }
}