using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CSharp_Net_module1_7_1_lab
{
    class Program
    {
        static void Main(string[] args)
        {
            // 3) create collection of computers;
            // set path to file and file name
            List<Computer> computers = new List<Computer>();
            computers.Add(new Computer() { Cores = 5, Frequency = 2500, Hdd = 10, Memory = 8});
            computers.Add(new Computer() { Cores = 6, Frequency = 3500, Hdd = 20, Memory = 4 });
            computers.Add(new Computer() { Cores = 7, Frequency = 4500, Hdd = 30, Memory = 6 });

            InOutOperation.CurrentFile = "test.txt";
            InOutOperation.CurrentPath = @"D:\InOutOperation";

            // удаляем все перед запуском
            var curDirectory = new DirectoryInfo(InOutOperation.CurrentPath);
            if (curDirectory.Exists)
                curDirectory.Delete(true);

            // 4) save data and read it in the seamplest way (with WriteData() and ReadData() methods)
            Console.WriteLine("Обычная запись в файл");
            InOutOperation.WriteData(computers);
            Console.WriteLine();
            Console.WriteLine("Чтение данных с файла");
            InOutOperation.ReadData();
            Console.WriteLine();

            // 5) save data and read it with WriteZip() and ReadZip() methods
            // Note: create another file for these operations
            Console.WriteLine("Сжатая запись в файл");
            InOutOperation.WriteZip();
            Console.WriteLine();

            Console.WriteLine("Чтение данных с жатого файла");
            InOutOperation.ReadZip();
            Console.WriteLine();

            // 6) read info about computers asynchronously (from the 1st file)
            // While asynchronous method will be running, Main() method must print ‘*’ 

            Console.WriteLine("Чтение данных с файла асинхронно");
            Task readAsync = InOutOperation.ReadAsync();
            Console.WriteLine();


            // use 
            // collection of Task with info about computers as type to get returned data from method ReadAsync()
            // use property Result of collection of Task to get access to info about computers
            List<Task> list = new List<Task>();
            list.Add(InOutOperation.ReadAsync());
            list.Add(InOutOperation.ReadAsync());

            // Note:
            // print all info about computers after reading from files


            // ADVANCED:
            // 8) save data to memory stream and from memory to file
            // declare file stream and set it to null
            // call method WriteToMemory() with info about computers as parameter
            // save returned stream to file stream

            // call method WriteToFileFromMemory() with parameter of file stream
            // open file with saved data and compare it with input info

            Console.WriteLine("Done!");
            Console.ReadKey();
        }
    }
}
