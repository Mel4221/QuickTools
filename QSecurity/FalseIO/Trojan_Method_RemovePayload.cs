using System;
using System.Collections.Generic;
using QuickTools.QCore;
using QuickTools.QIO;
using System.IO;

namespace QuickTools.QSecurity.FalseIO
{

    /// <summary>
    /// Trojan is a safe way to insert a file inside another and being able to 
    /// remove it from it later
    /// </summary>
    public partial class Trojan
    {

        /// <summary>
        /// Removes the payload from the given trojan file
        /// </summary>
        /// <param name="trojanFile">Trojan file.</param>
        public void RemovePayload(string trojanFile)
        {

            byte[] payload;
            string  metadata, str;
            int metadataLength, metaCounter;
            bool open; 
            int len, breaker, maxBreak;
            this.TrojanFile = trojanFile; 
            if (this.TrojanFile == "" || !File.Exists(this.TrojanFile))
            {
                throw new Exception("Missing or not found the trojan file: " + this.TrojanFile);
            }
           // trojanFile = this.TrojanFile;
            payload = Binary.Reader(trojanFile);
            metadata = "";
            str = "";
            metadataLength = payload.Length - 1;
            //Stage 1 Getting metadata
            //getting the metadata size 

            breaker = 0;
            maxBreak = 0;
            while (true)
            {
                metadata = IConvert.ToString(new byte[] { payload[metadataLength] }) + metadata;
                maxBreak = (payload.Length / (payload.Length / PorcentOfMaxBreak) * 100);

                str += metadata;
                if (Get.IsNumber(metadata.Replace(":", "").Replace(";", "")) && metadata.Contains(":"))
                {
                    metadata = metadata.Replace(":", "").Replace(";", "");
                    break;
                }
                if (breaker == maxBreak)
                {
                    Get.Red();
                    throw new Exception("Not Payload Found!!");
                }
                // Get.Wait(metadata); 
                metadataLength--;
                breaker++;
                //Get.Red($"Finding Metadata...Break: {breaker} Max: {payload.Length - (payload.Length - (payload.Length * 100) / 90) }"); 
                Get.Red($"Finding Metadata Break: [{breaker}] MaxBreak: [{maxBreak}]");
                this.CurrentStage = $"Finding Metadata Break: [{breaker}] MaxBreak: [{maxBreak}]";
            }

            if (AllowDebugger)
            {
                Get.Green($"Stage_1: Reading Metadata [{metadata}]");
                Get.WaitTime();
            }
            this.CurrentStage = $"Stage_1: Reading Metadata [{metadata}]";

            //Stage 2 getting payload information 
            //getting the entired line of metadata 
            metaCounter = 0;
            str = null;
            for (int meta = payload.Length; meta > 0; meta--)
            {
                str = IConvert.ToString(new byte[] { payload[meta - 1] }) + str;

                if (metaCounter == int.Parse(metadata))
                {
                    break;
                }
                metaCounter++;
            }
            metadata = str;
            str = null;
            open = false;
            if (AllowDebugger)
            {
                Get.Green($"Stage_2: Checking Metadata");
                Get.WaitTime();
            }
            this.CurrentStage = $"Stage_2: Checking Metadata";

            //Stage 3 Reading Properties
            List<string> info = new List<string>();
            for (len = 0; len < metadata.Length; len++)
            {

                if (metadata[len] == ':')
                {
                    open = true;
                }
                if (metadata[len] != ':' && metadata[len] != ';')
                {
                    str += metadata[len];
                }
                if (metadata[len] == ';' && open == true)
                {
                    info.Add(str);
                    str = null;
                    open = false;
                }

            }


            //:exelBook.pdf;:243758;:17364199;:;:3/11/2023 4:17:27 AM;:60;
            if (AllowDebugger)
            {
                Get.Green($"Stage_3: Building Metadata");
                Get.WaitTime();
            }
            this.CurrentStage = $"Stage_3: Building Metadata";
            Trojan trojan = new Trojan()
            {
                Payload = info[0].Substring(1),
                IndexStart = info[1],
                IndexEnd = info[2],
                Description = info[3]
            };
            if (AllowDebugger)
            {
                Get.Green($"Stage_4: Writting File: [{trojan.Payload}]");
                Get.WaitTime();
            }
            this.CurrentStage = $"Stage_4: Writting File: [{trojan.Payload}]";
            //Stage 4 Writting File
            //this.DefaultDeletePayloadFromFile = true;
            //if (this.DefaultDeletePayloadFromFile == true)
            //{
                Binary.Write(trojanFile, payload, 0, int.Parse(trojan.IndexStart));
            //}
            if (this.DefaultDeleteSourceFile == true)
            {
                Binary.Write(trojanFile, new byte[payload.Length], 0, payload.Length);
                File.Delete(trojanFile);
            }

 
        }
    }
}
