using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjekt
{
    class Tournament : TennisMatch
    {
        //Tennis player properties, disse behøves vidst ikke idet den burde arve fra match
  //      public static string Fname { get; }
  //      public static string Mname { get; }
  //      public static string Lname { get; }
  //      public static DateTime DOB { get; }
  //      public static string Na { get; }
  //      public static bool sex { get; }

        //Tournament properties
        public string tournamentName { get; set; }
        public DateTime tournamentStart { get; set; }
        public DateTime tournamentEnd { get; set; }
        public DateTime TYearStartToEnd { get; set; }

        public Tournament(DateTime TDateStart, DateTime TDateEnd, string Tname)
        {
            tournamentStart = TDateStart;
            tournamentEnd = TDateEnd;
            tournamentName = Tname;
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

        public override string ToString()
        {
            int yearStart = tournamentStart.Year;
            int yearEnd = tournamentEnd.Year;
            /*
            string player01Name, player02Name;
            if (Player01.firstName == null)
            {
                player01Name = "navn findes ikke";
                player02Name = "denied";
            }
            else
            {
                player01Name = Player01.firstName;
                player02Name = Player02.firstName;
            }*/



            return "Tournament name: " + tournamentName + yearStart.ToString(" d") + " - " + yearEnd.ToString("d") + Environment.NewLine +
                    "Players competing:" + /*player01Name +*/ " and " /*+ player02Name*/ +  Environment.NewLine +
                    "Matches in total:" + Environment.NewLine;
        }

        public static void mainTournament()
        {
            System.DateTime tournamentStart = new System.DateTime(2017, 11, 22);
            System.DateTime tournamentEnd = new System.DateTime(2018, 01, 05);
            Tournament T1 = new Tournament(tournamentStart, tournamentEnd, "Winter Olympics");
            Console.WriteLine(T1);
        }
    }
}
