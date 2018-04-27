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

        List<TennisPlayer> _listOfMalePlayerObjects = new List<TennisPlayer>();

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

                var malePlayer = new TennisPlayer(id, fname, mname, lname, dob, na, sex);
                _listOfMalePlayerObjects.Add(malePlayer);
            }
            par.Close();
        }

        public override string ToString()
        {
            var rv = "";
            //Shows how the variable (string) "line" in "_listOfMalePlayerObjects" list should be printed
            #region
            foreach (var line in _listOfMalePlayerObjects)
            {
                rv += line + Environment.NewLine;
            }
            return rv;
            #endregion
        }

        public static void ReadFile()
        {
            var malePlayers = new FileHandler(@"C:\Users\Christian(Atlik)\Desktop\Miniprojekt-christian2\tennis_data\MalePlayer.txt");
            malePlayers.LoadMalePlayer();
            Console.WriteLine(malePlayers);
        }
    }
}
