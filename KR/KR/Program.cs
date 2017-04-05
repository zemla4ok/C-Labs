using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR
{
    class Program
    {
        static void Main(string[] args)
        {
            ////1
            //Console.WriteLine(E.A + "  " + E.B + "  " + E.C);
            //string s = "123.456.789";
            //string[] s1 = new string[3];
            //s1 = s.Split('.');
            //for (int i = 0; i < 3; i++)
            //{
            //    Console.WriteLine(s1[i]);
            //}
            //int[] ia = new int[4] { 1, 2, 3, 4 };
            //int z = 0;
            //for (int i = 0; i < 4; i++)
            //{
            //    z *= 10;
            //    z += ia[i];
            //}
            //Console.WriteLine(z);

            ////2
            //Computer c1 = new Computer(1, 2);
            //Computer c2 = new Computer(2, 10);
            //Console.WriteLine(c1.CompareTo(c2));

            //3
            //Case c = new KR.Case();
            //c.ItsOk();
            //c.Fine();
            //4

            //5
            string[] str1 = new string[2] { "asdf", "asds" };
            string[] str2 = new string[3] { "sadsf", "asds", "Asdsa" };   
            Console.WriteLine(str1.Concat(str2).Count());
            //6
            A a = new A();
            Ev e = new Ev();
            e.Some += a.M1;
            e.Some += a.M2;
            e.Some += a.M3;
            e.OnSome();
        }
    }
    //1
    enum E { A, B, C };
    //2
    class Computer : IComparable<Computer>
    {
        public const int a = 3;
        public static int b;
        public int c;

        public Computer(int pb, int pc)
        {
            b = pb;
            c = pc;
        }
        public int CompareTo(Computer other)
        {
            if (this.c < other.c)
                return -1;
            else
            if (this.c > other.c)
                return 1;
            return 0;
        }


    }
    //3
    interface IGood
    {
        void Fine();

    }
    abstract class Something : IGood
    {
        public void Fine()
        {
            throw new NotImplementedException();
        }

        public abstract void ItsOk();
    }
    class Case : Something
    {
        public override void ItsOk()
        {
            throw new NotImplementedException();
        }
    }
    //4
    class SuperDic<T, R> 
    {
        Dictionary<T, R> d = new Dictionary<T, R>();

        void Find(T obj)
        {
            for (int i = 0; i < d.Count; i++)
            {
            }
        }
    }
    //6
    delegate void UI();
    class Ev
    {
        public event UI Some;

        public void OnSome()
        {
            Some();
        }
    }
    class A
    {
         public void M1()
        {
            Console.Write("Martch, ");
        }
        public void M2()
        {
            Console.Write("25, 1917, 2017, ");
        }
        public void M3()
        {
            Console.Write("May");
        }
    }
}