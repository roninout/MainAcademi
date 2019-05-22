using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_4
{
    class Program
    {
        static void Main(string[] args)
        {
            // ������� ���������.
            var �ollection = new CustomCollection<Element>();

            // �������� � ��������� 4 ��������.
            �ollection[0] = new Element(1, 2);
            �ollection[1] = new Element(3, 4);
            �ollection[2] = new Element(5, 6);
            �ollection[3] = new Element(7, 8);

            // � ����������� ����������� foreach ������� ���������� ��������� �� �����.
            foreach (var element in �ollection)
            {
                Console.WriteLine($"{element.FieldA}, {element.FieldB}");
            }

            Console.WriteLine(new string('-', 5));

            // � ����������� ����������� foreach ������� ���������� ��������� �� �����.
            foreach (var element in �ollection)
            {
                Console.WriteLine($"{element.FieldA}, {element.FieldB}");
            }

            // Delay.
            Console.ReadKey();
        }
    }
}
