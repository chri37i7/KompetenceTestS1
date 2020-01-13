using System;

namespace FærdighedsDelOpg2
{
    class Program
    {
        static void Main(string[] args)
        {
            // For loop, repeating 10 times
            for(int i = 1; i != 11; i++)
            {
                // Int for counting the seven table
                int sevenTable = 7 * i;

                // Output message
                Console.WriteLine(sevenTable);
            }
        }
    }
}
