using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjekt
{
    /* Dette projekt er lavet af Christian og Ferdinand
     * 
     * Beskrivelse af projektet...
     * 
     * Christian Gundersen Holmgaard,   studie nr. 20155309
     * Ferdinand Brødløs,               studie nr. 20167752
     */
    class Program 
    {
        static Random rand = new Random();

        static void Main(string[] args)
        {     
                var Player01 = 0;
                var Player02 = 0;
                string Player01win = "";
                string Player02win = "";

                for (var i = 0; i < 3; i++)
                {
                    while (true)
                    {
                        {
                            var dice = rand.Next(0, 2);
                            if (dice == 0)
                            {
                                ++Player01;
                                //Console.WriteLine("Player 1 gets a point: " + Player01);
                                if (Player01 == 6)
                                Player01win = "Player 1 wins the game ";
                                Player02win = "";
                            }
                            else if (dice == 1)
                            {
                                ++Player02;
                                //Console.WriteLine("Player 2 gets a point: " + Player02);
                                if (Player02 == 6)
                                Player01win = "";
                                Player02win = "Player 2 wins the game ";
                            }
                            if (Player01 == 6 || Player02 == 6)
                            {
                                Console.WriteLine("The sets of the game was: " + Player01 + " - " + Player02 + " " +  Player01win + Player02win + Environment.NewLine);
                                Player01 = 0;
                                Player02 = 0;
                                break;
                            }
                        }
                    }
                }
            

            Tournament.mainTournament();
            TennisMatch.mainMatch();
        }
    }
}
