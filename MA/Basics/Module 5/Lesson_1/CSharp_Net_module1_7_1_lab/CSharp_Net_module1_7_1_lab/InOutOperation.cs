using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Threading;

namespace CSharp_Net_module1_7_1_lab
{
    static class InOutOperation
    {
        #region properties
        // 1) declare properties
        public static string CurrentPath { get; set; }         // CurrentPath - path to file (without name of file)
        public static string CurrentDirectory { get; set; }    // CurrentDirectory - name of current directory
        public static string CurrentFile { get; set; }         // CurrentFile - name of current file
        #endregion

        #region methods
        // 2) declare public methods:
        //ChangeLocation() - change of CurrentPath; 
        // method takes new file path as parameter, creates new directories (if it is necessary)
        public static void ChangeLocation(string newFilePath)
        {
            var curDirectory = new DirectoryInfo(newFilePath);
            if (!curDirectory.Exists)
                curDirectory.Create();

            CurrentPath = curDirectory.FullName;
        }

        // CreateDirectory() - create new directory in current location
        public static void CreateDirectory(string newDir)
        {
            var curDirectory = new DirectoryInfo(CurrentPath);

            if (!curDirectory.Exists)
                curDirectory.CreateSubdirectory(newDir);
        }

        // WriteData() – save data to file
        // method takes data (info about computers) as parameter
        public static void WriteData(List<Computer> computers)
        {
            var curDirectory = new DirectoryInfo(CurrentPath);
            if (!curDirectory.Exists)
                curDirectory.Create();

            // Создаем файл.
            var file = new FileInfo(CurrentPath + "\\" + CurrentFile);

            // С помощью экземпляра StreamWriter записываем в файл несколько строк текста. 
            using (StreamWriter writer = file.AppendText())
            {
                foreach (var computer in computers)
                {
                    writer.WriteLine($"{computer.Cores},{computer.Frequency},{computer.Hdd},{computer.Memory}");
                }
                Console.WriteLine($"Сохранение в файл {file} завершено. Исходный размер: {file.Length.ToString()}.");
            }
        }

        // ReadData() – read data from file
        // method returns info about computers after reading it from file
        public static void ReadData()
        {
            string input;
            var file = new FileInfo(CurrentPath + "\\" + CurrentFile);
            if (file.Exists)
            {
                using (StreamReader reader = file.OpenText())
                {
                    // Выводим содержимое файла в консоль.
                    while ((input = reader.ReadLine()) != null)
                    {
                        string[] result = input.Split(',');
                        Console.WriteLine($"Cores: {result[0]},Frequency: {result[1]},Hdd: {result[2]},Memory: {result[3]}");
                    }
                }
            }                    
        }

        // WriteZip() – save data to zip file
        // method takes data (info about computers) as parameter
        public static void WriteZip()
        {
            string sourceFile = CurrentPath + "\\" + CurrentFile;
            string[] temp = CurrentFile.Split('.');
            string compressedFile = $"{CurrentPath}\\{temp[0]}.gz";

            // поток для чтения исходного файла
            using (FileStream sourceStream = new FileStream(sourceFile, FileMode.OpenOrCreate))
            {
                // поток для записи сжатого файла
                using (FileStream targetStream = File.Create(compressedFile))
                {
                    // поток архивации
                    using (GZipStream compressionStream = new GZipStream(targetStream, CompressionMode.Compress))
                    {
                        sourceStream.CopyTo(compressionStream); // копируем байты из одного потока в другой
                        Console.WriteLine($"Сжатие файла {sourceFile} завершено. Исходный размер: {sourceStream.Length.ToString()}  сжатый размер: {targetStream.Length.ToString()}.");
                    }
                }
            }
        }

        // ReadZip() – read data from file
        // method returns info about computers after reading it from file
        public static void ReadZip()
        {
            string[] temp = CurrentFile.Split('.');
            string compressedFile = $"{CurrentPath}\\{temp[0]}.gz";
            string input;

            // поток для чтения из сжатого файла
            using (FileStream sourceStream = new FileStream(compressedFile, FileMode.OpenOrCreate))
            {
                // поток разархивации
                using (GZipStream decompressionStream = new GZipStream(sourceStream, CompressionMode.Decompress))
                {
                    using (StreamReader sr = new StreamReader(decompressionStream))
                    {
                        while (!sr.EndOfStream)
                        {
                            if ((input = sr.ReadLine()) != null)
                            {
                                string[] result = input.Split(',');
                                Console.WriteLine($"Cores: {result[0]},Frequency: {result[1]},Hdd: {result[2]},Memory: {result[3]}");
                            }
                        }
                    }
                }
            }
        }

        // ReadAsync() – read data from file asynchronously
        // method is async
        // method returns Task with info about computers
        // use ReadLineAsync() method to read data from file
        // Note: don't forget about await
        public static async Task ReadAsync()
        {
            string sourceFile = CurrentPath + "\\" + CurrentFile;
            string input;

            using (StreamReader reader = new StreamReader(sourceFile))
            {
                while ((input = await reader.ReadLineAsync()) != null) // асинхронное чтение из файла
                {
                    string[] result = input.Split(',');
                    Console.WriteLine($"Cores: {result[0]},Frequency: {result[1]},Hdd: {result[2]},Memory: {result[3]}");
                }
            }

            //await Task.Run(() => ReadData());
        }

        // 7)
        // ADVANCED:
        // WriteToMemoryStream() – save data to memory stream
        // method takes data (info about computers) as parameter
        // info about computers is saved to Memory Stream
        public static void WriteToMemoryStream(List<Computer> computers)
        {
            using (var memory = new MemoryStream())
            {
                foreach (var computer in computers)
                {
                    string temp = String.Concat($"{computer.Cores},{computer.Frequency},{computer.Hdd},{computer.Memory}");
                    byte[] bytes = Encoding.ASCII.GetBytes(temp);

                    // Записываем байты в поток.
                    for (var i = 0; i < bytes.Length; i++)
                    {
                        memory.WriteByte(bytes[i]);
                    }
                }
                Console.WriteLine($"Запись в MemoryStream произведена успешно.");
            }
        }

        // use  method GetBytes() from class UnicodeEncoding to save array of bytes from string data 
        // create new file stream
        // use method WriteTo() to save memory stream to file stream 
        // method returns file stream

        // WriteToFileFromMemoryStream() – save data to file from memory stream and read it
        // method takes file stream as parameter
        // save data to file
        public static void WriteToFileFromMemoryStream()
        {

        }


        // Note: 
        // - use '//' in path string or @ before it (for correct path handling without escape sequence)
        // - use 'using' keyword to organize correct working with files
        // - don't forget to check path before any file or directory operations
        // - don't forget to check existed directory and file before creating
        // use File class to check files, Directory class to check directories, Path to check path

        #endregion
    }
}
