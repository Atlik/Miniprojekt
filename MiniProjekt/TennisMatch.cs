using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MiniProjekt
{
    class TennisMatch
    {
        //Tennis Match properties
        #region
        public string results { get; set; }
        public int menSingleSet { get; set; }
        public int womenSingleSet { get; set; }
        public string Match { get; set; }
        #endregion

        public TennisMatch()
        {
            //Assigns new player objects and print their information
            #region
            var Player01 = new TennisPlayer("Christian", "Gundersen", "Holmgaard", new DateTime(1996, 05, 09), "Denmark", true);
            var Player02 = new TennisPlayer("Ferdinand", "", "Brødløs", new DateTime(1995, 07, 19), "Denmark", true);
            var Player03 = new TennisPlayer("Mia", "Bødker", "Nissen", new DateTime(1991, 11, 11), "Denmark", false);
            Console.WriteLine(Player01 + Environment.NewLine + Player02 + Environment.NewLine + Player03);
            #endregion

            //checks if player is Male or Female, if Male it will run a match with best of 5 sets, else a match with best of 3 sets
            #region
            if (Player01.gender == true)
            {
                Console.WriteLine("test test, vi har med et hankøn gøre! Simulerer 5 set...");
            }
            else
            {
                Console.WriteLine("pas på! der er et hunkøn tilstede! Simulerer 3 set...");
            }

            if (Player01.gender == true && Player02.gender == true)
            {
                RandSetsTournament.MaleMatch();
                //skrald
                #region
                /*
                foreach (var sets in set)
                {
                    amountOfSets++;
                }

                if (amountOfSets <= 5 && amountOfSets > 3)
                {
                    setMen = "This is a mens single match";
                }*/
                #endregion
            }
            else if (Player01.gender == false && Player02.gender == false)
            {
                RandSetsTournament.FemaleMatch();
                //skrald
                #region
            /*    foreach (var sets in set)
                {
                    amountOfSets++;
                }

                if (amountOfSets <= 3)
                {
                    //setWomen = "This is a womens single match";
                }*/
                #endregion
            }
            else
            {
                Console.WriteLine("There is no match");
            }
            #endregion
        }

        public class RandSetsTournament
        {
            //Simulate matches between males and femlase
            #region
            static Random rand = new Random();

            public static void MaleMatch()
            {
                int player01Point = 0;
                int player02Point = 0;
                int SetWinCount01 = 0;
                int SetWinCount02 = 0;
                string SetWin01 = "";
                string SetWin02 = "";

                for (int i = 0; i < 5; i++)
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
                                SetWin01 = "Player 1 wins the game ";
                                SetWin02 = null;
                                SetWinCount01++;
                            }
                        }
                        else if (dice == 1)
                        {
                            ++player02Point;
                            //Tester hvordan point systemet gives
                            //Console.WriteLine("Player 2 gets a point: " + Player02);
                            if (player02Point == 6)
                            {
                                SetWin01 = null;
                                SetWin02 = "Player 2 wins the game ";
                                SetWinCount02++;
                            }
                        }
                        #endregion

                        //Player points pr. set is printed
                        #region
                        if (player01Point == 6 || player02Point == 6)
                        {
                            Console.WriteLine("The sets of the game was: " + player01Point + " - " + player02Point +
                                                " " + SetWin01 + SetWin02 + Environment.NewLine);
                            player01Point = 0;
                            player02Point = 0;
                        }
                        #endregion

                        //Checks the amount of sets each player has won
                        #region
                        if (SetWinCount01 == 3 || SetWinCount02 == 3)
                        {
                            break;
                        }
                        #endregion
                    }
                }
            }

            public static void FemaleMatch()
            {
                int player01Point = 0;
                int player02Point = 0;
                int SetWinCount01 = 0;
                int SetWinCount02 = 0;
                string SetWin01 = "";
                string SetWin02 = "";

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
                                SetWin01 = "Player 1 wins the game ";
                                SetWin02 = null;
                                SetWinCount01++;
                            }
                        }
                        else if (dice == 1)
                        {
                            ++player02Point;
                            //Tester hvordan point systemet gives
                            //Console.WriteLine("Player 2 gets a point: " + Player02);
                            if (player02Point == 6)
                            {
                                SetWin01 = null;
                                SetWin02 = "Player 2 wins the game ";
                                SetWinCount02++;
                            }
                        }
                        #endregion

                        //Player points pr. set is printed
                        #region
                        if (player01Point == 6 || player02Point == 6)
                        {
                            Console.WriteLine("The sets of the game was: " + player01Point + " - " + player02Point +
                                                " " + SetWin01 + SetWin02 + Environment.NewLine);
                            player01Point = 0;
                            player02Point = 0;
                        }
                        #endregion

                        //Checks the amount of sets each player has won
                        #region
                        if (SetWinCount01 == 2 || SetWinCount02 == 2)
                        {
                            break;
                        }
                        #endregion
                    }
                }
            }
            #endregion
        }

        public static void mainMatch()
        {
            var matchNo = new TennisMatch();
            Console.WriteLine(matchNo);
        }
    }
}
