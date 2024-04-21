using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace Cows_and_Bulls_Final
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int topscore = 1000;
            string returnMenu = "Yes";
            int Digits = 4;
            int RandomNum = 0;
            var rand = new Random();
            int cows = 0;
            int bulls = 0;
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            string text = @" ██████╗ ██████╗ ██╗    ██╗███████╗             █████╗ ███╗   ██╗██████╗             ██████╗ ██╗   ██╗██╗     ██╗     ███████╗
██╔════╝██╔═══██╗██║    ██║██╔════╝            ██╔══██╗████╗  ██║██╔══██╗            ██╔══██╗██║   ██║██║     ██║     ██╔════╝
██║     ██║   ██║██║ █╗ ██║███████╗            ███████║██╔██╗ ██║██║  ██║            ██████╔╝██║   ██║██║     ██║     ███████╗
██║     ██║   ██║██║███╗██║╚════██║            ██╔══██║██║╚██╗██║██║  ██║            ██╔══██╗██║   ██║██║     ██║     ╚════██║
╚██████╗╚██████╔╝╚███╔███╔╝███████║            ██║  ██║██║ ╚████║██████╔╝            ██████╔╝╚██████╔╝███████╗███████╗███████║
╚═════╝ ╚═════╝  ╚══╝╚══╝ ╚══════╝            ╚═╝  ╚═╝╚═╝  ╚═══╝╚═════╝             ╚═════╝  ╚═════╝ ╚══════╝╚══════╝╚══════╝";
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(" ");
            Console.WriteLine("Welcome to Tahmeed's Cows and Bulls game!");
            Console.WriteLine(" ");
            Console.WriteLine("Guess the 4-digit number.");
            Console.WriteLine(" ");
            while (returnMenu == "Yes")
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Menu:"); // Sub-Project: Menu screen
                Console.WriteLine("1 - Play");
                Console.WriteLine("2 - Rules");
                Console.WriteLine("3 - Top Score");
                Console.WriteLine("4 - Change number of digits ");
                Console.WriteLine("5 - Quit ");
                Console.WriteLine(" ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Choose an option");
                string option = Console.ReadLine();
                Console.WriteLine(" ");

                while (option != "1")
                {
                    if (option == "2")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Rules: ");
                        Console.WriteLine(" -  You have to guess a number (default is 4 digits but you can change it from the menu)");
                        Console.WriteLine(" -  For every correct digit in the wrong position you get a cow. ");
                        Console.WriteLine(" -  For every correct digit in the right position you get a bull. ");
                        Console.WriteLine(" -  First digit cannot be 0 ");
                        Console.WriteLine(" -  There can not be any repeating digits ");
                        Console.WriteLine(" -  If you happen to break these rules, you will be told. That attempt will not be counted. ");
                        Console.WriteLine("The top score is the lowest number of attempts to guess a number correctly. ");
                        Console.WriteLine(" ");
                    }
                    if (option == "5")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("Goodbye!");
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");
                        string credits = @" _  _   __   ____  ____        ____  _  _        ____   __   _  _  _  _  ____  ____  ____ 
( \/ ) / _\ (    \(  __)      (  _ \( \/ )      (_  _) / _\ / )( \( \/ )(  __)(  __)(    \
/ \/ \/    \ ) D ( ) _)        ) _ ( )  /         )(  /    \) __ (/ \/ \ ) _)  ) _)  ) D (
\_)(_/\_/\_/(____/(____)      (____/(__/         (__) \_/\_/\_)(_/\_)(_/(____)(____)(____/";

                        Console.WriteLine(credits);
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");
                        return;
                    }
                    if (option == "3")
                    {
                        if (topscore == 1000)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Play a round to see your top score");
                            Console.WriteLine(" ");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Top Score: " + topscore);
                            Console.WriteLine(" ");
                        }
                    }
                    if (option == "4")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("How many digits do you want the number to have? (maximum 9)");
                        Digits = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(" ");
                        while (Digits > 9 || Digits < 3)
                        {
                            Console.WriteLine("Please enter a number from 3-9.");
                            Digits = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine(" ");
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("Choose an option from the menu.");
                    option = Console.ReadLine();
                    Console.WriteLine(" ");
                }
                    if (option == "1")
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    bool valid = false;
                    string number = "0";
                    int LowerBound = Convert.ToInt32(Math.Pow(10, Digits - 1));
                    int UpperBound = Convert.ToInt32(Math.Pow(10, Digits) - 1);
                    valid = false;
                    while (valid == false)
                    {
                        RandomNum = rand.Next(LowerBound, UpperBound);
                        number = Convert.ToString(RandomNum);
                        valid = true;
                        for (int i = 0; i < Digits; i++)
                        {
                            for (int j = 0; j < Digits; j++)
                            {
                                if (i != j && number[i] == number[j])
                                {
                                    valid = false;
                                    break;
                                }
                            }
                        }
                    }
                    int attempts = 0;
                    while (true)
                    {
                        cows = 0;
                        bulls = 0;
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write("Enter your guess: ");
                        string guessStr = Console.ReadLine();
                        try
                        {
                            int guess = Convert.ToInt32(guessStr);
                        } 
                        catch (FormatException)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Invalid guess. Please enter a valid number.");
                            continue;
                        }
                        bool validGuess = true;
                        if (guessStr.Length != Digits || guessStr[0] == '0')
                        {
                            validGuess = false;
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Please enter a " + Digits + "-digit number.");
                            continue;
                        }
                        for (int y = 0; y < Digits; y++)
                        {
                            for (int x = 0; x < Digits; x++)
                            {
                                while (y != x && guessStr[y] == guessStr[x])
                                {
                                    validGuess = false;
                                    break;           
                                }
                            }
                        }
                        if (!validGuess)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Invalid guess. Please enter a valid number.");
                            continue;
                        }
                            cows = 0;
                            bulls = 0;
                        for (int a = 0; a < Digits; a++)
                        {
                            for (int b = 0; b < Digits; b++)
                            {
                                if (a != b && guessStr[a] == number[b])
                                {
                                    cows++;
                                }
                                else if (guessStr[a] == number[b])
                                {
                                    bulls++;
                                }
                            }
                        }
                        Console.WriteLine("Cows:   " + cows);
                        Console.WriteLine("Bulls:  " + bulls);
                        attempts++;
                        if (Convert.ToString(guessStr) == number)
                        {

                            Console.WriteLine(" ");
                            if (attempts == 1)
                            {
                                Console.WriteLine("Congratulations! You've guessed the number " + number + " in " + 1 + " attempt.");
                            }
                            else
                            {
                                Console.WriteLine("Congratulations! You've guessed the number " + number + " in " + attempts + " valid attempts.");
                            }
                            if (topscore > attempts)
                            {
                                topscore = attempts;
                            }
                            Console.WriteLine(" ");
                            Console.WriteLine("Go back to main menu? (Yes / No) (Case Sensitive)");
                            returnMenu = Console.ReadLine();
                            if (returnMenu == "No")
                            {
                                Console.WriteLine(" ");
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.WriteLine("Thanks for playing!");
                                Console.WriteLine(" ");
                                string credits = @" _  _   __   ____  ____        ____  _  _        ____   __   _  _  _  _  ____  ____  ____ 
( \/ ) / _\ (    \(  __)      (  _ \( \/ )      (_  _) / _\ / )( \( \/ )(  __)(  __)(    \
/ \/ \/    \ ) D ( ) _)        ) _ ( )  /         )(  /    \) __ (/ \/ \ ) _)  ) _)  ) D (
\_)(_/\_/\_/(____/(____)      (____/(__/         (__) \_/\_/\_)(_/\_)(_/(____)(____)(____/";
                                Console.WriteLine(credits);
                                Console.WriteLine(" ");
                                break;
                            }
                            else
                                {
                                Console.WriteLine(" ");
                                break;
                            }
                        }
                    }  
                }
            }
        }
    }
}
