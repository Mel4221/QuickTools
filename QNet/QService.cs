using System;
using System.Net; 
using System.Threading;
using QuickTools.QCore;
using System.Collections.Generic;
using QuickTools.QData; 
namespace QuickTools.QNet
{


    /// <summary>
    /// QService is a method wich provides funtionalities
    /// to share information along other programs through 
    /// an standard api
    /// </summary>
    public partial class QService
    {


        private void CheckForKeys(string cmd)
        {
            List<Key> keys = QKeyManager.ToKeyList(cmd,new Key() {KeyAssingChar='=',KeyTerminatorChar=';' });
            if(keys.Count > 0)
            {
                keys.ForEach((obj) => Get.Green(obj.ToString()));
            }

        }

        /// <summary>
        /// Makes the request.
        /// </summary>
        /// <param name="keys">Keys.</param>
        public static void MakeRequest(List<Key> keys)
        {
            /*
                //ID NAME TYPE INFO STATUS CURRENT GOAL BUFFER-LENGTH

                1w2e3r5tu78d MV SHARE "moving file from a to b" 0% 0 100 128292
                1w2e3r5tu78d MV UPDATE "moving file from a to b" 45% 45 100 128292
                1w2e3r5tu78d MV GET "moving file from a to b" 0% 0 100 128292
            */

        }

        private void CheckForExitCommand(string cmd)
        {

            switch(cmd)
            {
                case "exit":
                    Get.Box($"EXIT");
                    this.ExitRequest = true; 
                    return;
                case "reboot":
                    Get.Box($"REBOOT");
                    //this.ExitRequest = true;
                    this.Services.Clear();
                    //this.Start();
                    return;
                default:
                    this.CheckForKeys(cmd); 
                    return;
            }
        }

        /// <summary>
        /// Start this instance.
        /// </summary>
        public void Start()
        {
            //GC.WaitForFullGCComplete();
            //GC.Collect();
            this.QServiceThread = new Thread(() => 
            { 
                 while(!this.ExitRequest)
                {

                    try
                    {

                        HttpListenerRequest request = this.Server.Listen();
                        this.Server.ResponseFunction = (item) => { return Get.Bytes("OK"); };
                        string cmd = request.RawUrl.Substring(1);
                        if (this.AllowDebugger)
                        {
                            Get.Print("REQUEST", cmd);
                        }
                        this.CheckForExitCommand(cmd);
                    }
                    catch
                    {
                        this.Port++;
                        this.Server = new QServer("localhost",this.Port);
                    }

                }
            });

            this.QServiceThread.Start();
        }


    }
}
