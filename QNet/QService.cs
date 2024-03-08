using System;
using System.Net; 
using System.Threading;
using QuickTools.QCore;
using System.Collections.Generic; 
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
        public string ID { get; set; } = IRandom.RandomText(16);
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
					$"Goal: {this.Goal}\n";
        }
    }

    /// <summary>
    /// QService is a method wich provides funtionalities
    /// to share information along other programs through 
    /// an standard api
    /// </summary>
    public class QService
    {

        /// <summary>
        /// The Thread  for the service manager
        /// </summary>
        public Thread QServiceThread;
        /// <summary>
        /// Gets or sets the server.
        /// </summary>
        /// <value>The server.</value>
        public QServer Server { get; set; } = new QServer("localhost",IRandom.RandomInt(4221,4251)); 
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:QuickTools.QNet.QService"/> exit request.
        /// </summary>
        /// <value><c>true</c> if exit request; otherwise, <c>false</c>.</value>
        public bool ExitRequest { get; set; } = false;
        /// <summary>
        /// Gets or sets the services.
        /// </summary>
        /// <value>The services.</value>
        public Queue<QServer> Services { get; set; } = new Queue<QServer>();

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:QuickTools.QNet.QService"/> allow deubbuger.
        /// </summary>
        /// <value><c>true</c> if allow deubbuger; otherwise, <c>false</c>.</value>
        public bool AllowDeubbuger { get; set; } = false; 

        private void CheckForExitCommand(string cmd)
        {
            switch(cmd)
            {
                case "exit":
                    this.ExitRequest = true; 
                    return;
                default:
                    return;
            }
        }

        /// <summary>
        /// Start this instance.
        /// </summary>
        public void Start()
        {

            QServiceThread = new Thread(() => 
            { 
                 while(!this.ExitRequest)
                {
                    HttpListenerRequest request = this.Server.Listen();
                    string cmd = request.RawUrl.Substring(0); 
                    if (this.AllowDeubbuger)
                    {
                        Get.Print("Request", cmd);
                    }
                    this.CheckForExitCommand(cmd);
                }
            });
            QServiceThread.Start();
        }
       
    }
}
