using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace MiniProjekt
{
    class FileHandler
    {
        //FileHandler properties
        private readonly List<string> _content = new List<string>();
        public string FileName { get; set; }
        public string Delimiter { get; set; }

        List<TennisPlayer> _listOfPersonsObjects = new List<TennisPlayer>();

        public FileHandler(string fn, string delim = "|")
        {
            FileName = fn;
            Delimiter = delim;
        }

        public int Load()
        {
            StreamReader file = null;
            int noLines = 0;

            //Read and add text from file to a string List
            #region
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
                _listOfPersonsObjects.Add(malePlayer);
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

                var FemalePlayer = new TennisPlayer(id, fname, mname, lname, dob, na, sex, PoR);
                _listOfPersonsObjects.Add(FemalePlayer);
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
                _listOfPersonsObjects.Add(maleReferee);
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


                var FemaleReferee = new TennisPlayer(id, fname, mname, lname, dob, na, sex, PoR, LGdate, LRdate);
                _listOfPersonsObjects.Add(FemaleReferee);
            }
            par.Close();
        }

        public override string ToString()
        {
            var rv = "";
            //Shows how the variable (string) "line" in "_listOfMalePlayerObjects" list should be printed
            #region
            foreach (var line in _listOfPersonsObjects)
            {
                rv += line + Environment.NewLine;
            }
            return rv;
            #endregion
        }

        public static void ReadFile()
        {
            var malePlayers = new FileHandler(@"C:\Users\ferdi\Desktop\tennis_data\MalePlayer.txt");
            //malePlayers.LoadMalePlayer();
            //Console.WriteLine(malePlayers);

            var FemalePlayers = new FileHandler(@"C:\Users\ferdi\Desktop\tennis_data\FemalePlayer.txt");
            //FemalePlayers.LoadFemalePlayer();
            //Console.WriteLine(FemalePlayers);

            var maleReferee = new FileHandler(@"C:\Users\ferdi\Desktop\tennis_data\MaleRefs.txt");
            //maleReferee.LoadMaleReferee();
            //Console.WriteLine(maleReferee);

            var FemaleReferee = new FileHandler(@"C:\Users\ferdi\Desktop\tennis_data\FemaleRefs.txt");
            //FemaleReferee.LoadFemaleReferee();
            //Console.WriteLine(FemaleReferee);
        }
    }
}
