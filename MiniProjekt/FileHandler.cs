using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MiniProjekt
{
    class FileHandler
    {
        //FileHandler properties
        private List<string> content = new List<string>();
        public string FileName { get; set; }

        public FileHandler(string fn)
        {
            FileName = fn;
        }

        public int Load()
        {
            StreamReader file = null;
            int noLines = 0;
            string line;

            //Read and add text from file to a string List
            #region
            try
            {
                file = new StreamReader(FileName);
                while ((line = file.ReadLine()) != null)
                {
                    content.Add(line);
                    noLines++;
                }
            }
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

            //Shows how the variable (string) "line" in "content" list should be printed
            #region
            foreach(var line in content)
            {
                rv += line + "\n";
            }
            return rv;
            #endregion
        }

        public static void ReadFile()
        {
            var MalePlayers = new FileHandler(@"C:\Users\Christian(Atlik)\Desktop\Miniprojekt-christian2\tennis_data\MalePlayer.txt");
            var no = MalePlayers.Load();
            Console.WriteLine(MalePlayers);
        }
    }
}
