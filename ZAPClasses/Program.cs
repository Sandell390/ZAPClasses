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


            Console.ReadLine();
        }
    }
}
