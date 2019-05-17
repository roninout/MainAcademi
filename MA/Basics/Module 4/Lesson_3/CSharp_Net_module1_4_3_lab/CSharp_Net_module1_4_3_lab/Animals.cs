using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharp_Net_module1_4_3_lab
{
    //6) implement interface IEnumerable
    class Animals : IEnumerable
    {
        // 7) declare private array of Animal
        private Animal[] animals;

        // 8) declare parameter constructor to initialize array 
        public Animals(params Animal[] anim) : base()
        {
            this.animals = new Animal[anim.Length];
            Array.Copy(anim, this.animals, anim.Length);
        }  

        // 9) implement method GetEnumerator(), which returns IEnumerator
        // use foreach on array of Animal
        // and yield return for every animal
        public IEnumerator GetEnumerator()
        {
            foreach (var animal in animals)
                yield return animal;
        }

    }
}
