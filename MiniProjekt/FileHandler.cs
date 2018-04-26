using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.VisualBasic;

namespace MiniProjekt
{
    class FileHandler
    {
        public string FileName { get; set; }
        public string Delimiter { get; set; }

        public FileHandler(string fn, string delim)
        {
            FileName = fn;
            Delimiter = delim;
        }

        public void Read()
        {
           // FileIO.TextFieldParser par = new TextFieldParser(FileName);
        }
    }
}
