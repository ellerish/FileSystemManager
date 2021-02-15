using System;
using System.Collections.Generic;
using System.Text;

namespace FileSystemManager
{
    class Menu
    {
        public static int inputChoice = 0;
        public void mainMenu()
        {
            do
            {
                welcome();

            } while (true);
        }

        public static void welcome()
        {
            Console.WriteLine("------------------------\n");
            Console.WriteLine("Enter 1 to see the menu or enter 2 to exit)");
            Console.WriteLine("------------------------\n");
            inputChoice = checkValidInput(1, 2);
            //Checks for exit value (2)
            if(inputChoice == 2)
            {
                Environment.Exit(2);
            }
            firstMenu();
        }

        public static void firstMenu()
        {
          
            var f = new FileService();
            Console.WriteLine("Choose from menu");
            Console.WriteLine("1. List all files");
            Console.WriteLine("2. List files by extension");
            Console.WriteLine("3. Get info about dracula.txt");
            inputChoice = checkValidInput(1, 3);
            switch (inputChoice)
            {
                case 1:
                    Console.Write("List all files \n");
                    f.listAllFiles();
                    break;

                case 2:
                    secondMenu();
                    break;

                case 3:
                    // thirdMenu();
                    f.getFileInfoName();
                    f.getLinesOfFile();
                    break;
                
               default:
                    Console.Write("Input correct option\n");
                    break;
            }

        }

        public static void secondMenu()
        {
            Console.WriteLine("Select: ");
            Console.WriteLine("1. jpeg");
            Console.WriteLine("2. jfif");
            Console.WriteLine("3. png");
            Console.WriteLine("4. jpg");
            inputChoice = checkValidInput(1, 4);
            switch (inputChoice)
            {
                case 1:
                    Console.Write("Choosen jpeg");
                    break;

                case 2:
                    Console.Write("Choosen jfif");
                    break;

                case 3:
                    Console.Write("Choosen png");
                    break;

                case 4:
                    Console.Write("Choosen jpg");
                    break;

                default:
                    Console.Write("Input correct option\n");
                    break;
            }

        }

        public void thirdMenu()
        {
            Console.WriteLine("Select: ");
            Console.WriteLine("1. GetName of file");
            Console.WriteLine("2. Get Lines of file");
            Console.WriteLine("3. Search for word in file");
        }



        /* Menu :
         * 1 : List all files
         * 2: List all files by extension? - new menu. Show extension - then list all files 
         * 3. Play with dractula text - new manu 
         * 
         */


        //Provides dynamic integer input prompting
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
