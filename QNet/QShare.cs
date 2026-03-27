using QuickTools.QCore;
using QuickTools.QIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace QuickTools.QNet
{
      class QShare
    {

        /// <summary>
        /// QServer is by default on all the settings 
        /// </summary>
        public QServer Server { get; set; } = new QServer();
        /// <summary>
        /// All the settings are by default
        /// </summary>
        public QHttp Http { get; set; } = new QHttp();

        /// <summary>
        /// allow to display messages as the program runs
        /// </summary>
        public bool AllowDebugger { get; set; } = true;
        /// <summary>
        /// by default is 1024*1024 which is 10MB
        /// </summary>
        public int BufferSize { get; set; } = (1024*1024)*10;

        private void Echo(object msg)
        {
            if (this.AllowDebugger)
            {
                Get.Yellow(msg); 
            }
        }
   
        public void SendFile(string file)
        {
            byte[] bytes = Binary.Reader(file);

            Echo($"File Received: {file} Bytes: {bytes.Length}");
            

            string sendData = $"{this.Server.Address}{IConvert.BytesToString(bytes)}";

            this.Http.Headers.Add(new QHttp.Header()
            {
                Key="FileName",
                Value=file
            });
            this.Http.Headers.Add(new QHttp.Header()
            {
                Key="FileHash",
                Value=Get.HashCode(bytes).ToString()
            });
            Echo($"Headers Count: {this.Http.Headers.Count}");
            this.Http.Get(sendData);
            Get.Yellow($"FileSent: {file} Hash: {Get.HashCode(bytes)}");
         
        }

        public void ReceiveFile()
        {
            HttpListenerRequest request = this.Server.Listen();
            Get.Yellow(this.Server.URL);

        }

        public QShare()
        {


        }
    }
}
