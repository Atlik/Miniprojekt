using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;

namespace MiniProjekt
{
    /// <summary cref="List{T}">
    /// Filehandler handles all loading and reading of files
    /// When reading the files, it will insert each line from the textfiles in their respective objects
    /// </summary>
    class FileHandler
    {
        //FileHandler properties
        /// <summary>
        /// FileHandler property: Handles the use of the string FileName that indcates which file the Filehandler should search for.
        /// </summary>
        private string FileName { get; }
        /// <summary>
        /// FileHandler property: Is used to indicate what separates important information from the textfiles from eachother
        /// </summary>
        private string Delimiter { get; }

        //Instantiate new lists of Tennisplayer objects
        #region
        private readonly List<string> _content = new List<string>();
        readonly List<TennisPlayer> _listOfMalePlayers = new List<TennisPlayer>();
        readonly List<TennisPlayer> _listOfFemalePlayers = new List<TennisPlayer>();
        readonly List<TennisPlayer> _listOfMaleReferee = new List<TennisPlayer>();
        readonly List<TennisPlayer> _listOfFemaleReferee = new List<TennisPlayer>();
        #endregion

        /// <summary>
        /// Reads the textfile with male players.
        /// Each line from the textfile indicate a new object instance of TennisPlayer
        /// </summary>
        /// <returns>The return value _listOfMalePlayers is used in <see cref="Tournament"/> to compile and handle the objects which should be used in <see cref="TennisMatch"/></returns>
        public List<TennisPlayer> GetListMalePlayers()
        {
            #region
            TextFieldParser par = new TextFieldParser(FileName);
            par.TextFieldType = FieldType.Delimited;
            par.SetDelimiters(Delimiter);

            while (!par.EndOfData)
            {
                string[] fields = par.ReadFields();
                int id = Int32.Parse(fields[0]);
                string fname = fields[1];
                string mname = fields[2];
                string lname = fields[3];
                DateTime dob = DateTime.Parse(fields[4]);
                string na = fields[5];
                bool sex = true;
                bool PoR = false;

                var malePlayer = new TennisPlayer(id, fname, mname, lname, dob, na, sex, PoR);
                _listOfMalePlayers.Add(malePlayer);
            }
            return _listOfMalePlayers;
            #endregion
        }

        /// <summary>
        /// Reads the textfile with FemalePlayers.
        /// Each line from the textfile indicate a new object instance of TennisPlayer
        /// </summary>
        /// <returns>The return value _listOfFemalePlayers is used in <see cref="Tournament"/> to compile and handle the objects which should be used in <see cref="TennisMatch"/></returns>
        public List<TennisPlayer> GetListFemalePlayers()
        {
            #region
            TextFieldParser par = new TextFieldParser(FileName);
            par.TextFieldType = FieldType.Delimited;
            par.SetDelimiters(Delimiter);

            while (!par.EndOfData)
            {
                string[] fields = par.ReadFields();
                int id = Int32.Parse(fields[0]);
                string fname = fields[1];
                string mname = fields[2];
                string lname = fields[3];
                DateTime dob = DateTime.Parse(fields[4]);
                string na = fields[5];
                bool sex = false;
                bool PoR = false;

                var femalePlayer = new TennisPlayer(id, fname, mname, lname, dob, na, sex, PoR);
                _listOfFemalePlayers.Add(femalePlayer);
            }
            par.Close();
            return _listOfFemalePlayers;
            #endregion
        }

        /// <summary>
        /// Reads the textfile with Male Referees
        /// Each Line from the textfile indicate a new object instance of Tennisplayer
        /// </summary>
        /// <returns>The return value _listOfMaleReferee is used in <see cref="Tournament"/> to compile and handle the objects which should be used in <see cref="TennisMatch"/></returns>
        public List<TennisPlayer> GetListMaleReferee()
        {
            #region
            TextFieldParser par = new TextFieldParser(FileName);
            par.TextFieldType = FieldType.Delimited;
            par.SetDelimiters(Delimiter);

            while (!par.EndOfData)
            {
                string[] fields = par.ReadFields();
                int id = Int32.Parse(fields[0]);
                string fname = fields[1];
                string mname = fields[2];
                string lname = fields[3];
                DateTime dob = DateTime.Parse(fields[4]);
                string na = fields[5];
                bool sex = true;
                bool PoR = true;
                DateTime LGdate = DateTime.Parse(fields[7]);
                DateTime LRdate = DateTime.Parse(fields[8]);


                var maleReferee = new TennisPlayer(id, fname, mname, lname, dob, na, sex, PoR, LGdate, LRdate);
                _listOfMaleReferee.Add(maleReferee);
            }
            par.Close();
            return _listOfMaleReferee;
            #endregion
        }

        /// <summary>
        /// Reads the textfile with Female Referees
        /// Each line from the textfile indicate a new object instnce of TennisPlayer
        /// </summary>
        /// <returns>The return value _listOfFemaleReferee is used in <see cref="Tournament"/> to compile and handle the objects which should be used in <see cref="TennisMatch"/></returns>
        public List<TennisPlayer> GetListFemaleReferee()
        {
            #region
            TextFieldParser par = new TextFieldParser(FileName);
            par.TextFieldType = FieldType.Delimited;
            par.SetDelimiters(Delimiter);

            while (!par.EndOfData)
            {
                string[] fields = par.ReadFields();
                int id = Int32.Parse(fields[0]);
                string fname = fields[1];
                string mname = fields[2];
                string lname = fields[3];
                DateTime dob = DateTime.Parse(fields[4]);
                string na = fields[5];
                bool sex = false;
                bool PoR = true;
                DateTime LGdate = DateTime.Parse(fields[7]);
                DateTime LRdate = DateTime.Parse(fields[8]);


                var femaleReferee = new TennisPlayer(id, fname, mname, lname, dob, na, sex, PoR, LGdate, LRdate);
                _listOfFemaleReferee.Add(femaleReferee);
            }
            par.Close();
            return _listOfFemaleReferee;
            #endregion
        }

        /// <summary>
        /// Constructor of FileHandler: Indicate what FileHandler will need in order to be instantiated
        /// </summary>
        /// <param name="fn"></param>
        /// <param name="delim"></param>
        public FileHandler(string fn, string delim = "|")
        {
            FileName = fn;
            Delimiter = delim;
        }

        //Test cases for the file 
#region
        /* public int Load()
         {
             //Read and add text from file to the string List _content 
             //og forsøg på hvordan exceptions bliver lavet
             #region
             StreamReader file = null;
             int noLines = 0;

             try
             {
                 string line;
                 file = new StreamReader(FileName);
                 while ((line = file.ReadLine()) != null)
                 {
                     _content.Add(line);
                     noLines++;
                 }
             }
             //Exceptions
             #region
             catch (System.IO.FileNotFoundException)
             {
                 var message = String.Format("File: {0} does not exist", FileName);
                 Console.WriteLine(message);
             }
             catch (System.IO.DirectoryNotFoundException)
             {
                 var message = String.Format("Dir: {0} does not exist, part of file or directory is not loaded",
                     FileName);
                 Console.WriteLine(message);
             }
             catch (System.IO.PathTooLongException)
             {
                 Console.WriteLine("Path to file name is too long");
             }
             catch (System.IO.FileLoadException)
             {
                 var message = String.Format("File: {0} can't be loaded", FileName);
                 Console.WriteLine(message);
             }
             catch (System.Exception)
             {
                 Console.WriteLine("There happened a general error");
             }
             #endregion
             finally
             {
                 if (file != null)
                 {
                     file.Close();
                 }
             }
             return noLines;
             #endregion
         }

         public override string ToString()
         {
             //Shows how the variable (string) "line" in "_content" list should be printed
             //Listen _content bliver lavet i metoden Load() bruges kun i det tilfælde at det er nødvendigt at printe indhold
             #region
             var rv = "";

             foreach (var line in _content)
             {
                 rv += line + Environment.NewLine;
             }

             foreach (var line in _listOfMalePlayers)
             {
                 rv += line + Environment.NewLine;
             }

             foreach (var line in _listOfMaleReferee)
             {
                 rv += line + Environment.NewLine;
             }

             foreach (var line in _listOfFemalePlayers)
             {
                 rv += line + Environment.NewLine;
             }
             foreach (var line in _listOfFemaleReferee)
             {
                 rv += line + Environment.NewLine;
             }

             return rv;
             #endregion
         }

         public static void ReadFile()
         {
             //Husk at ændre til korrekt kildesti!
             //Her kan indhold printes hvis nødvendigt
             #region 
             var loadContent = new FileHandler(@"C:\Users\Christian(Atlik)\Desktop\Miniprojekt\MiniProjekt\tennis_data\MalePlayer.txt");

             var malePlayers = new FileHandler(@"C:\Users\Christian(Atlik)\Desktop\Miniprojekt\MiniProjekt\tennis_data\MalePlayer.txt");
             //malePlayers.LoadMalePlayer();
             //Console.WriteLine(malePlayers);

             var femalePlayers = new FileHandler(@"C:\Users\Christian(Atlik)\Desktop\Miniprojekt\MiniProjekt\tennis_data\FemalePlayer.txt");
             //femalePlayers.LoadFemalePlayer();
             //Console.WriteLine(femalePlayers);

             var maleReferee = new FileHandler(@"C:\Users\Christian(Atlik)\Desktop\Miniprojekt\MiniProjekt\tennis_data\MaleRefs.txt");
             //maleReferee.LoadMaleReferee();
             //Console.WriteLine(maleReferee);

             var femaleReferee = new FileHandler(@"C:\Users\Christian(Atlik)\Desktop\Miniprojekt\MiniProjekt\tennis_data\FermaleRefs.txt");
             //femaleReferee.LoadFemaleReferee();
             //Console.WriteLine(femaleReferee);
             #endregion
         }*/
#endregion
    }
}