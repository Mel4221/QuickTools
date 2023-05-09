﻿using System;
using System.Threading;
using System.IO;
using QuickTools.QIO;
namespace QuickTools.QCore
{
    public partial class Get
    {



        /// <summary>
        /// Allows To navigate throug directories and at the end could return the data colected at given directory
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static void Ls(string path)
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
                    if (File.Exists((files[file])))
                    {
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
                    if (Directory.Exists(directory[folder]))
                    {
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
            }
            catch
            {
                Get.Red($"Directorys or Directory Not Founc {directory[folder]}");
            }
             
        }


        /// <summary>
        /// Allows To navigate throug directories and at the end could return the data colected at given directory
        /// </summary>
        /// <param name="path"></param>
        /// <param name="dateFormat"></param>
        /// <returns></returns>
        public static void Ls(string path, string dateFormat)
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
                    if (File.Exists(files[file]))
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
                    if (Directory.Exists(directory[folder]))
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
            }
            catch
            {
                Get.Red($"Directorys or Directory Not Founc {directory[folder]}");
            }
           
        }

    }
}
