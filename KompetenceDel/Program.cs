using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading;
using System.Collections.Generic;

namespace KompetenceDel
{
    class Program
    {
        // List for storing film objecs
        private static List<Film> filmList = new List<Film>();

        // String for filepath  
        static string path = @"C:\Users\baek\Documents\movies.txt";

        // File to make sure path file exists
        static bool fileExists = File.Exists(path);

        // Boolean for keeping loop running
        static bool done = false;

        // Main Method
        static void Main()
        {
            // Create list containing movies from file
            CreateMovieList();

            while(!done) // Loop program
            {
                PrintMenu(); // Print menu with choices

                // Ask for choice
                Console.Write("\nIndtast valg: ");
                string consoleInput = Console.ReadLine();

                // Register user choic
                UserChoice(consoleInput);
            }
        }

        // Print Menu Method
        static void PrintMenu()
        {
            Console.WriteLine(
                "Velkommen til Filmhåndteringsprogrammet version 1.0\n\n" +
                "Du har nu 4 muligheder. Ønsker du at:\n" +
                "1) Gemme en ny film\n" +
                "2) Se alle film\n" +
                "3) Søge på efter en film\n" +
                "4) Afslutte programmet");
        }

        //User Choices Method
        static void UserChoice(string inputChoice)
        {
            // Statements
            if(inputChoice == "1")
            {
                SaveFilm();
            }
            else if(inputChoice == "2")
            {
                ViewAllFilms();
            }
            else if(inputChoice == "3")
            {
                SearchForFilm();
            }
            else if(inputChoice == "4")
            {
                ExitProgram();
            }
            else
            {
                Console.Clear();
            }
        }

        //Save Film Method
        static void SaveFilm()
        {
            Console.Clear();
            // If path file doesn't exist
            if(fileExists == false)
            {
                ErrorMessage("Filen eksisterer ikke!");
            }
            else
            {
                // Film name
                Console.Write("Indtast navn: ");
                string inputName = Console.ReadLine();

                // Year film released
                Console.Write("Indtast udgivelsesår: ");
                string consoleInput = Console.ReadLine();

                // Try and convert input, then test with statement
                int.TryParse(consoleInput, out int inputYear);
                if(inputYear < 1900 || inputYear > 2020)
                {
                    ErrorMessage("Du indtastede ikke et årstal");
                    SaveFilm(); // Resets method
                }

                // Film instructor name
                Console.Write("Indtast filminstruktør: ");
                string inputInstructor = Console.ReadLine();

                // Film company name
                Console.Write("Indtast filmselskab: ");
                string inputCompany = Console.ReadLine();


                // Create Film object using inputs
                Film film = new Film(inputName, inputYear, inputInstructor, inputCompany);

                // Add film to list
                filmList.Add(film);

                // Write object to file, using method
                WriteToFile(film); 
            }
            Console.Clear();
        }

        //Write Film To File Method
        static void WriteToFile(Film film)
        {
            try
            {
                // Write input to file using StreamWriter
                using(StreamWriter writer = new StreamWriter(path, true, Encoding.Default))
                {
                    writer.WriteLine(film.FilmTitle + "," + film.FilmYear + "," + film.FilmInstructor + "," + film.FilmCompany);
                }
                Console.Clear();
                // Write message & pause console
                Console.WriteLine("Filmen blev gemt til tekstfilen.");
                Console.ReadLine();
            }
            // Catch cannot access file error
            catch(IOException)
            {
                ErrorMessage("Filen bliver brugt at en anden process. Genstart programmet.");
            }
        }

        //View All Films Method
        static void ViewAllFilms()
        {
            Console.Clear();
            // If path file doesn't exist
            if(fileExists == false)
            {
                ErrorMessage("Filen eksisterer ikke!");
            }
            else
            {
                // Write message & all found results
                Console.WriteLine("Her kan du se alle film i tekstfilen:\n");
                foreach(Film film in filmList)
                {
                    Console.WriteLine(
                        $"Titel: {film.FilmTitle}\n" +
                        $"Udgivelsesår: {film.FilmYear}\n" +
                        $"Instruktør: {film.FilmInstructor}\n" +
                        $"Filmselskab: {film.FilmCompany}\n");
                }
                Console.ReadLine(); // Prevent console restart
            }
            Console.Clear();
        }

        //Search For Film Method
        static void SearchForFilm()
        {
            Console.Clear();
            // If path file doesn't exist
            if(fileExists == false)
            {
                ErrorMessage("Filen eksisterer ikke!");
            }
            else
            {
                // Ask for input & store in string
                Console.WriteLine("Søg efter en filmtitel, og få vist dem der matcher.");
                Console.Write("Indtast titel: ");
                string userInput = Console.ReadLine();

                // Enumerator for searching
                IEnumerable<Film> result = filmList.Where(film => film.FilmTitle.ToLower().Contains(userInput.ToLower()));

                // Write message & all results found
                Console.WriteLine("\nFølgende film blev fundet:\n");
                foreach(Film film in result)
                {
                    Console.WriteLine(
                        $"Titel: {film.FilmTitle}\n" +
                        $"Udgivelsesår: {film.FilmYear}\n" +
                        $"Instruktør: {film.FilmInstructor}\n" +
                        $"Filmselskab: {film.FilmCompany}\n");
                }
                Console.ReadLine(); // Prevent console reset.
            }
            Console.Clear();
        }

        // Create list containing Film objects
        static void CreateMovieList()
        {
            try
            {
                // FileStream & StreamReader for reading the textfile
                using(FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    using(StreamReader reader = new StreamReader(fileStream))
                    {
                        while(!reader.EndOfStream)
                        {
                            string documentLine;
                            // Read until end is reached
                            while((documentLine = reader.ReadLine()) != null)
                            {
                                try
                                {
                                    // Split document lines into array
                                    string[] lineArray = documentLine.Split(",");

                                    // TryParse second line to int
                                    int.TryParse(lineArray[1], out int lineArrayInt);

                                    // Create film object with array
                                    Film film = new Film(lineArray[0], lineArrayInt, lineArray[2], lineArray[3]);
                                    // Add film to list
                                    filmList.Add(film);
                                }
                                catch(IndexOutOfRangeException)
                                {
                                    ErrorMessage("Der opsted en fejl ved indlæsning, check tekstfilen for mellemrum.");
                                }
                            }
                        }
                    }
                }
            }
            catch(FileNotFoundException)
            {
                ErrorMessage("Filen eksisterer ikke.");
            }
        }

        // Exit Program Method
        static void ExitProgram()
        {
            Console.Clear(); // Clear previous console output

            // Goodbye message
            Console.WriteLine("Programmet lukker, farvel...");

            Thread.Sleep(2500); // Pause for 2.5 seconds

            done = true; // Shut down program
        }

        // Error Message Method
        static void ErrorMessage(string inputMessage)
        {
            Console.Clear(); // Clear previous console output

            // Write error message & pause
            Console.WriteLine($"FEJL! {inputMessage}");
            Console.ReadLine();

            Console.Clear(); // Clear console before reset
        }
    }
}