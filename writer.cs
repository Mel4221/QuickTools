using System;
using System.IO;
using System.Text;
using System.Collections.Generic; 
namespace QuickTools
{       
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
                                     
                                    if(option.Select() == 1)
                                    {
                                        CreateFile(file,data); 
                                    }
                            }
                        }

            public static void WriteFile(string file, object data, bool OverriteOrCreate)
            {
                  if (OverriteOrCreate == true)
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
                                    CreateFile(file, data);

                        }
                  }
            }


            public static void CreateFile(string fileName,object data)
                        {
                                
                                try{
                                    if(File.Exists(fileName) == false){
                                        
                                  using(FileStream fs = File.Create(fileName)){}
                                   WriteFile(fileName,data); 
                                    }else{
                                        
                                        
                                Options.Label = "This File Exist '"+fileName+"' Would you like to override it?"; 
                                var app = new Options(true||false); 
                                        
                                       
                                       if(app.Select() == 1)
                                       {
                                           WriteFile(fileName,data); 
                                       }
                                    }
                                }catch(Exception e)
                                {
                                    Color.Yellow("This file could not be Wreated or Written, more details : "+e); 
                                }
                        }
                        public static void CreateFile(string fileName)
                        {
                                try{
                                  using(FileStream fs = File.Create(fileName)){}
                                }catch(Exception e)
                                {
                                    Color.Yellow("This file could not be created , more details : "+e); 
                                }
                        }

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