using System;
using System.Collections.Generic;
using System.Text;

namespace ZAPClasses
{
    public class Additions
    {
        private int amount;

        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }


        private AdditionType type;

        public AdditionType Type
        {
            get { return type; }
            set { type = value; }
        }

        public enum AdditionType
        {
            BreakfastA,
            BreakfastK,
            Bike,
            WaterlandA,
            WaterlandK,
            endClean,
            BedThing,
            


        }



    }
}
