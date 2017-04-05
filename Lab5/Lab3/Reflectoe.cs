using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace Lab3
{
    class Reflector
    {
        public static void MethodA<T>(T obj)
        {
            using (StreamWriter sw = new StreamWriter(@"F:\2kyrs\2sem\С#\lab\Lab6\info.txt", false, Encoding.ASCII, 32))
            {
                Type t = typeof(T);
                Console.WriteLine("Information about class " + obj.GetType());
                sw.WriteLine("Information about class " + obj.GetType());

                Console.WriteLine("---Constructors---");
                sw.WriteLine("---Constructors---");
                ConstructorInfo[] constArr = t.GetConstructors();
                foreach (ConstructorInfo c in constArr)
                {
                    Console.WriteLine("> " + c.ReflectedType.Name);
                    sw.WriteLine("> " + c.ReflectedType.Name);
                }

                Console.WriteLine("---Methods---");
                sw.WriteLine("---Methods---");
                MethodInfo[] methArr = t.GetMethods();
                foreach (MethodInfo m in methArr)
                {
                    Console.WriteLine("> " + m.Name);
                    sw.WriteLine("> " + m.Name);
                }

                Console.WriteLine("---Fields---");
                sw.WriteLine("---Fields---");
                FieldInfo[] fieldArr = t.GetFields();
                foreach (FieldInfo f in fieldArr)
                {
                    Console.WriteLine("> " + f.Name);
                    sw.WriteLine("> " + f.Name);
                }

                Console.WriteLine("---Properties---");
                sw.WriteLine("---Properties---");
                PropertyInfo[] prArr = t.GetProperties();
                foreach (PropertyInfo p in prArr)
                {
                    Console.WriteLine("> " + p.Name);
                    sw.WriteLine("> " + p.Name);
                }

                Console.WriteLine();
            }
        }
        public static void MethodB<T>(T obj) where T : class
        {
            Type t = typeof(T);

            MethodInfo[] arr = t.GetMethods();
            Console.WriteLine("Methods of class " + obj.GetType());
            foreach (MethodInfo m in arr)
            {
                if (m.IsPublic)
                    Console.WriteLine("-- " + m.ReflectedType.Name + "\t" + m.Name);
            }
            Console.WriteLine();
        }
        public static void MethodC<T>(T obj)
        {
            Type t = typeof(T);
            Console.WriteLine(obj.GetType());
            Console.WriteLine("---Fields---");
            FieldInfo[] fieldArr = t.GetFields();
            foreach (FieldInfo f in fieldArr)
            {
                Console.WriteLine("> " + f.Name);
            }

            Console.WriteLine("---Properties---");
            PropertyInfo[] prArr = t.GetProperties();
            foreach (PropertyInfo p in prArr)
            {
                Console.WriteLine("> " + p.Name);
            }

            Console.WriteLine();
        }
        public static void MethodD<T>(T obj)
        {
            Type t = typeof(T);
            Console.WriteLine(t.GetType());

            Console.WriteLine("---INterfaces---");
            Type[] interArr = t.GetInterfaces();
            foreach (Type ti in interArr)
            {
                Console.WriteLine("> " + ti.Name);
            }
        }
        public static void MethodE<T, P>(T obj, P par)
        {
            Type t = typeof(T);
            MethodInfo[] MArr = t.GetMethods();
            Type pa = typeof(P);

            bool fl = false;
            Console.WriteLine("\n---Methods with " + pa.Name + "---");

            foreach (MethodInfo m in MArr)
            {
                ParameterInfo[] p = m.GetParameters();
                for (int i = 0; i < p.Length; i++)
                {
                    if (p[i].ParameterType == par.GetType())
                    {
                        fl = true;
                    }
                }
                if (fl)
                {
                    Console.WriteLine("> " + m.Name);
                    fl = false;
                }
            }
        }
        public static void MethodF(string className, String methodName)
        {
            Console.WriteLine("\n---Cast method---");

            Type type = Type.GetType(className, false, true);
            MethodInfo method = type.GetMethod(methodName);
            object classinstance = Activator.CreateInstance(type);

            using (StreamReader sr = new StreamReader(@"F:\2kyrs\2sem\С#\lab\Lab6\params.txt"))
            {
                object[] paramArray = sr.ReadToEnd().Split(' ');
                try
                {
                    method.Invoke(classinstance, paramArray);
                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                }
            }
        }
    }
}

//TODO: output to file in MethodA