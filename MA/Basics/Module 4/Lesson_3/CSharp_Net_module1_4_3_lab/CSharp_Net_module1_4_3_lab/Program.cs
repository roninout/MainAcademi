using System;

namespace CSharp_Net_module1_4_3_lab
{
    class Program
    {
        static void Main(string[] args)
        {
            // 10) Create an array of Animal objects and object of Animals
            Animal animal1 = new Animal("Dog", 12);
            Animal animal2 = new Animal("Catt", 13);
            Animal animal3 = new Animal("Chiken", 14);

            Animal[] array = { animal1, animal2, animal3 };

            Animals animals = new Animals(animal1 , animal2 , animal3);

            // print animals with foreach operator for object of Animals
            Console.WriteLine("---------object of Animals---------");
            foreach (Animal item in animals)
                Console.WriteLine($"{item.Genus} {item.Weight}");

            // 11) Invoke 3 types of sorting
            Console.WriteLine();
            Console.WriteLine("Invoke 3 types of sorting");
            Console.WriteLine();

            Console.WriteLine("---------Standart---------");
            Array.Sort(array);
            foreach (Animal item in array)
                Console.WriteLine($"{item.Genus} {item.Weight}");

            // Array.Sort(animals, animals, Animal.SortGenusDescending().Compare());
            Console.WriteLine("---------Genus---------");
            Array.Sort(array, Animal.SortGenusDescending());

            //Animal.SortGenusDescending();
            foreach (Animal item in array)
                Console.WriteLine($"{item.Genus} {item.Weight}");

            Console.WriteLine("---------Weight---------");
            Array.Sort(array, Animal.SortWeightAscending());
            // and print results with foreach operator for array of Animal objects
            foreach (Animal item in array)
                Console.WriteLine($"{item.Genus} {item.Weight}");

            Console.ReadLine();
        }
    }
}
