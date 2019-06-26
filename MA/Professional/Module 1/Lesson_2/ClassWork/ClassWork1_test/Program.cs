using System;
using System.Reflection;

namespace ClassWork1_test
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Assembly
            //Assembly asm = Assembly.Load("ClassWork_new");
            //Console.WriteLine($"GAC : {asm.GlobalAssemblyCache}");
            //Console.WriteLine($"Name : {asm.GetName().Name}");
            //Console.WriteLine($"Version : {asm.GetName().Version}");
            //Console.WriteLine($"Culture : {asm.GetName().CultureInfo.DisplayName}");

            //Console.WriteLine();
            //Console.WriteLine("// ------------------------------------------------------------------------");
            #endregion

            #region GetCustomAttribute
            Assembly asm = Assembly.Load("ClassWork_new");
            Type BirdSpecies = asm.GetType("ClassWork_new.BirdSpeciesAttribute");
            PropertyInfo Prop_cl = BirdSpecies.GetProperty("Classification");
            Type[] types = asm.GetTypes();

            foreach (var t in types)
            {
                object[] objs = t.GetCustomAttributes(BirdSpecies, false);
                foreach (var ob in objs)
                    Console.WriteLine($" - {t.Name} : {Prop_cl.GetValue(ob, null)}");
            }
            Console.ReadKey();
            #endregion

            #region Type
            //Type[] types = asm.GetTypes();
            //Console.WriteLine();
            //Console.WriteLine("Types:");
            //foreach (var itm in types)
            //{
            //    Console.WriteLine("Type: {0}", itm);
            //    ListMethod(itm);
            //}

            //Console.WriteLine();
            //Console.WriteLine("// ------------------------------------------------------------------------");
            #endregion
        }

        static void ListMethod(Type t)
        {
            Console.WriteLine();
            Console.WriteLine("Methods:");
            MethodInfo[] meth = t.GetMethods();
            foreach (MethodInfo me in meth)
            {
                string retVal = me.ReturnType.FullName;
                string prm = "( ";

                foreach (ParameterInfo pi in me.GetParameters())
                {
                    prm += string.Format("type " + pi.ParameterType + " " + pi.Name);
                }
                prm += " )";

                Console.WriteLine(" Full name " + retVal + "." + me.Name + prm);
            }
            Console.WriteLine();
        }
    }
}
