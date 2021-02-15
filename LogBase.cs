using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

/***
   * write to a file, placed in a appropaite folder
   * Log all the result from file service, log the meassge, time stamp, 
   * execute duration
   * 
   * */

namespace FileSystemManager
{
    public abstract class LogBase
    {
        public abstract void Log(string message);
    }

    public class FileLogger : LogBase
    {
        public string filePath = @"C:/Users/erisha/desktop/fsm/FileSystemManager/log/TestLog.txt";
        String now = GetTime(DateTime.Now);
        int duration = GetDuration();

        public static String GetTime(DateTime value)
        {
            return value.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss");
        }

        public static int GetDuration() 
        {
            return 2;
        }

        public override void Log(string message)
        {
     
                try
                {
                    using (StreamWriter streamWriter = new StreamWriter(filePath, true))
                    {
                        streamWriter.WriteLine(message);
                        streamWriter.WriteLine($"Time of execution: {now} duration of execution: {duration}");
                        streamWriter.Close();
                    }
                } catch (FileNotFoundException ex)
                {
                    Console.WriteLine("Could not write to file dosent exist");
                    Console.WriteLine(ex.Message);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            
        }
    }
}
