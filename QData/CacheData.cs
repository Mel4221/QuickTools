using QuickTools.QCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public readonly string CacheFile = "QuickTools.cache";
        public void Cach(string key,string data)
        {
            settings = new QSettings(this.Path, "", "");
            settings.AddSetting(key, data); 
        }
        public void CachBytes(string key , byte[] data)
        {
            settings = new QSettings(this.Path, "", "");
            settings.AddSetting(key, IConvert.BytesToString(data)); 
        }
        public string GetCache(string key)
        {
            settings =  new QSettings(this.Path, "", "");
            return settings.GetSetting(key); 
        }

        public byte[] GetCacheBytes(string key)
        {
            settings = new QSettings(this.Path, "", "");
            return IConvert.StringToBytesArray(settings.GetSetting(key)); 
        }
        /// <summary>
        /// Removes the  cache 
        /// </summary>
        /// <param name="key"></param>
        public void RemoveCache(string key)
        {
            settings = new QSettings(this.Path, "", "");
            settings.RemoveSetting(key); 
        }

        /// <summary>
        /// Clear all cache stored
        /// </summary>
        public void ClearCache()
        {
            settings = new QSettings(this.Path, "", "");
            settings.DeleteSettingsFile();
        }

        /// <summary>
        /// Initialise the class
        /// </summary>
        public DataCacher()
        {
            this.Path = Get.DataPath("cache");
            Make.File($"{this.Path}/{this.CacheFile}");
        }
        public DataCacher(bool doNotClearPreviusCache)
        {
            this.Path = Get.DataPath("cache");
        }
    }
}
