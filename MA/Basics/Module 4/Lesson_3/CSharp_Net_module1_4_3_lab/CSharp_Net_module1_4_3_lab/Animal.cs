using System;
using System.Collections;

namespace CSharp_Net_module1_4_3_lab
{
    // 12) change methods of sorting to properties

    // 1) implement interface IComparable
    public class Animal : IComparable
    {
        // 2) declare properties and parameter constructor
        public string Genus { get; set; }
        public int Weight { get; set; }

        public Animal(string genus, int weight)
        {
            Genus = genus;
            Weight = weight;
        }

        // 3) implement method ComareTo()
        public int CompareTo(object obj)
        {
            // it comares Genus of type string - return result of method String.Compare 
            // for this.genus and argument object
            // don't forget to cast object to Animal
            var animal = obj as Animal;
            return animal != null ? Genus.CompareTo(animal.Genus) : throw new Exception("Невозможно сравнить два объекта");
        }


        // 4) declare methods SortWeightAscending(), SortGenusDescending()
        public static IComparer SortWeightAscending()
        {
            return
        }
        // they are static and return IComparer
        // return type is custed from constructor of classes SortWeightAscendingHelper, 
        // SortGenusDescendingHelper calling 


        // 5) declare 2 nested private classes SortWeightAscendingHelper, SortGenusDescendingHelper 
        // they implement interface IComparer
        // every nested class has implemented method Comare with 2 parameters of object and return int
        // class SortWeightAscendingHelper sort weight by ascending
        // class SortGenusDescendingHelper sort genus by descending

    }
}
