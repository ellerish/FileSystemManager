using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;

/*
 * FileSystemManager
 */

namespace FileSystemManager
{
    class FileService
    {
        FileInfo fileTest = new FileInfo(@$"{directoryPath}\Dracula.txt");
        public static String directoryPath = @".\resources";

        //Logging time of execution and duration to log.txt
        FileLogger fileLogger = new FileLogger();
        Stopwatch watch = new Stopwatch();

        public void listAllFiles()
        {
            try
            {
                watch.Start();
                //list of files
                string[] files = Directory.GetFiles(directoryPath);
                // FileInfo f = new FileInfo(files);
                foreach (string file in files)
                {
                    //Get name of each file
                    FileInfo fileInfo = new FileInfo(file);
                    Console.WriteLine($"{fileInfo.Name}");
                }
                watch.Stop();
                fileLogger.Log($"List all files,  {watch.ElapsedMilliseconds} ms");
            }
            //Catch file not found exception
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("File not found");
                Console.WriteLine(ex.Message);
            }
            //Catch any exception
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void listFilesByExtension(String extension)
        {
            try
            {
                watch.Start();
                //List by extenstion based on userinput
                string[] files = Directory.GetFiles(directoryPath, $"*.{extension}", SearchOption.AllDirectories);
                foreach (string file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    Console.WriteLine($"{fileInfo.Name}");
                }
                watch.Stop();
                fileLogger.Log($"List all files of extenstion {extension}, {watch.ElapsedMilliseconds} ms");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("File not found");
                Console.WriteLine(ex.Message);
            }
            //Catch any exception
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void getFileNameAndSize()
        {
            watch.Start();
            //Get name and size of Dracula file using FileInfo. 
            Console.WriteLine($"\n The file name is: {fileTest.Name} and the size of file is: {fileTest.Length} bytes." +
                $" The file can be found in directory: {fileTest.Directory}");
            watch.Stop();
            fileLogger.Log($"Get file name: {fileTest.Name}, {watch.ElapsedMilliseconds} ms");
        }

        public void getFileSize()
        {
            Console.WriteLine($"File Size is: {fileTest.Length} ");
        }

        public void getLinesOfFile()
        {
            try
            {
                watch.Start();
                // Get lines of file using streamreader. Looping through every line and updates linecount
                int lineCount = 0;
                using (StreamReader reader = File.OpenText($"{fileTest}"))
                {
                    while (reader.ReadLine() != null)
                    {
                        lineCount++;
                    }
                    //close reader
                    reader.Close();
                }
                Console.WriteLine($"File contains {lineCount} lines");
                watch.Stop();
                fileLogger.Log($"Get lines of file: {lineCount}, {watch.ElapsedMilliseconds} ms");
            }
            //Catch file not found exception
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Could read from file");
                Console.WriteLine(ex.Message);
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().Name);
            }
        }

        public void getWordInText()
        {
            try
            {
                watch.Start();
                Console.Write("Enter word to search for...\n");
                String word = Console.ReadLine().Trim().ToLower();
                using (StreamReader reader = File.OpenText($"{fileTest}"))
                {
                    //counts the number of times word is found.
                    int wordCount = 0;
                    while (!reader.EndOfStream)
                    {
                        //Check matches for input word, updates wordcount if match
                        string lineCheck = reader.ReadLine();
                        bool match = Regex.IsMatch(lineCheck, $@"\b{word.ToLower()}\b", RegexOptions.IgnoreCase);
                        if (match)
                        {
                            wordCount++;
                        }
                    }
                    //close reader
                    reader.Close();
                    //No macthes
                    if (wordCount == 0)
                    {
                        Console.WriteLine($"\n Your word: {word} was not found in the text!");
                    }
                    else
                    {
                        Console.WriteLine($"\n File contains the word: {word}, the word appears {wordCount} times!");
                    }
                    watch.Stop();
                    fileLogger.Log($"Get word: {word} in file, found {wordCount} times, {watch.ElapsedMilliseconds} ms");
                }
            }
            //Catch file not found exception
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Could read from file");
                Console.WriteLine(ex.Message);
            }
            //Catch any other exceptions
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().Name);
            }
        }

    }
}