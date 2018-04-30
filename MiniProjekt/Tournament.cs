using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;

namespace MiniProjekt
{
    class Tournament
    {
        static Random rnd = new Random();

        //Tournament properties
        #region
        public string TournamentName { get; set; }
        public DateTime TournamentStart { get; set; }
        public DateTime TournamentEnd { get; set; }
        #endregion

        //Filehandler Initiering
        FileHandler listOfMalePlayer = new FileHandler(@"C:\Users\Christian(Atlik)\Desktop\Miniprojekt\MiniProjekt\tennis_data\MalePlayer.txt");
        FileHandler listOfMaleReferee = new FileHandler(@"C:\Users\Christian(Atlik)\Desktop\Miniprojekt\MiniProjekt\tennis_data\MaleRefs.txt");
        FileHandler listOfFemalePlayer = new FileHandler(@"C:\Users\Christian(Atlik)\Desktop\Miniprojekt\MiniProjekt\tennis_data\FemalePlayer.txt");
        FileHandler listOfFemaleReferee = new FileHandler(@"C:\Users\Christian(Atlik)\Desktop\Miniprojekt\MiniProjekt\tennis_data\FermaleRefs.txt");

        //Runde Lister
        List<TennisPlayer> malePlayerForRoundList = new List<TennisPlayer>();
        List<TennisPlayer> referees = new List<TennisPlayer>();
        List<TennisPlayer> femalePlayerForRoundList = new List<TennisPlayer>();

        //Constructor of Tournament
        public Tournament(DateTime tourDateStart, DateTime tourDateEnd, string tourName)
        {
            TournamentStart = tourDateStart;
            TournamentEnd = tourDateEnd;
            TournamentName = tourName;
        }

        public List<TennisPlayer> TournamentHandlerRefs()
        {
            List<TennisPlayer> refFemale = listOfFemaleReferee.GetListFemaleReferee();
            List<TennisPlayer> refMale = listOfMaleReferee.GetListMaleReferee();

            for (int i = 0; i < refFemale.Count; i++)
            {
                referees.Add(refFemale[i]);
                for (int j = 0; j < refMale.Count; j++)
                {
                    referees.Add(refMale[j]);
                }
            }

            return referees;
        }

        public List<TennisPlayer> TournamentHandlerFemaleGame()
        {
            List<TennisPlayer> femaleTennisPlayers = listOfFemalePlayer.GetListFemalePlayers();
            int no = 0;

            while (no < 8)
            {
                int r = rnd.Next(femaleTennisPlayers.Count);

                if (!femalePlayerForRoundList.Contains(femaleTennisPlayers[r]))
                {
                    femalePlayerForRoundList.Add(femaleTennisPlayers[r]);
                    no++;
                }
            }

            return femalePlayerForRoundList;
        }

        public List<TennisPlayer> TournamentHandlerMaleGame()
        {
            List<TennisPlayer> maleTennisPlayers = listOfMalePlayer.GetListMalePlayers();

            int no = 0;

            while (no < 8)
            {
                int r = rnd.Next(maleTennisPlayers.Count);

                if (!malePlayerForRoundList.Contains(maleTennisPlayers[r]))
                {
                    malePlayerForRoundList.Add(maleTennisPlayers[r]);
                    no++;
                }
            }

            return malePlayerForRoundList;
        }

        public override string ToString()
        {
            //Defines how the object tournament should be printed
            #region
            int yearStart = TournamentStart.Year;
            int yearEnd = TournamentEnd.Year;

            return "Tournament name: " + TournamentName + " " + yearStart.ToString("d") + " - " + yearEnd.ToString("d") + Environment.NewLine;
            #endregion
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
