using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //singleton
                Scala.getInstance().doubleType = 123.123;
                Scala.getInstance().integerType = 123;
                Scala.getInstance().stringType = "qwerty";
                Scala.getInstance().WriteToFile();



                C ci = new C(147, "258", 3.69);
                var z = ci.Cortage(123, "456", 7.89);
                Console.WriteLine("cortage");
                Console.WriteLine("i={0}, s={1}, d={2}", z.Item1, z.Item2, z.Item3);


                Console.WriteLine("\n");
                Cpp cpp1 = new Cpp(123, "456", 7.89);
                Cpp cpp2 = new Cpp(147, "258", 3.69);
                Cpp cpp = new Cpp();
                Console.WriteLine("cpp1");
                cpp1.WriteToFile();
                Console.WriteLine("cpp2");
                cpp2.WriteToFile();
                cpp = cpp1 + cpp2;
                Console.WriteLine("+");
                cpp.WriteToFile();

                cpp = cpp1 - cpp2;
                Console.WriteLine("-");
                cpp.WriteToFile();
                
                cpp = cpp1 * cpp2;
                Console.WriteLine("*");
                cpp.WriteToFile();

                cpp = cpp1 / cpp2;
                Console.WriteLine("/");
                cpp.WriteToFile();

                Console.WriteLine("<");
                if (cpp1 < cpp2)
                    Console.WriteLine("true");
                else Console.WriteLine("false");

                Console.WriteLine(">");
                if (cpp1 > cpp2)
                    Console.WriteLine("true");
                else Console.WriteLine("false");

                Console.WriteLine("=");
                if (cpp1 == cpp2)
                    Console.WriteLine("true");
                else Console.WriteLine("false");

                Console.WriteLine("!=");
                if (cpp1 != cpp2)
                    Console.WriteLine("true");
                else Console.WriteLine("false");
                Console.WriteLine("\n");

                Console.WriteLine("Memento----------------");
                Java jva = new Java(1, "2", 1.2);
                Console.WriteLine("before save");
                jva.WriteToFile();
                Restorer rst = new Restorer();
                Memento mem = rst.SaveState(jva);
                jva.integerType = 4;
                Console.WriteLine("new jva");
                jva.WriteToFile();
                rst.RestoreState(jva, mem);
                Console.WriteLine("restate");
                jva.WriteToFile();

                Console.WriteLine("\n");
                Java jv = new Java(100, "2", 3.45);
                jv.WriteToFile();
                Object obj = jv as Object;
                if (jv is Object)
                    Console.WriteLine("yo");
            }
            catch (Exception)
            {
                Console.WriteLine("Error");
            }
            finally
            {
                Console.WriteLine("Program cancelled");
                Console.ReadKey();
            }
        }
    }
}