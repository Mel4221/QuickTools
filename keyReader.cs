
using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;





namespace QuickTools
{
           public class KeyReader
           {            
                        public static byte[] KeyStored = new byte[16];
                        public static string StringKey = null;
                  
                            /*
                             using(var reader = new StreamReader(file))
                              {    
                                StKey;ringKey = reader.ReadLine(); 
                              }
                              return String 
                          */
                        
                        public static string  Parse(string file)
                        {
                            try{
                                // here we are trying to get the string of the file to get the 
                                // key for the file 
                                 using(var reader = new StreamReader(file))
                              {    
                                    StringKey =  reader.ReadLine(); 
                              }
                           //   Get.Green(); 
                           //   Get.Yellow(KeyReader.StringKey);
                              return StringKey;
                            }catch{
                                
                                    Get.NotFound(file); 
                             return "notFound";    
                            }
                           
                            
                        }
                        
                        
                        
                        // this will convert the key from an string 
                        // to a clear array suitable for the key desconmpretion
                    
                        public static byte[] GetKey(string file)
                        {
                            try{
                            // here we will parse the key    
                            if(Parse(file) != "notFound" )
                            {
                                    // variables 
                                    string key,fraction;
                                    int number,keySlot;
                                    //char divition;
                                    bool isNumber,isNext; 
                                    // this are all the variable needed 
                                    isNumber = false; 
                                    isNext = false;
                                    fraction = "";
                                    keySlot = 0; 
                                    key = StringKey; 
                                    // variables 
                                        // this is supposed to loop trhoug each character and 
                                        // determine if it will be able to be a number or not a number 
                  
                                                for(int i=0; i< key.Length; i++)
                                                    {
                                                            isNumber = int.TryParse(key[i].ToString(),out number);
                                                            
                                                            switch(isNumber)
                                                            {
                                                                    case true:
                                                                                if(isNext == false)
                                                                                {
                                                                                    fraction += number.ToString(); 
                                                                                }
                                                                    break; 
                                                                    
                                                                    case false :
                                                                                if(isNext == false)
                                                                                {
                                                                                  //  Get.Box("Current Value : "+fraction);
                                                                                    KeyStored[keySlot] = Convert.ToByte(fraction);  
                                                                                    keySlot++; 
                                                                                    
                                                                                    fraction = ""; 
                                                                                }
                                                                    break; 
                                                            }
                                                    }
                                return KeyStored; // this will return an invalid array 
                            }
                             return KeyStored; // this will retunr an invalid array or empty 
                        }catch(Exception e){
                            Get.Yellow(e);
                            Get.Green("for mor help please visit : https://mbvapps.xyz/QuickTools/"); 
                            Get.Wrong("There was an error with the key , more likely that is in an incorrect format or has been modified");
                             KeyStored = new byte[16]; 
                            return KeyStored; 
                        }
                }
                
                
                public KeyReader()
                {
                                    string file = "keys.txt"; 
                                    KeyReader.GetKey(file); 
                                    
                }
                public KeyReader(string file)
                {
                                    KeyReader.GetKey(file); 
                }
                
           }
           
           
}