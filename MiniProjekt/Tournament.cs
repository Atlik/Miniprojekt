using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjekt
{
    class Tournament
    {
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

        public override string ToString()
        {
            int yearStart = tournamentStart.Year;
            int yearEnd = tournamentEnd.Year;

            return "Tournament name: " + tournamentName + " " + yearStart.ToString("d") + " - " + yearEnd.ToString("d") + Environment.NewLine;
        }

        public static void mainTournament()
        {
            DateTime tournamentStart = new DateTime(2017, 11, 22);
            DateTime tournamentEnd = new DateTime(2018, 01, 05);
            Tournament T1 = new Tournament(tournamentStart, tournamentEnd, "Winter Olympics");
            Console.WriteLine(T1);
        }
    }
}
