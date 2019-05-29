using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                FlStream_BArr();

                //ZipFile("System.dll", "System.gz");
                //UnZipFile("System.dll.gz", "System.dll.tst");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void ZipFile(string inFl, string outFl)
        {
            FileStream src = File.OpenRead(inFl);
            FileStream dst = File.Create(outFl);

            GZipStream zipStream = new GZipStream(dst, CompressionMode.Compress);

            int oneByte = src.ReadByte();

            while (oneByte != -1)
            {
                zipStream.WriteByte((byte)oneByte);
                oneByte = src.ReadByte();
            }

            src.Close();
            zipStream.Close();
            dst.Close();
        }

        static void UnZipFile(string inFl, string outFl)
        {
            FileStream src = File.OpenRead(inFl);
            FileStream dst = File.Create(outFl);
            // Create compressed stream
            GZipStream Zip_Stream = new GZipStream(src, CompressionMode.Decompress);
            // Write  data
            int One_Byte = Zip_Stream.ReadByte();
            while (One_Byte != -1)
            {
                dst.WriteByte((byte)One_Byte);
                One_Byte = Zip_Stream.ReadByte();
            }
            // Clear
            src.Close();
            Zip_Stream.Close();
            dst.Close();
        }

        static void FlStream_BArr()
        {
            Console.WriteLine("FileStreams - Byte Arrays");
            try
            {
                // Get a FileStream 
                using (FileStream Fl_Stream = File.Open("Hello_io_message.txt", FileMode.Create))
                {
                    // Encode a string as an bytes array .
                    string msg = "Hello I/O!";
                    byte[] msg_BArr = Encoding.Default.GetBytes(msg);
                    // Write array to file
                    Fl_Stream.Write(msg_BArr, 0, msg_BArr.Length);
                    // Reset internal position of stream
                    Fl_Stream.Position = 0;
                    // Read the types from file and display to standart output
                    Console.Write("Array of bytes: ");
                    byte[] BArr_FromFile = new byte[msg_BArr.Length];
                    for (int i = 0; i < msg_BArr.Length; i++)
                    {
                        BArr_FromFile[i] = (byte)Fl_Stream.ReadByte();
                        Console.Write(BArr_FromFile[i]);
                    }
                    // Display decoded messages.
                    Console.WriteLine(" Decoded Message: ");
                    Console.WriteLine(Encoding.Default.GetString(BArr_FromFile));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }

        static void Method1()
        {
            using (StreamWriter strWr = new StreamWriter("Hello.txt"))
            {
                strWr.Write("Hello");
                strWr.WriteLine("_IO_");
                strWr.WriteLine("Hello");
            }

            using (StreamWriter strWr1 = new StreamWriter("Hello.txt", true))
            {
                strWr1.WriteLine(" !");
            }
        }

        static void Method2()
        {
            using (FileStream flStream = new FileStream("Hello.txt", FileMode.Open))
            {

                using (StreamReader strRd = new StreamReader(flStream))
                {
                    Console.WriteLine(strRd.ReadToEnd());
                }
            }

            using (StreamReader strRd = new StreamReader("Hello.txt", System.Text.Encoding.Default))
            {
                char[] array = new char[4];
                strRd.Read(array, 0, 4);
                Console.WriteLine(array);
            }
        }

        static void Method3()
        {
            FileInfo fileInfo = new FileInfo("Hello.txt");
            using (BinaryWriter binaryWriter = new BinaryWriter(fileInfo.OpenWrite()))
            {
                Console.WriteLine("Base: {0}");
            }
        }
}
}
