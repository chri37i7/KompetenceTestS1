using System;

namespace FærdighedsDelOpg4
{
    class Program
    {
        static void Main()
        {
            // Bool for keeping loop running
            bool done = false;

            while(!done)
            {
                // Write Message
                Console.WriteLine("Indtast to tal over 0, og få udregnet addition, subtraktion, multiplikation, division, og modulus af tallene.");

                // Ask for input and convert input string to int
                Console.Write("Indtast første tal: ");
                string firstInput = Console.ReadLine();
                double.TryParse(firstInput, out double firstNumber);

                // Ask for input and convert input string to int
                Console.Write("Indtast andet tal: ");
                string secondInput = Console.ReadLine();
                double.TryParse(secondInput, out double secondNumber);

                if(firstNumber == 0 || secondNumber == 0)
                {
                    // Clear previous I/O
                    Console.Clear();

                    // Write error message
                    Console.WriteLine("FEJL! Et indtastet tal kan ikke være 0.");

                    // Pause console
                    Console.ReadLine();
                }
                else
                {
                    // Clear previous I/O
                    Console.Clear();

                    // Use method for calculations
                    PrintResult(firstNumber, secondNumber);

                    // Stop the loop
                    done = true;

                    // Pause console
                    Console.ReadLine();
                }
            }
        }

        private static void PrintResult(double firstNumber, double secondNumber)
        {
            // Calculate numbers added together
            double plusResult = firstNumber + secondNumber;

            // Calculate numbers subtracted & output results
            double minusResult = firstNumber - secondNumber;

            // Calculate numbers multiplied & output results
            double multiplicationResult = firstNumber * secondNumber;

            // Calculate numbers devided & output results
            double divisionResult = firstNumber / secondNumber;

            // Calculate Modulo & output results
            double moduloResult = firstNumber % secondNumber;


            Console.WriteLine(
                $"Addition: {plusResult}\n" +
                $"Subtraktion: {minusResult}\n" +
                $"Multiplikation: {multiplicationResult}\n" +
                $"Division: {divisionResult:f}\n" +
                $"Modulus: {moduloResult}");
        }
    }
}
