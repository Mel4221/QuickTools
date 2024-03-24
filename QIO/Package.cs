using System;
using System.Collections.Generic; 
using QuickTools.QCore;
namespace QuickTools.QIO
{
    /// <summary>
    /// Contains the Package object in which it could contain all the references
    /// to an actual file
    /// </summary>
    public partial class Package
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; } = String.Empty;
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string Id { get; set; } = IRandom.RandomText(16);
        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>The size.</value>
        public string Size { get; set; } = String.Empty;
        /// <summary>
        /// Gets or sets the creator.
        /// </summary>
        /// <value>The creator.</value>
        public string Creator { get; set; } = String.Empty;
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; } = String.Empty;
        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>The date.</value>
        public string Date { get; set; } = DateTime.Now.ToString("MM/dd/yyyy");
        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>The source.</value>
        public string Source { get; set; } = String.Empty;
        /// <summary>
        /// Gets or sets the dependency files.
        /// </summary>
        /// <value>The dependency files.</value>
        public List<Files> DependencyFiles { get; set; } = new List<Files>();
        /// <summary>
        /// Gets or sets the dependency dirs.
        /// </summary>
        /// <value>The dependency dirs.</value>
        public List<Directorys> DependencyDirs { get; set; } = new List<Directorys>(); 


        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:QuickTools.QIO.Package"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:QuickTools.QIO.Package"/>.</returns>
        public override string ToString()
        {
            return $"NAME: [{this.Name}]\n" +
                   $"ID: [{this.Id}]\n" +
                   $"SIZE: [{this.Size}]\n" +
                   $"CREATOR: [{this.Creator}]\n" +
                   $"DESCRIPTION: [{this.Description}]\n" +
                   $"DATE: [{this.Date}]\n" +
                   $"SOURCE: [{this.Source}]\n" +
                   $"DEPENDENCY-FILES: [{this.DependencyFiles.Count}]\n" +
                   $"DEPENDENCY-DIRS: [{this.DependencyDirs.Count}]\n";
        }
        /// <summary>
        /// Clear this instance.
        /// </summary>
        public void Clear()
        {
            this.Name = string.Empty;
            this.Id = string.Empty;
            this.Size = string.Empty;
            this.Creator = string.Empty;
            this.Description = string.Empty;
            this.Date = string.Empty;
            this.Source = string.Empty;
            this.DependencyFiles = new List<Files>();
            this.DependencyDirs = new List<Directorys>(); 

        }
    }
}
