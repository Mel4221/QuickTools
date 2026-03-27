
using System;
using System.Text;
using System.IO;
using QuickTools.QIO;
using QuickTools.QCore;
using System.Security.Cryptography;
namespace QuickTools.QSecurity
{
    /// <summary>
    /// The Secure class works pretty well so far on text DO NOT USE IT ON BINARY DATA IT COULD BREAK 
    /// THE FILES    
    /// </summary>
    public partial class Secure
    {
        /// <summary>
        /// Encrypt a file with the given password and iv key
        /// </summary>
        /// <param name="file"></param>
        /// <param name="password"></param>
        /// <param name="iv"></param>
        /// <exception cref="FileNotFoundException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public void EncryptFile(string file, string password, byte[] iv)
        {
            /*
                Creatting the checks to make sure that we are good to go
             */
            if (!File.Exists(file))
            {
                throw new FileNotFoundException($"The Given file '{file}' was not found");
            }
            if (password == "" || password == null)
            {
                throw new ArgumentNullException("No password was provided");
            }
            if (iv.Length == 0)
            {
                throw new ArgumentNullException("The IV key was not provided");
            }
            Check check = new Check();
            byte[] bytes, pass, binary;
            string data, message;
            binary = new byte[0];
            /*
                displaying the size of the file that we will be working with 
             */
            check.Start();
            bytes = Binary.Reader(file);
            if (bytes.Length == 0)
            {
                throw new Exception("The File is enpty");
                // return; 
            }

            message = $"File Size: {Get.FileSize(bytes)} & Converting to String Format...";
            if (this.AllowDebugger)
            {
                Get.Yellow(message);
                // Get.WaitTime(PrintingTime);
            }
            /*
                Converting the bytes to a text format to encrypt the program
                as a text format
             */
            data = IConvert.BytesToString(bytes, this.AllowDebugger);
            if (data == null)
            {
                message = $"The Conversion Failed very likely due to running out of RAM";
                if (this.AllowDebugger)
                    Get.Red(message);
                return;
            }
            message = $"Building Password...";
            if (this.AllowDebugger)
            {
                Get.Yellow(message);
                //// Get.WaitTime(PrintingTime);
            }
            /*
                if allow the debugger print a loop in the mind time is waitting
                other wise just wait until is encrypted 
             */

            file = this.OutFile == null ? file : this.OutFile;

            if (this.AllowDebugger)
            {
                Get.Wait($"Please wait encrypting {file}...", () => {
                    pass = CreatePassword(password);
                    bytes = Get.Bytes(data);
                    binary = this.Encrypt(bytes, pass, iv);
                });
            }
            if (!this.AllowDebugger)
            {
                pass = CreatePassword(password);
                bytes = Get.Bytes(data);
                binary = this.Encrypt(bytes, pass, iv);
            }


            message = $"Encrypted File size: {Get.FileSize(binary)} & Writting to: {file}";
            if (this.AllowDebugger)
            {
                Get.Yellow(message);
                // Get.WaitTime(PrintingTime);
            }

            Binary.Writer(file, Get.Bytes(IConvert.BytesToString(binary)));
            message = $"{file} Sucessfully Encrypted!!! \nEncrypting Time: {check.Stop()}";
            if (this.AllowDebugger)
            {
                Get.Yellow(message);
                Get.Ok();
                // Get.WaitTime(PrintingTime);
            }
        }
    }
}
