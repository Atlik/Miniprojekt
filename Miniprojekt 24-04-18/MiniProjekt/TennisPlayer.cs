using System;
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
        //Properties
        public virtual string firstName { get; set; }   
        public virtual string middleName { get; set; }   
        public virtual string lastName { get; set; }    
        public virtual string nationality { get; set; }   
        public virtual bool gender { get; set; }           
        public DateTime dateOfBirth { get; set; }

        //Constructor of TennisPlayer
        public TennisPlayer(string Fname, string Mname, string Lname, DateTime DOB, string Na, bool sex)
        {
            firstName = Fname;
            middleName = Mname;
            lastName = Lname;
            dateOfBirth = DOB;
            nationality = Na;
            gender = sex;
        }

        public override string ToString()
        {
            string GenderCheck = "";
            switch (gender)
            {
                case true:
                    GenderCheck = "Male";
                    break;
                case false:
                    GenderCheck = "Female";
                    break;
            }

            string MiddleNameSpaceCheck;
            if (middleName == "")
                MiddleNameSpaceCheck = "";
            else
                MiddleNameSpaceCheck = " " + middleName;

            //Calculate the persons DateOfDay to Age
            #region
            var DateTimeToday = DateTime.Today;
            var PlayersAge = DateTimeToday.Year - dateOfBirth.Year;
            if (dateOfBirth > DateTimeToday.AddYears(-PlayersAge)) PlayersAge--;
            #endregion 

            //ToShortDateString() is used to delete time
            return "Players Name: " + firstName + MiddleNameSpaceCheck + " " + lastName +
            Environment.NewLine + "Players birthday is the: " + dateOfBirth.ToShortDateString() +
            Environment.NewLine + "The players nationality is: " + nationality +
            Environment.NewLine + "The players gender is: " + GenderCheck + 
            Environment.NewLine + "The players age is: " + PlayersAge + 
            Environment.NewLine;
        }

    }
}
