﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
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
            string FileName01 = "tennis_data";
            string FileName = "MaleRefs";
            string FileName02 = "FermaleRefs";
            FileHandler listOfFemaleReferee = new FileHandler(@"" + Environment.CurrentDirectory + "\\" + FileName01 + "\\" + FileName02 + ".txt");
            FileHandler listOfMaleReferee = new FileHandler(@"" + Environment.CurrentDirectory + "\\" + FileName01 + "\\" + FileName + ".txt");

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

            try
            {
                Console.WriteLine("Do you want to be GameMaster for the Tournament?" + Environment.NewLine +
                                  " please answer with yes or no");
                string gameMaster = Convert.ToString(Console.ReadLine());

                if (gameMaster == "yes")
                {
                    Console.WriteLine("Please enter your name");
                    string userGameMaster = Convert.ToString((Console.ReadLine()));
                    Console.WriteLine("You are now GameMaster!");
                    Console.WriteLine("GameMaster of the tournament is: {0}", userGameMaster);
                }
                else if (gameMaster == "no")
                {
                    Console.WriteLine("Finding a Referee to be GameMaster");
                    Console.WriteLine("GameMaster of the tournament is: {0}", referees[0]);
                }
                else
                {
                    throw new System.Exception();
                }
            }
            catch (System.Exception)
            {
                Console.WriteLine("You have typed something wrong");
            }

            int amount = referees.Count - 1;
            return referees.GetRange(1, amount);
        }

        public List<TennisPlayer> TournamentHandlerFemaleGame()
        {
            string FileName01 = "tennis_data";
            string FileName = "FemalePlayer";
            FileHandler listOfFemalePlayer = new FileHandler(@"" + Environment.CurrentDirectory + "\\" + FileName01 + "\\" + FileName + ".txt");

            List<TennisPlayer> femaleTennisPlayers = listOfFemalePlayer.GetListFemalePlayers();
            try
            {
                Console.WriteLine("What amount of female players do you want to play at the tournament?");
                Console.WriteLine("The amount of players has to be even such as: 32, 16 or 8 as an example ");
                int upTo = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("You have typed the number {0} and the tournament will now be played" + Environment.NewLine, upTo);

                int i = 0;

                while (i < upTo)
                {
                    int r = rnd.Next(femaleTennisPlayers.Count);

                    if (!femalePlayerForRoundList.Contains(femaleTennisPlayers[r]))
                    {
                        femalePlayerForRoundList.Add(femaleTennisPlayers[r]);
                        i++;
                    }
                }
            }
            catch (System.FormatException)
            {
                Console.WriteLine("You have to type an integer before the tournament can start");
            }
            catch (System.IO.IOException ioex)
            {
                if (ioex.Message.ToLowerInvariant().Contains("32"))
                {
                    Console.WriteLine("You will now see the tournament simulated");
                    throw;
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
            string FileName = "MalePlayer";
            string FileName01 = "tennis_data";
            FileHandler listOfMalePlayer = new FileHandler(@"" + Environment.CurrentDirectory + "\\" + FileName01 + "\\" + FileName + ".txt");

            List<TennisPlayer> maleTennisPlayers = listOfMalePlayer.GetListMalePlayers();
            try
            {
                Console.WriteLine("What amount of male players do you want to play at the tournament?");
                Console.WriteLine("The amount of players has to be even such as: 32, 16 or 8 as an example and be between 2 and 64");
                int upTo = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("You have typed the number {0} and the tournament will now be played" + Environment.NewLine, upTo);

                int i = 0;

                while (i < upTo)
                {
                    int r = rnd.Next(maleTennisPlayers.Count);

                    if (!malePlayerForRoundList.Contains(maleTennisPlayers[r]))
                    {
                        malePlayerForRoundList.Add(maleTennisPlayers[r]);
                        i++;
                    }
                }
            }
            catch (System.FormatException e)
            {
                Console.WriteLine("You have to type a integer before the tournament can start\n" + e);
                Console.WriteLine("\n System will now close down");
                Console.ReadLine();

            }
            catch (System.IO.IOException ioex)
            {
                if (ioex.Message.ToLowerInvariant().Contains("32"))
                {
                    Console.WriteLine("You will now see the tournament simulated");
                    throw;
                }
                else
                {
                    Console.WriteLine("Something went wrong!");
                    throw;
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
    }
}