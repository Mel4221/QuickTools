using System;
using System.Text;

namespace QuickTools.QSecurity
{
   public partial class Secure
    {
        /// <summary>
        /// Creates the password Based on the given input to be able to be addes as a key for the Encription or decription
        /// </summary>
        /// <returns>The password.</returns>
        /// <param name="password">Password.</param>
        public static byte[] CreatePassword(object password)
        {
            byte[] passByes = null;

            byte[] array = Encoding.ASCII.GetBytes(password.ToString());
            if (array.Length < 16)
            {

                passByes = new byte[16];
                for (int value = 0; value < array.Length; value++)
                {
                    passByes[value] = array[value];
                }
                return passByes;
            }
            else
            {
                passByes = new byte[16];
                byte[] bigerArray = Encoding.ASCII.GetBytes(password.ToString());

                for (int value = 0; value < passByes.Length; value++)
                {
                    passByes[value] = bigerArray[value];
                }
                return passByes;
            }


        }

    }
}
