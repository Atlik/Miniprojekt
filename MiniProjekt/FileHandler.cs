using System;
using System.Collections.Generic;
using System.IO;

namespace MiniProjekt
{
    class FileHandler
    {
        //FileHandler properties
        private readonly List<string> _content = new List<string>();
        public string FileName { get; set; }

        public FileHandler(string fn)
        {
            FileName = fn;
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

        public override string ToString()
        {
            string rv = "";
            //Shows how the variable (string) "line" in "_content" list should be printed
            #region
            foreach(var line in _content)
            {
                rv += line + "\n";
            }
            return rv;
            #endregion
        }

        public static void ReadFile()
        {
            var malePlayers = new FileHandler(@"C:\Users\Christian(Atlik)\Desktop\Miniprojekt-christian2\tennis_data\MalePlayer.txt");
            var no = malePlayers.Load();
            Console.WriteLine(malePlayers);
        }
    }
}
