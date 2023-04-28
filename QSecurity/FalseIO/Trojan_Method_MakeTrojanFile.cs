//
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
using System.IO;
using QuickTools.QCore;
using QuickTools.QIO;

namespace QuickTools.QSecurity.FalseIO
      {

            /// <summary>
            /// The Trojan class does not create a Virus or anything like creatting a maleware but it can create a file that will 
            /// look like a regular file but inside it it could contain the data given to it  as a payload. 
            /// The name of the class is Trojan Mainly for how a trojan virus will behave
            /// </summary>
            public partial class Trojan
            {

            /// <summary>
            /// Makes the trojan file.
            /// </summary>
            public void MakeTrojanFile()
                  {
                  byte[] trojan, load, pack, metadata;
                  string file, payload, fake, description, str, str2, date;
                  int indexer, len;

                  if(this.TrojanFile == "" || !File.Exists(this.TrojanFile))
                        {
                        throw new Exception("Missing Trojan File: "+this.TrojanFile); 
                        }
                  if(this.Payload == "" || !File.Exists(this.Payload))
                        {
                        throw new Exception("Missing The Payload: "+this.Payload); 
                        }

                  file = this.TrojanFile;
                  payload = this.Payload; 
                  fake = $"{this.DefaultFilnalLabelIdentity}{file}";
                  description = this.Description;
                  date = this.Date == "" ? DateTime.Now.ToString() : this.Date;
                  trojan = Binary.Reader(file);
                  load = Binary.Reader(payload);

                  //start from meta data and this is just trying to get the metadata just in the right format
                  str = $":{payload};:{trojan.Length};:{load.Length};:{description};:{date};";
                  len = $":{str.Length};".Length;
                  str2 = str + $":{len + str.Length};";
                  //end from metadata preparaation 

                  metadata = Get.Bytes(str2);
                  //Get.Wait(metadata.Length); 
                  pack = new byte[trojan.Length + load.Length + metadata.Length];

                  if(this.AllowDebugger)
                        {
                        Get.Yellow($"MetaData: [{IConvert.ToString(metadata)}]");
                        Get.WaitTime(); 
                        Get.Yellow($"Sorce File: [{file}] Size: [{Get.FileSize(file)}] Payload Size: [{Get.FileSize(payload)}]");
                        Get.WaitTime(); 
                        Get.Yellow($"Total Load: [{Get.FileSize(pack)}]");
                        Get.WaitTime(); 
                        }
                  this.CurrentStage = $"Building Metadata: {IConvert.ToString(metadata)} Sorce File: {file} Payload Size: {Get.FileSize(payload)}";
                  for(int tr = 0 ; tr < trojan.Length ; tr++)
                        {
                        pack[tr] = trojan[tr];
                        }

                  indexer = trojan.Length;
                  for(int lo = 0 ; lo < load.Length ; lo++)
                        {
                        pack[indexer] = load[lo];
                        indexer++;
                        }

                  for(int meta = 0 ; meta < metadata.Length ; meta++)
                        {
                        pack[indexer] = metadata[meta];
                        indexer++;
                        }




                  BinaryWriter writer = new BinaryWriter(new FileStream(fake , FileMode.Create));

                  writer.Write(pack , 0 , pack.Length);
                  if(this.AllowDebugger)
                        {
                        Get.Yellow($"Completed Sucessfully: [ {Get.HashCode(trojan) != Get.HashCode(pack)} ] ");
                        }
                  this.CurrentStage = $"{Get.HashCode(trojan) != Get.HashCode(pack)}"; 

                  }
            }
      }
