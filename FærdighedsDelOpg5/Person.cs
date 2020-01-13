using System;
using System.Collections.Generic;
using System.Text;

namespace FærdighedsDelOpg5
{
    class Person
    {
        // Fields
        private string firstName;
        private string lastName;
        private DateTime birthDate;
        private int age;

        // Constructor
        public Person(string firstName, string lastName, DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
        }

        // Properties
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }
        public DateTime BirthDate
        {
            get
            {
                return birthDate;
            }
            set
            {
                birthDate = value;
            }
        }
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }

        /*
         *  Age Calculation Method
         */

        public void AgeCalculation()
        {
            // Get birth date as string, and convert to int
            string birthDateToString = birthDate.ToString("yyyyMMdd");
            int.TryParse(birthDateToString, out int dateOfBirth);

            // Get current date as string, and convert to int
            string currentTimeToString = DateTime.Now.ToString("yyyyMMdd");
            int.TryParse(currentTimeToString, out int currentTime);

            /*
             * Calculate age by subtracting the to ints,
             * and deviding by 10000 to only get the first 2 numbers,
             * since variable age is an int, the comma numbers gets ignored
             * 
             */
            age = (currentTime - dateOfBirth) / 10000;
        }

        /*
         *  Print age Info Method
         */

        public void PrintInfo()
        {
            // If birthDate is after today
            if(birthDate > DateTime.Now)
            {
                // Output error message
                Console.WriteLine("Fejl! Fødselsdatoen er ikke før i dag.");
            }
            else
            {
                // Clear console from previous I/O
                Console.Clear();

                // Write info
                Console.WriteLine(
                    $"Navn: {firstName} {lastName}\n" +
                    $"Fødselsdagsdato: {birthDate.ToString("dd/MM/yyyy")}\n" +
                    $"Alder: {age}");
            }
        }
    }
}
