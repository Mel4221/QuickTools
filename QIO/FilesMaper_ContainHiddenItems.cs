using System;
using QuickTools.QCore;
namespace QuickTools.QIO
{
    public partial class FilesMaper
    {
        private bool ContainHiddenItems(string path)
        {
            bool check = false;
            if (string.IsNullOrEmpty(path) || string.IsNullOrWhiteSpace(path)) return check;
            if (path.Length == 0) return check;
            /*
                /home/mel/x/.path/
                /.f

            */
            for(int ch = 0; ch < path.Length; ch++)
            {
                if(path[ch] == '.' && path[ch-1] == Get.SlashChar())
                {
                    return true;    
                }
            }
            return check;
        }
    }
}
