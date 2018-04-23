using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament
{
    public class Turney
    {
        /* de forskellige data jeg regner med at arbejde med
         * bruger int for år, siden datetime giver mig dag, måned, år, time, minut og sekund = alt for meget info
         */
        public string TName { get; set; }
        public int TYear { get; set; } 
        DateTime TDate1 = new DateTime(2017, 06, 06); //dikterer min start dato
        DateTime TDate2 = new DateTime(2017, 06, 16); //dikterer min slut dato
        public int TPlayers { get; set; }
        
        // i opgaven var mængden af matches baseret på deltagere
        public int TMatches
        {
            get { return TPlayers /= 2; }
        }

        // min basiske constructor
        public Turney()
        {
            TName = "Unknown";
        }

        // den basiske constructor, men den tager 3 variabler
        public Turney(string TN, int TY, int TP)
        {
            TName = TN;
            TYear = TY;
            TPlayers = TP;
        }

        // min override
        public override string ToString()
        {
            return "Tournament Name: " + TName + "\r\n" +
                "Year: " + TYear + "\r\n" +
                "Date from: " + TDate1.ToString("d") + " To: " + TDate2.ToString("d") + "\r\n" +
                "Players: " + TPlayers + "\r\n" +
                "Amount of matches: " + TMatches;
        }
    }

    public class Demo1
    {
        static void Main(string[] args)
        {
            Turney T1 = new Turney();
            Console.WriteLine(T1);
            Console.WriteLine();
            Turney T2 = new Turney("De glade drenge", 2017, 64);
            Console.WriteLine(T2);
            Console.ReadLine();
        }
    }
}
