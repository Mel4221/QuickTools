using System;
using QuickTools.QCore;
namespace QuickTools.QIO
{
    public partial class BinDownloader : BinBuilder
    {

        private Package GetPackage(string package)
        {
            foreach (Package p in this.Packages)
            {
                if (p.Name == package)
                {
                    return p;
                }
            }
            throw new Exception($"Package [{package}] NotFound!!!");
        }
        private string ToRaw(string url)
        {
            string link, branch;
            link = url;
            branch = "";
            if (string.IsNullOrEmpty(url) || string.IsNullOrWhiteSpace(url)) throw new Exception($"The given url is not valid [{url}]");
            if (link[link.Length - 1] == '/')
            {
                link = link.Substring(0, link.Length - 2);
            }
            branch = link.Substring(link.LastIndexOf('/') + 1);
            link = link.Substring(0, link.LastIndexOf('/'));
            link = link.Substring(0, link.LastIndexOf('/'));
            if (this.AllowDeubbuger)
            {
                Get.Yellow($"Branch: [{branch}]");
                Get.Red($"Link: [{link}]");
                link = $"{link}/raw/{branch}/";
                Get.Green($"Conbined: [{link}]");
            }
            this.CurrentStatus = $"LINK: {link}";
            //Get.Yellow(link);
            return link;
        }
    }
}
