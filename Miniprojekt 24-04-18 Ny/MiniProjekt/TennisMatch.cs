﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MiniProjekt
{
    class TennisMatch
    {
        // Skal ikke bruges siden TennisMatch ikke skal nedarve fra TennisPlayer
        /*
        //Tennis player properties
        public static string Fname { get; }
        public static string Mname { get; }
        public static string Lname { get; }
        public static DateTime DOB { get; }
        public static string Na { get; }
        public static bool sex { get; }
        */

        //Tennis Match properties
        public string results { get; set; }
        string setWomen, setMen;
        public int menSingleSet { get; set; }
        public int womenSingleSet { get; set; }
        public string Match { get; set; }

        //bruges i Tournament klassen
        public TennisPlayer Player01 { get; set; }
        public TennisPlayer Player02 { get; set; }

        int amountOfSets = 0;
        //Få ordnet en random generate function til at genere resultater og parse til int values
        string[] set = { "set0", "set1", "set2", "set3", "set4" };

        public TennisMatch()
        {
            var Player01 = new TennisPlayer("Christian", "Gundersen", "Holmgaard", new DateTime(1996, 05, 09), "Denmark", true);
            var Player02 = new TennisPlayer("Ferdinand", "", "Brødløs", new DateTime(1995, 07, 19), "Denmark", true);
            var Player03 = new TennisPlayer("Mia", "Bødker", "Nissen", new DateTime(1991, 11, 11), "Denmark", false);
            Console.WriteLine(Player01 + Environment.NewLine + Player02 + "\r\n" + Player03);

          //  Player01.firstName = player01Name;
          //  Player02.firstName = player02Name;

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
