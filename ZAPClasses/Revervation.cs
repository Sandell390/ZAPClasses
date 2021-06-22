using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ZAPClasses
{
    public class Revervation
    {
        private int adult = 1;
        private int child = 0;
        private int dog = 0;
        private DateTime startDate;
        private List<Additions> additions = new List<Additions>();
        private DateTime endDate;
        private CampType type = CampType.BigCampWater;
        private Customer customer;
        private Season seasonType = Season.None;
        private CampSpot camp;

        public CampSpot Camp
        {
            get { return camp; }
            set { camp = value; }
        }


        public int Adult { get { return adult; } set { adult = value; } }
        public int Child { get { return child; } set { child = value; } }
        public int Dog { get { return dog; } set { dog = value; } }
        public DateTime StartDate { get { return startDate; } set { startDate = value; } }
        public DateTime EndDate { get { return endDate; } set { endDate = value; } }
        public List<Additions> Additions { get { return additions; } set { additions = value; } }
        public Customer Customer { get { return customer; } set { customer = value; } }
        public CampType Type { get { return type; } set { type = value; } }
        public Season SeasonType { get { return seasonType; } set { seasonType = value; } }

        public enum CampType
        {
            BigCampWater = 1, //Stor Plads med udsigt
            BigCamp = 2, //Stor plads uden udsigt
            SmallCampWater = 3, //Lille plads med udsigt
            SmallCamp = 4, //Lille plads uden udsigt
            TentWater = 5, //Telt med udsigt
            Tent = 6, //Telt uden udsigt
            Cottage = 7, //Hytte
            LuxuryCottage = 8 //Luksus Hytte

        }

        public enum Season
        {
            None,
            Winter,
            Spring,
            Summer,
            Autumn
        }

        public Revervation(DateTime startDate, DateTime endDate)
        {
            this.startDate = startDate;
            this.endDate = endDate;
        }

        public Revervation(DateTime startDate, DateTime endDate, int adult, int child, int dog) : this(startDate, endDate)
        {
            this.adult = adult;
            this.child = child;
            this.dog = dog;
        }

        public Revervation(DateTime startDate, DateTime endDate, CampType type) : this(startDate, endDate)
        {
            this.type = type;
        }

        public Revervation(DateTime startDate, DateTime endDate, int adult, int child, int dog, CampType type) : this(startDate, endDate, adult, child, dog)
        {
            this.type = type;
        }

        public Revervation(DateTime startDate, DateTime endDate, int adult, int child, int dog, CampType type, Season season) : this(startDate, endDate, adult, child, dog, type)
        {
            this.seasonType = season;
        }

        //Add an additions to the reservations
        public void AddAdditiions(Additions additions)
        {
            this.additions.Add(additions);
        }

        //Calculates the price of it.
        public double CalulatePrice(Dal dal)
        {
            //if its has a season it will set the price for season price.
            if (this.seasonType != Season.None)
            {
                //checks which season type is active
                switch (this.seasonType)
                {
                    case Season.Autumn:
                        return 2900;
                    case Season.Spring:
                        return 4100;
                    case Season.Summer:
                        return 9300;
                    case Season.Winter:
                        return 3500;
                }
            }
            //if its just a normal reservation it will calculate the price here.
            else
            {
                //Result is the calculatet price variable
                double result = 0;

                //connecting to database and gets the price scheme of the type.
                using (SqlConnection connection = new SqlConnection(dal.ConnString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("select PriceID, HighSeason, LowSeason from TypePrice where TypeID = @TypeNr", connection);
                    cmd.Parameters.Add(new SqlParameter("@TypeNr", this.type));
                    SqlDataReader reader = cmd.ExecuteReader();

                    //Reading the Data we got from the database
                    while (reader.Read())
                    {
                        DateTime date = this.startDate;
                        do
                        {
                            date = date.AddDays(1);
                            int readerOption = 2;

                            //checks if the date is in the High Season period
                            if ((date.Day >= 14 && date.Month == 6) || date.Month == 7 || (date.Day < 15 || date.Month == 8))
                            {
                                readerOption = 1;
                            }

                            switch (reader[0])
                            {
                                case "Adult":
                                    result += ((int)reader[readerOption] * this.adult);
                                    break;
                                case "Child":
                                    result += ((int)reader[readerOption] * this.child);
                                    break;
                                case "Dog":
                                    result += ((int)reader[readerOption] * this.dog);
                                    break;
                                case "CampFee":
                                    result += (int)reader[readerOption];

                                    //adds the additions
                                    if (this.additions.Count != 0)
                                    {
                                        for (int i = 0; i < this.additions.Count; i++)
                                        {
                                            result += this.additions[i].getPrice();
                                        }
                                    }
                                    break;
                            }
                        } while (!(date.Day == this.endDate.Day && date.Month == this.endDate.Month && date.Year == this.endDate.Year));
                    }
                }
                return result;
            }
            return 0;
        }

    }
}
