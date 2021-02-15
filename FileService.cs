using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace FileSystemManager
{
    class FileService
    {
        FileInfo fileTest = new FileInfo(@"C:/Users/erisha/desktop/fsm/FileSystemManager/resources/Dracula.txt");
        String directoryPath = @"C:/Users/erisha/desktop/fsm/FileSystemManager/resources/";
        FileLogger fileLogger = new FileLogger();
        Stopwatch watch = new System.Diagnostics.Stopwatch();

        public void listAllFiles()
        {
            watch.Start();
            // get list of files
            string[] files = Directory.GetFiles(directoryPath);
            Console.WriteLine(String.Join(Environment.NewLine, files));
            watch.Stop();
            fileLogger.Log($"List all files,  {watch.ElapsedMilliseconds} ms");
        }

        public void listFilesByExtension(String extension)
        {
            string[] files = Directory.GetFiles(directoryPath, $"*.{extension}", SearchOption.AllDirectories);
            Console.WriteLine(String.Join(Environment.NewLine, files));

        }

        public void getFileInfoName()
        {
            watch.Start();
            Console.WriteLine($"The file name is:  {fileTest.Name } can be found in {fileTest.Directory}" +
                $" and is {fileTest.Length} long ");
            watch.Stop();
            fileLogger.Log($"Get file name: {fileTest.Name }, {watch.ElapsedMilliseconds} ms");
        }

        public void getFileSize()
        {
            Console.WriteLine($"File Size is: {fileTest.Length} ");
        }

        public void getLinesOfFile()
        {
            watch.Start();
            var lineCount = 0;
            using (StreamReader reader = File.OpenText($"{fileTest}"))
            {
                while (reader.ReadLine() != null)
                {
                    lineCount++;
                }
            }
            Console.WriteLine($"File contains {lineCount} lines");
            watch.Stop();
            fileLogger.Log($"Get lines of file: {lineCount}, {watch.ElapsedMilliseconds} ms");

        }

        public void getWordInText()
        {
            watch.Start();
            Console.Write("Enter word to search for...\n");
            String word = Console.ReadLine().Trim();
            using (StreamReader reader = File.OpenText($"{fileTest}"))
            {
                //counts the number of times wordResponse is found.
                int wordCount = 0; 
                int lineNumber = 0;
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    lineNumber++;
                    int position = line.IndexOf(word.Trim());
                    if (position != -1)
                    {
                        wordCount++;
                    }
                }
                if (wordCount == 0)
                {
                    Console.WriteLine("your word was not found!");
                }
                else
                {
                    Console.WriteLine($"File contains {wordCount} of the word {word}");
                }
                watch.Stop();
                fileLogger.Log($"Get word: {word} in file, found {wordCount} times, {watch.ElapsedMilliseconds} ms");
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
}