using System;

namespace FileSystemManager
{
    class Program
    {
        static void Main(string[] args)
        {
            var l = new FileLogger();
            l.Log("Tester4");
            l.Log("Mama");
            l.Log("     ");

          /*  var m = new Menu();
              m.mainMenu();*/
        }
    }


}
