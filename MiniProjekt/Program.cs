using System;

namespace MiniProjekt
{
    /// <summary>
    /// Dette projekt er lavet af Christian og Ferdinand
    /// You must write a very short 0.5 - 1.0 page documentation that describes the overall structure of the program.
    /// In addition, you must document any assumptions that you have made.
    /// If you have use code that is not in the.Net library you must clear document where the code is from and what you have used it for.
    /// The documentation must be added as a comment at the top of the files that deals with the tournament class.
    ///
    ///
    /// This project is made by Ferdinand Brødløs and Christian Gundersen Holmgaard
    /// Christian Gundersen Holmgaard, studie nr. 20155309
    /// Ferdinand Brødløs, studie nr. 20167752
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
