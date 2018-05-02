using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;

namespace MiniProjekt
{
    class FileHandler
    {
        //FileHandler properties
        public string FileName { get; set; }
        public string Delimiter { get; set; }

        //Instantiate new lists of Tennisplayer objects
        #region
        private readonly List<string> _content = new List<string>();
        readonly List<TennisPlayer> _listOfMalePlayers = new List<TennisPlayer>();
        readonly List<TennisPlayer> _listOfFemalePlayers = new List<TennisPlayer>();
        readonly List<TennisPlayer> _listOfMaleReferee = new List<TennisPlayer>();
        readonly List<TennisPlayer> _listOfFemaleReferee = new List<TennisPlayer>();
        #endregion

        public List<TennisPlayer> GetListMalePlayers()
        {
            //Inserts text from textfile into correct object references for Male Players
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
        public List<TennisPlayer> GetListFemalePlayers()
        {
            //Inserts text from textfile into correct object references for Female Players
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
        public List<TennisPlayer> GetListMaleReferee()
        {
            //Inserts text from textfile into correct object references for Male Refs
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
        public List<TennisPlayer> GetListFemaleReferee()
        {
            //Inserts text from textfile into correct object references for Female Refs
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

        public FileHandler(string fn, string delim = "|")
        {
            FileName = fn;
            Delimiter = delim;
        }

        public int Load()
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
        }
    }
}

//skrald
#region

/*
public void LoadMalePlayer()
{
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
    par.Close();
}

public void LoadFemalePlayer()
{
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
}

public void LoadMaleReferee()
{
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
}

public void LoadFemaleReferee()
{
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
}*/
#endregion