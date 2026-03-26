using System;
using System.Threading;
using System.IO;
using QuickTools.QIO;
using QuickTools.QColors;

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
            Get.WriteL(" ");

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

                   

                    if (File.Exists((files[file])))
                    {
                        string f = $"{Get.FileNameFromPath(files[file])}\t";
                        switch (Get.FileExention(files[file]))
                        {
                            case "exe":
                                Get.Green();
                                Get.Write(f);
                                break; 
                            case "bin":
                            case "pdf":
                            case "doc":
                            case "docx":
                            case "iso":
                            case "rar":
                            case "zip":
                            case "tar":
                            case "gz":
                            case "xyz":
                                Get.Red();
                                Get.Write(f);
                                break;
                            case "py":
                            case "bash":
                            case "bat":
                                Color.Cyan();
                                Get.Write(f);
                                break;
                            case "config":
                            case "log":
                            case "xml":
                            case "db":
                            case "html":
                            case "css":
                            case "js":
                            case "cs":
                            case "c":
                            case "cc":
                            case "h":
                                Color.Yellow();
                                Get.Write(f);
                                break;
                            case "jpg":
                            case "png":
                            case "mp4":
                            case "mp3":
                            case "mov":
                            case "webm":
                            case "mkv":
                            case "flv":
                            case "avi":
                            case "vob":
                            case "gif":
                            case "ogv":
                            case "ogg":
                            case "gifv":
                            case "wmv":
                            case "m4p":
                            case "svb":
                            case "jpeg":
                            case "bmp":
                            case "ico":
                            case "svg":
                            case "odt":
                            case "rtf":
                            case "tex":
                            case "wpd":
                            case "aae":
                            case "csv":
                            case "key":
                            case "mpp":
                            case "obb":
                            case "ppt":
                            case "pptx":
                            case "rpt":
                            case "aif":
                            case "flac":
                            case "mid":
                            case "wav":
                            case "wma":
                            case "3gp":
                            case "asf":
                            case "m4v":
                            case "mpg":
                            case "srt":
                            case "swf":
                            case "ts":
                            case "3dm":
                            case "bl":
                            case "dae":
                            case "fbx":
                            case "max":
                            case "obj":
                            case "dcm":
                            case "dds":
                            case "djvu":
                            case "heic":
                            case "psd":
                            case "tga":
                            case "tif":
                            case "ai":
                            case "cdr":
                            case "emf":
                            case "eps":
                            case "ps":
                            case "sk":
                            case "vs":
                            case "indd":
                            case "ox":
                            case "pmd":
                            case "pub":
                            case "qxp":
                            case "xps":
                                Get.Pink();
                                Get.Write(f);
                                break;
                            case "dll":
                            case "lib":
                            case "jlv":
                                Get.Red();
                                Get.Write(f);
                                break;
                            default:
                                Get.White();
                                Get.Write(f);
                                break; 
                        }
                      

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
                      
                        string f = $" {Get.FileNameFromPath(directory[folder])}{Get.Slash()} ";
                         
                                Get.Blue();
                                Get.Write(f);
                      
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
                Get.WriteL(" ");

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
            Get.WriteL(" ");

            try
            {
                for (file = 0; file < files.Length; file++)
                {
                    if (File.Exists(files[file]))
                    {
                        Get.Yellow();
                        Get.Write($" {File.GetLastWriteTime(files[file]).ToString(dateFormat)} ");
                        GC.Collect();
                        Get.White();
                        Get.Write($" {Get.FileSize(files[file])} ");
                        string f = $" {Get.FileNameFromPath(files[file])} ";
                        switch (Get.FileExention(files[file]))
                        {
                            case "exe":
                                Get.Green();
                                Get.Write(f);
                                break;
                            case "bin":
                            case "pdf":
                            case "doc":
                            case "docx":
                            case "iso":
                            case "rar":
                            case "zip":
                                Get.Red();
                                Get.Write(f);
                                break;
                            case "py":
                            case "bash":
                            case "bat":
                                Color.Cyan();
                                Get.Write(f);
                                break;
                            case "config":
                            case "log":
                            case "xml":
                            case "db":
                            case "html":
                            case "css":
                            case "js":
                            case "cs":
                                Color.Yellow();
                                Get.Write(f);
                                break;
                            case "jpg":
                            case "png":
                            case "mp4":
                            case "mp3":
                            case "mov":
                            case "webm":
                            case "mkv":
                            case "flv":
                            case "avi":
                            case "vob":
                            case "gif":
                            case "ogv":
                            case "ogg":
                            case "gifv":
                            case "wmv":
                            case "m4p":
                            case "svb":
                            case "jpeg":
                            case "bmp":
                            case "ico":
                            case "svg":
                                Get.Pink();
                                Get.Write(f);
                                break;
                            default:
                                Get.White();
                                Get.Write(f);
                                break;
                        }
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
                Get.WriteL(" ");

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
                        Get.Blue($" {Get.FileNameFromPath(directory[folder])}{Get.Slash()}");
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
                Get.WriteL(" ");

            }
            catch
            {
                Get.Red($"Directorys or Directory Not Founc {directory[folder]}");
            }
           
        }

        /// <summary>
        /// trys to match the file type extention
        /// </summary>
        /// <param name="file"></param>
        /// <param name="test"></param>
        /// <returns></returns>
       public static bool MatchFileExtention(string file, string test) => Get.FileExention(file) == Get.FileExention(test);



        /// <summary>
        /// only prints the one that meet the type 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="printType"></param>
        /// <param name="printOnlyType"></param>
        public static void Ls(string path,string printType,bool printOnlyType)
        {
            Get.WriteL(" ");

            string[] files = new FilesMaper().GetFiles(path);
            //string[] directory = new FilesMaper().GetDirs(path);
            foreach(string file in files)
            {
                if (Get.MatchFileExtention(file, printType))
                {
                    string f = Get.FileNameFromPath(file);
                    switch (Get.FileExention(file))
                    {
                        case "exe":
                            Get.Green();
                            Get.Write(f);
                            break;
                        case "bin":
                        case "pdf":
                        case "doc":
                        case "docx":
                        case "iso":
                        case "rar":
                        case "zip":
                            Get.Red();
                            Get.Write(f);
                            break;
                        case "py":
                        case "bash":
                        case "bat":
                            Color.Cyan();
                            Get.Write(f);
                            break;
                        case "config":
                        case "log":
                        case "xml":
                        case "db":
                        case "html":
                        case "css":
                        case "js":
                        case "cs":
                            Color.Yellow();
                            Get.Write(f);
                            break;
                        case "jpg":
                        case "png":
                        case "mp4":
                        case "mp3":
                        case "mov":
                        case "webm":
                        case "mkv":
                        case "flv":
                        case "avi":
                        case "vob":
                        case "gif":
                        case "ogv":
                        case "ogg":
                        case "gifv":
                        case "wmv":
                        case "m4p":
                        case "svb":
                        case "jpeg":
                        case "bmp":
                        case "ico":
                        case "svg":
                            Get.Pink();
                            Get.Write(f);
                            break;
                        default:
                            Get.White();
                            Get.Write(f);
                            break;

                    }
                    Get.WriteL(" ");
                } 
            }

        }

    }
}
