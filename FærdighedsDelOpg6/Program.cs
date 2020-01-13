using System;
using System.IO;
using System.Text;

namespace FærdighedsDelOpg6
{
    class Program
    {
        // String for filepath  
        static string path = @"C:\Users\chri37i7\Documents\Document.txt";

        static void Main()
        {
            // Boolean for while-loop
            bool done = false;

            while(!done)
            {
                // Display choices & take input
                DisplayMenu();
                string userInput = Console.ReadLine();

                // Statements
                if(userInput == "1")
                {
                    DisplayTestFileContent();
                }
                else if(userInput == "2")
                {
                    AddContentToTextFile();
                }
                else if(userInput == "3")
                {
                    // Clear console before reset
                    Console.Clear();

                    // Write goodbye
                    Console.WriteLine("Du afsluttede programmet. Farvel...");

                    // Stop loop
                    done = true;
                }
                else
                {
                    // Clear console before reset
                    Console.Clear();
                }
            }
        }

        static void DisplayMenu()
        {
            Console.Write(
                "1) Se alt indhold i tekstfilen.\n" +
                "2) Skriv noget som gemmes i tekstfilen.\n" +
                "3) Afslut programmet.\n\n" +
                "Indtast valg: ");
        }

        static void DisplayTestFileContent()
        {
            // Clear console from previous I/O
            Console.Clear();

            // Boolean to check if file exists
            bool fileExists = File.Exists(path);

            // Statements
            if(fileExists == true)
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
                                    string[] textArray = documentLine.Split("\t");

                                    for(int i = 0; i < textArray.Length; i++)
                                    {
                                        Console.WriteLine(textArray[i]);
                                    }
                                }
                                catch(IndexOutOfRangeException)
                                {
                                    Console.WriteLine("Der opsted en fejl ved indlæsning, check tekstfilen for mellemrum.");
                                }
                            }
                        }
                    }
                }
                // Prevent console restart
                Console.ReadLine();
                // Clear console before reset
                Console.Clear();
            }
        }

        static void AddContentToTextFile()
        {
            Console.Clear();

            Console.Write("Skriv exit for at gå tilbage\n\nIndtast teksten du vil tilføje: ");
            string userInput = Console.ReadLine();

            if(userInput == "exit")
            {
                Console.Clear();
                
                Main();
            }
            else
            {
                try
                {
                    using(StreamWriter writer = new StreamWriter(path, true, Encoding.Default))
                    {
                        writer.WriteLine(userInput);
                    }
                }
                catch(IOException)
                {
                    // Write Error Message
                    Console.WriteLine("FEJL! Tekstfilen bliver brugt af et andet program.");

                    // Prevent console restart
                    Console.ReadLine();
                }
            }
            // Clear console before reset
            Console.Clear();
        }
    }
}