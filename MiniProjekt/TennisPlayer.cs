using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjekt
{
    /// This class will implement the information about the player
    public class TennisPlayer //public so everyone can see it
    {
        //Properties
        #region
        public virtual string firstName { get; set; }
        public virtual string middleName { get; set; }
        public virtual string lastName { get; set; }
        public virtual string nationality { get; set; }
        public virtual bool gender { get; set; }
        public DateTime dateOfBirth { get; set; }
        #endregion

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
            //Checks and gives the gender a string name
            #region
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
            #endregion

            //Checks if the player has a middlename, if true, gives spacing
            #region
            string MiddleNameSpaceCheck;
            if (middleName == "")
                MiddleNameSpaceCheck = "";
            else
                MiddleNameSpaceCheck = " " + middleName;
            #endregion

            //Calculate the persons DateOfDay to Age
            #region
            var DateTimeToday = DateTime.Today;
            var PlayersAge = DateTimeToday.Year - dateOfBirth.Year;
            if (dateOfBirth > DateTimeToday.AddYears(-PlayersAge)) PlayersAge--;
            #endregion

            //Inserts player information in correct order if printed
            #region
            //ToShortDateString() is used to delete time
            // "\r\n" is euqal as the same as Environment.NewLine
            return "Contestant Name: " + firstName + MiddleNameSpaceCheck + " " + lastName +
            Environment.NewLine + "Contestants birthday is the: " + dateOfBirth.ToShortDateString() +
            Environment.NewLine + "The contestants nationality is: " + nationality +
            Environment.NewLine + "The contestants gender is: " + GenderCheck +
            Environment.NewLine + "The contestants age is " + PlayersAge + Environment.NewLine;
            #endregion
        }
    }
}
