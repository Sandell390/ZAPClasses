using System;
using System.Collections.Generic;
using System.Text;

namespace ZAPClasses
{
    public class Additions
    {
        private int amount = 1;
        private AdditionType type;

        public int Amount { get { return amount; } set { amount = value; } }
        public AdditionType Type { get { return type; } set { type = value; } }


        public enum AdditionType
        {
            BreakfastA,
            BreakfastC,
            Bike,
            WaterlandA,
            WaterlandC,
            endClean,
            BedThing,
        }

        public Additions(AdditionType type, int amount)
        {
            this.type = type;
            this.amount = amount;
        }

        public double getPrice() {
            switch(type)
            {
                case AdditionType.BreakfastA:
                    return 75 * this.amount;
                case AdditionType.BreakfastC:
                    return 50 * this.amount;
                case AdditionType.Bike:
                    return 200 * this.amount;
                case AdditionType.WaterlandA:
                    return 30 * this.amount;
                case AdditionType.WaterlandC:
                    return 15 * this.amount;
                case AdditionType.endClean:
                    return 150;
                case AdditionType.BedThing:
                    return 20 * this.amount;
            }
            return 0;
        }
    }
}
