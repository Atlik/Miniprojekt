using System;
using System.Collections.Generic;


namespace MiniProjekt
{
    /// <summary>
    /// Vi har i dette projekt fokuseret på at samle generering af kampe i klassen “TennisMatch”.
    /// Dette har gjort at constructoren af “TennisMatch” samler og instantiere de øvrige klasser og metoder.
    /// Udover klassen “TennisMatch” er der lavet 4 andre klasser ved navn: “FileHandler”, “TennisPlayer”, “Tournament” og “Program”.
    /// Klassen “Program” er kun lavet for at have en separat fil hvori det er muligt at kalde metoder,
    /// objekter eller lignende vi gerne vil have kørt/udskrevet i konsollen uden at ændre på koden i de øvrige metoder.
    /// Programmet starter her i det vi her kalder et nyt objekt af “TennisMatch” der instantiere de brugte metoder.
    /// Klassen “FileHandler” loader og læser filerne der skal bruges i programmet,
    /// og indsætter dem i lister af objekter der bliver defineret af constructoren TennisPlayer i klassen “TennisPlayer”.
    /// Klassen “TennisPlayer” sørger for at informationerne omkring spillerne i turneringen er repræsenteret korrekt når de kaldes i andre metoder eller udskrives på konsollen.
    /// Klassen “Tournament” sørger for at det korrekte antal af spillere og dommere bliver sendt videre til “TennisMatch”, og dermed konstruere essentielle dele for at en turnering kan afholdes.
    /// </summary>

    ///<summary>
    ///The class tournament constructs the elements in which should be simulated in the tournament
    /// </summary>
    class Tournament
    {
        private static readonly Random Rnd = new Random();

        //Tournament properties
        #region
        private string TournamentName { get; }
        private DateTime TournamentStart { get; }
        private DateTime TournamentEnd { get; }
        #endregion

        //Runde Lister
        readonly List<TennisPlayer> _malePlayerForRoundList = new List<TennisPlayer>();
        readonly List<TennisPlayer> _referees = new List<TennisPlayer>();
        readonly List<TennisPlayer> _femalePlayerForRoundList = new List<TennisPlayer>();

        /// <summary>
        /// Constructor of Tournament
        /// </summary>
        /// <param name="tourDateStart"></param>
        /// <param name="tourDateEnd"></param>
        /// <param name="tourName"></param>
        public Tournament(DateTime tourDateStart, DateTime tourDateEnd, string tourName)
        {
            TournamentStart = tourDateStart;
            TournamentEnd = tourDateEnd;
            TournamentName = tourName;
        }

        /// <summary>
        /// Handles the lists returned from GetListFemaleReferee() and GetListMaleReferee() in <see cref="FileHandler"/>
        /// Combines the two lists of referees from <see cref="FileHandler"/> into the list "referees", after which it will ask the user, if it should use a referee from list as gamemaster or if he/she wants to be the GameMaster
        /// <exception cref="Exception"> Is thrown if the user types something wrong in the console  </exception>
        /// </summary>
        /// <returns> A list of referees minus the referee at index number [0] </returns>
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
                    _referees.Add(refFemale[i]);
                    for (int j = 0; j < refMale.Count; j++)
                    {
                        _referees.Add(refMale[j]);
                    }
                }

                Console.WriteLine("Do you want to be GameMaster for the Tournament?" + Environment.NewLine + "Please answer with yes or no");
                string gameMaster = Convert.ToString(Console.ReadLine());

                if (gameMaster == "yes")
                {
                    int check;
                    Console.WriteLine("Please enter your name");
                    string userGameMaster = Convert.ToString((Console.ReadLine()));

                    if (userGameMaster == "" || int.TryParse(userGameMaster, out check))
                    {
                        throw new Exception("Your name cannot be empty or only consist of integers");
                    }
                    else
                    {
                        Console.WriteLine("You are now GameMaster!" + Environment.NewLine);
                        Console.WriteLine("GameMaster of the tournament is: {0}", userGameMaster);
                    }
                }
                else if (gameMaster == "no")
                {
                    Console.WriteLine(Environment.NewLine + "Finding a Referee to be GameMaster" + Environment.NewLine);
                    Console.WriteLine("GameMaster of the tournament is: {0}", _referees[0]);
                }
                else
                {
                    throw new Exception("You have typed something wrong, please type yes or no to continue the Tournament");
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Environment.NewLine + "{0}" + Environment.NewLine, ex.Message);
                Console.ResetColor();

                TournamentHandlerRefs();
            }
            int amount = _referees.Count - 1;
            return _referees.GetRange(1, amount);
        }

        /// <summary>
        /// Handles the list returned from GetListMalePlayers() in <see cref="FileHandler"/>
        /// Inserts a random TennisPlayer object into the list malePlayerForRound with amount that the user defines in his/hers prompt
        /// <exception cref="System.FormatException">  </exception>
        /// </summary>
        /// <returns> _malePlayerForRoundList, which is a list of TennisPlayer objects used in <see cref="TennisMatch"/></returns>
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
                        int r = Rnd.Next(maleTennisPlayers.Count);

                        if (!_malePlayerForRoundList.Contains(maleTennisPlayers[r]))
                        {
                            _malePlayerForRoundList.Add(maleTennisPlayers[r]);
                            i++;
                        }
                    }
                }
                else
                {
                    throw new Exception("You didn't type one of the asked numbers, please type one of the valid numbers!");
                }
            }
            catch (System.FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Environment.NewLine + "You typed something wrong, please type one of the valid numbers!" + Environment.NewLine);
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
            return _malePlayerForRoundList;
        }

        /// <summary>
        /// Handles the list returned from GetListFemalePlayer() in <see cref="FileHandler"/>
        /// Based on how many Female players the user defines that they want to play at the tournament, it returns this amount of random players.
        /// <exception cref="System.FormatException"> </exception>
        /// </summary>
        /// <returns> femalePlayerForRoundList which is a list of TennisPlayer objects that will be used in the class <see cref="TennisMatch"/> </returns>
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
                        int r = Rnd.Next(femaleTennisPlayers.Count);

                        if (!_femalePlayerForRoundList.Contains(femaleTennisPlayers[r]))
                        {
                            _femalePlayerForRoundList.Add(femaleTennisPlayers[r]);
                            i++;
                        }
                    }
                }
                else
                {
                    throw new Exception("You didn't type one of the asked numbers, please type one of the valid numbers!");
                }
            }
            catch (System.FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Environment.NewLine + "You typed something wrong, please type one of the valid numbers!" + Environment.NewLine);
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
            return _femalePlayerForRoundList;
        }

        /// <summary>
        /// ToString method
        /// </summary>
        /// <returns>Returns a string in which the object Tournament should be represented</returns>
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