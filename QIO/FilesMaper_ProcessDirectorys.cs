using System;
using QuickTools.QCore;
namespace QuickTools.QIO
{
    public partial class FilesMaper
    {
        private void ProcessDirectory(string targetDirectory)
        {


            if (!this.IgnoreHiddenDirectorys)
            {
                if (this.AllowDebugger) Get.Blue(targetDirectory);
                this.Directories.Add(targetDirectory);
            }
            if (this.IgnoreHiddenDirectorys)
            {
                bool hasHiddenDirs = this.ContainHiddenItems(targetDirectory);
                if (!hasHiddenDirs)
                {
                    this.Directories.Add(targetDirectory);
                }
                if (hasHiddenDirs && this.AllowDebugger) Get.Red($"IGNORED HIDDEN DIR: [{targetDirectory}]");
            }

            // Process the list of files found in the directory.
            string[] fileEntries;
            try
            {
                fileEntries = this.GetFiles(targetDirectory);


                foreach (string fileName in fileEntries)
                {

                    ProcessFile(fileName);
                }

                // Recurse into subdirectories of this directory.
                try
                {
                    string[] subdirectoryEntries = this.GetDirs(targetDirectory);
                    foreach (string subdirectory in subdirectoryEntries)
                    {

                        ProcessDirectory(subdirectory);
                        // Get.Blue(subdirectory);

                    }
                }
                catch (Exception ex)
                {
                    string error = $"File Error: {ex.Message}";
                    if (this.AllowDebugger)
                    {
                        Get.Red(error);
                    }


                    this.FileErrors.Add(error);

                }
            }
            catch (Exception ex)
            {
                string error = $"Directory Error: {ex.Message}";
                if (this.AllowDebugger)
                {
                    Get.Red(error);
                }
                this.DirectoriesError.Add(error);
            }
        }
    }
}
