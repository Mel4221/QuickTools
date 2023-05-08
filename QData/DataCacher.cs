using QuickTools.QCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickTools.QIO;
using System.IO;

namespace QuickTools.QData
{

    /// <summary>
    /// provides a diferent way to cache the data on a way that the data does get deleted right after if is not required
    /// </summary>
    public class DataCacher
    {
        private QSettings settings;
        /// <summary>
        /// contains the path to get to the cache
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// contains the Cache file 
        /// </summary>
        public readonly string CacheFile = "QuickToolsCache.xml";

        /// <summary>
        /// Cache the given data 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        public void Cach(string key, string data)
        {

            settings.AddSetting(key, data);
        }

        /// <summary>
        /// Cache the given data on binary 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        public void CachBytes(string key, byte[] data)
        {
            string cacheFile = $"{Get.DataPath("cache")}{key}.cache";
            if (!File.Exists(cacheFile))
            {
                Binary.Writer(cacheFile, data);
                return;
            }
            else
            {
                throw new Exception("Cache Already Contains that key");
            }
        }

        /// <summary>
        /// Gets te data with the given key 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetCache(string key)
        {
            return settings.GetSetting(key);
        }

        /// <summary>
        /// Gets the binary data with the given key 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public byte[] GetCacheBytes(string key)
        {
            string cacheFile = $"{Get.DataPath("cache")}{key}.cache";

            return Binary.Reader(cacheFile);
        }
        /// <summary>
        /// Removes the  cache 
        /// </summary>
        /// <param name="key"></param>
        public void RemoveCache(string key)
        {
            settings.RemoveSetting(key);
        }

        /// <summary>
        /// Clear all cache stored
        /// </summary>
        public void ClearCache()
        {
            FilesMaper maper = new FilesMaper();
            string[] files = maper.GetFiles(Get.DataPath("cache"));
            foreach (string file in files)
            {
                if (File.Exists(file))
                {
                    File.Delete(file);
                }
            }

        }

        /// <summary>
        /// Initialise the class
        /// </summary>
        public DataCacher()
        {
            this.ClearCache();
            this.Path = Get.DataPath("cache");
            settings = new QSettings(this.CacheFile, "DataCacher", "Data", this.Path);
            settings.Create();

        }

    }
}
