using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_2
{
    public class Program
    {
        static void Main(string[] args)
        {
            GenericList1<int, string> list1 = new GenericList1<int, string>();
            GenericList1<int, GenericList1<int, int>> list2 = new GenericList1<int, GenericList1<int, int>>();
            GenericList1<SomeTestClass, object> list3 = new GenericList1<SomeTestClass, object>();

            Console.ReadKey();
        }
    }

    #region GenericList1

    public interface IGenericList<T, U>
    {
        void Add(T inputData1, U inputData2);
    }
    public class GenericList1<T, U> : IGenericList<T, U>
    {
        public void Add(T inputData1, U inputData2) { }
    }
    #endregion

    #region GenericList2
    public interface IGenericList2<T, U> : IGenericList<T, U> where T : class where U : class
    {
        bool CompareAsObjects(T inputData1, U inputData2);
    }

    public class GenericList2<T, U> : IGenericList2<T, U> where T : class where U : class
    {
        public void Add(T inputData1, U inputData2)
        {
            throw new NotImplementedException();
        }

        public bool CompareAsObjects(T inputData1, U inputData2)
        {
            return inputData1 == inputData2;
        }
    }
    #endregion



    class SomeTestClass
    {

    }

}
