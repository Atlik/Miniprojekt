﻿using System;
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
        readonly FileHandler _listOfMalePlayer = new FileHandler(@"C:\Users\ferdi\Desktop\tennis_data\MalePlayer.txt");
        readonly FileHandler _listOfMaleReferee = new FileHandler(@"C:\Users\ferdi\Desktop\tennis_data\MaleRefs.txt");
        readonly FileHandler _listOfFemalePlayer = new FileHandler(@"C:\Users\ferdi\Desktop\tennis_data\FemalePlayer.txt");
        readonly FileHandler _listOfFemaleReferee = new FileHandler(@"C:\Users\ferdi\Desktop\tennis_data\FermaleRefs.txt");

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
            List<TennisPlayer> refFemale = _listOfFemaleReferee.GetListFemaleReferee();
            List<TennisPlayer> refMale = _listOfMaleReferee.GetListMaleReferee();

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

        /*
         public List<TennisPlayer> TournamentHandlerFemaleGame()
        {
            List<TennisPlayer> femaleTennisPlayers = _listOfFemalePlayer.GetListFemalePlayers();
            int no = 0;

            while (no < 32)
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
        */
        public List<TennisPlayer> TournamentHandlerFemaleGame()
        {
            List<TennisPlayer> femaleTennisPlayers = _listOfFemalePlayer.GetListFemalePlayers();

            try
            {
                Console.WriteLine("What amount of female player do you want to the tournament? ");
                Console.WriteLine("The amount of player has to be even such as: 32, 16 or 8 as example ");
                int upTo = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("You have type the number {0} and the tournement will now be played", upTo);

                int no = 0;

                while (no < upTo)
                {
                    int r = rnd.Next(femaleTennisPlayers.Count);

                    if (!femalePlayerForRoundList.Contains(femaleTennisPlayers[r]))
                    {
                        femalePlayerForRoundList.Add(femaleTennisPlayers[r]);
                        no++;
                    }
                }
            }
            catch (System.FormatException)
            {
                Console.WriteLine("You have to type a integer before the tournament can start");
            }
            catch (System.IO.IOException ioex)
            {
                if (ioex.Message.ToLowerInvariant().Contains("32"))
                {

                }
                else
                {
                    Console.WriteLine("Something went wrong!");
                    throw;
                }
            }
            return femalePlayerForRoundList;
        }

        public List<TennisPlayer> TournamentHandlerMaleGame()
        {
            List<TennisPlayer> maleTennisPlayers = _listOfMalePlayer.GetListMalePlayers();

            int no = 0;

            while (no < 32)
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
