using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClassWork_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Intro();

            //Console.WriteLine();
            //Console.WriteLine("Calling method with unsafe code");

            //// Window for rotate
            //int w = 10, h = 20;

            //// Rotate window "safely"
            //Console.WriteLine("\r\nSafe rotate");
            //Console.WriteLine("Window before safe rotate: width = {0}, height = {1}", w, h);
            //SafeRotate(ref w, ref h);
            //Console.WriteLine("Window after safe Rotate: width = {0}, height = {1}", w, h);

            //// Rotate window "unsafely"
            //Console.WriteLine("\r\nUnsafe Rotate");
            //Console.WriteLine("Window before unsafe Rotate: width = {0}, height = {1}", w, h);

            //unsafe { UnsafeRotate(&w, &h); }

            //Console.WriteLine("Window after unsafe Rotate: width = {0}, height = {1}", w, h);

            //UseFixed();

            //StructPointers();

            FixedWindowSize();
        }

        unsafe public static void Intro()
        {
            int* a;
            int b = 8;
            a = &b;

            Console.WriteLine(*a);
            Console.WriteLine($"Value of b {b}");
            Console.WriteLine($"Address of b {(int)a:X}");

            b = b + 8;
            Console.WriteLine(*a);

            *a = 2;
            Console.WriteLine(b);
        }

        public static void SafeRotate(ref int i, ref int j)
        {
            int temp = i;
            i = j;
            j = temp;
        }

        unsafe public static void UnsafeRotate(int* i, int* j)
        {
            int temp = *i;
            *i = *j;
            *j = temp;
        }

        unsafe static void UseFixed()
        {
            var watch = Stopwatch.StartNew();
            int[] Nmbrs = new int[8] { 0, 1, 2, 3, 4, 5, 6, 7 };

            Console.WriteLine("\r\nIndexing pointer like array");

            fixed (int* ptr = Nmbrs)
            {
                for (int i = 0; i < 8; i++)
                    ptr[i] = i;

                for (int i = 0; i < 8; i++)
                    Console.WriteLine("ptr[{0}]: {1} ", i, ptr[i]);
            }

            watch.Stop();
            Console.WriteLine(watch.ElapsedTicks);
            watch.Reset();

            Console.WriteLine("\r\nArithmetic operations with pointers");

            watch.Start();
            fixed (int* ptr = Nmbrs)
            {

                for (int i = 0; i < 8; i++)
                    *(ptr + i) = i;

                for (int i = 0; i < 8; i++)
                    Console.WriteLine("*(ptr+{0}): {1} ", i, *(ptr + i));

            }
            watch.Stop();
            Console.WriteLine(watch.ElapsedTicks);
            watch.Reset();
        }

        unsafe static void StructPointers()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            MySize wnd;
            MySize* ptr = &wnd;
            ptr->MyWidth = 300;
            ptr->MyHeight = 100;
            Console.WriteLine("\r\nStructure via pointers");
            Console.WriteLine("{0} {1}", ptr->MyWidth, ptr->MyHeight);
            Console.WriteLine("Structure ");
            Console.WriteLine("{0} {1}", wnd.MyWidth, wnd.MyHeight);

            watch.Stop();
            Console.WriteLine("Time:  " + watch.ElapsedTicks);
            watch.Reset();

            watch.Start();
            MySize wnd2;
            MySize* ptr_2 = &wnd2;
            (*ptr_2).MyWidth = 300;
            (*ptr_2).MyHeight = 100;
            Console.WriteLine("Structure via pointers indirection");
            Console.WriteLine("{0} {1}", wnd2.MyWidth.ToString(), wnd2.MyHeight.ToString());
            watch.Stop();
            Console.WriteLine("Time:  " + watch.ElapsedTicks);
            watch.Reset();
        }

        struct MySize{
            public int MyWidth;
            public int MyHeight;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        unsafe struct FixedWindow
        {
            public fixed byte WindowTitle[50];
            public int Width;
            public int Height;

        }

        unsafe static void FixedWindowSize()
        {
            Console.WriteLine($"SizeOf = {sizeof(FixedWindow)}");
        }
    }
}
