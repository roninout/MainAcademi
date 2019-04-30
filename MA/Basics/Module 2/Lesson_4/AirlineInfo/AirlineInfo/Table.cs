using System;

namespace AirlineInfo
{
    static class Table
    {
        const int tableArrivalLine = 106;
        const int tableDepartureLine = 98;

        // отображаем основное меню
        public static void DisplayMainMenu()
        {
            Console.WriteLine($"Основное меню:");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"1 - вылеты самолетов");
            Console.ForegroundColor = ConsoleColor.Blue;
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
            Console.WriteLine($"1 - изменить НОМЕР РЕЙСА");
            Console.WriteLine($"2 - изменить ВРЕМЯ");
            Console.WriteLine($"3 - изменить НАЗНАЧЕНИЕ");
            Console.WriteLine($"4 - изменить ПЕРЕВОЗЧИКА");
            Console.WriteLine($"5 - изменить ТЕРМИНАЛ");
            Console.WriteLine($"6 - изменить GATE");
            Console.WriteLine($"7 - изменить СТАТУС");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"0 - выход в сновное меню");
            Console.ResetColor();
        }

        // отображение табло ВЫЛЕТ-ов / ПРИЛЁТ-ов
        public static void DisplayFlightsTable(Flight[] flights, bool type = true)
        {
            Console.Clear();
            Console.ForegroundColor = flights[0] is IArrivalFlight ? ConsoleColor.Cyan : ConsoleColor.Blue;
            Console.WriteLine(flights[0] is IArrivalFlight ? new string('-', tableArrivalLine) : new string('-', tableDepartureLine));
            if (type)
            {
                Console.WriteLine(flights[0] is IArrivalFlight ? $"{"ВЫЛЕТЫ САМОЛЕТОВ",60}" : $"{"ПРИЛЁТЫ САМОЛЕТОВ",60}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(flights[0] is IArrivalFlight ? $"{"ВЫЛЕТЫ САМОЛЕТОВ - РЕДАКТИРОВАНИЕ",60}" : $"{"ПРИЛЁТЫ САМОЛЕТОВ - РЕДАКТИРОВАНИЕ",60}");
                Console.ForegroundColor = flights[0] is IArrivalFlight ? ConsoleColor.Cyan : ConsoleColor.Blue;
            }
            Console.WriteLine(flights[0] is IArrivalFlight ? new string('-', tableArrivalLine) : new string('-', tableDepartureLine));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(
                $"{"Рейс".PadRight((int)Columns.colFlightNumber, ' ')}" +
                $"{"Время".PadRight((int)Columns.colDateTime, ' ')}" +
                $"{"Назначение".PadRight((int)Columns.colCityPort, ' ')}" +
                $"{"Перевозчик".PadRight((int)Columns.colAirline, ' ')}" +
                $"{"Терминал".PadRight((int)Columns.colTerminal, ' ')}"
                );
            Console.WriteLine(flights[0] is IArrivalFlight ? $"{"Гейт".PadRight((int)Columns.colGate, ' ')}{"Статус".PadRight((int)Columns.colFlightStatus, ' ')}" : $"{"Статус".PadRight((int)Columns.colDevFlightStatus, ' ')}");
            Console.ResetColor();

            BubbleSort(flights); // сортировка по времени

            foreach (var item in flights)
                item.Show();

            Console.WriteLine(flights[0] is IArrivalFlight ? new string('-', tableArrivalLine) : new string('-', tableDepartureLine));
            Console.WriteLine();
        }

        // редактирование табла ВЫЛЕТ-ов/ПРИЛЁТ-ов
        public static void DisplayEditTable(Flight[] flights)
        {
            string menuSelect = String.Empty;

            while (menuSelect != "0")
            {
                DisplayFlightsTable(flights, false);
                try
                {
                    Console.Write(flights is IArrivalFlight[] ? $"Выберите номер рейса (0-{Data.maxArrivalFlight - 1}) :" : $"Выберите номер рейса (0-{Data.maxDepartureFlight - 1}) :");
                    int selectType = int.Parse(Console.ReadLine());
                    Console.WriteLine($"Был выбран {selectType} рейс: {flights[selectType].FlightNumber}");

                    DisplayEditMenu();
                    menuSelect = Console.ReadLine().ToLower();
                    Console.ForegroundColor = ConsoleColor.Red;
                    switch (menuSelect)
                    {
                        case "1": // НОМЕР РЕЙСА

                            Console.SetCursorPosition(0, selectType + 4);
                            flights[selectType].Edit(Columns.colFlightNumber, selectType);
                            break;
                        case "2": // ВРЕМЯ
                            Console.SetCursorPosition((int)Columns.colFlightNumber, selectType + 4);
                            flights[selectType].Edit(Columns.colDateTime, selectType);
                            break;
                        case "3": // НАЗНАЧЕНИЕ
                            Console.SetCursorPosition((int)Columns.colFlightNumber + (int)Columns.colDateTime, selectType + 4);
                            flights[selectType].Edit(Columns.colCityPort, selectType);
                            break;
                        case "4": // ПЕРЕВОЗЧИК
                            Console.SetCursorPosition((int)Columns.colFlightNumber + (int)Columns.colDateTime + (int)Columns.colCityPort, selectType + 4);
                            flights[selectType].Edit(Columns.colAirline, selectType);
                            break;
                        case "5": // ТЕРМИНАЛ
                            Console.SetCursorPosition((int)Columns.colFlightNumber + (int)Columns.colDateTime + (int)Columns.colCityPort + (int)Columns.colAirline, selectType + 4);
                            flights[selectType].Edit(Columns.colTerminal, selectType);
                            break;
                        case "6": // GATE
                            Console.SetCursorPosition((int)Columns.colFlightNumber + (int)Columns.colDateTime + (int)Columns.colCityPort + (int)Columns.colAirline + (int)Columns.colTerminal, selectType + 4);
                            flights[selectType].Edit(Columns.colGate, selectType);
                            break;
                        case "7": // СТАТУС
                            Console.Clear();
                            DisplayFlightsTable(flights, false);
                            flights[selectType].Edit(Columns.colFlightStatus, selectType);
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

        // сортировка пузырьком
        private static void BubbleSort(Flight[] flights)
        {
            Flight tmpFlight = null;

            for (int i = 0; i < flights.Length - 1; i++)
            {
                for (int j = 0; j < flights.Length - 1 - i; j++)
                {
                    if (flights[j].DateTime > flights[j + 1].DateTime)
                    {
                        tmpFlight = flights[j + 1];
                        flights[j + 1] = flights[j];
                        flights[j] = tmpFlight;
                    }
                }
            }
        }
    }
}
