using System;
using System.Collections.Generic;
using System.Text;

namespace ZAPClasses
{
    public class Manager
    {
        private Revervation revervation;
        private Dal dal;

        public Manager()
        {
            dal = new Dal();
        }

        public Revervation Revervation
        {
            get { return revervation; }
            set { revervation = value; }
        }

        public void MakeReveration(Revervation revervation)
        {
            this.revervation = revervation;
        }

        public string FindAvailableCamps(DateTime starTime, DateTime endTime, Revervation.CampType type)
        {
            List<CampSpot> allCampSpots = dal.GetCampSpotsOfType(type);



            return "";
        }
    }
}
