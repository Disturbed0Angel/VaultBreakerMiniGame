// See https://aka.ms/new-console-template for more information
using System.Threading.Channels;

string correctPin = "1234";
string userGuess = "";
int attempts = 0;

Console.WriteLine("--- YOU HAVE ENTERED THE VAULT, TIME IS SHORT, CRACK THE CODE TO ESCAPE! ---");

while (userGuess != correctPin && attempts < 10)
{
    Console.WriteLine("ENTER THE 4 DIGIT PIN: ");
    userGuess = Console.ReadLine();
    attempts++;

    if (userGuess != correctPin)
    {
        Console.WriteLine("ACCESS DENIED!");
        Console.Beep();

        switch (attempts)
        {
            case 2:
                Console.WriteLine("HINT, THE PIN STARTS WITH 1!");
                break;
            case 4:
                Console.WriteLine("HINT, THE SECOND DIGIT IS 2!");
                break;
            case 6:
                Console.WriteLine("HINT, THE THIRD DIGIT IS 3!");
                break;
            case 8:
                Console.WriteLine("HINT, THE FINAL DIGIT IS 4!");
                break;
        }
    }

    if (userGuess == correctPin)
    {
        Console.WriteLine("--- ENTRY GRANTED! ---");
    }
    else if (attempts == 10)
    {
        Console.WriteLine("--- VAULT SAFETY TRIGGERD, POLICE IN ROUTE! ---");
    }
}

Console.WriteLine("\nPress any key to exit and thanks for playing...");
Console.ReadKey();
