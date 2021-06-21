using System;
using System.Collections.Generic;
using System.Text;

namespace ZAPClasses
{
    public class Revervation
    {
        private int adult;

        public int Adult
        {
            get { return adult; }
            set { adult = value; }
        }

        private int kid;

        public int Kids
        {
            get { return kid; }
            set { kid = value; }
        }

        private int dog;

        public int Dog
        {
            get { return dog; }
            set { dog = value; }
        }

        private DateTime starteDate;

        public DateTime StartDate
        {
            get { return starteDate; }
            set { starteDate = value; }
        }


        private DateTime endDate;

        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        private List<Additions> additions;
                    
        public List<Additions> Additions
        {
            get { return additions; }
            set { additions = value; }
        }

        private Customer customer;

        public Customer Customer
        {
            get { return customer; }
            set { customer = value; }
        }

        private CampType type;

        public CampType Type
        {
            get { return type; }
            set { type = value; }
        }

        private Season seasonType;

        public Season SeasonType
        {
            get { return seasonType; }
            set { seasonType = value; }
        }


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



    }
}
