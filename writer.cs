using System;
using System.IO;
using System.Text;
using System.Collections.Generic; 
namespace QuickTools
{       
      /// <summary>
      /// Write content into files
      /// </summary>
            public class Writer
            {
                        /*
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
                                     
                                    if(option.Pick() == 1)
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
            /// Creates the file.
            /// </summary>
            /// <param name="fileName">File name.</param>
                        public static void CreateFile(string fileName)
                        {
                                try{
                                  using(FileStream fs = File.Create(fileName)){}
                                }catch(Exception e)
                                {
                                    Color.Yellow("This file could not be created , more details : "+e); 
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
      }
      
}