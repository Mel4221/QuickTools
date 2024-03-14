using System;
namespace QuickTools.QData
{


    /// <summary>
    /// contains the format for the the key >
    /// </summary>
    public class Key
    {


        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:QuickTools.QData.Key"/> is empty.
        /// </summary>
        /// <value><c>true</c> if is empty; otherwise, <c>false</c>.</value>
        public bool IsEmpty { get; set; } = false;
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; } = null;
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public string Value { get; set; } = null;
        /// <summary>
        /// The key terminator char.
        /// </summary>
        public char KeyTerminatorChar { get; set; } = ';';
        /// <summary>
        /// The key assing char.
        /// </summary>
        public char KeyAssingChar { get; set; } = '=';


        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:QuickTools.QData.Key"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:QuickTools.QData.Key"/>.</returns>
        public override string ToString()
        {
            return $"KEY{this.KeyAssingChar}{this.Name}{this.KeyTerminatorChar}VALUE{this.KeyAssingChar}{this.Value}{this.KeyTerminatorChar}";
        }

        /// <summary>
        /// this returns the text into 2 main formats html and json 
        /// it will return the formatinto a key and value that will be understood by html
        /// and also by json engine 
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public string ToString(string format)
        {
            switch (format)
            {
                case "html":
                    return $"<KEY='{this.Name}'VALUE='{this.Value}'/>".Replace("'", '"'.ToString());
                case "json":
                    return "{\n" +
                        $"\t'{this.Name}':".Replace("'", '"'.ToString()) +
                        $"{this.Value}\n" +
                        "}";
                default:
                    return this.ToString();
            }
        }
    }
}
