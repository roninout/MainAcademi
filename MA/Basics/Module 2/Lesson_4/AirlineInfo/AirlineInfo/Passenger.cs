using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineInfo
{
    class Passenger
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Nationality { get; set; }
        public string Passport { get; set; }
        public DateTime DateOfBirthday { get; set; }
        public Sex Sex { get; set; }
        public FlyClass FlyClass { get; set; }
        public string FlightNumber { get; set; }

        protected static Random random = new Random();

        public Passenger()
        {
            Sex = (Sex)random.Next(Enum.GetNames(typeof(Sex)).Length);
            if (Sex == Sex.Male)
            {
                FirstName = Data.firstNameMale[random.Next(Data.firstNameMale.Count)];
                SecondName = Data.secondNameMale[random.Next(Data.secondNameMale.Count)];
            }
            else
            {
                FirstName = Data.firstNameFemale[random.Next(Data.firstNameFemale.Count)];
                SecondName = Data.secondNameFemale[random.Next(Data.secondNameFemale.Count)];
            }
            Nationality = Data.nationality[random.Next(Data.nationality.Count)];
            Passport = Data.passportId[random.Next(Data.passportId.Count)];
            DateOfBirthday = Data.RandomDayFunc(random)();
            FlyClass = (FlyClass)random.Next(Enum.GetNames(typeof(FlyClass)).Length);
            FlightNumber = Data.flightNumber[random.Next(Data.flightNumber.Count)];
        }

        // отображение
        public void Show()
        {
            Console.WriteLine(new string('-', 30));
            Console.ForegroundColor = Sex == Sex.Male ? ConsoleColor.Blue : ConsoleColor.Magenta;
            Console.WriteLine($"Sex:            {Sex}");
            Console.ResetColor();
            Console.WriteLine(new string('-', 30));
            Console.WriteLine($"First Name:     {FirstName}");
            Console.WriteLine($"Second Name:    {SecondName}");
            Console.WriteLine($"Nationality:    {Nationality}");
            Console.WriteLine($"Passport:       {Passport}");
            Console.WriteLine($"DateOfBirthday: {DateOfBirthday:d}");
            Console.WriteLine($"FlightNumber:   {FlightNumber}");
            Console.WriteLine($"FlyClass:       {FlyClass}");
            Console.WriteLine(new string('-', 30));
        }

    }

    enum Sex
    {
        Male,
        Female
    }

    enum FlyClass
    {
        Business,
        Economy
    }
}
