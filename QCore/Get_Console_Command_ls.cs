using System;
using System.Threading;
using System.IO;
using QuickTools.QIO;
namespace QuickTools.QCore
{
    public partial class Get
    {


        /// <summary>
        /// Contains the Object with the 2 types of data collected 
        /// </summary>
        public class LsData
        {
            /// <summary>
            /// the list of files 
            /// </summary>
            public string[] Files;

            /// <summary>
            /// the list of directoryes 
            /// </summary>
            public string[] Directorys; 
        }

        /// <summary>
        /// Allows To navigate throug directories and at the end could return the data colected at given directory
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static LsData Ls(string path)
        {
            string[] files = new FilesMaper().GetFiles(path);
            string[] directory = Directory.GetDirectories(path);
            int change, file, folder;
           
            file = 0;
            change = 0;
            folder = 0;


            try
            {
                for (file = 0; file < files.Length; file++)
                {
                    Get.Red();
                    Get.Write($"{Get.FileNameFromPath(files[file])} ");
                    if (change <= 4)
                    {
                        change++;
                    }
                    if (change == 4)
                    {
                        Get.WriteL(" ");
                        change = 0;
                    }
                }

            }
            catch
            {
                Get.Red($"Files or File Not Found {files[file]}");
            }
            try
            {

                for (folder = 0; folder < directory.Length; folder++)
                {
                    Get.Red();
                    Get.Blue($"{Get.FileNameFromPath(directory[folder])} ");
                    if (change <= 4)
                    {
                        change++;
                    }
                    if (change == 4)
                    {
                        Get.WriteL(" ");
                        change = 0;
                    }
                }
            }
            catch
            {
                Get.Red($"Directorys or Directory Not Founc {directory[folder]}");
            }
            return new LsData()
            {
                Files = files,
                Directorys = directory
            }; 
        }


        /// <summary>
        /// Allows To navigate throug directories and at the end could return the data colected at given directory
        /// </summary>
        /// <param name="path"></param>
        /// <param name="dateFormat"></param>
        /// <returns></returns>
        public static LsData Ls(string path, string dateFormat)
        {

            string[] files = new FilesMaper().GetFiles(path);
            string[] directory = Directory.GetDirectories(path);
            int change, file, folder;
            file = 0;
            change = 0;
            folder = 0;
            try
            {
                for (file = 0; file < files.Length; file++)
                {
                    Get.Yellow();
                    Get.Write($" {File.GetLastWriteTime(files[file]).ToString(dateFormat)} ");
                    Get.Red();
                    Get.Write($" {Get.FileNameFromPath(files[file])} ");
                    if (change <= 1)
                    {
                        change++;
                    }
                    if (change == 1)
                    {
                        Get.WriteL(" ");
                        change = 0;
                    }
                }

            }
            catch
            {
                Get.Red($"Files or File Not Found {files[file]}");
            }

            try
            {
                change = 1;
                for (folder = 0; folder < directory.Length; folder++)
                {
                    Get.Yellow();
                    Get.Write($" {Directory.GetLastWriteTime(directory[folder]).ToString(dateFormat)} ");
                    Get.Red();
                    Get.Blue($" {Get.FileNameFromPath(directory[folder])} ");
                    if (change <= 1)
                    {
                        change++;
                    }
                    if (change == 1)
                    {
                        Get.WriteL(" ");
                        change = 0;
                    }
                }
            }
            catch
            {
                Get.Red($"Directorys or Directory Not Founc {directory[folder]}");
            }
           return new LsData()
            {
                Files = files,
                Directorys = directory
            };
        }

    }
}
