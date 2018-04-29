using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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

        //FileHandler objekter/instantieringer
        #region
        FileHandler listOfMalePlayer = new FileHandler(@"C:\Users\Christian(Atlik)\Desktop\Miniprojekt\MiniProjekt\tennis_data\MalePlayer.txt");
        FileHandler listOfMaleReferee = new FileHandler(@"C:\Users\Christian(Atlik)\Desktop\Miniprojekt\MiniProjekt\tennis_data\MaleRefs.txt");
        FileHandler listOfFemalePlayer = new FileHandler(@"C:\Users\Christian(Atlik)\Desktop\Miniprojekt\MiniProjekt\tennis_data\FemalePlayer.txt");
        FileHandler listOfFemaleReferee = new FileHandler(@"C:\Users\Christian(Atlik)\Desktop\Miniprojekt\MiniProjekt\tennis_data\FermaleRefs.txt");
        #endregion

        public TennisMatch()
        {
            //Prints lists of objects from FileHandler(tekstfiler)
            #region
            List<TennisPlayer> maleTennisPlayers = listOfMalePlayer.GetListMalePlayers();

            for (int i = 0; i < maleTennisPlayers.Count; i++)
            {
               // Console.WriteLine(maleTennisPlayers[i]);
            }

            List<TennisPlayer> maleReferees = listOfMaleReferee.GetListMaleReferee();

            for (int i = 0; i < maleReferees.Count; i++)
            {
               // Console.WriteLine(maleReferees[i]);
            }

            List<TennisPlayer> femaleTennisPlayers = listOfFemalePlayer.GetListFemalePlayers();

            for (int i = 0; i < femaleTennisPlayers.Count; i++)
            {
              // Console.WriteLine(femaleTennisPlayers[i]);
            }

            List<TennisPlayer> femaleReferee = listOfFemaleReferee.GetListFemaleReferee();

            for (int i = 0; i < femaleReferee.Count; i++)
            {
               // Console.WriteLine(femaleReferee[i]);
            }
            #endregion

            //Assigns new player objects and print their information
            #region

            var player01 = new TennisPlayer(997, "Christian", "Gundersen", "Holmgaard", new DateTime(1996, 05, 09), "Denmark", true, false);
            var player02 = new TennisPlayer(998, "Ferdinand", "", "Brødløs", new DateTime(1995, 07, 19), "Denmark", true, false);
            var player03 = new TennisPlayer(999, "Mia", "Bødker", "Nissen", new DateTime(1991, 11, 11), "Denmark", false, false);
            var player04 = new TennisPlayer(1000, "Tina", "Hammer", "Sørensen", new DateTime(1996, 03, 23), "Denmark", false, false);

            var referee01 = new TennisPlayer(996, "Kristian", "", "Torp", new DateTime(1983, 11, 11), "Denmark", true, true, new DateTime(2006, 08, 20), new DateTime(2018, 04, 27));
          //  Console.WriteLine(player01 + Environment.NewLine + player02 + Environment.NewLine + player03 + Environment.NewLine + referee01);
            #endregion

            //Checks if player is Male or Female, if Male it will run a match with best of 5 sets, else a match with best of 3 sets
            #region
            Console.ForegroundColor = ConsoleColor.Green;
            
            if (player01.Gender == true)
            {
                Console.WriteLine("test test, vi har med et hankøn gøre! Simulerer 5 set...");
            }
            else
            {
                Console.WriteLine("pas på! der er et hunkøn tilstede! Simulerer 3 set...");
            }
            Console.ResetColor();

            if (player01.Gender == true && player02.Gender == true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("A single male game has been set for player 01: {0} and player 2: {1}" + Environment.NewLine + Environment.NewLine + "The game will be controlled by the referee: {2} " + Environment.NewLine, player01.FirstName, player02.FirstName, referee01.FirstName);
                Console.ResetColor();

                RandSetsTournament.MaleMatch();
            }
            else if (player01.Gender == false && player02.Gender == false)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("A single female game has been set for player 01: {0} and player 2: {1}" + Environment.NewLine + Environment.NewLine + "The game will be controlled by the referee: {2} " + Environment.NewLine, player03.FirstName, player04.FirstName, referee01.FirstName);
                Console.ResetColor();

                RandSetsTournament.FemaleMatch();
            }
            else
            {
                Console.WriteLine("There is no match");
            }
            #endregion

        }

        public class RandSetsTournament
        {
            //Simulate matches between Males and Females
            #region
            static Random rand = new Random();

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
                        var dice = rand.Next(0, 2);
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
                    Console.WriteLine("There has been played {0} sets and Player 1 has won the game", matchOfSetsCounter);
                    matchOfSetsCounter = 0;

                }
                else if (setWinCount02 == 3)
                {
                    Console.WriteLine("There has been played {0} sets and Player 2 has won the game", matchOfSetsCounter);
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
                        var dice = rand.Next(0, 2);
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
                    Console.WriteLine("There has been a sets of: " + matchOfSetsCounter + " Player 1 has won the game!");
                    matchOfSetsCounter = 0;

                }
                else if (setWinCount02 == 2)
                {
                    Console.WriteLine("There has been a sets of: " + matchOfSetsCounter + " Player 2 has won the game!");
                    matchOfSetsCounter = 0;
                }
                #endregion
            }
            #endregion
        }

        public static void MainMatch()
        {
            var matchNo = new TennisMatch();
            Console.WriteLine(matchNo);
        }
    }
}
