namespace NumberGuessingGame
{
        internal class Program
        {
            static string? MainMenu()
            {
                Console.WriteLine("============ Guessing Game ============");
                Console.WriteLine("1 - Single Player Mode");
                Console.WriteLine("2 - Two Player Mode");
                Console.WriteLine("3 - Survival Mode");
                Console.WriteLine("4 - Mastermind Mode");
                Console.WriteLine("5 - Exit Game");
                Console.WriteLine("=======================================");
                Console.WriteLine("Enter 1, 2, 3, 4, or 5");
                Console.WriteLine("=======================================");
                return Console.ReadLine();
            }

            static void SinglePlayerGuessingGame()
            {
                Console.WriteLine("============ Single Player Mode ============");
                int randNum = new Random().Next(1, 100);
                int lower = 1; int upper = 100; int userInput; int counter = 0;

                while (true)
                {
                    Console.WriteLine($"Enter a number between {lower} and {upper}: ");
                    if (!int.TryParse(Console.ReadLine(), out userInput))
                    {
                        Console.WriteLine("BAD INPUT, TRY AGAIN!!!"); continue;
                    }
                    counter++;

                    if (userInput > randNum)
                    {
                        Console.WriteLine("Guess something smaller!");
                        upper = userInput;
                    }
                    else if (userInput < randNum)
                    {
                        Console.WriteLine("Guess something bigger!");
                        lower = userInput;
                    }
                    else
                    {
                        Console.WriteLine($"Game is over it took {counter} time to guess it!");
                        return;
                    }
                }
            }
            static void TwoPlayerGuessingGame()
            {
                Console.WriteLine("============ Two Player Mode ============");
                Console.WriteLine("Player 1, enter your name: ");
                string? player1 = Console.ReadLine();
                while (string.IsNullOrEmpty(player1) || !player1.All(char.IsLetter))
                {
                    Console.WriteLine("Invalid input. Input must be letters only and should be atleast 1 character! Please try again.");
                    player1 = Console.ReadLine(); //Does not read line but prevents an infinite loop to happen
                }
                Console.WriteLine("Player 2, enter your name: ");
                string? player2 = Console.ReadLine();
                while (string.IsNullOrEmpty(player2) || !player2.All(char.IsLetter))
                {
                    Console.WriteLine("Invalid input. Input must be letters only and should be atleast 1 character! Please try again.");
                    player2 = Console.ReadLine(); //Does not read line but prevents an infinite loop to happen
                }

                byte startPlayer = (byte)new Random().Next(1, 3);
                byte randNum = (byte)new Random().Next(1, 100);
                byte upper = 100; byte lower = 1; byte counter = 0;

                Console.WriteLine("================================================");
                Console.WriteLine(startPlayer == 1 ? $"{player1}'s turn!" : $"{player2}'s turn!");

                while (true)
                {
                    try
                    {

                        Console.WriteLine($"Enter a number between {lower} to {upper}: ");
                        byte userInput = Convert.ToByte(Console.ReadLine());
                        counter++;

                        if (userInput == 0)
                        {
                            Console.WriteLine($"Input is not within range. Enter a number between {lower} to {upper}!");
                            continue;
                        }
                        else if (randNum > userInput)
                        {
                            Console.WriteLine("Guess something bigger!");
                            lower = userInput;
                        }
                        else if (randNum < userInput)
                        {
                            Console.WriteLine("Guess something smaller!");
                            upper = userInput;
                        }

                        else
                        {
                            if (startPlayer == 1)
                            {
                                Console.WriteLine($"Congratulation {player1}, you won the game! It took a total of {counter} guesses to find the number");
                            }
                            else
                            {
                                Console.WriteLine($"Congratulation {player2}, you won the game! It took a total of {counter} guesses to find the number");
                            }
                            return;
                        }
                        startPlayer = (byte)((startPlayer == 1) ? 2 : 1);

                        Console.WriteLine("================================================");
                        Console.WriteLine(startPlayer == 1 ? $"{player1}'s turn!" : $"{player2}'s turn!");
                    }

                    catch (OverflowException)
                    {
                        Console.WriteLine($"Uh Oh! Invalid Input detected. The highest number you can input is {upper} and the lowest is {lower}! You may try again.");

                    }
                }
            }
            static void SurvivalModeGuessingGame()
            {
                Console.WriteLine("============ Survival Mode ============");
                int randNum = new Random().Next(1, 100);
                int lower = 1; int upper = 100; int userInput; int energy = 7;

                while (true)
                {
                    Console.WriteLine($"Enter a number between {lower} and {upper}: ");
                    if (!int.TryParse(Console.ReadLine(), out userInput))
                    {
                        Console.WriteLine("BAD INPUT, TRY AGAIN!!!"); continue;
                    }

                    if (energy > 0)
                    {
                        if (userInput > randNum)
                        {
                            Console.WriteLine("Guess something smaller!");
                            upper = userInput;
                            energy--;
                            Console.WriteLine($"You have {energy} energy remaining.");
                            Console.WriteLine("=====================================");
                            continue;
                        }
                        else if (userInput < randNum)
                        {
                            Console.WriteLine("Guess something bigger!");
                            lower = userInput;
                            energy--;
                            Console.WriteLine($"You have {energy} energy remaining.");
                            Console.WriteLine("=====================================");
                            continue;
                        }
                        else
                        {
                            Console.WriteLine($"Congratulations you guess the number with {energy} energy left! The game is now over!");
                            return;
                        }
                    }
                    else
                    {
                        Console.WriteLine("The game is over, you have ran out of energy.");
                        return;
                    }
                }
            }
            static void MastermindModeGuessingGame()
            {
                while (true) // Play-again loop
                {
                    Console.WriteLine("=========== Mastermind Mode ===========");
                    Console.WriteLine("Think of a secret number between 1 and 100.");
                    Console.WriteLine("The computer will try to guess it!");
                    Console.WriteLine("Respond with:");
                    Console.WriteLine("  H = My number is LOWER");
                    Console.WriteLine("  L = My number is HIGHER");
                    Console.WriteLine("  C = Correct!");
                    Console.WriteLine("========================================");

                    int low = 1;
                    int high = 100;
                    int guess;
                    string? feedback;

                    while (true)
                    {
                        guess = (low + high) / 2;
                        Console.WriteLine($"\nComputer guesses: {guess}");
                        Console.Write("Your response (H/L/C): ");
                        feedback = Console.ReadLine();

                        if (feedback == "H")
                        {
                            high = guess - 1;
                        }
                        else if (feedback == "L")
                        {
                            low = guess + 1;
                        }
                        else if (feedback == "C")
                        {
                            Console.WriteLine($"The computer guessed your number: {guess}!");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter H, L, or C.");
                        }

                        if (low > high)
                        {
                            Console.WriteLine("Your hints were inconsistent. The game cannot continue.");
                            break;
                        }
                    }
                }
            }



            static void Main(string[] args)
            {
                while (true)
                {
                    string? choice = MainMenu();
                    Console.Clear();
                    switch (choice)
                    {
                        case "1": SinglePlayerGuessingGame(); break;
                        case "2": TwoPlayerGuessingGame(); break;
                        case "3": SurvivalModeGuessingGame(); break;
                        case "4": MastermindModeGuessingGame(); break;
                        case "5": Environment.Exit(0); break;
                        default: Console.WriteLine("BAD INPUT!!!"); break;

                    }
                }
            }
        }
    }

