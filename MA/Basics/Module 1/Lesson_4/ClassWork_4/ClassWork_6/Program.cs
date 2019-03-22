using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal animal;
            animal.species = "cat";
            animal.name = "Tazik";
            animal.age = 3;
            animal.sex = Sex.Male;
            //Console.WriteLine(animal.name);

            animal.Write();

            Animal animal2 = new Animal();
            animal2.species = animal.species;
            animal2.name = "Milka";
            animal2.age = 5;
            animal2.sex = Sex.Female;

            animal2.Write();
        }
    }

    struct Animal
    {
        public string species;
        public string name;
        public int age;
        public Sex sex;

        public void Write()
        {
            Console.WriteLine($"Species: {species} Name: {name} Age: {age} Sex: {sex}");
            Console.WriteLine(new string('-',50));
        }
    }

    enum Sex
    {
        Male,
        Female
    }
}
