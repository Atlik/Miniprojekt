using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MiniProjekt
{
    class TennisMatch
    {
        public string results { get; set; }
        string setWomen, setMen;
        public int menSingleSet { get; set; }
        public int womenSingleSet { get; set; }
        public string Match { get; set; }
        bool player1 = false;
        bool player2 = false;
        int amountOfSets = 0;

        /*
               public int noSets(string results)
               {

                   /*
                   sets['0-6', '6-0', '6-2']


                  String pattern = @"(\d+)\s+([-])\s+(\d+)";
                   foreach (var expression in results)
                   {
                       foreach (Match m in Regex.Matches(expression, pattern))
                       {
                           int num1 = Int32.Parse(m.Groups[1].Value);
                           int num2 = Int32.Parse(m.Groups[3].Value);
                           int i; 

                           results = i++;

                           if (results = 3)
                           {

                           }
                       }
                   }
                   return String.Format("{0}-{1}", num01, num02);

               }
       */


        public TennisMatch()
        {
            //array skal genereres automatisk
            string[] set = { "set0", "set1", "set2", "set3", "set4" };

            if (player1 == true && player2 == true)
            {
                foreach (var sets in set)
                {
                    amountOfSets++;
                }

                if (amountOfSets <= 5 && amountOfSets > 3)
                {
                    setMen = "This is a mens single match";
                }
            }
            else if (player1 == false && player2 == false)
            {
                foreach (var sets in set)
                {
                    amountOfSets++;
                }

                if (amountOfSets <= 3)
                {
                    setWomen = "This is a womens single match";
                }
            }
            else
            {
                Console.WriteLine("there is no match");
            }
        }

        public override string ToString()
        {
            Console.WriteLine("There is {0} sets ", amountOfSets);
            return "Match: " + Match + Environment.NewLine + "Women single match: " + setWomen + Environment.NewLine + "Men single match: " + setMen;
        }

        static void Main(string[] args)
        {
            var matchNo = new TennisMatch();
            matchNo.Match = "Testing the field";
            Console.WriteLine(matchNo);
        }
    }
}
