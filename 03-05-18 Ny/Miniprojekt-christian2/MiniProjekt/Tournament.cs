using System;
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
        List<TennisPlayer> referees = new List<TennisPlayer>();
        List<TennisPlayer> malePlayerForRoundList = new List<TennisPlayer>();
        List<TennisPlayer> femalePlayerForRoundList = new List<TennisPlayer>();

        //Constructor of Tournament
        public Tournament(DateTime tourDateStart, DateTime tourDateEnd, string tourName)
        {
            TournamentStart = tourDateStart;
            TournamentEnd = tourDateEnd;
            TournamentName = tourName;
        }

        //Christian-senpai use this<3
        public List<TennisPlayer> TournamentHandlerRefs()
        {
            string FileName01 = "tennis_data";
            string FileName = "MaleRefs";
            string FileName02 = "FermaleRefs";
            FileHandler listOfFemaleReferee = new FileHandler(@"" + Environment.CurrentDirectory + "\\" + FileName01 + "\\" + FileName02 + ".txt");
            FileHandler listOfMaleReferee = new FileHandler(@"" + Environment.CurrentDirectory + "\\" + FileName01 + "\\" + FileName + ".txt");

            List<TennisPlayer> refFemale = listOfFemaleReferee.GetListFemaleReferee();
            List<TennisPlayer> refMale = listOfMaleReferee.GetListMaleReferee();
            try
            {
                for (int i = 0; i < refFemale.Count; i++)
                {
                    referees.Add(refFemale[i]);
                    for (int j = 0; j < refMale.Count; j++)
                    {
                        referees.Add(refMale[j]);
                    }
                }


                Console.WriteLine("Do you want to be GameMaster for the Tournament?" + Environment.NewLine + "Please answer with yes or no");
                string gameMaster = Convert.ToString(Console.ReadLine());


                if (gameMaster == "yes")
                {
                    int check;
                    Console.WriteLine("Please enter your name");
                    string userGameMaster = Convert.ToString((Console.ReadLine()));

                    // int.TryParse code has been borrow from the website: https://stackoverflow.com/questions/1752499/c-sharp-testing-to-see-if-a-string-is-an-integer?utm_medium=organic&utm_source=google_rich_qa&utm_campaign=google_rich_qa
                    if (userGameMaster == "" || int.TryParse(userGameMaster, out check))
                    {
                        throw new Exception("Your name cannot either be empty or a integer");
                    }
                    else
                    {
                        Console.WriteLine("You are now GameMaster!");
                        Console.WriteLine("GameMaster of the tournament is: {0}", userGameMaster);
                    }
                }
                else if (gameMaster == "no")
                {
                    Console.WriteLine(Environment.NewLine + "Finding a Referee to be GameMaster");
                    Console.WriteLine("GameMaster of the tournament is: {0}", referees[0]);
                }
                else
                {
                    throw new Exception("You have typed something wrong, please type yes or no for continue the Tournament");
                }

            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Environment.NewLine + "{0}" + Environment.NewLine, ex.Message);
                Console.ResetColor();

                TournamentHandlerRefs();
            }
            int amount = referees.Count - 1;
            return referees.GetRange(1, amount);
        }

        public List<TennisPlayer> TournamentHandlerMaleGame()
        {
            string FileName = "MalePlayer";
            string FileName01 = "tennis_data";
            FileHandler listOfMalePlayer = new FileHandler(@"" + Environment.CurrentDirectory + "\\" + FileName01 + "\\" + FileName + ".txt");

            List<TennisPlayer> maleTennisPlayers = listOfMalePlayer.GetListMalePlayers();
            try
            {
                Console.WriteLine("What amount of male players do you want to play at the tournament?" +
                                    Environment.NewLine + "The amount of players that can be reseprented to the tournanemnt is: 2, 4, 8, 16, 32 or 64 Players");
                int upTo = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("You have typed the number {0} and the tournament will now be played" + Environment.NewLine, upTo);

                if (upTo == 2 || upTo == 4 || upTo == 8 || upTo == 16 || upTo == 32 || upTo == 64)
                {
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
                else
                {
                    throw new Exception("You didn't type one of the asked integer, please type one of the valid integer");
                }
            }
            catch (System.FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Environment.NewLine + "You typed something wrong, please type one of the valid integer" + Environment.NewLine);
                Console.ResetColor();

                TournamentHandlerMaleGame();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Environment.NewLine + "{0}" + Environment.NewLine, ex.Message);
                Console.ResetColor();

                TournamentHandlerMaleGame();
            }
            return malePlayerForRoundList;
        }

        public List<TennisPlayer> TournamentHandlerFemaleGame()
        {
            string FileName01 = "tennis_data";
            string FileName = "FemalePlayer";
            FileHandler listOfFemalePlayer = new FileHandler(@"" + Environment.CurrentDirectory + "\\" + FileName01 + "\\" + FileName + ".txt");

            List<TennisPlayer> femaleTennisPlayers = listOfFemalePlayer.GetListFemalePlayers();
            try
            {
                Console.WriteLine("What amount of female players do you want to play at the tournament?" +
                    Environment.NewLine + "The amount of players that can be reseprented to the tournanemnt is: 2, 4, 8, 16, 32 or 64 Players");
                int upTo = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("You have typed the number {0} and the tournament will now be played" + Environment.NewLine, upTo);


                if (upTo == 2 || upTo == 4 || upTo == 8 || upTo == 16 || upTo == 32 || upTo == 64)
                {
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
                else
                {
                    throw new Exception("You didn't type one of the asked integer, please type one of the valid integer");
                }
            }
            catch (System.FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Environment.NewLine + "You typed something wrong, please type one of the valid integer" + Environment.NewLine);
                Console.ResetColor();

                TournamentHandlerFemaleGame();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Environment.NewLine + "{0}" + Environment.NewLine, ex.Message);
                Console.ResetColor();

                TournamentHandlerFemaleGame();
            }
            return femalePlayerForRoundList;
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


/*
catch (System.Exception)
{
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine(Environment.NewLine + "You have typed something wrong, please type yes or no for continue the Tournament" + Environment.NewLine);
Console.ResetColor();

TournamentHandlerRefs();

while (true)
{
Environment.Exit(0);
}

}
*/
