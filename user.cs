using System; 
namespace QuickTools
{
        


	public class User
		{
			public static string Name { get; set; }

			public static string LatName { get; set; }

			public static string Password { get; set; }

			public static string Dob { get; set; }

			public static string Phone { get; set; }

			public static string Email { get; set; }

			// this contructor is for the login 
			public User(string name, string password)
			{
				Name = name;
				Password = password;
			}

			// this contructor is for the singup 
			public User(string name, string lastName, string password, string dob, string phone, string email)
			{
				Name = name;
				LatName = lastName;
				Password = password;
				Dob = dob;
				Phone = phone;
				Email = email;
			}

			public static void Data()
			{
				Color.Yellow();
				// title box 
				Get.Box(" [ " + "Name" + " ] " + " [ " + "Last Name" + " ] " + " [ " + "Password" + " ] " + " [ " + "DOB" + " ] " + " [ " + "Phone" + " ] " + " [ " + "Email" + " ] ");
				Get.Box(" [ " + Name + " ] " + " [ " + LatName + " ] " + " [ " + Password + " ] " + " [ " + Dob + " ] " + " [ " + Phone + " ] " + " [ " + Email + " ] ");
				Get.Wait();
			}
		}

}