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

        public void InsertCustomer()
        {
            dal.InsertCustomer(revervation.Customer);
        } 

        public void MakeReveration(Revervation revervation)
        {
            this.revervation = revervation;
        }

        /// <summary>
        /// Returns a random available CampSpot.
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="type"></param>
        /// <returns> CampSpot ID </returns>
        public string FindAvailableCamps(DateTime startTime, DateTime endTime, Revervation.CampType type)
        {
            //Get all campSpots of a type 
            List<CampSpot> allCampSpots = dal.GetCampSpotsOfType(type);

            //Get all booked campSpot
            List<CampSpot> bookedCampSpots = dal.GetBookedCampSpots(startTime, endTime);

            //Make a list to available camps for use later 
            List<CampSpot> availableCampSpots = new List<CampSpot>();

            bool isBooked = false;

            //Loops through allCampSpots and check if the id's on allCampSpots and BookedCampSpot are the same, the CampSpot are not added to the list.
            for (int i = 0; i < allCampSpots.Count; i++)
            {
                isBooked = false;

                for (int j = 0; j < bookedCampSpots.Count; j++)
                {
                    if (allCampSpots[i].Id == bookedCampSpots[j].Id)
                    {
                        isBooked = true;
                    }
                }

                if (!isBooked)
                {
                    availableCampSpots.Add(allCampSpots[i]);
                }
            }
            

            
            Random random = new Random();
            //Selects a random CampSpot and returns it as a string
            return availableCampSpots[random.Next(0,availableCampSpots.Count - 1)].Id;
        }
    }
}
