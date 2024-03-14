using System;
using QuickTools.QCore; 
namespace QuickTools.QNet
{
    /// <summary>
    /// Defines the Service object
    /// </summary>
    public class Service
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string ID { get; set; } = IRandom.RandomText(QuickToolsStandars.ServiceRandomIdLength);
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; } = "not-provided";
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public string Type { get; set; } = "not-given";
        /// <summary>
        /// Gets or sets the info.
        /// </summary>
        /// <value>The info.</value>
        public string Info { get; set; } = "not-provided";
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public string Status { get; set; } = "not-started";
        /// <summary>
        /// Gets or sets the current.
        /// </summary>
        /// <value>The current.</value>
        public double Current { get; set; } = 0;
        /// <summary>
        /// Gets or sets the goal.
        /// </summary>
        /// <value>The goal.</value>
        public double Goal { get; set; } = 0;

        /// <summary>
        /// Gets or sets the buffer size of the service request
        /// </summary>
        /// <value>The buffer.</value>
        public string Buffer { get; set; } = ""; 
        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:QuickTools.QNet.Service"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:QuickTools.QNet.Service"/>.</returns>
        public override string ToString()
        {
            return  $"ID: {this.ID}\n" +
                    $"Name: {this.Name}\n" +
                    $"Type: {this.Type}\n" +
                    $"Info: {this.Info}\n" +
                    $"Status: {this.Status}\n" +
                    $"Current: {this.Current}\n" +
                    $"Goal: {this.Goal}\n" +
                	$"BufferSize: {this.Buffer.Length}";
        }
    }
}
