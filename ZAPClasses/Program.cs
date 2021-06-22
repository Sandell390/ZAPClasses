using System;

namespace ZAPClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Manager manager = new Manager();

            manager.MakeReveration(new Revervation(DateTime.Parse("10-04-2021"), DateTime.Parse("16-04-2021")));
            manager.Revervation.AddAdditiions(new Additions(Additions.AdditionType.BreakfastA, 1));

            Console.WriteLine(manager.Revervation.CalulatePrice(manager.Dal));
            var test = dalmanager.GetCampSpotsOfType(Revervation.CampType.Tent);


            Manager manager = new Manager();

            DateTime startDate = DateTime.Parse("21-06-2021");
            DateTime endDate = DateTime.Parse("26-06-2021");
            Revervation.CampType hej = Revervation.CampType.Tent;

            string id = manager.FindAvailableCamps(startDate,endDate ,hej);

            Console.WriteLine(id);

            Customer kage = new Customer()
            {
                Address = "Hej med digvej", Eamil = "Email@email.com", FirstName = "Knud", LastName = "Hansen",
                TelefonNr = "1235465"
            };

            manager.Revervation = new Revervation() {Adult = 2, Customer = kage, Camp = new CampSpot(id), Dog = 2, Kids = 12, StartDate = startDate, EndDate = endDate, Type = hej, SeasonType = Revervation.Season.None};

            manager.InsertCustomer();

            dalmanager.InsertRevervation(manager.Revervation);

            var test1 = dalmanager.GetBookedCampSpots(DateTime.Parse("23-06-2021"), DateTime.Parse("26-06-2021"));

            Console.ReadLine();
        }
    }
}
