# QuickTools
This is my first C# Libreary and this  has been created in the C# languague to try to help reduce the amout of code required to create simple tools

Full Compiled Dll is right here on the bin release folder 


# Im very open to hear from you 
Right now im not constantly posting for any documentation , but feel free to contact me for any information about how the Project  work and if you would like to contribute or report any buggs 


# More
for other versions from .net freamwork  i have one version available for .net 6 already compiled on the falloowing github : https://github.com/Mel4221/QuickTools-dotnet6/tree/main/bin/Debug/net6.0


# Where to start
This Project was created under very spesific conditions and to solve an spesific problem , but i was able to see that this could be 
exported to other platforms since when this IDEA was consived i was working in a call center while i was coding and some times 
i had a litter time to write some code and it used to be a kind of time consuming to write Console.WriteLine("To print something")
so i came up with the idea to make things simpler , so to start using this class first lets make it very simple . 

Get:
	it was the first class created and contains must of the functions that may be used such as colors for the console and 
	Console input that could  useful depending on the situations such as 

	Get.Input(); 
	Get.TextInput(); 
	Get.NumberInput(); 

	And  almost on the same way it could be retrived :

	Get.Number
	Get.Text
	
	Some times you may want to give some color to what you are printing on the console just to make the diference between 
	some results and another so a way to do it with Get would be 
	Get.Box("and here the content");  but some times you may want to make it colorful so that is way the Color class was created
	
Color:

	Color contains a list of Static methods that can be used with parameters or without them such as 
	Color.Green("and the content")
	or just Color.Green() and as Get inetter the Color class you could simply just do Get.Green(Get.Text);
	which could be an way of using it. 
	Colors available:
	Magenta OR Pink
	Cyan
	Yellow
	Blue
	White
	Black
	Greeen
	i think that could be more but you can check it out at any time 


IRandom or New or CreateRandom:
	They all belong to the same class which is intended to create random 
	16 bits keys  , text , pin , passwords 
	like:
	New.Pin(); or New.Pin(32)
	New.Password() or New.Password(16)
	
	
	I have to work on the documentation yet but still working to improve on this Library  
	here are the current usings on the testing and the future newer versions 


> using QuickTools.QIO;

> using QuickTools.QNet;

> using QuickTools.QData;

> using QuickTools.QCore;

> using QuickTools.QColors;

> using QuickTools.QConsole;

> using QuickTools.QSecurity;

> using QuickTools.QSecurity.FalseIO; 


...



