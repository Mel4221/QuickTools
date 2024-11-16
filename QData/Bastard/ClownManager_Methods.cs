
using System.Collections.Generic;

namespace QuickTools.QData.Bastard
{
    public partial class ClownManager
    {

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

        public virtual string GetValue(string name)
        {
            return this.GetKey(name).Value;
        }
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
        public virtual void UpdateValue(string name, string value)
        {

        }
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
