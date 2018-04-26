using System;

namespace MiniProjekt
{
    /// This class will implement the information about the player
    public class TennisPlayer //public so everyone can see it
    {
        //Properties
        #region
        public virtual string FirstName { get; set; }
        public virtual string MiddleName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Nationality { get; set; }
        public virtual bool Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        #endregion

        //Constructor of TennisPlayer
        public TennisPlayer(string fname, string mname, string lname, DateTime dob, string na, bool sex)
        {
            FirstName = fname;
            MiddleName = mname;
            LastName = lname;
            DateOfBirth = dob;
            Nationality = na;
            Gender = sex;
        }

        public override string ToString()
        {
            //Checks and gives the gender a string name
            #region
            string genderCheck = "";
            switch (Gender)
            {
                case true:
                    genderCheck = "Male";
                    break;
                case false:
                    genderCheck = "Female";
                    break;
            }
            #endregion

            //Checks if the player has a middlename, if true, gives spacing
            #region
            string middleNameSpaceCheck;
            if (MiddleName == "")
                middleNameSpaceCheck = "";
            else
                middleNameSpaceCheck = " " + MiddleName;
            #endregion

            //Calculate the persons DateOfDay to Age
            #region
            var dateTimeToday = DateTime.Today;
            var playersAge = dateTimeToday.Year - DateOfBirth.Year;
            if (DateOfBirth > dateTimeToday.AddYears(-playersAge)) playersAge--;
            #endregion

            //Inserts player information in correct order if printed
            #region
            //ToShortDateString() is used to delete time
            // "\r\n" is euqal as the same as Environment.NewLine
            return "Contestant Name: " + FirstName + middleNameSpaceCheck + " " + LastName +
            Environment.NewLine + "Contestants birthday is the: " + DateOfBirth.ToShortDateString() +
            Environment.NewLine + "The contestants nationality is: " + Nationality +
            Environment.NewLine + "The contestants gender is: " + genderCheck +
            Environment.NewLine + "The contestants age is " + playersAge + Environment.NewLine;
            #endregion
        }
    }
}
