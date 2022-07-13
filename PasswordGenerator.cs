/*
This Contains all the shortcuts for the Alerts
and events of colors for the display of the 
text. 
important Date : today i have change the class name from "Do static class"
to "Get static class" due to some not sence ideas behing the idea of doing stuff
it is nothing related with the performance but more with relation with the 
action that it creates DATE OF UPDATE : 03/11/2022


*/


/*
    how to use it , please falow the examples below.
              
              ________________________________________________________________________
              Get.Green("This is a secrure passwor of 16 digits "+Password.Secure(16));
              Get.Yellow("This is a Default Password of 9 digits "+Password.Secure());
              Get.Green("This is a Secure Pin of 16 digits  "+Password.Pin(16));
              Get.Yellow("This is a Secure Pin of 4 digits  "+Password.Pin());
              ________________________________________________________________________  
    
    
    
*/
using System;


namespace QuickTools
{

    public class Password
    {
      public static string Generated = null;
      public static string[] LowerCase =
	{ "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m",
"n",
	"o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
      };
      public static string[] UpperCase =
	{ "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M",
"N",
	"O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"
      };
      public static string[] Symbols =
	{ "!", "@", "%", "^", "&", "*", "=", "?", ".", ")", "(", "_", "+",
"-", "*", "/",
	"+","`","~"
      };
      public static int[] Numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

      /*
         //Lower 26
         //UpperCase 26
         //Symbols 14
         // Numbers 10 
       */

     // this is the random selector 
      static Random ranOrder = new Random ();


      public static object Secure ()
      {				// this one will generate a minimum passowrd of 9 digits 
	string password = "";
	Random lower, upper, symbol, number;

	lower = new Random ();
	upper = new Random ();
	symbol = new Random ();
	number = new Random ();

	// this will change the order of the password

	for (int PassWordLengh = 0; PassWordLengh < 9; PassWordLengh++)
	  {
	    int order = ranOrder.Next (0, 4);
	    switch (order)
	      {
	      case 0:
		password += LowerCase[lower.Next (0, LowerCase.Length)];

		break;
	      case 1:
		password += UpperCase[upper.Next (0, UpperCase.Length)];
		break;
	      case 2:
		password += Symbols[symbol.Next (0, Symbols.Length)];
		break;
	      case 3:
		password += Numbers[number.Next (0, Numbers.Length)];
		break;
	      default:
		password += Numbers[number.Next (0, Numbers.Length)];
		break;

	      }
	  }
	Generated = password.Replace (" ", "");
	return password.Replace (" ", "");
      }


            /*
                  _____________________________________________           
                  this is the secure password that is generated
                  based on the input needed 
                  _____________________________________________                 
            */

      public static object Secure (int passwordLenght)
      {                       // this one will generate a minimum passowrd of 9 digits 
      
      string password = "";
	Random lower, upper, symbol, number;

	lower = new Random ();
	upper = new Random ();
	symbol = new Random ();
	number = new Random ();

	// this will change the order of the password

	for (int PassWordLengh = 0; PassWordLengh < passwordLenght; PassWordLengh++)
	  {
	    int order = ranOrder.Next (0, 4);

	    switch (order)
	      {
	      case 0:
		password += LowerCase[lower.Next (0, 26)];

		break;
	      case 1:
		password += UpperCase[upper.Next (0, 26)];
		break;
	      case 2:
		password += Symbols[symbol.Next (0, 14)];
		break;
	      case 3:
		password += Numbers[number.Next (0, 10)];
		break;
	      default:
		password += Numbers[number.Next (0, 10)];
		break;

	      }
	  }
	Generated = password.Replace (" ", "");
	return password.Replace (" ", "");
      }

      public static int pin;
      public static int Pin ()
      {
	string password = "".Replace (" ", "");
	Random number = new Random ();

	// this will change the order of the password

	for (int pin = 0; pin < 4; pin++)
	  {

	    password += Numbers[number.Next (0, 9)];
	  }
	pin = int.Parse (password);
	return int.Parse (password);
      }

      public static object Pin (int Level)
      {
	string password = "".Replace (" ", "");
	Random number = new Random ();

	// this will change the order of the password

	for (int pin = 0; pin < Level; pin++)
	  {

	    password += Numbers[number.Next (0, 9)];
	  }

	return password;
      }

    }
  }

