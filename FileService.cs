using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FileSystemManager
{
    class FileService
    {
        FileInfo fileTest = new FileInfo(@"C:/Users/erisha/desktop/fsm/FileSystemManager/resources/Dracula.txt");
        public void listAllFiles()
        {
            string dir = @"C:/Users/erisha/desktop/fsm/FileSystemManager/resources/";

            // get list of files
            string[] files = Directory.GetFiles(dir);
            Console.WriteLine(String.Join(Environment.NewLine, files));
        }

        public void getFileInfoName()
        {
            Console.WriteLine($"The file name is:  {fileTest.Name } can be found in {fileTest.Directory}" +
                $" and is {fileTest.Length} long ");
        }

        public void getFileSize()
        {
            Console.WriteLine($"File Size is: {fileTest.Length} ");
        }

        public void getLinesOfFile()
        {
            var lineCount = 0;
            using (var reader = File.OpenText($"{fileTest}"))
            {
                while (reader.ReadLine() != null)
                {
                    lineCount++;
                }
            }
            Console.WriteLine($"File contains {lineCount} lines");
        }

        public static string getWordInText(String word)
        {
            return word;

        }
        

    }
  

    /*
     * Method List all files
     * Method Get spesific file by extension, list all files by extension
     * 
     * Text file : give info
     *  - name of file, size of file, how many lines the files has, 
     *  - search for a spesific word in the text, how many times a spesific word appears
     * 
     * 
     * */
}
