using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Java java = new Java(10, "java EE", 1.23, 7);
                C c = new C(11, "C", 4.56, 4);
                Cpp cpp = new Lab3.Cpp(789, "C++", 7.89, 17);

                Programmer progr = new Programmer();
                //подписка на событие New Version
                progr.Update += java.NewVersion;
                progr.Update += cpp.NewVersion;
                //событие происходит
                progr.OnUpdate();

                //подписка на событие Reset
                progr.Reset += java.DoReset;
                progr.Reset += c.DoReset;
                progr.Reset += cpp.DoReset;
                //event
                progr.OnReset();

                Console.WriteLine();
                String s = "x";
                int i = 0;

                Reflector.MethodA(java);    // all information to file
                Reflector.MethodB(java);    // all public methods
                Reflector.MethodC(java);    // Fields and Properties
                Reflector.MethodD(java);    // INterfaces
                Reflector.MethodE(java, i); //methods with param

                string className = "Lab3.Java";
                string methodName = "Method";
                Reflector.MethodF(className, methodName);

                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.Message);

            }
            finally
            {
                Console.WriteLine("Program cancelled");
                Console.ReadKey();
            }
        }
    }
}