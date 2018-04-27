using System;

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

        public TennisMatch()
        {
            //Assigns new player objects and print their information
            #region
            var player01 = new TennisPlayer(997, "Christian", "Gundersen", "Holmgaard", new DateTime(1996, 05, 09), "Denmark", true);
            var player02 = new TennisPlayer(998, "Ferdinand", "", "Brødløs", new DateTime(1995, 07, 19), "Denmark", true);
            var player03 = new TennisPlayer(999, "Mia", "Bødker", "Nissen", new DateTime(1991, 11, 11), "Denmark", false);
            Console.WriteLine(player01 + Environment.NewLine + player02 + Environment.NewLine + player03);
            #endregion

            //Checks if player is Male or Female, if Male it will run a match with best of 5 sets, else a match with best of 3 sets
            #region
            if (player01.Gender == true)
            {
                Console.WriteLine("test test, vi har med et hankøn gøre! Simulerer 5 set...");
            }
            else
            {
                Console.WriteLine("pas på! der er et hunkøn tilstede! Simulerer 3 set...");
            }

            if (player01.Gender == true && player02.Gender == true)
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
            else if (player01.Gender == false && player02.Gender == false)
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
                    Console.WriteLine("Player 1 has won the game!");
                }
                else if (setWinCount02 == 3)
                {
                    Console.WriteLine("Player 2 has won the game!");
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
                    Console.WriteLine("Player 1 has won the game!");
                }
                else if (setWinCount02 == 2)
                {
                    Console.WriteLine("Player 2 has won the game!");
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
