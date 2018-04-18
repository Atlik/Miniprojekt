﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjekt
{
    /// <summary>
    /// This class will implement the information about the player
    /// </summary>
    public class TennisPlayer //public so everyone can see it
    {
        protected virtual string firstName { get; set; }      //Property
        protected virtual string middleName { get; set; }     //Property
        protected virtual string lastName { get; set; }       //Property
        protected DateTime dateOfBirth { get; set; }
        protected virtual string nationality { get; set; }    //Property
        protected virtual bool gender { get; set; }           //Check for gender, True for Male and False for Female

        public TennisPlayer(string FN, string MN, string LN, DateTime Da, string Na, bool Ge) //Constructor for TennisPlayer
        {
            firstName = FN;
            middleName = MN;
            lastName = LN;
            dateOfBirth = Da;
            nationality = Na;
            gender = Ge;
        }

        public override string ToString()
        {
            string GenderCheck = "";
            switch (gender)
            {
                case true:  // 
                    GenderCheck = "Male";
                    break;  // break if the case is true
                case false:
                    GenderCheck = "Female";
                    break;
            }

            string MiddleNameSpaceCheck;
            if (middleName is null)
                MiddleNameSpaceCheck = "";
            else
                MiddleNameSpaceCheck = " " + middleName;

            //ToShortDateString() is used to delete time
            return "Players Name: " + firstName + MiddleNameSpaceCheck + " " + lastName +
            Environment.NewLine + "Players birthday is the: " + dateOfBirth.ToShortDateString() +
            Environment.NewLine + "The players nationality is: " + nationality +
            Environment.NewLine + "The players gender is: " + GenderCheck + Environment.NewLine;
        }

        public static void mainPlayer()
        {
            var Player01 = new TennisPlayer("Christian", "Gundersen", "Holmgaard", new DateTime(1996, 05, 09), "Denmark", true);

            Console.WriteLine(Player01);
            Console.WriteLine();
        }
    }
}
