using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjekt
{
    class Tournament : TennisPlayer
    {
        //Tennis player properties
        public static string Fname { get; }
        public static string Mname { get; }
        public static string Lname { get; }
        public static DateTime DOB { get; }
        public static string Na { get; }
        public static bool sex { get; }

        //Tournament properties
        public string tournamentName { get; set; }
        public DateTime tournamentStart { get; set; }
        public DateTime tournamentEnd { get; set; }
        // mangel -> tournament start year, kan fås gennem tournamentstart med nyt object af System.DateTime og kan findes derigennem med pointer reference via .Year
        /*
        System.DateTime yearReference = new System.DateTime(1999, 05, 09);

        int year = yearReference.Year;

        Console.WriteLine(year);
        */

        public Tournament() : base(Fname, Mname, Lname, DOB, Na, sex)
        {

        }

        public string Simulate()
        {       
        //Denne metode skal have parametre fra tennisplayer(navnligt deres navn) og simulere resultaterne for deres kampe, 
        //Create a method that can pick the winners of the first four games and create two new games with these four
        //Simulate the rest of the tournament and declare a winner.
        //Keep all the code that is used to simulate the tournament separate from the ”real” code -> HUSK!!

            string simulate = null;
            return simulate;
        }

        public static void mainTournament()
        {

        }
    }
}
