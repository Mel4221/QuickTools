
using System.Collections.Generic;

namespace QuickTools.QData.Bastard
{
    public partial class ClownManager
    {
        /// <summary>
        /// Add the specified keys.
        /// </summary>
        /// <param name="key">Key.</param>
        public virtual void Add(ClownKey key )
        {
            this.Keys.Add(key); 
        }
        /// <summary>
        /// Gets the name of the all by.
        /// </summary>
        /// <returns>The all by name.</returns>
        /// <param name="name">Name.</param>
        public virtual List<ClownKey> GetAllByName(string name)
        {
            List<ClownKey> clownKeys = new List<ClownKey>();
            for (int item = 0; item < this.Keys.Count; item++)
            {
                if (this.Keys[item].Name == name)
                {
                    clownKeys.Add((this.Keys[item]));
                }
            }
            return clownKeys;
        }
        /// <summary>
        /// Gets the key.
        /// </summary>
        /// <returns>The key.</returns>
        /// <param name="name">Name.</param>
        public virtual ClownKey GetKey(string name)
        {
            for (int item = 0; item < this.Keys.Count; item++)
            {
                if (this.Keys[item].Name == name)
                {
                    return this.Keys[item];
                }
            }
            return new ClownKey();
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <returns>The value.</returns>
        /// <param name="name">Name.</param>
        public virtual string GetValue(string name)
        {
            return this.GetKey(name).Value;
        }
        /// <summary>
        /// Searchs the name of the all by.
        /// </summary>
        /// <returns>The all by name.</returns>
        /// <param name="name">Name.</param>
        public virtual List<ClownKey> SearchAllByName(string name)
        {
            List<ClownKey> keys = new List<ClownKey>();
            for (int item = 0; item < this.Keys.Count; item++)
            {
                if (this.Keys[item].Name == name)
                {
                    keys.Add(this.Keys[item]);
                }
            }
            return keys;
        }
        /// <summary>
        /// Updates the value.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="value">Value.</param>
        public virtual void UpdateValue(string name, string value)
        {
            throw new System.NotImplementedException("not implemented yet");
        }
        /// <summary>
        /// Updates the name of the key value by.
        /// </summary>
        /// <param name="key">Key.</param>
        public virtual void UpdateKeyValueByName(ClownKey key)
        {
            for (int item = 0; item < this.Keys.Count; item++)
            {
                if (this.Keys[item].Name == key.Name)
                {
                    this.Keys[item].Name = key.Name;
                    this.Keys[item].Value = key.Value;
                    this.Keys[item].Buffer = key.Buffer;
                    this.Keys[item].Index = key.Index;
                    this.Keys[item].length = key.length;
                    return;
                }
            }
        }
    }
}
