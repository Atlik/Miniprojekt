using System;

namespace MiniProjekt
{
    class Tournament
    {
        //Tournament properties
        #region
        public string TournamentName { get; set; }
        public DateTime TournamentStart { get; set; }
        public DateTime TournamentEnd { get; set; }
        #endregion

        public Tournament(DateTime tourDateStart, DateTime tourDateEnd, string tourName)
        {
            TournamentStart = tourDateStart;
            TournamentEnd = tourDateEnd;
            TournamentName = tourName;
        }

        public override string ToString()
        {
            int yearStart = TournamentStart.Year;
            int yearEnd = TournamentEnd.Year;

            //Defines how the object tournament should be printed
            return "Tournament name: " + TournamentName + " " + yearStart.ToString("d") + " - " + yearEnd.ToString("d") + Environment.NewLine;
        }

        public static void MainTournament()
        {
            //Assigns objects of tournament and prints it
            #region
            DateTime tournamentStart = new DateTime(2017, 11, 22);
            DateTime tournamentEnd = new DateTime(2018, 01, 05);
            Tournament T1 = new Tournament(tournamentStart, tournamentEnd, "Winter Olympics");
            Console.WriteLine(T1);
            #endregion
        }
    }
}
