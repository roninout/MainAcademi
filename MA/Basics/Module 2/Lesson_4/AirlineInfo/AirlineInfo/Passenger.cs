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

        protected static Random random = new Random();

        public Passenger()
        {
            Sex = (Sex)random.Next(Enum.GetNames(typeof(Sex)).Length);
            if (Sex == Sex.Man)
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
            DateOfBirthday = Data.RandomDayFunc()();
            FlyClass = (FlyClass)random.Next(Enum.GetNames(typeof(FlyClass)).Length);
        }

        // отображение
        public void Show()
        {
            Console.WriteLine(new string('-', 30));
            Console.ForegroundColor = Sex == Sex.Man ? ConsoleColor.Blue : ConsoleColor.Magenta;
            Console.WriteLine($"Sex:            {Sex}");
            Console.ResetColor();
            Console.WriteLine(new string('-', 30));
            Console.WriteLine($"First Name:     {FirstName}");
            Console.WriteLine($"Second Name:    {SecondName}");
            Console.WriteLine($"Nationality:    {Nationality}");
            Console.WriteLine($"Passport:       {Passport}");
            Console.WriteLine($"DateOfBirthday: {DateOfBirthday}");
            Console.WriteLine($"FlyClass:       {FlyClass}");
            Console.WriteLine(new string('-', 30));
        }

    }

    enum Sex
    {
        Man,
        Woman
    }

    enum FlyClass
    {
        Business,
        Economy
    }
}
