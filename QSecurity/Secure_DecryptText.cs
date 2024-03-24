
using System;
using System.Text; 
using System.IO;
using QuickTools.QIO; 
using QuickTools.QCore;
using System.Security.Cryptography;


namespace QuickTools.QSecurity
{
      /// <summary>
      /// The Secure class works pretty well so far on text DO NOT USE IT ON BINARY DATA IT COULD BREAK 
      /// THE FILES    
      /// </summary>
    public partial class Secure 
    {
            /// <summary>
            /// Decrypts the text.
            /// </summary>
            /// <returns>The text.</returns>
            /// <param name="text">Text.</param>
            /// <param name="password">Password.</param>
            public string DecryptText(string text, object password) => this.Decrypt(IConvert.StringToBytesArray(text),CreatePassword(password), Get.KeyBytesSaved());

     }
}