using System;
using System.Text;
using System.IO;
using QuickTools.QIO;
using QuickTools.QCore;
using System.Security.Cryptography;
namespace QuickTools.QSecurity
{
    public partial class Secure
    {
        /// <summary>
        /// Decrypt the file with the given information 
        /// </summary>
        /// <param name="file"></param>
        /// <param name="password"></param>
        /// <param name="iv"></param>
        /// <exception cref="FileNotFoundException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception">Invalid Password Exseption</exception>
        public void DecryptFile(string file, string password, byte[] iv)
        {
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
            byte[] bytes, pass;
            string data, message;
            bytes = IConvert.StringToBytesArray(IConvert.ToString(Binary.Reader(file)), this.AllowDebugger);//binary.BufferList.ToArray();//IConvert.StringToBytesArray(Reader.Read(file));
            message = $"File Size: {Get.FileSize(bytes)} & Creatting password...";
            if (this.AllowDebugger)
            {
                Get.Yellow(message);
                // Get.WaitTime(PrintingTime);
            }
            pass = CreatePassword(password);

            data = this.Decrypt(bytes, pass, iv);
            message = $"Dcrypting...";
            if (this.AllowDebugger)
            {
                Get.Yellow(message);
                // Get.WaitTime(PrintingTime);
            }
            if (data == null || data == "")
            {
                message = $"Decrypting Failed due to wrong format or wrong password";
                if (this.AllowDebugger)
                {
                    Get.Red(message);
                    // Get.WaitTime(PrintingTime);
                }
                throw new Exception($"Invalid Password");
            }
            message = $"Converting String Format to Binary...";
            if (this.AllowDebugger)
            {
                Get.Yellow(message);
                // Get.WaitTime(PrintingTime);
            }
            bytes = IConvert.StringToBytesArray(data);
            file = this.OutFile == null ? file : this.OutFile;
            message = $"Writting bytes to {file}";
            if (this.AllowDebugger)
            {
                Get.Yellow(message);
                // Get.WaitTime(PrintingTime);
            }
            Binary.Writer(file, bytes);
            message = $"{file} Sucessfully Decrypted!!!";
            if (this.AllowDebugger)
            {
                Get.Yellow(message);
                Get.Ok();
                // Get.WaitTime(PrintingTime);
            }
        }

    }
}
