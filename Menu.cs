using System;
using System.Collections.Generic;
using System.Text;

namespace FileSystemManager
{
    class Menu
    {
        public void mainMenu()
        {

            Console.WriteLine("------------------------\n");
            Console.WriteLine("Press 1 to see the menu or any key to exit");
            Console.WriteLine("------------------------\n");
            firstMenu();
      
        }

        public void firstMenu()
        {
            var f = new FileService();
            //  f.listFileInfo();
            //1- List all files 
            // 2- List file by extension
            // 3 Info dracula text

            int choice;
            Console.WriteLine("Choose from menu");
            Console.WriteLine("1. List all files");
            Console.WriteLine("2. List files by extension");
            Console.WriteLine("3. Get info about dracula.txt");
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
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

        public void secondMenu()
        {
            Console.WriteLine("2 was choosen");
        }

        public void thirdMenu()
        {
            Console.WriteLine("3 was choosen");

        }



        /* Menu :
         * 1 : List all files
         * 2: List all files by extension? - new menu. Show extension - then list all files 
         * 3. Play with dractula text - new manu 
         * 
         */

        public void checkInput(String input)
        {
            //handle error input, go back to menu??
        }
    }
}
