using System;
using System.Linq;

namespace CSharp_Net_module1_1_4_lab
{
    class Program
    {
        // 1) declare enum ComputerType
        public enum ComputerType
        {
            Desktop,
            Laptop,
            Server
        }

        // 2) declare struct Computer
        public struct Computer
        {
            public ComputerType _computerType;
            public int _CPU;
            public double _frequency;
            public int _memory;
            public int _HDD;

            public Computer(ComputerType computerType) : this()
            {
                switch (computerType)
                {
                    case ComputerType.Desktop:
                        InitComputerByType(computerType, 4, 2.5, 6, 500);
                        break;
                    case ComputerType.Laptop:
                        InitComputerByType(computerType, 2, 1.7, 4, 250);
                        break;
                    case ComputerType.Server:
                        InitComputerByType(computerType, 8, 3, 16, 2048);
                        break;
                    default:
                        InitComputerByType(computerType, 0, 0, 0, 0);
                        break;
                }
            }

            private void InitComputerByType(ComputerType computerType, int CPU, double frequency, int memory, int HDD)
            {
                _computerType = computerType;
                _CPU = CPU;
                _frequency = frequency;
                _memory = memory;
                _HDD = HDD;
            }
        }

        static void Main(string[] args)
        {
            // 3) declare jagged array of computers size 4 (4 departments)
            Computer[][] departments = new Computer[4][];

            // 4) set the size of every array in jagged array (number of computers)
            // 5) initialize array
            // Note: use loops and if-else statements
            departments[0] = new Computer[]
            {
                new Computer(ComputerType.Desktop),
                new Computer(ComputerType.Desktop),
                new Computer(ComputerType.Laptop),
                new Computer(ComputerType.Laptop),
                new Computer(ComputerType.Server)
            };

            departments[1] = new Computer[]
            {
                new Computer(ComputerType.Laptop),
                new Computer(ComputerType.Laptop),
                new Computer(ComputerType.Laptop)
            };
            departments[2] = new Computer[]
            {
                new Computer(ComputerType.Desktop),
                new Computer(ComputerType.Desktop),
                new Computer(ComputerType.Desktop),
                new Computer(ComputerType.Laptop),
                new Computer(ComputerType.Laptop)
            };
            departments[3] = new Computer[]
            {
                new Computer(ComputerType.Desktop),
                new Computer(ComputerType.Laptop),
                new Computer(ComputerType.Server),
                new Computer(ComputerType.Server)
            };

            // 6) count total number of every type of computers
            // 7) count total number of all computers
            // Note: use loops and if-else statements
            // Note: use the same loop for 6) and 7)
            int countAll = 0, countDesktop = 0, countLaptop = 0, countServer = 0;

            foreach (var departmen in departments)
            {
                foreach (var computer in departmen)
                {
                    if (computer._computerType == ComputerType.Desktop)
                        countDesktop++;
                    if (computer._computerType == ComputerType.Laptop)
                        countLaptop++;
                    if (computer._computerType == ComputerType.Server)
                        countServer++;
                    countAll++;
                }
            }
            Console.WriteLine($"All - {countAll}, Desktop - {countDesktop}, Laptop - {countLaptop}, Server - {countServer}");
            Console.WriteLine();

            // 8) find computer with the largest storage (HDD) - 
            // compare HHD of every computer between each other; 
            // find position of this computer in array (indexes)
            // Note: use loops and if-else statements

            int maxHDD = 0;
            string temp = "";

            for (int i = 0; i < departments.Length; i++)
            {
                for (int j = 0; j < departments[i].Length; j++)
                {
                    if (departments[i][j]._HDD > maxHDD)
                    {
                        maxHDD = departments[i][j]._HDD;
                        temp = $"department {i}.{j}, Type: {departments[i][j]._computerType}, Size HDD: {maxHDD} GB";
                    }
                }
            }
            Console.WriteLine($"Computer with the largest storage: {temp}");


            // 9) find computer with the lowest productivity (CPU and memory) - 
            // compare CPU and memory of every computer between each other; 
            // find position of this computer in array (indexes)
            // Note: use loops and if-else statements
            // Note: use logical oerators in statement conditions

            int minCPU = departments[0][0]._CPU;
            int minMem = departments[0][0]._memory;
            string descrCPU = "", descrMem = "";

            for (int i = 0; i < departments.Length; i++)
            {
                for (int j = 0; j < departments[i].Length; j++)
                {
                    if (departments[i][j]._CPU < minCPU)
                    {
                        minCPU = departments[i][j]._CPU;
                        descrCPU = $"Computer with min CPU: department {i}.{j}, Type: {departments[i][j]._computerType}, CPU: {minCPU} cores";
                    }
                    if (departments[i][j]._memory < minMem)
                    {
                        minMem = departments[i][j]._memory;
                        descrMem = $"Computer with min memory: department {i}.{j}, Type: {departments[i][j]._computerType}, Memory: {minMem} Gb";
                    }
                }
            }
            Console.WriteLine(descrCPU);
            Console.WriteLine(descrMem);
            Console.WriteLine();

            // 10) make desktop upgrade: change memory up to 8
            // change value of memory to 8 for every desktop. Don't do it for other computers
            // Note: use loops and if-else statements

            for (int i = 0; i < departments.Length; i++)
            {
                for (int j = 0; j < departments[i].Length; j++)
                {
                    if (departments[i][j]._computerType == ComputerType.Desktop)
                        departments[i][j]._memory = 8;
                }
            }

            // вывод результата на экран
            for (int i = 0; i < departments.Length; i++)
            {
                for (int j = 0; j < departments[i].Length; j++)
                    Console.WriteLine($"Value of memory: department: {i}.{j}, type: {departments[i][j]._computerType}, size: {departments[i][j]._memory} Gb");
            }

            Console.ReadKey();
        }

    }
}