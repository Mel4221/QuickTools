
using System.Collections.Generic;

namespace QuickTools.QData.Bastard
{
    public partial class ClownManager
    {
        public string FileName { get; set; }
        public List<ClownKey> Keys = new List<ClownKey>();
        public int BufferLength { get; set; } = 1024 * 1024 * 10;//10MB
        public long StreamLength { get; set; }
        public long FailSafe { get; set; } = 0;
        public long MaxAttemps { get; set; } = 5;
        public bool AllowDebugger { get; set; } = false;
        public bool LoadAsBytes { get; set; } = false;
        public bool SaveAsBytes { get; set; } = false;
        public string TextStatus { get; set; } = "not-started";
        public int ProgressStatus { get; set; } = 0;
    }
}
