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
        //Tennis Match properties
        public string results { get; set; }
        string setWomen, setMen;
        public int menSingleSet { get; set; }
        public int womenSingleSet { get; set; }
        public string Match { get; set; }

        int amountOfSets = 0;
        //Få ordnet en random generate function til at genere resultater og parse til int values
        string[] set = { "set0", "set1", "set2", "set3", "set4" };

        public TennisMatch()
        {
            //Assigns new player objects and print their information
            #region
            var Player01 = new TennisPlayer("Christian", "Gundersen", "Holmgaard", new DateTime(1996, 05, 09), "Denmark", true);
            var Player02 = new TennisPlayer("Ferdinand", "", "Brødløs", new DateTime(1995, 07, 19), "Denmark", true);
            var Player03 = new TennisPlayer("Mia", "Bødker", "Nissen", new DateTime(1991, 11, 11), "Denmark", false);
            Console.WriteLine(Player01 + Environment.NewLine + Player02 + Environment.NewLine + Player03);
            #endregion

            if (Player01.gender == true)
            {
                Console.WriteLine("test test, vi har med et hankøn gøre!");
            }
            else
            {
                Console.WriteLine("pas på! der er et hunkøn tilstede!");
            }

            if (Player01.gender == true && Player02.gender == true)
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
            else if (Player01.gender == false && Player02.gender == false)
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

        public class RandSetsTournament
        {
            static Random rand = new Random();

            public static void TGeneration()
            {
                int Player01 = 0;
                int Player02 = 0;
                string Player01win = "";
                string Player02win = "";

                //Skal bruges til at tælle op på set -> int CounterOfSets = 0;

                for (int i = 0; i < 3; i++)
                {
                    while (true)
                    {
                        {
                            var dice = rand.Next(0, 2);
                            if (dice == 0)
                            {
                                ++Player01;
                                //Tester hvordan point systemet gives
                                //Console.WriteLine("Player 1 gets a point: " + Player01);
                                if (Player01 == 6)
                                {
                                    Player01win = "Player 1 wins the game ";
                                    Player02win = "";
                                }
                            }
                            else if (dice == 1)
                            {
                                ++Player02;
                                //Tester hvordan point systemet gives
                                //Console.WriteLine("Player 2 gets a point: " + Player02);
                                if (Player02 == 6)
                                {
                                    Player01win = "";
                                    Player02win = "Player 2 wins the game ";
                                }
                            }
                            if (Player01 == 6 || Player02 == 6)
                            {
                                Console.WriteLine("The sets of the game was: " + Player01 + " - " + Player02 + " " + Player01win + Player02win + Environment.NewLine);
                                Player01 = 0;
                                Player02 = 0;
                                break;
                            }
                        }
                    }
                }
            }
        }

        public override string ToString()
        {
            int i;
            Console.WriteLine("There is {0} sets ", amountOfSets);
            if (amountOfSets > 0)
            {
                for (i = 0; i < amountOfSets; i++)
                {
                    var Game = "Match results: " + set[i];
                    Console.WriteLine(Game);
                }
            }
            else
            {
                Console.WriteLine("Game results could not be found");
            }

            return "Women single match: " + setWomen + Environment.NewLine + "Men single match: " + setMen;
        }

        public static void mainMatch()
        {
            var matchNo = new TennisMatch();
            Console.WriteLine(matchNo);

            RandSetsTournament.TGeneration();

        }
    }
}


/*            var matchResults = new HashSet<string> { "set0", "set1", "set2", "set3", "set4" };
            Console.WriteLine("There was {0} sets in the game", matchResults.Count);
            amountOfSets = matchResults.Count;
            foreach (string s in matchResults)
            {
                Console.WriteLine("The match went as following: " + s);
            }*/
