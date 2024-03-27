using System;
namespace QuickTools.QIO
{
    public partial class Package
    {

            /// <summary>
            /// Files.
            /// </summary>
            public class Files
            {
                /// <summary>
                /// Gets or sets the name.
                /// </summary>
                /// <value>The name.</value>
                public string Name { get; set; } = "NOT-GIVEN";
                /// <summary>
                /// Gets or sets the size.
                /// </summary>
                /// <value>The size.</value>
                public string Size { get; set; } = "NOT-GIVEN";
                /// <summary>
                /// Gets or sets the hash.
                /// </summary>
                /// <value>The hash.</value>
                public string Hash { get; set; } = "NOT-GIVEN";
                /// <summary>
                /// Gets or sets the length.
                /// </summary>
                /// <value>The length.</value>
                public string Length { get; set; } = "NOT-GIVEN";
                /// <summary>
                /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:QuickTools.QIO.Package.Dependencys.Files"/>.
                /// </summary>
                /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:QuickTools.QIO.Package.Dependencys.Files"/>.</returns>
                public override string ToString() => $"FILE: [{this.Name}] SIZE: [{this.Size}] HASH: [{this.Hash}] LENGTH: [{this.Length}]";
                /// <summary>
                /// Clear this instance.
                /// </summary>
                public void Clear()
                {
                    this.Name = string.Empty;
                    this.Size = string.Empty;
                    this.Hash = string.Empty;
                }

        }
            /// <summary>
            /// Directorys.
            /// </summary>
            public class Directorys
            {
                /// <summary>
                /// Gets or sets the name.
                /// </summary>
                /// <value>The name.</value>
                public string Name { get; set; }
                /// <summary>
                /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:QuickTools.QIO.Package.Directorys"/>.
                /// </summary>
                /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:QuickTools.QIO.Package.Directorys"/>.</returns>
                public override string ToString() => $"DIR: [{this.Name}]";

            }

 
    }
}
