using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MiniProjekt
{ 
    class TennisMatch : TennisPlayer
    {
        public string results { get; set; }
        string setWomen, setMen;
        public int menSingleSet { get; set; }
        public int womenSingleSet { get; set; }
        public string Match { get; set; }

        public static string Fname { get; }
        public static string Mname { get; }
        public static string Lname { get; }
        public static DateTime DOB { get; }
        public static string Na { get; }
        public static bool sex { get; }

        int amountOfSets = 0;
        string[] set = { "set0", "set1", "set2", "set3", "set4" };

        public TennisMatch() : base(Fname, Mname, Lname, DOB, Na, sex)
        {
            if (sex == true)
            {
                Console.WriteLine("test test, vi har med et hankøn gøre!");
            }
            else
            {
                Console.WriteLine("pas på! der er et hunkøn tilstede!");
            }

            if (sex == true && sex == true)
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
            else if (sex == false && sex == false)
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
                Console.WriteLine("There is no match");
            }
        }

        public override string ToString()
        {

            Console.WriteLine("There is {0} sets ", amountOfSets);
            return "Match results: " + Match + Environment.NewLine + "Women single match: " + setWomen + Environment.NewLine + "Men single match: " + setMen;
        }

        public static void mainMatch()
        {
            var Player01 = new TennisPlayer("Christian", "Gundersen", "Holmgaard", new DateTime(1996, 05, 09), "Denmark", true);
            var Player02 = new TennisPlayer("Ferdy", "", "Brødløs", new DateTime(1995, 07, 19), "Denmark", true);
            Console.WriteLine(Player01 + Environment.NewLine + Player02);

            var matchNo = new TennisMatch();
            matchNo.Match = "Testing the field";
            Console.WriteLine(matchNo);
        }
    }
}
