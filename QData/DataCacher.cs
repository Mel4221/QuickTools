using QuickTools.QCore;
using System;
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
        /// contains the Cache file
        /// QuickToolsCache.xml
        /// </summary>
        public string CacheFile { get; set; } = "QuickTools.cache";

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
            //this.ClearCache();
            
            
            this.settings = new QSettings(this.CacheFile);
            this.settings.Create();
            this.settings.Load();

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:QuickTools.QData.DataCacher"/> class.
        /// </summary>
        /// <param name="clearCache">If set to <c>true</c> clear cache.</param>
        public DataCacher(bool clearCache)
        {
            if (clearCache)
            {
                this.ClearCache();
            }

          
            this.settings = new QSettings(this.CacheFile);
            this.settings.Create();
            this.settings.Load();

        }


    }
}
