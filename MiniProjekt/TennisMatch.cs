using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;

namespace MiniProjekt
{
    //This class handles and simulate each match in the tournament
    class TennisMatch
    {
        //Tennis Match properties
        #region
        public string Results { get; set; }
        public int MenSingleSet { get; set; }
        public int WomenSingleSet { get; set; }
        public string Match { get; set; }
        #endregion
        static Random rnd = new Random();
        //static Random rand = new Random();

        public TennisMatch()
        {
            #region
            DateTime tournamentStart = new DateTime(2017, 11, 22);
            DateTime tournamentEnd = new DateTime(2018, 01, 05);
            Tournament listOfPersonsForRound = new Tournament(tournamentStart, tournamentEnd, "Winter Olympics");
            List<TennisPlayer> tournamentMalePlayers = listOfPersonsForRound.TournamentHandlerMaleGame();
            List<TennisPlayer> tournamentFemalePlayers = listOfPersonsForRound.TournamentHandlerFemaleGame();
            List<TennisPlayer> tournamentRefs = listOfPersonsForRound.TournamentHandlerRefs();

            //Console.WriteLine("Male Players");
            for (int i = 0; i < tournamentMalePlayers.Count; i++)
            {
                // Console.WriteLine(tournamentMalePlayers[i]);
            }
            //Console.ReadLine();
            //Console.WriteLine("Female Players");
            for (int i = 0; i < tournamentFemalePlayers.Count; i++)
            {
                //Console.WriteLine(tournamentFemalePlayers[i]);
            }
            //Console.ReadLine();
            //Console.WriteLine("Referees");
            for (int i = 0; i < tournamentRefs.Count; i++)
            {
                //Console.WriteLine(tournamentRefs[i]);
            }
            //Console.ReadLine();
            #endregion

            int p2 = 1;
            for (int p1 = 0; p1 < tournamentMalePlayers.Count; p1 += 2)
            {
                int r = rnd.Next(tournamentRefs.Count);
                Console.WriteLine(tournamentMalePlayers[p1]);
                Console.WriteLine(tournamentMalePlayers[p2]);
                Console.WriteLine(
                    "A single male game has been set for player 01: {0} and player 2: {1} \r\n" +
                    "The game will be controlled by the referee: {2}" +
                    Environment.NewLine,
                    tournamentMalePlayers[p1].FirstName, tournamentMalePlayers[p2].FirstName,
                    tournamentRefs[r].FirstName);

                //Simulate matches between players
                #region
                while (true)
                {
                    int player01Point = 0;
                    int player02Point = 0;
                    string setWin01 = "";
                    string setWin02 = "";
                    int matchOfSetsCounter = 0;
                    int setWinCount01 = 0;
                    int setWinCount02 = 0;

                    for (var i = 0; i < 5; i++)
                    {
                        while (true)
                        {
                            //Points is given
                            #region
                            var dice = rnd.Next(0, 2);
                            if (dice == 0)
                            {
                                ++player01Point;
                                //Tester hvordan point systemet gives
                                //Console.WriteLine("Player 1 gets a point: " + Player01);
                                if (player01Point == 6)
                                {
                                    setWin01 = "Player 1:" + tournamentMalePlayers[p1].FirstName + " wins the game ";
                                    setWin02 = null;
                                    setWinCount01++;
                                }
                            }
                            else if (dice == 1)
                            {
                                ++player02Point;
                                //Tester hvordan point systemet gives
                                //Console.WriteLine("Player 2 gets a point: " + Player02);
                                if (player02Point == 6)
                                {
                                    setWin01 = null;
                                    setWin02 = "Player 2: " + tournamentMalePlayers[p2].FirstName + " wins the game ";
                                    setWinCount02++;
                                }
                            }
                            #endregion

                            //Player points pr. set is printed
                            #region
                            if (player01Point == 6 || player02Point == 6)
                            {
                                Console.WriteLine("The sets of the game was: " + player01Point + " - " + player02Point +
                                                    " " + setWin01 + setWin02 + Environment.NewLine);
                                player01Point = 0;
                                player02Point = 0;
                                matchOfSetsCounter++;
                            }
                            #endregion

                            //Checks the amount of sets each player has won
                            #region
                            if (setWinCount01 == 3 || setWinCount02 == 3)
                            {
                                break;
                            }
                            #endregion
                        }
                    }
                    //Prints who won the game
                    #region
                    if (setWinCount01 == 3)
                    {
                        Console.WriteLine("There has been a sets of: " + matchOfSetsCounter + " Player 1: {0} has won the game!\r\n", tournamentMalePlayers[p1].FirstName);
                        matchOfSetsCounter = 0;
                        break;
                    }
                    else if (setWinCount02 == 3)
                    {
                        Console.WriteLine("There has been a sets of: " + matchOfSetsCounter + " Player 2: {0} has won the game!\r\n", tournamentMalePlayers[p2].FirstName);
                        matchOfSetsCounter = 0;
                        break;
                    }
                    #endregion
                }
                #endregion
                p2 += 2;
            }
            p2 = 1;
        }

        //Simulate matches between Males and Females
        #region
        public static void MaleMatch()
        {
            int player01Point = 0;
            int player02Point = 0;
            int setWinCount01 = 0;
            int setWinCount02 = 0;
            string setWin01 = "";
            string setWin02 = "";
            int matchOfSetsCounter = 0;

            for (var i = 0; i < 5; i++)
            {
                while (true)
                {
                    //Points is given
                    #region
                    var dice = rnd.Next(0, 2);
                    if (dice == 0)
                    {
                        ++player01Point;
                        //Tester hvordan point systemet gives
                        //Console.WriteLine("Player 1 gets a point: " + Player01);
                        if (player01Point == 6)
                        {
                            setWin01 = "Player 1 wins the game ";
                            setWin02 = null;
                            setWinCount01++;
                        }
                    }
                    else if (dice == 1)
                    {
                        ++player02Point;
                        //Tester hvordan point systemet gives
                        //Console.WriteLine("Player 2 gets a point: " + Player02);
                        if (player02Point == 6)
                        {
                            setWin01 = null;
                            setWin02 = "Player 2 wins the game ";
                            setWinCount02++;
                        }
                    }
                    #endregion

                    //Player points pr. set is printed
                    #region
                    if (player01Point == 6 || player02Point == 6)
                    {
                        Console.WriteLine("The sets of the game was: " + player01Point + " - " + player02Point +
                                            " " + setWin01 + setWin02 + Environment.NewLine);
                        player01Point = 0;
                        player02Point = 0;
                        matchOfSetsCounter++;
                    }
                    #endregion

                    //Checks the amount of sets each player has won
                    #region
                    if (setWinCount01 == 3 || setWinCount02 == 3)
                    {
                        break;
                    }
                    #endregion
                }
            }
            //Prints who won the game
            #region
            if (setWinCount01 == 3)
            {
                Console.WriteLine("There has been a sets of: " + matchOfSetsCounter + " Player 1 has won the game!\r\n");
                matchOfSetsCounter = 0;

            }
            else if (setWinCount02 == 3)
            {
                Console.WriteLine("There has been a sets of: " + matchOfSetsCounter + " Player 2 has won the game!\r\n");
                matchOfSetsCounter = 0;
            }
            #endregion
        }

        public static void FemaleMatch()
        {
            int player01Point = 0;
            int player02Point = 0;
            int setWinCount01 = 0;
            int setWinCount02 = 0;
            string setWin01 = "";
            string setWin02 = "";
            int matchOfSetsCounter = 0;

            for (int i = 0; i < 3; i++)
            {
                while (true)
                {
                    //Points is given
                    #region
                    var dice = rnd.Next(0, 2);
                    if (dice == 0)
                    {
                        ++player01Point;
                        //Tester hvordan point systemet gives
                        //Console.WriteLine("Player 1 gets a point: " + Player01);
                        if (player01Point == 6)
                        {
                            setWin01 = "Player 1 wins the game ";
                            setWin02 = null;
                            setWinCount01++;
                        }
                    }
                    else if (dice == 1)
                    {
                        ++player02Point;
                        //Tester hvordan point systemet gives
                        //Console.WriteLine("Player 2 gets a point: " + Player02);
                        if (player02Point == 6)
                        {
                            setWin01 = null;
                            setWin02 = "Player 2 wins the game ";
                            setWinCount02++;
                        }
                    }
                    #endregion

                    //Player points pr. set is printed
                    #region
                    if (player01Point == 6 || player02Point == 6)
                    {
                        Console.WriteLine("The sets of the game was: " + player01Point + " - " + player02Point +
                                            " " + setWin01 + setWin02 + Environment.NewLine);
                        player01Point = 0;
                        player02Point = 0;
                        matchOfSetsCounter++;
                    }
                    #endregion

                    //Checks the amount of sets each player has won
                    #region
                    if (setWinCount01 == 2 || setWinCount02 == 2)
                    {
                        break;
                    }
                    #endregion
                }
            }
            //Prints who won the game
            #region
            if (setWinCount01 == 2)
            {
                Console.WriteLine("There has been a sets of: " + matchOfSetsCounter + " Player 1 has won the game!\r\n");
                matchOfSetsCounter = 0;

            }
            else if (setWinCount02 == 2)
            {
                Console.WriteLine("There has been a sets of: " + matchOfSetsCounter + " Player 2 has won the game!\r\n");
                matchOfSetsCounter = 0;
            }
            #endregion
        }
        #endregion

        public static void MainMatch()
        {
            var matchNo = new TennisMatch();
            Console.WriteLine(matchNo);
        }
    }
}
