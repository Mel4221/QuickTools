using System;
namespace QuickTools.QSecurity
{
    public partial class Secure
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:QuickTools.Secure"/> class.
        /// </summary>
        public Secure()
        {
            //DefaultKey = new byte[16];
            //DefaultIV = new byte[16];
        }




        /// <summary>
        /// This inizializtion gives you full controll of how to Encrypter the file 
        /// </summary>
        /// <param name="clearText">Clear text.</param>
        /// <param name="key">Key.</param>
        /// <param name="iv">Iv.</param>
        public Secure(object clearText, byte[] key, byte[] iv)
        {
            this.Key = key;
            this.IV = iv;
            this.ClearText = clearText.ToString();
        }

    }
}
