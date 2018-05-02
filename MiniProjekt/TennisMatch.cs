using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;

namespace MiniProjekt
{
    //This class handles and simulate each match in the tournament
    class TennisMatch
    {

        static Random rnd = new Random();

        public TennisMatch()
        {
            try
            {
                //Initiating Tournament and lists

                #region
                DateTime tournamentStart = new DateTime(2017, 11, 22);
                DateTime tournamentEnd = new DateTime(2018, 01, 05);
                Tournament listOfPersonsForRound = new Tournament(tournamentStart, tournamentEnd, "Winter Olympics");
                List<TennisPlayer> tournamentRefs = listOfPersonsForRound.TournamentHandlerRefs();
                #endregion

                Console.WriteLine(listOfPersonsForRound);

                //Simulate Tournament for Males

                #region

                List<TennisPlayer> tournamentMalePlayers = listOfPersonsForRound.TournamentHandlerMaleGame();

                //Sort the tournamentMalePlayers by firstname before the tournament starts
                #region
                List<TennisPlayer> sortedMalePlayer = tournamentMalePlayers.OrderBy(tennisPlayer => tennisPlayer.FirstName).ToList();

                for (int i = 0; i < sortedMalePlayer.Count; i++)
                {
                    Console.WriteLine(sortedMalePlayer[i].FirstName + " Players number: {0} ", i);
                }

                Console.WriteLine("Sorted list has been made: ");
                Console.ReadLine();
                #endregion


                Console.WriteLine("Tournament for male players is beginning!!");
                if (tournamentMalePlayers == null)
                {
                    throw new System.IO.IOException();
                }

                int round = 0;
                int p2 = 1;
                List<TennisPlayer> winners = new List<TennisPlayer>();
                List<int> losers = new List<int>();

                while (true)
                {
                    for (int p1 = 0; p1 < tournamentMalePlayers.Count; p1 += 2)
                    {
                        //Generate a random Referee for each game and inserts which players will play eachother

                        #region

                        int r = rnd.Next(tournamentRefs.Count);
                        Console.WriteLine(tournamentMalePlayers[p1]);
                        Console.WriteLine(tournamentMalePlayers[p2]);
                        Console.WriteLine(
                            "A single male game has been set for player 01: {0} and player 2: {1} \r\n" +
                            "The game will be controlled by the referee: {2}" +
                            Environment.NewLine,
                            tournamentMalePlayers[p1].FirstName, tournamentMalePlayers[p2].FirstName,
                            tournamentRefs[r].FirstName);

                        #endregion

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
                                            setWin01 = "Player 1: " + tournamentMalePlayers[p1].FirstName +
                                                       " wins the game ";
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
                                            setWin02 = "Player 2: " + tournamentMalePlayers[p2].FirstName +
                                                       " wins the game ";
                                            setWinCount02++;
                                        }
                                    }

                                    #endregion

                                    //Player points pr. set is printed

                                    #region

                                    if (player01Point == 6 || player02Point == 6)
                                    {
                                        Console.WriteLine("The sets of the game was: " + player01Point + " - " +
                                                          player02Point +
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
                                Console.WriteLine(
                                    "There has been a sets of: " + matchOfSetsCounter +
                                    " Player 1: {0} has won the game!\r\n", tournamentMalePlayers[p1].FirstName);
                                matchOfSetsCounter = 0;
                                //Console.ReadLine();
                                winners.Add(tournamentMalePlayers[p1]);
                                losers.Add(tournamentMalePlayers[p2].Identifikation);
                                break;
                            }
                            else if (setWinCount02 == 3)
                            {
                                Console.WriteLine(
                                    "There has been a sets of: " + matchOfSetsCounter +
                                    " Player 2: {0} has won the game!\r\n",
                                    tournamentMalePlayers[p2].FirstName);
                                matchOfSetsCounter = 0;
                                //Console.ReadLine();
                                winners.Add(tournamentMalePlayers[p2]);
                                losers.Add(tournamentMalePlayers[p1].Identifikation);
                                break;
                            }

                            #endregion
                        }

                        #endregion

                        p2 += 2;
                    }

                    //Prints winners and remove losers from list

                    #region

                    round++;
                    int m = 1;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Winners of Round: {0}", round);
                    for (int i = 0; i < winners.Count; i++)
                    {
                        Console.WriteLine("Winner of Game {0} was the players: {1}", m, winners[i].FirstName);
                        m++;
                    }

                    m = 1;
                    Console.ResetColor();
                    for (int i = 0; i < tournamentMalePlayers.Count; i++)
                    {
                        for (int k = 0; k < losers.Count; k++)
                        {
                            for (int o = 0; o < winners.Count; o++)
                            {
                                if (tournamentMalePlayers[i].Identifikation == losers[k] ||
                                    winners[o].Identifikation == losers[k])
                                {
                                    tournamentMalePlayers.RemoveAt(i);
                                    winners.RemoveAt(o);
                                }
                            }
                        }
                    }

                    #endregion

                    p2 = 1;
                    if (tournamentMalePlayers.Count == 1)
                    {
                        Console.WriteLine("Tournament for Male player is done" + Environment.NewLine);
                        break;
                    }
                }

                #endregion

                //Simulate Tournament for females

                #region

                List<TennisPlayer> tournamentFemalePlayers = listOfPersonsForRound.TournamentHandlerFemaleGame();

                //Sort the tournamentfemalePlayers by firstname before the tournament starts
                #region
                List<TennisPlayer> sortedfemale = tournamentFemalePlayers.OrderBy(TennisPlayer => TennisPlayer.FirstName).ToList();

                for (int i = 0; i < sortedfemale.Count; i++)
                {
                    Console.WriteLine(sortedfemale[i].FirstName + " Players number: {0} ", i);
                }

                Console.WriteLine("Sorted list has been made: ");
                Console.ReadLine();
                #endregion


                Console.WriteLine("Female tournament will now start");
                if (tournamentFemalePlayers == null)
                {
                    throw new System.IO.IOException();
                }

                int femaleRound = 0;
                int femalep2 = 1;
                List<TennisPlayer> femaleWinners = new List<TennisPlayer>();
                List<int> femaleLosers = new List<int>();

                while (true)
                {
                    for (int p1 = 0; p1 < tournamentFemalePlayers.Count; p1 += 2)
                    {
                        //generate a random Referee for each game and inserts which players will play eachother

                        #region

                        int r = rnd.Next(tournamentRefs.Count);
                        Console.WriteLine(tournamentFemalePlayers[p1]);
                        Console.WriteLine(tournamentFemalePlayers[femalep2]);
                        Console.WriteLine(
                            "A single female game has been set for player 01: {0} and player 2: {1} \r\n" +
                            "The game will be controlled by the referee: {2}" +
                            Environment.NewLine,
                            tournamentFemalePlayers[p1].FirstName, tournamentFemalePlayers[femalep2].FirstName,
                            tournamentRefs[r].FirstName);

                        #endregion

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

                            for (var i = 0; i < 3; i++)
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
                                            setWin01 = "Player 1: " + tournamentFemalePlayers[p1].FirstName +
                                                       " wins the game ";
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
                                            setWin02 = "Player 2: " + tournamentFemalePlayers[femalep2].FirstName +
                                                       " wins the game ";
                                            setWinCount02++;
                                        }
                                    }

                                    #endregion

                                    //Player points pr. set is printed

                                    #region

                                    if (player01Point == 6 || player02Point == 6)
                                    {
                                        Console.WriteLine("The sets of the game was: " + player01Point + " - " +
                                                          player02Point +
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
                                Console.WriteLine(
                                    "There has been a sets of: " + matchOfSetsCounter +
                                    " Player 1: {0} has won the game!\r\n", tournamentFemalePlayers[p1].FirstName);
                                matchOfSetsCounter = 0;
                                //Console.ReadLine();
                                femaleWinners.Add(tournamentFemalePlayers[p1]);
                                femaleLosers.Add(tournamentFemalePlayers[femalep2].Identifikation);
                                break;
                            }
                            else if (setWinCount02 == 2)
                            {
                                Console.WriteLine(
                                    "There has been a sets of: " + matchOfSetsCounter +
                                    " Player 2: {0} has won the game!\r\n",
                                    tournamentFemalePlayers[femalep2].FirstName);
                                matchOfSetsCounter = 0;
                                //Console.ReadLine();
                                femaleWinners.Add(tournamentFemalePlayers[femalep2]);
                                femaleLosers.Add(tournamentFemalePlayers[p1].Identifikation);
                                break;
                            }

                            #endregion
                        }

                        #endregion

                        femalep2 += 2;
                    }

                    //Prints winners and remove losers from list
                    #region

                    femaleRound++;
                    int m = 1;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Winners of Round: {0}", femaleRound);
                    for (int i = 0; i < femaleWinners.Count; i++)
                    {
                        Console.WriteLine("Winner of Game {0} was the players: {1}", m, femaleWinners[i].FirstName);
                        m++;
                    }

                    m = 1;
                    Console.ResetColor();
                    for (int i = 0; i < tournamentFemalePlayers.Count; i++)
                    {
                        for (int k = 0; k < femaleLosers.Count; k++)
                        {
                            for (int o = 0; o < femaleWinners.Count; o++)
                            {
                                if (tournamentFemalePlayers[i].Identifikation == femaleLosers[k] ||
                                    femaleWinners[o].Identifikation == femaleLosers[k])
                                {
                                    tournamentFemalePlayers.RemoveAt(i);
                                    femaleWinners.RemoveAt(o);
                                }
                            }
                        }
                    }

                    femalep2 = 1;

                    #endregion

                    if (tournamentFemalePlayers.Count == 1)
                    {
                        Console.WriteLine("Tournament for female players is done" + Environment.NewLine);
                        break;
                    }
                }

                #endregion
            }
            catch (SystemException)
            {
                Console.WriteLine("Something went wrong");
            }
        }

        public static void MainMatch()
        {
            var match = new TennisMatch();
            Console.WriteLine(match);
        }
    }
}
