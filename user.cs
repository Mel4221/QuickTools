using System; 
namespace QuickTools
{
        

      /// <summary>
      /// This class simplified the creation of a regular login for a console application
      /// </summary>
	public class User
		{
                  /// <summary>
                  /// Gets or sets the name.
                  /// </summary>
                  /// <value>The name.</value>
			public static string Name { get; set; }
            /// <summary>
            /// Gets or sets the last name 
            /// </summary>
            /// <value>The name of the lat.</value>
			public static string LatName { get; set; }
            /// <summary>
            /// Gets or sets the password.
            /// </summary>
            /// <value>The password.</value>
			public static string Password { get; set; }
            /// <summary>
            /// Gets or sets the date of birth.
            /// </summary>
            /// <value>The dob.</value>
			public static string Dob { get; set; }
            /// <summary>
            /// Gets or sets the phone.
            /// </summary>
            /// <value>The phone.</value>
			public static string Phone { get; set; }
            /// <summary>
            /// Gets or sets the email.
            /// </summary>
            /// <value>The email.</value>
			public static string Email { get; set; }

			// this contructor is for the login 
            /// <summary>
            ///Constructor that set the name and password
            ///  Initializes a new instance of the <see cref="T:QuickTools.User"/> class.
            /// </summary>
            /// <param name="name">Name.</param>
            /// <param name="password">Password.</param>
			public User(string name, string password)
			{
				Name = name;
				Password = password;
			}

			// this contructor is for the singup 
            /// <summary>
            /// constructor that pass all the data at once 
            /// Initializes a new instance of the <see cref="T:QuickTools.User"/> class.
            /// </summary>
            /// <param name="name">Name.</param>
            /// <param name="lastName">Last name.</param>
            /// <param name="password">Password.</param>
            /// <param name="dob">Dob.</param>
            /// <param name="phone">Phone.</param>
            /// <param name="email">Email.</param>
			public User(string name, string lastName, string password, string dob, string phone, string email)
			{
				Name = name;
				LatName = lastName;
				Password = password;
				Dob = dob;
				Phone = phone;
				Email = email;
			}
                  /*
                        This used to print the data but this is not relevant
                  ______
			private static void Data()
			{
				Color.Yellow();
				// title box 
				Get.Box(" [ " + "Name" + " ] " + " [ " + "Last Name" + " ] " + " [ " + "Password" + " ] " + " [ " + "DOB" + " ] " + " [ " + "Phone" + " ] " + " [ " + "Email" + " ] ");
				Get.Box(" [ " + Name + " ] " + " [ " + LatName + " ] " + " [ " + Password + " ] " + " [ " + Dob + " ] " + " [ " + Phone + " ] " + " [ " + Email + " ] ");
				Get.Wait();
			}
			*/
		}

}