using System;
using System.Collections.Generic;
using System.Text;


namespace FileSystemManager
{
    class Menu
    {
        public static int inputChoice = 0;
        FileService service = new FileService();

        public void mainMenu()
        {
            //Continous prompt
            do
            {
                welcome();

            } while (true);
        }

        public void welcome()
        {
            Console.WriteLine("------------------------\n");
            Console.WriteLine("Enter 1 to see the menu or enter 2 to exit ");
            Console.WriteLine("\n------------------------");
            inputChoice = checkValidInput(1,2);
            //Checks for exit value (2)
            if(inputChoice == 2)
            {
                Environment.Exit(2);
            }
            firstMenu();
        }

        public void firstMenu()
        {
            Console.WriteLine("Choose from menu: \n");
            Console.WriteLine("1. List all files");
            Console.WriteLine("2. List files by extension");
            Console.WriteLine("3. Get info about dracula.txt");
            inputChoice = checkValidInput(1, 3);
            switch (inputChoice)
            {
                case 1:
                    service.listAllFiles();
                    break;

                case 2:
                    extenstionMenu();
                    break;

                case 3:
                     textFileMenu();
                    break;
                
               default:
                    Console.Write("Input correct option\n");
                    break;
            }

        }

        public void extenstionMenu()
        {
            Console.WriteLine("Choose from menu: \n");
            Console.WriteLine("1. jpeg");
            Console.WriteLine("2. jfif");
            Console.WriteLine("3. png");
            Console.WriteLine("4. jpg");
            //Checks valid input 1-4
            inputChoice = checkValidInput(1, 4);
            //Switch service on input
            switch (inputChoice)
            {
                case 1:
                    service.listFilesByExtension("jpeg");
                    break;

                case 2:
                    service.listFilesByExtension("jfif");
                    break;

                case 3:
                    service.listFilesByExtension("png");
                    break;

                case 4:
                    service.listFilesByExtension("jpg");
                    break;

                default:
                    Console.Write("Input correct option\n");
                    break;
            }

        }

        public void textFileMenu()
        {
            Console.WriteLine("Choose from menu: \n");
            Console.WriteLine("1. Get name and size of file");
            Console.WriteLine("2. Get number of lines of file");
            Console.WriteLine("3. Search for word in file");
            //Checks valid input 1-3
            inputChoice = checkValidInput(1, 3);
            //Switch service on input
            switch (inputChoice)
            {
                case 1:
                    service.getFileNameAndSize();
                    break;

                case 2:
                    service.getLinesOfFile();
                    break;

                case 3:
                    service.getWordInText();
                    break;

                default:
                    Console.Write("Input correct option\n");
                    break;
            }
        }

        //Provides dynamic integer input prompting //from course resource
        public static int checkValidInput(int min, int max)
        {
            var input = Console.ReadLine();
            int number;
            //Validates user input
            if (!int.TryParse(input, out number))
            {
                Console.WriteLine("Please enter your choice as a single number:");
                number = checkValidInput(min, max);
            }
            //Checks for valid input
            if (number >= min && number <= max)
            {
                return number;
            }
            else
            {
                //Error message for invalid input and calls for reprompt
                Console.WriteLine($"Please make sure you input a valid option ({min} - {max}):");
                number = checkValidInput(min, max);
            }
            return number;
        }
    }
}
