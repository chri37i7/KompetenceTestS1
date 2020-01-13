using System;

namespace FærdighedsDelOpg1
{
    class Program
    {
        static void Main()
        {
            // Take input & store in variable
            Console.Write("Indtast dit fornavn: ");
            string firstInput = Console.ReadLine();

            // Take input & store in variable
            Console.Write("Indtast dit efternavn: ");
            string secondInput = Console.ReadLine();

            // Output message
            Console.WriteLine($"Du hedder {firstInput} {secondInput}");
        }
    }
}