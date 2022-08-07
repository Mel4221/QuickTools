
using System;
using System.IO;
using System.Text; 
using System.Threading;
using System.Collections.Generic;





namespace QuickTools
{
            /// <summary>
            /// KeyReader is a class that Reads the keys stored in a file 
            /// and save it into the KeyStored or into the StringKey
            /// KeyStored = array byte[16]
            /// StringKey = row string  
            /// </summary>
           public class KeyReader
           {
            /// <summary>
            /// Key Stored max keys stored is 16
            /// </summary>
            public static byte[] KeyStored; 
            /// <summary>
            /// Key stored on an string format 
            /// </summary>

            public static  StringBuilder StringKey = new StringBuilder(); 
                  
                            /*
                             using(var reader = new StreamReader(file))
                              {    
                                StKey;ringKey = reader.ReadLine(); 
                              }
                              return String 
                          */
                        /// <summary>
                        /// Parse is a method that reads an entried file
                        /// and it returns the entired file as a row string
                        /// </summary>
                        /// <returns> The Content from the file</returns>
                        /// <param name="file">The file</param>
                        public static string  Parse(string file)
                        {

                            try{
                                // here we are trying to get the string of the file to get the 
                                // key for the file 
                                
                                 using(var reader = new StreamReader(file))
                              {
                                    StringKey.Append(reader.ReadLine()); 
                              }
                           //   Get.Green(); 
                           //   Get.Yellow(KeyReader.StringKey);
                              return StringKey.ToString();
                            }catch{
                                
                                    Get.NotFound(file); 
                             return "notFound";    
                            }
                           
                            
                        }



            // this will convert the key from an string 
            // to a clear array suitable for the key desconmpretion
            /// <summary>
            /// This Method get the keys stored in an array of strings 
            /// 
            /// </summary>
            /// <returns>The key.</returns>
            /// <param name="OnlyText">File.</param>
            public static byte[] GetKey(string OnlyText)
                        {

                  // variables 
                
                  string file = OnlyText;
                  string key, fraction;
                  int number, keySlot;
                  //char divition;
                  bool  isNext;
                  //byte[] temporalArray;
                  List<byte> temporalList = new List<byte>();
                  // this are all the variable needed 
                  //isNumber = false;
                  isNext = false;
                  fraction = "";
                  keySlot = 0;
                  key = StringKey.ToString();
                  // variables 


                  try
                  {
                            // here we will parse the key    
                            if(Parse(file) != "notFound" )
                            {
                                    
                                        // this is supposed to loop trhoug each character and 
                                        // determine if it will be able to be a number or not a number 
                  
                                                for(int i=0; i< key.Length; i++)
                                                    {
                                                            // this validate if is number or not 
                                                            // and is a method from Get 
                                                            bool isValid = Get.IsNumber(key[i].ToString());
                                                            number = Get.Number;
                                                            switch(isValid)
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
                                                                                    temporalList.Add(Convert.ToByte(fraction));  
                                                                                    keySlot++; 
                                                                                    
                                                                                    fraction = ""; 
                                                                                }
                                                                    break; 
                                                            }
                                                    }

                          KeyStored = new byte[temporalList.Count - 1];
                              for(int val = 0; val<KeyStored.Length; val++)
                              {
                                    KeyStored[val] = temporalList[val];
                                   
                              }

                              return KeyStored; // this will return an invalid array 
                            }
                              
                             return null; // this will retunr an invalid array or empty 
                        }catch(Exception e){
                            Get.Yellow(e);
                            Get.Green("for mor help please visit : https://mbvapps.xyz/QuickTools/"); 
                            Get.Wrong("There was an error with the key , more likely that is in an incorrect format or has been modified");
                             //KeyStored = new byte[16]; 
                            return null; 
                        }
                }
                
                
                /// <summary>
                /// This initialation start the process manually of reading the keys from the file 
                /// </summary>
                /// <param name="file">File that contains the keys</param>
                public KeyReader(string file)
                {
                                    KeyReader.GetKey(file); 
                }
                
           }
           
           
}