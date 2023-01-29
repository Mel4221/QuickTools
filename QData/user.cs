using System;
namespace QuickTools.QData
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
			public  string Name { get; set; }
            /// <summary>
            /// Gets or sets the last name 
            /// </summary>
            /// <value>The name of the lat.</value>
			public  string LatName { get; set; }
            /// <summary>
            /// Gets or sets the password.
            /// </summary>
            /// <value>The password.</value>
			public    string Password { get; set; }
            /// <summary>
            /// Gets or sets the date of birth.
            /// </summary>
            /// <value>The dob.</value>
			public string Dob { get; set; }
            /// <summary>
            /// Gets or sets the phone.
            /// </summary>
            /// <value>The phone.</value>
			public    string Phone { get; set; }
            /// <summary>
            /// Gets or sets the email.
            /// </summary>
            /// <value>The email.</value>
			public    string Email { get; set; }

			// this contructor is for the login 
            /// <summary>
            ///Constructor that set the name and password
            ///  Initializes a new instance of the <see cref="T:QuickTools.User"/> class.
            /// </summary>
            /// <param name="name">Name.</param>
            /// <param name="password">Password.</param>
			public User(string name, string password)
			{
				this.Name = name;
				this.Password = password;
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
				this.Name = name;
				this.LatName = lastName;
				this.Password = password;
				this.Dob = dob;
				this.Phone = phone;
				this.Email = email;
			}


            /// <summary>
            /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:QuickTools.User"/>.
            /// </summary>
            /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:QuickTools.User"/>.</returns>
            public override string ToString()
            {
                  return $"NAME: {this.Name} LASTNAME: {this.LatName} PASSWORD: {this.Password} DOB: {this.Dob} PHONE: {this.Phone} EMAIL: {this.Email}";
            }
            /// <summary>
            /// Tos the string.
            /// </summary>
            /// <returns>The string.</returns>
            /// <param name="type">Type.</param>
            public string ToString(string type)
            {     
                  switch(type)
                  {
                        case "json":
                              return $"[\n 'NAME': {this.Name} \n 'LASTNAME': {this.LatName} \n 'PASSWORD': {this.Password} \n 'DOB': {this.Dob} \n 'PHONE': {this.Phone} \n 'EMAIL': {this.Email} \n]".Replace("'", '"'.ToString()).Replace("[", "{").Replace("]", "}");
                        case "xml":
                              throw new Exception("xml not set up yet ");
                        default:
                              return $"NAME: {this.Name} LASTNAME: {this.LatName} PASSWORD: {this.Password} DOB: {this.Dob} PHONE: {this.Phone} EMAIL: {this.Email}";
                  }
            }


            /// <summary>
            /// Initializes a new instance of the <see cref="T:QuickTools.User"/> class.
            /// </summary>
            public User()
            {

            }
            /// <summary>
            /// Set the specified user data.
            /// </summary>
            /// <param name="user">User.</param>
            public virtual void Set(User user)
            {
                  this.Name = user.Name;
                  this.Dob = user.Dob;
                  this.Email = user.Email;
                  this.LatName = user.LatName;
                  this.Phone = user.Phone;
                  this.Password = user.Password; 
            }


      }

}