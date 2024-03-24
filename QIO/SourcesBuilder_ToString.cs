using System;
using System.Text;

namespace QuickTools.QIO
{
    public partial class SourcesBuilder
    {
        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:QuickTools.QIO.SourcesBuilder"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:QuickTools.QIO.SourcesBuilder"/>.</returns>
        public override string ToString()
        {
            Func<string> report = () => 
            {
                StringBuilder f = new StringBuilder();
                for (int item = 0; item < this.Packages.Count; item++)
                {
                    for (int subItem = 0; subItem < this.Packages[item].DependencyDirs.Count; subItem++)
                    {
                        f.Append($"{this.Packages[item].DependencyDirs[subItem].ToString()}\n");
                    }
                }
                for (int item = 0; item < this.Packages.Count; item++)
                {
                    for(int subItem = 0; subItem < this.Packages[item].DependencyFiles.Count; subItem++)
                    {
                        f.Append($"{this.Packages[item].DependencyFiles[subItem].ToString()}\n");
                    }
                }
                return $"{f.ToString()}";
            };
            return report();
        }
    }
}
