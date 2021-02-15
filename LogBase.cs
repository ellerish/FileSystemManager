using System;
using System.IO;
using System.Diagnostics;
using System.Threading;

/***
   * Log class, write to file Log.txt in log folder. 
   * Logs all the result from file service, log the meassge, time stamp, execute duration
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
        public string filePath = @$".\log\Logs.txt";
        String now = GetTime(DateTime.Now);

        public static String GetTime(DateTime value)
        {
            return value.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss");
        }

        public static int GetDuration() 
        {
            return 0;
        }

        public override void Log(string message)
        {
                try
                {
                    using (StreamWriter streamWriter = new StreamWriter(filePath, true))
                    {
                        streamWriter.WriteLine($"Time of execution: {now}: function executed : {message} = " +
                            $"duration of execution ");
                        streamWriter.Close();
                    }
                } 
                catch (FileNotFoundException ex)
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
