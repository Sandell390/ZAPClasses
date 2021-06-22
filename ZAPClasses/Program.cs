using System;

namespace ZAPClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Manager manager = new Manager();
            /*
            manager.MakeReveration(new Revervation(DateTime.Parse("10-04-2021"), DateTime.Parse("16-04-2021")));
            manager.Revervation.AddAdditiions(new Additions(Additions.AdditionType.BreakfastA, 1));

            Console.WriteLine(manager.Revervation.CalulatePrice(manager.Dal));
            */

            manager.MakeReveration(new Revervation(DateTime.Parse("05-05-2021"), DateTime.Today.AddDays(30), 2, 2, 1,
                Revervation.CampType.BigCamp));
            manager.Revervation.Customer = new Customer("Jespe123r", "H41256ej" , "Vej123123" ,"meail@k555jds.com", "123411122222223311123");

            manager.InsertCustomer();
            manager.Revervation.OrderID = manager.Dal.InsertRevervation(manager.Revervation);

            manager.Revervation.AddAdditiions(new Additions(Additions.AdditionType.Bike, 3));
            manager.Revervation.AddAdditiions(new Additions(Additions.AdditionType.BedThing, 4));
            manager.Revervation.AddAdditiions(new Additions(Additions.AdditionType.WaterlandA, 2));

            manager.Dal.InsertAddition(manager.Revervation);




            Console.ReadLine();
        }
    }
}
