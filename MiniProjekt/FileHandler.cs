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
        private List<string> content = new List<string>();
        public string FileName { get; set; }
   //     public string Delimiter { get; set; }

        public FileHandler(string fn)
        {
            FileName = fn;
         //   Delimiter = delim;
        }

        public int Load()
        {
            StreamReader file = null;
            int noLines = 0;
            string line;

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
        }

        public override string ToString()
        {
            string rv = "";
            foreach(var l in content)
            {
                rv += l + "\n";
            }
            return rv;
        }

        public static void ReadFile()
        {
            var MalePlayers = new FileHandler(@"C:\Users\Christian(Atlik)\Desktop\Miniprojekt-christian2\tennis_data\MalePlayer.txt");
            var no = MalePlayers.Load();
            Console.WriteLine(MalePlayers);
        }

        public void Read()
        {
           // FileIO.TextFieldParser par = new TextFieldParser(FileName);
        }
    }
}
