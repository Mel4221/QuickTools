using System;
using System.Threading;
using QuickTools.QCore; 
using System.Collections.Generic; 
namespace QuickTools.QNet
{ 
    public partial class QService
    {
        /// <summary>
        /// The Thread  for the service manager
        /// </summary>
        public Thread QServiceThread;
        /// <summary>
        /// Gets or sets the server.
        /// </summary>
        /// <value>The server.</value>
        public QServer Server { get; set; } = new QServer(); // new QServer("localhost",IRandom.RandomInt(4221,4251)); 
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:QuickTools.QNet.QService"/> exit request.
        /// </summary>
        /// <value><c>true</c> if exit request; otherwise, <c>false</c>.</value>
        public bool ExitRequest { get; set; } = false;
        /// <summary>
        /// Gets or sets the services.
        /// </summary>
        /// <value>The services.</value>
        public Queue<Service> Services { get; set; } = new Queue<Service>();

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:QuickTools.QNet.QService"/> allow deubbuger.
        /// </summary>
        /// <value><c>true</c> if allow deubbuger; otherwise, <c>false</c>.</value>
        public bool AllowDebugger { get; set; } = false;

        /// <summary>
        /// Gets or sets the port.
        /// </summary>
        /// <value>The port.</value>
        public int Port { get; set; } = QuickToolsStandars.DefaultPortA;
        /// <summary>
        /// The public identifier for each function that is being executed 
        /// </summary>
        public string PublicID = IRandom.RandomText(QuickToolsStandars.PublicIDLength); 
    }
}
