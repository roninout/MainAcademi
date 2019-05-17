using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_4
{
    class CustomCollection : ICollection
    {
        private readonly Array array;

        public CustomCollection(Type type, int lenght)
        {
            this.array = Array.CreateInstance(type, lenght);
        }

        public int Count => array.Length;

        public object SyncRoot => this;

        public bool IsSynchronized => (array as ICollection).IsSynchronized;

        public void CopyTo(Array array, int index)
        {
            //Array.CopyTo(array,this.array;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < array.Length; i++)
            {
                yield return array.GetValue(i);
            }
        }
    }
}
