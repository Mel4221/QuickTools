using System;
using QuickTools.QCore;
namespace QuickTools.QDevelop
{
    public partial class BinDownloader : BinBuilder
    {

        /// <summary>
        /// Gets the package.
        /// </summary>
        /// <returns>The package.</returns>
        /// <param name="package">Package.</param>
        public Package GetPackage(string package)
        {
            foreach (Package _p in this.Packages)
            {
                if (_p.Name == package)
                {
                    return _p;
                }
            }
            throw new Exception($"Package [{package}] NotFound!!!");
        }

    
          string GetLink(ref Package package ,string link)
        {
            string url, branch;
            url = "";
            branch = package.Branch;
            Get.Pink($"[{package.Name}] [{package.Branch}]");
            if (this.AllowDeubbuger) Get.Red(package.ToString()); 
            this.CurrentTextStatus = $"BRANCH: [{branch}]";
            if(this.AllowDeubbuger)Get.Red(this.CurrentIntStatus);
           
                url = $"{link.Substring(0, link.LastIndexOf('.'))}/raw/{branch}/";
            return url; 
        }
        /*
        public string ToRaw(string url)
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
            this.CurrentTextStatus = $"LINK: {link}";
            //Get.Yellow(link);
            return link;
        }
        */
    }
}
