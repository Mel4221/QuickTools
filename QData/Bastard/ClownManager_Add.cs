using System;
using System.IO;
using QuickTools.QCore;
using System.Linq;
namespace QuickTools.QData.Bastard
{
    public partial class ClownManager
    {
        /// <summary>
        /// Add the specified keys.
        /// </summary>
        /// <param name="key">Key.</param>
        public virtual void Add(ClownKey key)
        {
            //Get.Yellow($"Index: {this.Indexer} K: {k.Index}");
            //if (this.Indexer > 0) this.Indexer++; 
            key.Length = key.GetLength();
            if(this.Keys.Count == 0)
            {
                key.Index = 0;
            }
            if (this.Keys.Count > 0)
            {
                key.Index = this.Keys[this.Keys.Count - 1].GetSize() +
                            this.Keys[this.Keys.Count - 1].Index;
            }
            this.TextStatus = $"Adding key..: {key}";
            if (this.AllowDebugger) Get.Yellow(this.TextStatus);
            this.Keys.Add(key);
            this.Indexer += key.GetSize() + 1; 
            //Get.Yellow($"Index: {this.Indexer}");
            //this.Keys.ForEach(item => Get.Pink(item));

        }
    }
}
