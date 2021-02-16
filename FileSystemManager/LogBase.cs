using System;
using System.IO;

/*
 * FileLogger, streams to file "Log.txt" in log folder.  
 */

namespace FileSystemManager
{
    public abstract class LogBase
    {
        public abstract void Log(string message);
    }

    public class FileLogger : LogBase
    {
        //Path to log file
        public string filePath = @$".\log\Logs.txt";

        String timeOfExecution = GetTime(DateTime.Now);

        //Return value of datetime in presentable format 
        public static String GetTime(DateTime value)
        {
            return value.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss");
        }

        public static int GetDuration() 
        {
            return 0;
        }
        //Log to file using streamwriter
        public override void Log(string message)
        {
                try
                {    //using Streamwriter, true to append data to the file
                    using (StreamWriter streamWriter = new StreamWriter(filePath, true))
                    {
                        streamWriter.WriteLine($"Time of execution: {timeOfExecution}: function executed : {message} = " +
                            $"duration of execution ");
                        streamWriter.Close();
                    }
                } 
                //Catch file not found exception
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine("Could not write to file dosent exist");
                    Console.WriteLine(ex.Message);
                }
                 //Catch any other exception
                  catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
        }
    }
}
