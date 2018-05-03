using System;


namespace MiniProjekt
{
    /// <summary>
    /// This is the main of the program
    /// Its only use is to call different instances of the program to see if it works
    /// </summary>
    class Program 
    {
        static void Main(string[] args)
        {
            var match = new TennisMatch();
            Console.WriteLine(match);
        }
    }
}
