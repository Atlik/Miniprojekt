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
    /// <summary>
    /// The class TennisMatch handles and simulate each match in the tournament
    /// </summary>
    class TennisMatch
    {

        static Random rnd = new Random();

        /// <summary>
        /// Default constructor of TennisMatch
        /// </summary>
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
                List<TennisPlayer> tournamentMalePlayers = listOfPersonsForRound.TournamentHandlerMaleGame();
                #endregion

                //Prints the tournaments Datatime and name out
                Console.WriteLine(listOfPersonsForRound);

                //Sort the tournamentMalePlayers by firstname or lastname before the tournament starts
                #region
                List<TennisPlayer> SortedMalePlayerByFirstname = tournamentMalePlayers.OrderBy(tennisPlayer => tennisPlayer.FirstName).ToList();
                List<TennisPlayer> SortedMalePlayerByLastname = tournamentMalePlayers.OrderBy(tennisPlayer => tennisPlayer.LastName).ToList();

                Console.WriteLine("Before continue the tournament will you see the player list sort by their first- or lastname or will you continue?" +
                    Environment.NewLine + "Type 'f' for firstname 'l' for last name or type any other keys for continue");
                var input = Console.ReadKey();
                switch (input.Key)
                {
                    case ConsoleKey.F:
                        {
                            Console.WriteLine(Environment.NewLine);
                            for (int i = 0; i < SortedMalePlayerByFirstname.Count; i++)
                            {
                                Console.WriteLine(SortedMalePlayerByFirstname[i].FirstName + " " + SortedMalePlayerByFirstname[i].MiddleName + " " +
                                                  SortedMalePlayerByFirstname[i].LastName);
                            }

                            break;
                        }
                    case ConsoleKey.L:
                        {
                            Console.WriteLine(Environment.NewLine);
                            for (int i = 0; i < SortedMalePlayerByLastname.Count; i++)
                            {
                                Console.WriteLine(SortedMalePlayerByLastname[i].FirstName + " " + SortedMalePlayerByLastname[i].MiddleName + " " +
                                                  SortedMalePlayerByLastname[i].LastName);
                            }
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                #endregion

                //Simulate Tournament for Males

                #region

                Console.WriteLine(Environment.NewLine + "Tournament for male players will begin. Press ANY key to continue" + Environment.NewLine);
                Console.ReadKey();

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
                        Console.WriteLine(
                            "A single male game has been set between the player 1: {0} and player 2: {1} \r\n" +
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

                                    var point = rnd.Next(0, 2);
                                    if (point == 0)
                                    {
                                        ++player01Point;
                                        if (player01Point == 6)
                                        {
                                            setWin01 = "Player 1: " + tournamentMalePlayers[p1].FirstName + " " + tournamentMalePlayers[p1].MiddleName + " " + tournamentMalePlayers[p1].LastName + " wins the game ";
                                            setWin02 = null;
                                            setWinCount01++;
                                        }
                                    }
                                    else if (point == 1)
                                    {
                                        ++player02Point;
                                        if (player02Point == 6)
                                        {
                                            setWin01 = null;
                                            setWin02 = "Player 2: " + tournamentMalePlayers[p2].FirstName + " " + tournamentMalePlayers[p2].MiddleName + " " + tournamentMalePlayers[p2].LastName + " wins the game ";
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
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine(
                                    "There has been a sets of: " + matchOfSetsCounter +
                                    " Player 1: {0} has won the game!\r\n", tournamentMalePlayers[p1].FirstName);
                                Console.ResetColor();
                                matchOfSetsCounter = 0;
                                winners.Add(tournamentMalePlayers[p1]);
                                losers.Add(tournamentMalePlayers[p2].Identification);
                                break;
                            }
                            else if (setWinCount02 == 3)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine(
                                    "There has been a sets of: " + matchOfSetsCounter +
                                    " Player 2: {0} has won the game!\r\n", tournamentMalePlayers[p2].FirstName);
                                Console.ResetColor();
                                matchOfSetsCounter = 0;
                                winners.Add(tournamentMalePlayers[p2]);
                                losers.Add(tournamentMalePlayers[p1].Identification);
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
                    Console.ResetColor();
                    for (int i = 0; i < winners.Count; i++)
                    {
                        Console.WriteLine("Winner of game {0} was the players: {1}", m, winners[i].FirstName + " " + winners[i].MiddleName + " " + winners[i].LastName);
                        m++;
                    }
                    m = 1;

                    for (int i = 0; i < tournamentMalePlayers.Count; i++)
                    {
                        for (int k = 0; k < losers.Count; k++)
                        {
                            for (int o = 0; o < winners.Count; o++)
                            {
                                if (tournamentMalePlayers[i].Identification == losers[k] ||
                                    winners[o].Identification == losers[k])
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
                        Console.WriteLine(Environment.NewLine + "Tournament for Male player is done" + Environment.NewLine);
                        break;
                    }
                    Console.WriteLine("\r\nRound {0} has been played, press ANY key to continue the tournament", round);
                    Console.ReadKey();
                }

                #endregion

                Console.WriteLine("The female tournament will now start press ANY key continue");
                Console.ReadKey();
                Console.WriteLine();

                List<TennisPlayer> tournamentFemalePlayers = listOfPersonsForRound.TournamentHandlerFemaleGame();

                //Sort the tournamentFemalePlayers by firstname or lastname before the tournament starts
                #region
                List<TennisPlayer> SortedFemalePlayerByFirstname = tournamentFemalePlayers.OrderBy(tennisPlayer => tennisPlayer.FirstName).ToList();
                List<TennisPlayer> SortedFemalePlayerByLastname = tournamentFemalePlayers.OrderBy(tennisPlayer => tennisPlayer.LastName).ToList();

                Console.WriteLine("Before continue the tournament will you see the player list sort by their first- or lastname or will you continue?" +
                    Environment.NewLine + "Type 'f' for firstname 'l' for last name or type any other keys for continue");
                var inputFemale = Console.ReadKey();
                switch (inputFemale.Key)
                {
                    case ConsoleKey.F:
                        {
                            Console.WriteLine(Environment.NewLine);
                            for (int i = 0; i < SortedFemalePlayerByFirstname.Count; i++)
                            {
                                Console.WriteLine(SortedFemalePlayerByFirstname[i].FirstName + " " + SortedFemalePlayerByFirstname[i].MiddleName + " " +
                                                  SortedFemalePlayerByFirstname[i].LastName);
                            }

                            break;
                        }
                    case ConsoleKey.L:
                        {
                            Console.WriteLine(Environment.NewLine);
                            for (int i = 0; i < SortedFemalePlayerByLastname.Count; i++)
                            {
                                Console.WriteLine(SortedFemalePlayerByLastname[i].FirstName + " " + SortedFemalePlayerByLastname[i].MiddleName + " " +
                                                  SortedFemalePlayerByLastname[i].LastName);
                            }
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                #endregion

                //Simulate Tournament for females

                #region

                Console.WriteLine(Environment.NewLine + "Tournament for female players will begin. Press ANY key to continue" + Environment.NewLine);
                Console.ReadKey();

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
                        Console.WriteLine(
                            "A single female game has been set for player 1: {0} and player 2: {1} \r\n" +
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
                                        if (player01Point == 6)
                                        {
                                            setWin01 = "Player 1: " + tournamentFemalePlayers[p1].FirstName +
                                                tournamentFemalePlayers[p1].MiddleName +
                                                tournamentFemalePlayers[p1].LastName +
                                                " wins the game ";
                                            setWin02 = null;
                                            setWinCount01++;
                                        }
                                    }
                                    else if (dice == 1)
                                    {
                                        ++player02Point;
                                        if (player02Point == 6)
                                        {
                                            setWin01 = null;
                                            setWin02 = "Player 2: " + tournamentFemalePlayers[p2].FirstName +
                                                tournamentFemalePlayers[p2].MiddleName +
                                                tournamentFemalePlayers[p2].LastName +
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
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine(
                                    "There has been a sets of: " + matchOfSetsCounter +
                                    " Player 1: {0} has won the game!\r\n", tournamentFemalePlayers[p1].FirstName);
                                Console.ResetColor();
                                matchOfSetsCounter = 0;
                                femaleWinners.Add(tournamentFemalePlayers[p1]);
                                femaleLosers.Add(tournamentFemalePlayers[femalep2].Identification);
                                break;
                            }
                            else if (setWinCount02 == 2)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine(
                                    "There has been a sets of: " + matchOfSetsCounter +
                                    " Player 2: {0} has won the game!\r\n",
                                    tournamentFemalePlayers[femalep2].FirstName);
                                Console.ResetColor();
                                matchOfSetsCounter = 0;
                                femaleWinners.Add(tournamentFemalePlayers[femalep2]);
                                femaleLosers.Add(tournamentFemalePlayers[p1].Identification);
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
                    Console.ResetColor();
                    for (int i = 0; i < femaleWinners.Count; i++)
                    {
                        Console.WriteLine("Winner of game {0} was the players: {1}", m, femaleWinners[i].FirstName);
                        m++;
                    }
                    m = 1;

                    for (int i = 0; i < tournamentFemalePlayers.Count; i++)
                    {
                        for (int k = 0; k < femaleLosers.Count; k++)
                        {
                            for (int o = 0; o < femaleWinners.Count; o++)
                            {
                                if (tournamentFemalePlayers[i].Identification == femaleLosers[k] ||
                                    femaleWinners[o].Identification == femaleLosers[k])
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
                    Console.WriteLine("Round {0} has been played, press ANY key to continue the tournament", femaleRound);
                    Console.ReadKey();
                }

                #endregion
            }
            catch (SystemException)
            {
                Console.WriteLine("Something went wrong");
            }
        }
    }
}
