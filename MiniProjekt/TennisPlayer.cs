using System;
using System.Collections.Generic;

namespace MiniProjekt
{
    /// This class will implement the information about the player
    public class TennisPlayer
    {
        #region
        /// <summary>
        /// TennisPlayer property
        /// </summary>
        public virtual int Identifikation { get; set; }
        /// <summary>
        /// TennisPlayer property
        /// </summary>
        public virtual string FirstName { get; set; }
        /// <summary>
        /// TennisPlayer property
        /// </summary>
        public virtual string MiddleName { get; set; }
        /// <summary>
        /// TennisPlayer property
        /// </summary>
        public virtual string LastName { get; set; }
        /// <summary>
        /// TennisPlayer property
        /// </summary>
        public virtual string Nationality { get; set; }
        /// <summary>
        /// TennisPlayer property
        /// </summary>
        public virtual bool Gender { get; set; }
        /// <summary>
        /// TennisPlayer property
        /// </summary>
        public DateTime DateOfBirth { get; set; }
        /// <summary>
        /// TennisPlayer property
        /// </summary>
        public bool PlayerOrReferee { get; set; }
        #endregion

        //Referee properties
        #region
        /// <summary>
        /// TennisPlayer for the referee property
        /// </summary>
        public DateTime LicenseGot { get; set; }
        /// <summary>
        /// TennisPlayer for the referee property
        /// </summary>
        public DateTime LicenseRenewal { get; set; }
        #endregion

        //Constructor of TennisPlayer
        /// <summary>
        /// Constructor of Tennisplayer
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fname"></param>
        /// <param name="mname"></param>
        /// <param name="lname"></param>
        /// <param name="dob"></param>
        /// <param name="na"></param>
        /// <param name="sex"></param>
        /// <param name="PoR"></param>
        public TennisPlayer(int id, string fname, string mname, string lname, DateTime dob, string na, bool sex, bool PoR)
        {
            Identifikation = id;
            FirstName = fname;
            MiddleName = mname;
            LastName = lname;
            DateOfBirth = dob;
            Nationality = na;
            Gender = sex;
            PlayerOrReferee = PoR;
        }

        //Constructor of Referee
        #region
        /// <summary>
        /// Constructor of referee
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fname"></param>
        /// <param name="mname"></param>
        /// <param name="lname"></param>
        /// <param name="dob"></param>
        /// <param name="na"></param>
        /// <param name="sex"></param>
        /// <param name="PoR"></param>
        /// <param name="LGdate"></param>
        /// <param name="LRdate"></param>
        #endregion
        public TennisPlayer(int id, string fname, string mname, string lname, DateTime dob, string na, bool sex, bool PoR, DateTime LGdate, DateTime LRdate) : this(id, fname, mname, lname, dob, na, sex, PoR)
        {
            LicenseGot = LGdate;
            LicenseRenewal = LRdate;
        }
        
        /// <summary>
        /// ToString metode
        /// </summary>
        /// <returns> Referee values, Gender, Middlename if true, Age, Tennis player information order</returns>
        public override string ToString()
        {
            //checks and gives the referee ekstra variables
            #region
            string refereeCheck = "";
            switch (PlayerOrReferee)
            {
                case true:
                    refereeCheck = "This is a referee." + Environment.NewLine + 
                                   "The person got the license: " + LicenseGot.ToShortDateString() + 
                                   " and got it renewed: " + LicenseRenewal.ToShortDateString();
                    break;
                case false:
                    refereeCheck = "This is a player";
                    break;
            }
            #endregion

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
            {
                middleNameSpaceCheck = "";
            }
            else
            {
                middleNameSpaceCheck = " " + MiddleName;
            }

            #endregion

            //Calculate the persons DateOfDay to Age
            #region
            var dateTimeToday = DateTime.Today;
            var playersAge = dateTimeToday.Year - DateOfBirth.Year;

            if (DateOfBirth > dateTimeToday.AddYears(-playersAge))
            {
                playersAge--;
            }
            #endregion

            //Inserts player information in correct order if printed
            #region
            //ToShortDateString() is used to delete time
            // "\r\n" is equal to Environment.NewLine
            return "Identifikation: " + Identifikation +
                   Environment.NewLine + "Persons Name: " + FirstName + middleNameSpaceCheck + " " + LastName +
                   Environment.NewLine + "Persons birthday is the: " + DateOfBirth.ToShortDateString() +
                   Environment.NewLine + "The persons nationality is: " + Nationality +
                   Environment.NewLine + "The persons gender is: " + genderCheck +
                   Environment.NewLine + "The persons age is " + playersAge +
                   Environment.NewLine + refereeCheck +
                   Environment.NewLine;
            #endregion
        }
    }
}
