using System;
using System.IO;
using QuickTools.QCore;
using System.Diagnostics;
using QuickTools.QConsole;
using QuickTools.QData;
using System.Threading;


namespace QuickTools.QIO
{
    /// <summary>
    /// Creates an object that allow to transfer files and return or print the status of the transfer 
    /// </summary>
    public partial class FilesTransferer
    {

    

        /// <summary>
        /// Transfer the specified source and target.
        /// </summary>
        /// <param name="source">Source.</param>
        /// <param name="target">Target.</param>
        public void TransferFile(string source, string target)
        {

            this.CurrentStatus = $"{source}"+ "->"+$"{target}";
            if (this.AllowDebugger)
            {
                Get.Print($"{source}", "->", $"{target}");
            }
            if (!File.Exists(source)) throw new ArgumentException($"The Source File Does not exist {source}");
            if (target == "") throw new ArgumentException("The Target or File destination was not provided");

            string transfer_info = Get.DataPath("temp") + Get.Slash() + Get.FileNameFromPath(target) + ".transfer_info";//+= ".transfer_info";
            MiniDB db = new MiniDB(transfer_info);
            Check check = new Check();

            this.CurrentStatus = $"Computing a Hascode for the File: {source}";
            if (this.AllowDebugger)Get.Yellow(this.CurrentStatus);
            string fileHash = new Get().HashCodeFromFile(source,true).ToString();


            //GC.Collect(); 
            using (FileStream streamOpen = new FileStream(source, FileMode.Open, FileAccess.Read))
            {

                db.Drop();
                if (!db.Load())
                {
                    db.Create();
                    db.AddKeyOnHot("FileSource", source, fileHash);
                    db.AddKeyOnHot("FileDestination", target, fileHash);
                    db.AddKeyOnHot("FileHash", fileHash, source);

                    db.AddKeyOnHot("Transfer_Start_Time", DateTime.Now.ToString(), fileHash);
                    db.AddKeyOnHot("TransferSize", Get.FileSize(streamOpen.Length), fileHash);
                    db.AddKeyOnHot("TransferedSize", "0", fileHash);

                    db.AddKeyOnHot("CurrentByte", "", fileHash);
                    db.AddKeyOnHot("TotalBytes", streamOpen.Length.ToString(), fileHash);

                }

                using (FileStream streamWrite = new FileStream(target, FileMode.Create, FileAccess.Write))
                {
                    BinaryReader binaryReader = new BinaryReader(streamOpen);
                    BinaryWriter binaryWriter = new BinaryWriter(streamWrite);
                    Stopwatch sw = new Stopwatch();
                    QProgressBar bar = new QProgressBar();
                    TimeSpan time;
                    check.Start();
                    this.ChuckSize = this.ChuckSize > streamOpen.Length ? int.Parse(streamOpen.Length.ToString()) : this.ChuckSize;

                    sw.Start();
                    long current, goal;
                    string  eta;
                    goal = streamOpen.Length;
                    current = 0;

                    while (current < goal)
                    {
                        //this.FileMetadata.ChuncksSize = long.Parse(this.FileMetadata.ChuncksSize.ToString()) < (goal - current) ? this.FileMetadata.ChuncksSize : int.Parse(goal - current);
                        /*
                            If for some reason the current chuck remaining is actually smaller 
                            than the current remaining bytes just set that to be the final chunck                                   
                        */
                        this.ChuckSize = long.Parse(this.ChuckSize.ToString()) < (goal - current)? this.ChuckSize : int.Parse((goal-current).ToString());

                        time = Get.ETA(sw, current, goal - 1);
                        eta = time.Hours == 0 ? "" : $"{time.Hours}h ";
                        eta += time.Minutes == 0 ? "" : $"{time.Minutes}m";
                        eta += time.Seconds == 0 ? "" : $" {time.Seconds}s";
                        this.CurrentStatus = $"Status: [{Get.Status(current, goal - 2)}] RW: [{Get.FileSize(this.ChuckSize)}] Transfered: [{Get.FileSize(current)} / {Get.FileSize(goal)}] ETA: [{eta}]";
                       // this.CurrentStatus = status;

                        if (this.AllowDebugger)
                        {
                            bar.Label = this.CurrentStatus;
                            bar.Display(Get.Status(current, goal - 2));
                            //Get.Green(status);
                        }
                        streamOpen.Seek(current, SeekOrigin.Begin);

                        this.Buffer = new byte[this.ChuckSize];
                        binaryReader.Read(this.Buffer, 0, this.Buffer.Length);


                        streamWrite.Seek(current, SeekOrigin.Begin);
                        //binaryWriter = new BinaryWriter(streamWrite);
                        binaryWriter.Write(this.Buffer, 0, this.Buffer.Length);

                        new Thread(() =>
                        {
                            GC.WaitForPendingFinalizers();
                            db.UpdateKeyValue("CurrentByte", current.ToString());
                            db.UpdateKeyValue("TransferedSize", Get.FileSize(current));
                            db.SaveChanges();
                        //db.UpdateKeyWhereKey("CurrentByte", new DB() { Value=current.ToString()});
                        //db.UpdateKeyWhereKey("TransferedSize", new DB() { Value=Get.FileSize(current)});
                    }).Start();
                        current += this.ChuckSize;
                        // Get.Yellow(current); 


                    }


              
                }


            }
            if (this.CheckFileIntegrity)
            {
                this.CurrentStatus = $"Checking File Integrity...";
                if (this.AllowDebugger)
                {
                    try
                    {
                        Get.Reset();
                        Get.WriteL("");
                        Get.Wait(this.CurrentStatus,() => {
                            this.Target_Hash = new Get().HashCodeFromFile(target, false).ToString();
                        });
                    }
                    catch
                    {

                    }
                }
                if(!this.AllowDebugger)
                {
                    this.Target_Hash = new Get().HashCodeFromFile(target, false).ToString();
                }
            }
            //this.CurrentStatus = $"Done!!!";

            if (this.AllowDebugger)
            {

                Get.Print($"{source}", "->", $"{target}");
                //Get.Green($"Done!!!");
                Get.Yellow($"Transfer Time: {check.Stop()}");
                this.CurrentStatus = this.CheckFileIntegrity == true ? $"Source Hash: [{fileHash}] Target Hash: [{this.Target_Hash}] MATCH: [{fileHash == this.Target_Hash}]" : "";
                Get.Yellow(this.CurrentStatus);
                return;
            }

        }
        /// <summary>
        /// Transfers the directory.
        /// </summary>
        public void TransferDirectory() => this.TransferDirectory(this.Source, this.Target);
        /// <summary>
        /// Transfers the directory.
        /// </summary>
        /// <param name="source">Source.</param>
        /// <param name="target">Target.</param>
        /// <exception cref="T:System.NotImplementedException">since is not completed yet</exception>
        public void TransferDirectory(string source, string target)
        {
            if (!Directory.Exists(source)) throw new ArgumentException($"The Source Directory Does not exist {source}");
            if (target == "") throw new ArgumentException("The Target or Directory destination was not provided");
            throw new NotImplementedException("Not completed Yet");
        }
    }
}