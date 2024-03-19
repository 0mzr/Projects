using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;

namespace Pet_Game
{
    internal class Primary
    {
        public static dragonClass p1 = new dragonClass();//initialise 3 arrays for the 3 different pet types, each with their own unique features
        public static unicornClass p2 = new unicornClass();
        public static phoenixClass p3 = new phoenixClass();

        public static void forec(string colour)
        {
            Enum.TryParse<ConsoleColor>(colour, true, out ConsoleColor parsedColor);
            Console.ForegroundColor = parsedColor;
        }// changes text foreground colour to passed parameter. reduces amount of written code.

        public static void actionType(string type, string action)
        {
            switch (type)
            {
                case "1":
                    switch (action)
                    {
                        case "feed":
                            p1.Feed();
                            break;
                        case "excercise":
                            p1.Excercise();
                            break;
                        case "play":
                            p1.play();
                            break;
                        case "wash":
                            p1.wash();
                            break;
                        case "sleep":
                            p1.sleep();
                            break;
                        default:
                            Console.WriteLine("Switch statement error #0");
                            break;
                    }
                    break;
                case "2":
                    switch (action)
                    {
                        case "feed":
                            p2.Feed();
                            break;
                        case "excercise":
                            p2.Excercise();
                            break;
                        case "play":
                            p2.play();
                            break;
                        case "wash":
                            p2.wash();
                            break;
                        case "sleep":
                            p2.sleep();
                            break;
                        default:
                            Console.WriteLine("Switch statement error #0");
                            break;
                    }
                    break;
                case "3":
                    switch (action)
                    {
                        case "feed":
                            p3.Feed();
                            break;
                        case "excercise":
                            p3.Excercise();
                            break;
                        case "play":
                            p3.play();
                            break;
                        case "wash":
                            p3.wash();
                            break;
                        case "sleep":
                            p3.sleep();
                            break;
                        default:
                            Console.WriteLine("Switch statement error #0");
                            break;
                    }
                    break;
            }   
        }

        static void instructions()
        {
            Console.Clear();
            Console.WriteLine("In this Cyber Pet game, you have to take care of your pet.\n\n" +
                "Your pets values such as hunger and hapiness go down every couple of seconds.\n\n" +
                "Pet information will be displayed at the top of the console screen, with it being refreshed every second." +
                "\n\nDont feed your pet too much or they will explode (3 chances).\n\n" +
                "Play games to increase hapiness and perform actions to keep your pet healthy.\n\nTry to keep them alive." +
                "\n\n(Press enter once ready.)");
            Console.ReadLine();
            Console.Clear();
        }
        

        public static void createTimer(int milliseconds, string a)
        {
            Timer timer = new Timer(callback, a, 0, milliseconds);
        }

        static void callback(object state) 
        {
            switch (state)
            {
                case "1":// data update for "dragon"
                    p1.minusHunger(1);
                    p1.minusHapiness(1);
                    p1.minusEnergy(1);
                    p1.minusClean(1);
                    p1.gameEnd();
                    // Console.WriteLine("Test #1");
                    break;
                case "2":// data update for "unicorn"
                    p2.minusHunger(1);
                    p2.minusHapiness(1);
                    p2.minusEnergy(1);
                    p2.minusClean(1);
                    p2.gameEnd();
                    // Console.WriteLine("Test #2");
                    break;
                case "3":// data update for "phoenix"
                    p3.minusHunger(1);
                    p3.minusHapiness(1);
                    p3.minusEnergy(1);
                    p3.minusClean(1);
                    p3.gameEnd();
                    // Console.WriteLine("Test #3");
                    break;
                default:
                    Console.WriteLine("Switch Statement Error #1");
                    break;
            }
        }// Reduces pet values by 1 every 5 seconds and checks for game end after. switch statement to use correct class instance.

        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        public static void ClearLine(string a)
        {
            ClearCurrentConsoleLine();
            Console.Write(a);
            Console.ReadLine();
            Console.Clear();
        }

        public static string chooseWord()
        {
            Random random = new Random();
            string[] words = { "bemix", "bling", "blunk", "brick", "brung","chunk", "cimex", "clipt", "clunk", "cylix", "fjord", "glent", "grypt", "gucks", "gymps", "jumby", "jumpy", "kempt", "kreng", "nymph", "pling", "prick", "treck", "vibex", "vozhd", "waltz", "waqfs", "xylic" };
            int wordIndex = random.Next(0, words.Length);
            string chosenWord = words[wordIndex];
            return chosenWord;
        }

        public static string[] colours = new string[30];

        public static char[] wordleChars =
        {
            ' ', ' ', ' ', ' ', ' ',
            ' ', ' ', ' ', ' ', ' ',
            ' ', ' ', ' ', ' ', ' ',
            ' ', ' ', ' ', ' ', ' ',
            ' ', ' ', ' ', ' ', ' ',
            ' ', ' ', ' ', ' ', ' ',
        };

        public static void cw(char a, string c)
        {
            forec(c);
            Console.Write(a); Console.ResetColor(); Console.Write(" ║ ");
        }

        public static void wordleTable(char[] table, string[] colour)// prints wordle table to console
        {
            int index = 0;
            Console.WriteLine("╔═══╦═══╦═══╦═══╦═══╗");

            for (int row = 0; row < 6; row++)
            {
                Console.Write("║ ");
                for (int col = 0; col < 5; col++)
                {
                    cw(table[index], colour[index]);
                    index++;
                }
                if (row < 5)
                {
                    Console.WriteLine("\n╠═══╬═══╬═══╬═══╬═══╣");
                }
                else
                {
                    Console.WriteLine("\n╚═══╩═══╩═══╩═══╩═══╝");
                }
            }
        }

        public static void wordle()
        {
            string wordGuess = "";
            bool dupe = true;
            string randomWord = chooseWord();
            bool wordGuessCorrect = false;
            while (wordGuessCorrect == false)
            {
                for (int row = 0; row < 30; row += 5)
                {
                    wordleTable(wordleChars, colours);
                    Console.WriteLine(randomWord);
                    Console.Write("\nEnter guess: ");
                    wordGuess = Console.ReadLine().ToLower();
                    Console.Clear();
                    if (wordGuess.Length == 5) 
                    {
                        if (wordGuess == randomWord)
                        {
                            for (int i = 0; i < 5; i++)
                            {
                                wordleChars[i + row] = randomWord[i];
                                colours[i + row] = "green";
                            }
                            wordleTable(wordleChars, colours);
                            Console.WriteLine("You guessed correctly. Well Done. (+40 hapiness, -10 energy)");
                            actionType(type, "play");
                            Console.ReadLine();
                            row = 40;
                            wordGuessCorrect = true;
                            Console.Clear();
                        }
                        else
                        {
                            for (int i = 0; i < randomWord.Length; i++)
                            {
                                if (randomWord[i] == wordGuess[i])
                                {
                                    wordleChars[i + row] = wordGuess[i];
                                    colours[i + row] = "green";
                                }
                                else if (randomWord.Contains(wordGuess[i].ToString()))
                                {
                                    int index = randomWord.IndexOf(wordGuess[i]);
                                    if (colours[index + row] != "green")
                                    {
                                        wordleChars[index + row] = wordGuess[i];
                                        colours[index + row] = "yellow";
                                    }
                                }
                                else
                                {
                                    wordleChars[i + row] = wordGuess[i];
                                    colours[i + row] = "red";
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Input has to be 5 letters long.");
                        row -= 5;
                    }
                }
                if (wordGuessCorrect == false && wordGuess != randomWord)
                {
                    Console.WriteLine($"Game Over. The word was: {randomWord}.");
                }
            }
        }

        public static void reactionTimeGame()
        {
            Random random = new Random();
            Console.WriteLine("When the screen turns green press enter as quickly as you can.\n" +
                "(Press enter to start.)");
            Console.ReadLine();
            Console.Clear();
            forec("green");
            DateTime date = DateTime.Now;
            double ms = date.Millisecond;
            int randomSleep = random.Next(2000, 8000);
            Thread.Sleep(randomSleep);
            Console.Write("███████████████████████████████████████████████████████████████████████\n" +
                "███████████████████████████████████████████████████████████████████████\n" +
                "███████████████████████████████████████████████████████████████████████\n" +
                "███████████████████████████████████████████████████████████████████████\n" +
                "███████████████████████████████████████████████████████████████████████\n" +
                "███████████████████████████████████████████████████████████████████████\n" +
                "███████████████████████████████████████████████████████████████████████\n" +
                "███████████████████████████████████████████████████████████████████████\n" +
                "███████████████████████████████████████████████████████████████████████\n" +
                "███████████████████████████████████████████████████████████████████████\n" +
                "███████████████████████████████████████████████████████████████████████\n" +
                "███████████████████████████████████████████████████████████████████████\n");
            Console.ReadLine();
            Console.Clear();
            forec("white");
            DateTime date2 = DateTime.Now;
            double ms2 = date2.Millisecond;
            double reactionTime = ms2-ms;
            Console.WriteLine($"You got a time of {Math.Abs(reactionTime)}ms. (+40 hapiness, -10 energy)");
            actionType(type, "play");
        }

        static string type = "";
        static string gamePick;
        static int originalCursorTop = Console.CursorTop;

        static void Main(string[] args)
        {            
            bool invalidInput = true;
            bool petChoice = false;
            string nameInput = "";

            while (true)
            {
                while (invalidInput == true)
                {
                    Console.Write("Enter desired pet name (alphabetical format):\n");
                    nameInput = Console.ReadLine().ToLower();
                    if (Regex.IsMatch(nameInput, "^[a-z]*$") && !String.IsNullOrEmpty(nameInput)) // Checks if correct format is used for name using Regex and String functions.
                    {
                        Console.Clear();
                        nameInput = char.ToUpper(nameInput[0]) + nameInput.Substring(1);
                        invalidInput = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input. Use alphabetical format (a-z).");
                        Console.ReadLine(); Console.Clear();
                    }
                }
                petChoice = true;
                while (petChoice == true)
                {
                    Console.Clear();
                    Console.WriteLine($"Name: {nameInput}\n\nWhich type would you like {nameInput} to be?");
                    Console.Write("\n1. ");
                    forec("Red");
                    Console.WriteLine("Dragon (High energy capacity, High food capacity, Low cleanliness, Low hapiness)");
                    forec("White");
                    Console.Write("\n2. ");
                    forec("Magenta");
                    Console.WriteLine("Unicorn (Neutral energy capacity, Neutral food capacity, Neutral cleanliness, Neutral hapiness)");
                    forec("White");
                    Console.Write("\n3. ");
                    forec("DarkRed"); 
                    Console.WriteLine("Phoenix (Low energy capacity, Low food capacity, High cleanlinesss, High Hapiness)\n");
                    forec("White");

                    type = Console.ReadLine().ToLower();

                    string[] dragon = { "dragon",  "1"};
                    string[] unicorn = { "unicorn", "2" };
                    string[] phoenix = { "phoenix", "3" };

                    if (!String.IsNullOrEmpty(type))
                    {
                        if (dragon.Any(name => name.StartsWith(type)))
                        {
                            type = "1";
                            petChoice = false;
                        }
                        else if (unicorn.Any(name => name.StartsWith(type)))
                        {
                            type = "2";
                            petChoice = false;
                        }
                        else if (phoenix.Any(name => name.StartsWith(type)))
                        {
                            type = "3";
                            petChoice = false;
                        }
                        else
                        {
                            ClearLine("Invalid Input");
                        }
                    }
                    else
                    {
                        ClearLine("Invalid Input");
                    }
                }
                instructions();
                createTimer(5000, type);
                while ( p1.gameEnd() == false && p2.gameEnd() == false && p3.gameEnd() == false )
                {
                    string gamePick = "";
                    Console.WriteLine("What game would you like to do?");
                    Console.WriteLine("1. Reaction time game\n2. Wordle game\n3. Eat lunch\n4. Go for a walk\n" +
                        "5. Take a nap\n6. Wash your pet\n7. Check stats\n");
                    
                    gamePick = Console.ReadLine().ToLower();

                    string[] reaction = { "reaction time game", "1" };
                    string[] wordgame = { "wordle", "2" };
                    string[] lunch = { "lunch", "3" };
                    string[] run = { "run", "4" };
                    string[] nap = { "nap", "5" };
                    string[] shower = { "shower", "6" };
                    string[] stats = { "stats", "7" };


                    if (reaction.Any(name => name.StartsWith(gamePick)))
                    {
                        Console.Clear();
                        reactionTimeGame();
                    } 
                    
                    else if (wordgame.Any(name => name.StartsWith(gamePick)))
                    {
                        Console.Clear();
                        wordle();
                    }
                    else if (lunch.Any(name => name.StartsWith(gamePick)))
                    {
                        Console.Clear();
                        actionType(type, "feed");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else if (run.Any(name => name.StartsWith(gamePick)))
                    {
                        Console.Clear();
                        actionType(type, "excercise");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else if (nap.Any(name => name.StartsWith(gamePick)))
                    {
                        Console.Clear();
                        actionType(type, "sleep");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else if (shower.Any(name => name.StartsWith(gamePick)))
                    {
                        Console.Clear();
                        actionType(type, "wash");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else if (stats.Any(name => name.StartsWith(gamePick)))
                    {
                        Console.Clear();
                        if(type == "1")
                        {
                            Console.WriteLine($"Hunger: {p1.returnHunger()}/125\nHapiness: {p1.returnHapiness()}/75\nCleanliness: {p1.returnClean()}/75\nEnergy: {p1.returnEnergy()}/125");
                        }
                        else if (type == "2")
                        {
                            Console.WriteLine($"Hunger: {p2.returnHunger()}/100\nHapiness: {p2.returnHapiness()}/100\nCleanliness: {p2.returnClean()}/100\nEnergy: {p2.returnEnergy()}/100");
                        }
                        else if (type == "3")
                        {
                            Console.WriteLine($"Hunger: {p3.returnHunger()}/75\nHapiness: {p3.returnHapiness()}/125\nCleanliness: {p3.returnClean()}/125\nEnergy: {p3.returnEnergy()}/75");
                        }

                        Console.ReadLine();
                        Console.Clear();
                    }
                    else
                    {
                        ClearLine("Invalid Input");
                    }
                }
            }
        }
    }
}