﻿//
// ${Melquiceded Balbi Villanueva}
//
// Author:
//       ${Melquiceded} <${melquiceded.balbi@gmail.com}>
//
// Copyright (c) ${2089} MIT
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using System.Collections.Generic;
using QuickTools.QCore;
using QuickTools.QIO;
using System.IO;
using System.Text.RegularExpressions;

namespace QuickTools.QSecurity.FalseIO
      {

      public partial class Trojan
            {
                /// <summary>
                /// Pulls the payload from trojan File
                /// </summary>
            public  void PullPayloadFromTrojan()
                  {

                  byte[] payload;
                  string trojanFile, metadata, str;
                  int metadataLength, metaCounter;
                  bool open;
                  int  len;
                  if(this.TrojanFile == "" || !File.Exists(this.TrojanFile))
                  {
                        throw new Exception("Missing or not found the trojan file: " + this.TrojanFile); 
                  }
                  trojanFile = this.TrojanFile;
                  payload = Binary.Reader(trojanFile);
                  metadata = "";
                  str = "";
                  metadataLength = payload.Length - 1;
                  //Stage 1 Getting metadata
                  //getting the metadata size 
          
                  while(true)
                        {
                        metadata = IConvert.ToString(new byte[] { payload[metadataLength] }) + metadata;
                        str += metadata;

                        if(Get.IsNumber(metadata.Replace(":" , "").Replace(";" , "")) && metadata.Contains(":"))
                              {
                              metadata = metadata.Replace(":" , "").Replace(";" , "");
                              break;
                              }
                        // Get.Wait(metadata); 
                        metadataLength--;
                        }

                  if(AllowDebugger)
                        {
                        Get.Green($"Stage1: Reading Meetadata [{metadata}]");
                        }
                  //Stage 2 getting payload information 
                  //getting the entired line of metadata 
                  metaCounter = 0;
                  str = null;
                  for(int meta = payload.Length ; meta > 0 ; meta--)
                        {
                        str = IConvert.ToString(new byte[] { payload[meta - 1] }) + str;

                        if(metaCounter == int.Parse(metadata))
                              {
                              break;
                              }
                        metaCounter++;
                        }
                  metadata = str;
                  str = null;
                  open = false;

                  //Stage 3 Reading Properties
                  List<string> info = new List<string>();
                  for(len = 0 ; len < metadata.Length ; len++)
                        {

                        if(metadata[len] == ':')
                              {
                              open = true;
                              }
                        if(metadata[len] != ':' && metadata[len] != ';')
                              {
                              str += metadata[len];
                              }
                        if(metadata[len] == ';' && open == true)
                              {
                              info.Add(str);
                              str = null;
                              open = false;
                              }

                        }


                  //:exelBook.pdf;:243758;:17364199;:;:3/11/2023 4:17:27 AM;:60;

                  Trojan trojan = new Trojan()
                        {
                        Payload = info[0] ,
                        IndexStart = info[1] ,
                        IndexEnd = info[2] ,
                        Description = info[3]
                        };
                  if(AllowDebugger)
                        {
                        Get.Green($"Stage4: Writting File: [{trojan.Payload}]");
                        }
                  //Stage 4 Writting File


                  Binary.Write(IRandom.OnlyChars(trojan.Payload) , payload , int.Parse(trojan.IndexStart) , int.Parse(trojan.IndexEnd));

                  }
            }
      }