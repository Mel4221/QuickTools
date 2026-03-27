using System;
namespace QuickTools.QCore
{
    /// <summary>
    /// Quick tools standars.
    /// </summary>
    public static class QuickToolsStandars
    {   
        /// <summary>
        /// Gets or sets the public IDL ength.
        /// </summary>
        /// <value>The public IDL ength.</value>
        public static int PublicIDLength { get; set; } = 12;
        /// <summary>
        /// Gets or sets the default port a.
        /// </summary>
        /// <value>The default port a.</value>
        public static int DefaultPortA { get; set; } = 4251;
        /// <summary>
        /// Gets or sets the default port b.
        /// </summary>
        /// <value>The default port b.</value>
        public static int DefaultPortB { get; set; } = 4221;
        /// <summary>
        /// Gets or sets the length of the service random identifier.
        /// </summary>
        /// <value>The length of the service random identifier.</value>
        public static int ServiceRandomIdLength { get; set; } = 16; 
    }
}
