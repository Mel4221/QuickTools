using System;

namespace QuickTools.QData.Bastard
{
    public partial class ClownManager
    {
        private int AdjustedLength() { return this.BufferLength > this.StreamLength ? int.Parse(this.StreamLength.ToString()) : this.BufferLength; }
        private int NewLineLength() => Environment.NewLine.Length;

        private long AdjustedLength(long newLength)
        {
            return newLength;//this.BufferLength > newLength ? newLength : this.BufferLength;
        }
        public ClownManager() { }
        public ClownManager(string fileName) { this.FileName = fileName; }
        public void SoftLoad(string fileName) { this.FileName = fileName; }
        public void Load(string fileName)
        {
            this.FileName = fileName;
            this.Load();
        }
    }
}
