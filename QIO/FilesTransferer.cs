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
    public class FilesTransferer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:FilesTransferer"/> class.
        /// </summary>
        public FilesTransferer() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:FilesTransferer"/> class.
        /// </summary>
        /// <param name="allowDebugger">If set to <c>true</c> allow debugger.</param>
        public FilesTransferer(bool allowDebugger) => this.AllowDebugger = allowDebugger;
        /// <summary>
        /// Initializes a new instance of the <see cref="T:FilesTransferer"/> class.
        /// </summary>
        /// <param name="chuckSize">Chuck size.</param>
        public FilesTransferer(int chuckSize) => this.ChuckSize = chuckSize;
        /// <summary>
        /// Initializes a new instance of the <see cref="T:FilesTransferer"/> class.
        /// </summary>
        /// <param name="allowDebugger">If set to <c>true</c> allow debugger.</param>
        /// <param name="chuckSize">Chuck size.</param>
        public FilesTransferer(bool allowDebugger, int chuckSize) { this.AllowDebugger = allowDebugger; this.ChuckSize = chuckSize; }


        /// <summary>
        /// Gets or sets the current status.
        /// </summary>
        /// <value>The current status.</value>
        public string CurrentStatus { get; set; } = "Not-Started";
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:FilesTransferer"/> allow debugger.
        /// </summary>
        /// <value><c>true</c> if allow debugger; otherwise, <c>false</c>.</value>
        public bool AllowDebugger { get; set; } = false;
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:FilesTransferer"/> wait to acknolege transfer.
        /// </summary>
        /// <value><c>true</c> if wait to acknolege transfer; otherwise, <c>false</c>.</value>
        public bool WaitToAcknolegeTransfer { get; set; } = true;
        /// <summary>
        /// The size of the chuck and the default value is 1024 * 1024 * 64 = 670302208B or 64MB
        /// </summary>
        public int ChuckSize = 1024 * 1024 * 64;
        /// <summary>
        /// Gets or sets the buffer.
        /// </summary>
        /// <value>The buffer.</value>
        public byte[] Buffer { get; set; } = new byte[] { };
        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>The source.</value>
        public string Source { get; set; } = "Not-Set";
        /// <summary>
        /// Gets or sets the target.
        /// </summary>
        /// <value>The target.</value>
        public string Target { get; set; } = "Not-Set";

        /// <summary>
        /// Transfer this the file from the source to the given target directory.
        /// </summary>
        public void TransferFile() => this.TransferFile(this.Source, this.Target);

        /// <summary>
        /// Transfer the specified source and target.
        /// </summary>
        /// <param name="source">Source.</param>
        /// <param name="target">Target.</param>
        public void TransferFile(string source, string target)
        {

            if (this.AllowDebugger)
            {
                Get.Print($"{source}", "->", $"{target}");
            }
            if (!File.Exists(source)) throw new ArgumentException($"The Source File Does not exist {source}");
            if (target == "") throw new ArgumentException("The Target or File destination was not provided");

            string transfer_info = Get.DataPath("temp") + Get.Slash() + Get.FileNameFromPath(target) + ".transfer_info";//+= ".transfer_info";
            MiniDB db = new MiniDB(transfer_info);
            Get.Yellow($"Computing a Hascode for the File: {source}");
            string fileHash = Get.HashCodeFromFile(source).ToString();


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
                    Check check = new Check();
                    QProgressBar bar = new QProgressBar();
                    TimeSpan time;
                    check.Start();
                    this.ChuckSize = this.ChuckSize > streamOpen.Length ? int.Parse(streamOpen.Length.ToString()) : this.ChuckSize;
                    sw.Start();
                    long current, goal;
                    string status, eta;
                    goal = streamOpen.Length;
                    current = 0;

                    while (current < goal)
                    {
                        time = Get.ETA(sw, current, goal - 1);
                        eta = time.Hours == 0 ? "" : $"{time.Hours}h ";
                        eta += time.Minutes == 0 ? "" : $"{time.Minutes}m";
                        eta += time.Seconds == 0 ? "" : $" {time.Seconds}s";
                        status = $"Status: [{Get.Status(current, goal - 2)}] ChuckSize: [{Get.FileSize(this.ChuckSize)}] Transfered: [{Get.FileSize(current)} / {Get.FileSize(goal)}] ETA: [{eta}]";
                        this.CurrentStatus = status;
                        if (this.AllowDebugger)
                        {
                            bar.Label = status;
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
                    status = $"Done!!! {target}";
                    if (this.AllowDebugger)
                    {
                        Get.Print($"{source}", "->", $"{target}");
                        Get.Green($"Done!!!");
                        Get.Yellow($"Transfer Time: {check.Stop()}");
                        if (WaitToAcknolegeTransfer)
                        {
                            Get.Wait();
                        }
                    }
                }


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