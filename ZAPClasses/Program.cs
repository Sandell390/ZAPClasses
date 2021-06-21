using System;

namespace ZAPClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Dal dalmanager = new Dal();


            var test = dalmanager.GetCampSpotsOfType(Revervation.CampType.Tent);

            var test1 = dalmanager.GetBookedCampSpots(DateTime.Today, DateTime.Today.AddDays(50));

            Console.ReadLine();
        }
    }
}
