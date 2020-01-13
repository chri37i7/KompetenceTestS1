using System;

namespace FærdighedsDelOpg5
{
    class Program
    {
        static void Main()
        {
            /*
             *  Create Person object manually
             */

            // DateTime for birth date
            DateTime DateOfDate = new DateTime(1965, 11, 22);
            // Create person object
            Person manualPerson = new Person("Mads", "Dittmann Mikkelsen", DateOfDate);


            // Calculate object age
            manualPerson.AgeCalculation();
            // Print object info
            manualPerson.PrintInfo();

            /*
             *  Create Person object with user inputs
             */

            // Ask for input & store in string
            Console.Write("\nIndtast dit fornavn: ");
            string firstNameInput = Console.ReadLine();

            // Ask for input & store in string
            Console.Write("Indtast dit efternavn: ");
            string lastNameInput = Console.ReadLine();

            // Ask for input & store in string
            Console.WriteLine("\nIndtast din fødselsdagsdato i formatet: År, Måned, Dag");
            Console.Write("Indtast dato: ");
            string birthDateInput = Console.ReadLine();
            // Try to convert string to DateTime
            DateTime.TryParse(birthDateInput, out DateTime birthDate);


            // Create Person object with user input
            Person inputPerson = new Person(firstNameInput, lastNameInput, birthDate);


            // Calculate object age
            inputPerson.AgeCalculation();
            // Print object info
            inputPerson.PrintInfo();


            // Pause Console
            Console.ReadLine();
        }
    }
}
