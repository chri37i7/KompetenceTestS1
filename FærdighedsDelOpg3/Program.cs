using System;

namespace FærdighedsDelOpg3
{
    class Program
    {
        static void Main()
        {
            // Bool to keep while-loop running
            bool correctAnswer = false;

            // Write Message
            Console.WriteLine("Gæt hvilket tal mellem 1 og 10 jeg tænker på ;D!");

            // Loop for guessing game
            while(!correctAnswer)
            {
                // Create number generator object
                Random randomNumberGenerator = new Random();

                // Generate random number between 1 & 10
                int randomNumber = randomNumberGenerator.Next(1, 11);


                // Ask for input & store input in string
                Console.Write("Indtast gæt: ");
                string inputGuess = Console.ReadLine();

                // Try and convert input string to int
                int.TryParse(inputGuess, out int userGuess);


                // Check if answer is correct.
                if(userGuess == randomNumber)
                {
                    // Write correct & pause
                    Console.WriteLine($"Korrekt! Tallet er {userGuess}!");

                    // Set to true, to stop the while-loop
                    correctAnswer = true;
                }
                else
                {
                    // Write wrong answer to user
                    Console.WriteLine("Svaret er forkert!");
                }
            }
        }
    }
}
