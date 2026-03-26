using QuickTools.QCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickTools.QData
{
    /// <summary>
    /// This class provide a template for an error object
    /// </summary>
    public class Error
    {
        /// <summary>
        /// This get or set the type of error
        /// </summary>
        public   string Type { get; set; }
        /// <summary>
        /// This set or get the type 
        /// </summary>
        public   string Message { get; set; }

        /// <summary>
        /// This set or get the ID and as default is set to  <see cref="QuickTools.QCore.IRandom.RandomText(double)"/>
        /// </summary>
        public string ID = IRandom.RandomText(64); 
        /// <summary>
        /// Gets or set the Exception 
        /// </summary>
        public Exception ExceptionRecived { get; set; }
        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:QuickTools.QData.Error"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:QuickTools.QData.Error"/>.</returns>
        public override string ToString()
        {
            return $"Error Type: {this.Type} \n Error Message: {this.Message} \n Error ID: {this.ID} \n {this.ExceptionRecived}";
        }
    }
}
