﻿using System;
using System.Collections.Generic;
using QuickTools.QCore;
using QuickTools.QData;
using System.IO;
using QuickTools.QColors; 
namespace QuickTools.QIO
{


	/// <summary>
	/// This is a class that provides a way to destroy a file to avoid 
	/// the file to be restored to its normal form 
	/// </summary>
	public class FileShreder
	{

		/// <summary>
		/// Inizilize the instance
		/// </summary>
		public FileShreder() { }

		/// <summary>
		/// Initilize the instance with a file name 
		/// </summary>
		/// <param name="fileName"></param>
		public FileShreder(string fileName)
		{
			this.FileName = fileName;
		}

		/// <summary>
		/// initilize
		/// </summary>
		/// <param name="files"></param>
		public FileShreder(string[] files)
		{
			this.Files = files;
		}

		/// <summary>
		/// Contains the File Name of the file that will be destroied 
		/// </summary>
		public string FileName { get; set; } = string.Empty;

		/// <summary>
		/// Contains the fiiles that will be handeled
		/// </summary>
		public string[] Files { get; set; } = new string[] { };

		/// <summary>
		/// contains the current status of the Process
		/// </summary>
		public string CurrentStatus = "Not-Started";

        /// <summary>
        /// Progress.
        /// </summary>
        public static class Progress 
        {  
            /// <summary>
            /// The current. status of the Progress
            /// </summary>
            public static int Current { get; set; }

            /// <summary>
            /// The goal that needs to be meet
            /// </summary>
            public static int Goal { get; set; }

            /// <summary>
            /// Gets or sets the text progress.
            /// </summary>
            /// <value>The text progress.</value>
            public static string TextProgress { get; set; }

            /// <summary>
            /// Gets or sets the text status.
            /// </summary>
            /// <value>The text status.</value>
            public static string TextStatus { get; set; }
        }

        /// <summary>
        /// Allow to set debuggers 
        /// </summary>
        public bool AllowDebugger { get; set; } = false;

		/// <summary>
		/// Contains the list of erros 
		/// </summary>
		public List<Error> Erros { get; set; } = new List<Error>();


		/// <summary>
		/// Allow to shread a fiele and make it un restorable 
		/// </summary>
		/// <param name="file"></param>
		public void Shread(string file)
		{
			this.FileName = file;
			this.Shread();
		}

		/// <summary>
		/// Allow to shread a fiele and make it un restorable 
		/// </summary>
		/// <param name="files"></param>
		public void Shread(string[] files)
		{
			this.Files = files;
			this.Shread();
		}
		/// <summary>
		/// Allow to shread a fiele and make it un restorable 
		/// </summary>
		/// <exception cref="Exception">No Files were provided</exception>
		public void Shread()
		{
			string[] files = new string[] { };
			if (this.FileName == "" && this.Files.Length == 0)
			{
				throw new Exception("No Files were provied");
			}
			if (this.FileName != "")
			{
				files = new string[] { this.FileName };
			}
			if (this.Files.Length != 0)
			{
				files = this.Files;
			}
			int current, goal;
			string status;
			goal = files.Length-1;
			this.Erros = new List<Error>();
			if (this.AllowDebugger)
			{
				Print.List(files);
				Color.Yellow($"Files: {files.Length}");
				Get.WaitTime();
			}
			for (int file = 0; file < files.Length; file++)
			{
				try
				{
					if (this.AllowDebugger) Color.Yellow();
					byte[] buffer = new byte[0];
                    int length;
                    long len;
                    length = 0;
                    len = File.Open(files[file], FileMode.Open).Length;
                    //GC.Collect();
                    if (len > int.MaxValue / 2)
                    {
                        length = int.MaxValue / 2 / 2;
                    }
                    if (len < int.MaxValue / 2)
                    {
                        length = int.Parse(len.ToString());
                    }

                    if (!this.AllowDebugger)
					{
                        buffer = Get.Bytes(IRandom.RandomText(length));
					}
					if (this.AllowDebugger)
					{
						Get.Wait($"{files[file]} Building Random Buffer...", () =>
						{
                            buffer = Get.Bytes(IRandom.RandomText(length));
						});
					}

					if (this.AllowDebugger) Color.Yellow($"Buffer Size: [{Get.FileSize(buffer)}]");
					GC.Collect();
					current = file;
					status = $"Destroing File: [{files[file]}] [{Get.Status(current, goal)}]";
					this.CurrentStatus = status;

                    Progress.Current = file;
                    Progress.Goal = goal;
                    Progress.TextProgress = Get.Status(current, goal);
                    Progress.TextStatus = status;

                    if (this.AllowDebugger)
					{
					  Color.Red(status);
					}
					using (BinaryWriter binary = new BinaryWriter(new FileStream(files[file], FileMode.OpenOrCreate, FileAccess.Write)))
					{
						binary.Write(buffer, 0, buffer.Length);
					}
					//GC.Collect();
					File.Delete(files[file]);
					if (this.AllowDebugger)
					{
						Get.Ok();
					}
				}
				catch (Exception ex)
				{
					this.Erros.Add(new Error()
					{
						Message = ex.Message,
						Type = $"The File Failed to be Shreded: [{files[file]}]\n{ex}"
					});
					if (this.AllowDebugger) Color.Red($"Failed to be Destroied: {files[file]}");
				}
			}
			if (this.AllowDebugger)
			{
				Color.Green($"Files Sucessfully Destroied: {files.Length - this.Erros.Count}");
				if (this.Erros.Count > 0)
				{
					this.Erros.ForEach(item => QColors.Color.Red(item.ToString()));
					Color.Red($"Failed To Be Destroied: {this.Erros.Count}");

				}
				Get.Wait($"Done!!!");
			}
		}

        /*
		 *        /// <summary>
        /// This Class provides the methods to be able to delete a file by rewritting pregenerated text over it
        /// of the size of the file then delete it as a way to clear the data from it permanetly
        /// </summary>       
		public class FileShreder
		{

			/// <summary>
			/// Gets or sets the files.
			/// </summary>
			/// <value>The files.</value>
			public string[] Files { get; set; }
			/// <summary>
			/// Gets or sets a value indicating whether this <see cref="T:QuickTools.QIO.FileShreder"/> allow debbuger.
			/// </summary>
			/// <value><c>true</c> if allow debbuger; otherwise, <c>false</c>.</value>
			public bool AllowDebbuger { get; set; } = false;
			/// <summary>
			/// Gets or sets the status.
			/// </summary>
			/// <value>The status.</value>
			public string Status { get; set; } = "not-started";
			/// <summary>
			/// Gets or sets the human delay which allows the printing time to be slower 
			/// to be audited if required and by default is set to 500 seconds
			/// </summary>
			/// <value>The human delay.</value>
			public int HumanDelay { get; set; } = 500;


			public List<Error> Errors { get; set; } = new List<Error>(); 

			/// <summary>
			/// Evaluetes the total size of files that will be deleted but coudl messure also the 
			/// size of all the files selected or provided
			/// </summary>
			/// <returns>The size.</returns>
			/// <param name="files">Files.</param>
			public string EvalSize(string[] files)
			{
				int size, current, goal;
				byte[] bytes;
				string status;
				size = 0;
				current = 0;
				goal = files.Length - 1;

				foreach (string file in files)
				{
					bytes = Binary.Reader(file);
					size += bytes.Length;
					status = $"Evaluating Size: {Get.FileNameFromPath(file)} [{Get.Status(current, goal)}]";
					this.Status = status;
					if (this.AllowDebbuger)
					{
						Get.Yellow(status);
						int time = this.HumanDelay < 200 ? 200 : this.HumanDelay; 
						Get.WaitTime(time - 200);
					}
					current++;
				}

				bytes = new byte[size];
				return Get.FileSize(bytes);
			}

			/// <summary>
			/// Delete all the files listed on <see cref="T:QuickTools.QIO.FileShreder.Files"/>
			/// </summary>
			public void Delete()
			{
				if (this.Files.Length == 0) throw new ArgumentException("Not Files Provided");
				int current, goal, length;
				string text, status;
				byte[] bytes;
				current = 0;
				goal = this.Files.Length - 1;

				if (this.AllowDebbuger)
				{
					Print.List(this.Files);
					Get.Yellow($"Files To Delete: {this.Files.Length} Deleted Size: {EvalSize(this.Files)}");
					Get.Red("The Files Will be permanently Deleted");
					Console.Beep(); 
					Get.Ok();
					Get.WaitTime(this.HumanDelay);
				}
				foreach (string file in this.Files)
				{
					try
					{
						status = $"Deleting... [{Get.FileNameFromPath(file)}] [{Get.Status(current, goal)}]";
					this.Status = status;
					if (this.AllowDebbuger)
					{
						Get.Red(status);
						Get.WaitTime(this.HumanDelay);
					}

						bytes = Binary.Reader(file);
						length = bytes.Length;
						text = IRandom.RandomText(length);
						bytes = Get.Bytes(text);
						Writer.Write(file, bytes);
						//Get.Wait();
						GC.Collect();
						File.Delete(file);


					}
					catch (Exception e)
					{
						this.Errors.Add(new Error() { 
							ExceptionRecived = e,
							Message = e.Message,
							Type = $"File: {file}"
						});
					}
					current++;
				}
				if (this.AllowDebbuger)
				{

					if(this.Errors.Count > 0) 
					{
						Get.Red("Some Files Fail To be deleted");
						foreach(Error error in this.Errors) 
						{
							Get.Yellow($"{error.Message} {error.Type}"); 
						}

					}
					else
					{
						Print.List(this.Files);
						Get.Red($"Files Permanently Deleted {this.Files.Length}");
					}


				}

				this.Status = "ok";
			}

			/// <summary>
			/// Initializes a new instance of the <see cref="T:QuickTools.QIO.FileShreder"/> class.
			/// </summary>
			/// <param name="files">Files.</param>
			public FileShreder(string[] files)
			{
				this.Files = files;
			}
		}


	}
	*/
    }
}