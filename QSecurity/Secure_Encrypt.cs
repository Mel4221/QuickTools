using System;
using System.Text; 
using System.IO;
using System.Security.Cryptography;
using System.Diagnostics;

using QuickTools.QCore;


namespace QuickTools.QSecurity
{
      /// <summary>
      /// The secure class is a class that uses the Aes tecnology to encrypt data by using
      /// a public key and a 
      /// </summary>
      public partial class Secure:IDisposable
        {

            /// <summary>
            /// Encrypt the specified bytes, with password and IV.
            /// </summary>
            /// <returns>The encrypt.</returns>
            /// <param name="bytes">Bytes.</param>
            /// <param name="password">Password.</param>
            /// <param name="IV">Iv.</param>
            public byte[] Encrypt(byte[] bytes , byte[] password , byte[] IV)
            {
                  if(bytes.Length == 0 || password.Length == 0 || IV.Length == 0)
                  {
                        throw new ArgumentException("Pleas Check any of your arguments given due to the length is incorrect");
                  }

                  byte[] encrypted;
                  char[] chars = IConvert.ToCharArray(bytes); 

                  // Create an Aes object
                  // with the specified key and IV.
                  using (Aes aes = Aes.Create())
                  {



                        aes.Key = password;
                        aes.IV = IV;


                        // Create an encryptor to perform the stream transform.
                        ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                        // Create the streams used for encryption.
                        using (MemoryStream msEncrypt = new MemoryStream())
                        {
                              using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                              {
                                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                                    {
                                          //Write all data to the stream.

                                          swEncrypt.Write(chars,0,chars.Length);
                                    }
                                    encrypted = msEncrypt.ToArray();
                              }
                        }
                  }

                  // Return the encrypted bytes from the memory stream.
                  //string text = Encoding.ASCII.GetString(encrypted);
                  return encrypted;
                  // }catch(Exception)
                  // {
                  //    return null; 
                  //}
            }










      
            #region IDisposable Support
            private bool disposedValue = false; // To detect redundant calls

            /// <summary>
            /// Dispose the specified disposing.
            /// </summary>
            /// <param name="disposing">If set to <c>true</c> disposing.</param>
            protected virtual void Dispose(bool disposing)
            {
                  if (!disposedValue)
                  {
                        if (disposing)
                        {
                              // TODO: dispose managed state (managed objects).
                        }

                        // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                        // TODO: set large fields to null.

                        disposedValue = true;
                  }
            }

        


            /// <summary>
            /// Releases all resource used by the <see cref="T:QuickTools.Secure"/> object.
            /// </summary>
            /// 
            /// 
            public void Dispose()
            {
                  // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
                  Dispose(true);
                  // TODO: uncomment the following line if the finalizer is overridden above.
                  // GC.SuppressFinalize(this);
            }
            #endregion


      }
}