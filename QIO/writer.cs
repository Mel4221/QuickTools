using System;
using System.IO;
using System.Text;
using QuickTools.QColors;
using QuickTools.QConsole;
namespace QuickTools.QIO
{
      /// <summary>
      /// Write content into files
      /// </summary>
      public class Writer:IDisposable
            {
            /*
             * 12/07/2022 i added a new constructor around here                        
                Modified Date: 07/21/2022
                Editor : https://www.onlinegdb.com/fork/ss9o2_vdl
                So lets start by i hate documenting but i know that without it i would never be able
                to keep up with the changes but the type of IDE that im using online does not help at 
                all and by mistake i deleted information that i was not suposed to delete , so i had to 
                try again on a prevuse back up , so lets do this again 
                Writer class is an abtraction of StreamWriter and FileStream which are useful to quckly create a file 
                there are 2 ways of using CreateFile since you can just pass the name of the file and it will create it
                it also provides the option for you to pass  the data too , WriteFile also has an alert just in case if you would like
                to do not override data so it will comfirm  it with the end user
            */


            /// <summary>
            /// Writes the content passed into a file
            /// </summary>
            /// <param name="file">File.</param>
            /// <param name="data">Data.</param>
            public static void WriteFile(string file,object data)
                        {
                            
                            // for testing porpuses: 
                            //Get.Box(path); 
                            if(File.Exists(file) == true){
                                using(StreamWriter writer = new StreamWriter(file))
                                {
                                           writer.WriteLine(data); 
                                }
                            }else{
                              
                                    Options.Label = "The current File does not Exist : '"+file+"' Would you like to create it ?";    
                                    var option = new Options(true||false);
                                     
                                    if(option.Pick() == 0)
                                    {
                                        CreateFile(file,data); 
                                    }
                            }
                        }
            /// <summary>
            /// Writes the data into a file and if the last argument is true will Oveerride the content .
            /// </summary>
            /// <param name="file">File.</param>
            /// <param name="data">Data.</param>
            /// <param name="CanOverWrite">If set to <c>true</c> overrite or create.</param>
            public static void WriteFile(string file, object data, bool CanOverWrite)
            {
                  if (CanOverWrite == true)
                  {
                        // for testing porpuses: 
                        //Get.Box(path); 
                        if (File.Exists(file) == true)
                        {
                              using (StreamWriter writer = new StreamWriter(file))
                              {
                                    writer.WriteLine(data);
                              }
                        }
                        else
                        {

                              //      Get.Write("Overrided Was Process");
                              /*

                                    Create file already contains a validation method
                                    if the file already exist so it is not needed to add a new one                                    

                              */
                                    CreateFile(file, data);

                        }
                  }
            }








            /// <summary>
            /// This method writes to a file an entired array of type string
            /// </summary>
            /// <param name="fileName">File name.</param>
            /// <param name="array">Array.</param>
            public static void WriteArray( string fileName ,string[] array)
            {
                  StringBuilder content = new StringBuilder(); 
                  for(int value= 0; value <array.Length; value++)
                  {
                        content.Append(array[value]+",");
                  }
                  Writer.Write(fileName, content.ToString()); 
            }

            /// <summary>
            /// This method writes to a file an entired array of type int
            /// </summary>
            /// <param name="fileName">File name.</param>
            /// <param name="array">Array.</param>
            public static void WriteArray(string fileName, int[] array)
            {
                  StringBuilder content = new StringBuilder();
                  for (int value = 0; value < array.Length; value++)
                  {
                        content.Append(array[value] + ",");
                  }
                  Writer.Write(fileName, content.ToString());
            }



            /// <summary>
            /// Writs the given buffer to the file 
            /// </summary>
            /// <param name="file">File.</param>
            /// <param name="buffer">Buffer.</param>
            public static void IWrite(string file, byte[] buffer)
            {
                  if (File.Exists(file) == true)
                  {
                        File.Delete(file);
                  }
                  using (FileStream fs = new FileStream(file, FileMode.Create, FileAccess.Write))
                  {
                        fs.Write(buffer, 0, buffer.Length);
                  }
            }



            /// <summary>
            /// This method writes to a file an entired array of type byte
            /// </summary>
            /// <param name="fileName">File name.</param>
            /// <param name="array">Array.</param>
            public static void WriteArray(string fileName, byte[] array)
            {
                  StringBuilder content = new StringBuilder();
                  for (int value = 0; value < array.Length; value++)
                  {
                        content.Append(array[value] + ",");
                  }
                  Writer.Write(fileName, content.ToString());
            }
            /// <summary>
            /// Creates a file and write the content that is passed.
            /// </summary>
            /// <param name="fileName">File name.</param>
            /// <param name="data">Data.</param>
            public static void CreateFile(string fileName,object data)
                        {
                                
                                try{
                                    if(File.Exists(fileName) == false){
                                        
                                  using(FileStream fs = File.Create(fileName)){}
                                   WriteFile(fileName,data); 
                                    }else{
                                        
                                        
                                Options.Label = "This File Exist '"+fileName+"' Would you like to override it?"; 
                                var app = new Options(true); 
                                        
                                       
                                       if(app.Pick() == 0)
                                       {
                                           WriteFile(fileName,data); 
                                       }
                                    }
                                }catch(Exception e)
                                {
                                    Color.Yellow("This file could not be Wreated or Written, more details : "+e); 
                                }
                        }
   

                        /// <summary>
                        /// Creates the file passed as an argument
                        /// </summary>
                        /// <returns>The file.</returns>
                        /// <param name="fileName">File name.</param>
                        public static string CreateFile(string fileName)
                        {
                                try{
                                  using(FileStream fs = File.Create(fileName)){}
                        return fileName;
                                }catch(Exception e)
                                {
                                    Color.Yellow("This file could not be created , more details : "+e);
                        return null; 
                                }
                        }
            /// <summary>
            /// Write the content on a file and this use the FileStream on FileMode.Create and FileAccess.Write
            /// </summary>
            /// <param name="file">File.</param>
            /// <param name="data">Data.</param>
            public static void Write(string file, object data)
            {

                  using (FileStream fs = new FileStream(file, FileMode.Create, FileAccess.Write))
                  {
                        if (fs.CanWrite)
                        {
                              byte[] buffer = Encoding.ASCII.GetBytes(data.ToString());
                              fs.Write(buffer, 0, buffer.Length);
                        }
                  }
            }


            private string fileName = null;
            private string fileContent = null; 
            /// <summary>
            /// Allows you to initialize the writer with the value of the file name and the content of it 
            /// </summary>
            /// <param name="file">File.</param>
            /// <param name="contet">Contet.</param>
            public Writer(string file,string contet)
            {
                  fileName = file;
                  fileContent = contet; 
            }


            /// <summary>
            /// Allows you to write the file with the content that was specified on the Inizialation 
            /// </summary>
            public void Write()
            {
                  if(fileName!= null && fileContent != null)
                  {
                        Writer.Write(fileName,fileContent); 
                  }
            }

            #region IDisposable Support
            private bool disposedValue = false; // To detect redundant calls


            /// <summary>
            /// Dispose the specified disposing.
            /// </summary>
            /// <param name="disposing">If set to <c>true</c> disposing.</param>
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
            // ~Writer() {
            //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            //   Dispose(false);
            // }
            /// <summary>
            /// Releases all resource used by the <see cref="T:QuickTools.Writer"/> object.
            /// </summary>
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