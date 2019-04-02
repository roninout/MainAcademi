using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAirportPanel
{
    class Program
    {
        static void Main(string[] args)
        {
            Flight[] arrivalflights = CreateArrivalFlights();
            Flight[] departureflights = CreateDepartureFlights();

            string menuSelect = String.Empty;

            while (menuSelect != "0")
            {
                DisplayMainMenu();
                menuSelect = Console.ReadLine().ToLower();

                switch (menuSelect)
                {
                    case "1":
                        DisplayArrivalTable(arrivalflights);
                        break;
                    case "2":
                        DisplayDepartureTable(departureflights);
                        break;
                    case "3":
                        DisplayEditTable(arrivalflights, menuSelect);
                        break;
                    case "4":
                        DisplayEditTable(departureflights, menuSelect);
                        break;
                    case "0":
                        break;
                    default:
                        Console.Clear();
                        break;
                }
            }
        }

        // создание рейсов ВЫЛЕТ-ов
        public static Flight[] CreateArrivalFlights()
        {
            Flight[] flights = new Flight[5];

            flights[0] = new Flight("KC 406", new DateTime(2015, 7, 20), "Алматы", "Air Astana", "D", "D4", FlightStatus.Arrived);
            flights[1] = new Flight("PQ 7119", new DateTime(2015, 7, 20), "Шарм-Эль-Шейх", "Sky Up Airlines", "F", "F2", FlightStatus.Arrived);
            flights[2] = new Flight("LO 8312", new DateTime(2015, 7, 20), "Таллинн", "LOT Polish Airlines", "D", "D10", FlightStatus.Arrived);
            flights[3] = new Flight("PS 5673", new DateTime(2015, 7, 20), "Шарм-Эль-Шейх", "Ukraine International Airlines", "D", "D11", FlightStatus.Arrived);
            flights[4] = new Flight("LH 2545", new DateTime(2015, 7, 20), "Мюнхен", "Lufthansa", "D", "D8", FlightStatus.Arrived);

            return flights;
        }

        // создание рейсов ПРИЛЁТ-ов
        public static Flight[] CreateDepartureFlights()
        {
            Flight[] flights = new Flight[5];
            flights[0] = new Flight("LH 2544", new DateTime(2015, 7, 20), "Мюнхен", "Lufthansa", "D", "", FlightStatus.Canceled);
            flights[1] = new Flight("QU 4440", new DateTime(2015, 7, 20), "Шарм-Эль-Шейх", "Azur Air Ukraine", "F", "", FlightStatus.ChekIn);
            flights[2] = new Flight("PS 354", new DateTime(2015, 7, 20), "Афины", "Ukraine International Airlines", "D", "", FlightStatus.Delayed);
            flights[3] = new Flight("LH 1494", new DateTime(2015, 7, 20), "Франкфурт", "Lufthansa", "D", "", FlightStatus.DepartedAt);
            flights[4] = new Flight("PS 472", new DateTime(2015, 7, 20), "Цюрих", "Ukraine International Airlines", "D", "", FlightStatus.ExpectedAt);

            return flights;
        }

        // отображение табло ВЫЛЕТ-ов
        public static void DisplayArrivalTable(Flight[] flight)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(new string('-', 110));
            Console.WriteLine($"{"ВЫЛЕТЫ САМОЛЕТОВ", 60}");
            Console.WriteLine(new string('-', 110));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{"Рейс",0}{"Время",11}{"Назначение",27}{"Перевозчик",35}{"Терминал",13}{"Гейт",8}{"Статус",10}");
            Console.ResetColor();
            foreach (var item in flight)
            {
                Console.WriteLine($"{item.flightNumber,-10}{item.dateTime:dd:MM:yy hh:mm}{item.cityPort,18}{item.airline,35}{item.terminal,10}{item.gate,10}{item.flightStatus,12}");
            }
            Console.WriteLine(new string('-', 110));
            Console.WriteLine();
        }

        // отображение табло ПРИЛЁТ-ов
        public static void DisplayDepartureTable(Flight[] flight)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(new string('-', 110));
            Console.WriteLine($"{"ПРИЛЕТЫ САМОЛЕТОВ",60}");
            Console.WriteLine(new string('-', 110));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{"Рейс",0}{"Время",11}{"Назначение",27}{"Перевозчик",35}{"Терминал",13}{"Статус",18}");
            Console.ResetColor();
            foreach (var item in flight)
            {
                Console.WriteLine($"{item.flightNumber,-10}{item.dateTime:dd:MM:yy hh:mm}{item.cityPort,18}{item.airline,35}{item.terminal,10}{item.flightStatus,22}");
            }
            Console.WriteLine(new string('-', 110));
            Console.WriteLine();
        }

        // редактирование табла ВЫЛЕТ-ов/ПРИЛЁТ-ов
        public static void DisplayEditTable(Flight[] flights, string type)
        {
            string menuSelect = String.Empty;

            while (menuSelect != "0")
            {
                if (type == "3")
                    DisplayArrivalTable(flights);
                else
                    DisplayDepartureTable(flights);
                try
                {
                    Console.Write("Выберите номер рейса (0-4): ");
                    int selectType = int.Parse(Console.ReadLine());

                    Console.WriteLine($"Был выбран {selectType} рейс: {flights[selectType].flightNumber}");

                    DisplayEditMenu();
                    menuSelect = Console.ReadLine().ToLower();

                    switch (menuSelect)
                    {
                        case "1": // ВРЕМЯ
                            Console.Write($"Измените пункт ВРЕМЯ { flights[selectType].dateTime} на : ");
                            flights[selectType].dateTime = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine($"ВРЕМЯ было изменено на: { flights[selectType].dateTime}.\nДля продолжения нажмите...");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case "2": // НАЗНАЧЕНИЕ
                            Console.Write($"Измените пункт НАЗНАЧЕНИЯ { flights[selectType].cityPort} на : ");
                            flights[selectType].cityPort = Console.ReadLine();
                            Console.WriteLine($"Пункт назначения был изменен на: { flights[selectType].cityPort}.\nДля продолжения нажмите...");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case "3": // ПЕРЕВОЗЧИК
                            Console.Write($"Измените ПЕРЕВОЗЧИКА { flights[selectType].airline} на : ");
                            flights[selectType].airline = Console.ReadLine();
                            Console.WriteLine($"Перевозчик был изменен на: { flights[selectType].airline}.\nДля продолжения нажмите...");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case "4": // ТЕРМИНАЛ
                            Console.Write($"Измените ТЕРМИНАЛ { flights[selectType].terminal} на : ");
                            flights[selectType].terminal = Console.ReadLine();
                            Console.WriteLine($"Терминал был изменен на: { flights[selectType].terminal}.\nДля продолжения нажмите...");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case "5": // СТАТУС
                            Console.WriteLine($"Текущий статус рейса: {flights[selectType].flightStatus}");
                            Console.WriteLine(@"Для изменения СТАТУСА выберите следующие варианты:
    0 -  регистрация
    1 - гейт закрыт
    2 - прибыл
    3 - отправляется в ...
    4 - неизвестен
    5 - отменен
    6 - ожидается в ...
    7 - задерживается
    8 - в полёте");
                            flights[selectType].flightStatus = (FlightStatus)int.Parse(Console.ReadLine());
                            Console.WriteLine($"Статус был изменен на: { flights[selectType].flightStatus}.\nДля продолжения нажмите...");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case "0": // выход в сновное меню
                            Console.Clear();
                            break;
                        default:
                            Console.WriteLine("Некоректный выбор");
                            break;
                    }

                }
                catch (Exception)
                {
                }
            }
        }

        // отображаем основное меню
        public static void DisplayMainMenu()
        {
            Console.WriteLine($"Основное меню:");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"1 - вылеты самолетов");
            Console.WriteLine($"2 - прилеты самолетов");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"3 - редактирование вылетов самолетов");
            Console.WriteLine($"4 - редактирование прилетов самолетов");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"0 - выход");
            Console.ResetColor();
        }

        // отображаем меню редактирования
        public static void DisplayEditMenu()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Меню редактирования:");
            Console.WriteLine($"1 - изменить ВРЕМЯ");
            Console.WriteLine($"2 - изменить НАЗНАЧЕНИЕ");
            Console.WriteLine($"3 - изменить ПЕРЕВОЗЧИКА");
            Console.WriteLine($"4 - изменить ТЕРМИНАЛ");
            Console.WriteLine($"5 - изменить СТАТУС");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"0 - выход в сновное меню");
            Console.ResetColor();
        }
    }
}
