using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_2
{   
    class Straight
    { 
        
        public int len = 0;
        public readonly int ro;
        const double pi = 3.14d;
        public static int count = 0;

        public Straight()
        {
            Console.WriteLine("Constr without param");
            count++;
        }
        public Straight(int px1, int py1, int px2, int py2, int pz1, int pz2)
        {
            Console.WriteLine("Constr with param");
            X1 = px1;
            Y1 = py1;
            X2 = px1;
            Y2 = py2;
            Z1 = pz1;
            Z2 = pz2;
            ro = GetHashCode();
            count++;
        }

        private int x1;
        public int X1 { get { return x1; } set { x1 = value; } }
        public int Y1 { get; set; }
        public int Z1 { get; set; }
        private int x2;
        public int X2 { get { return x2; } set { x2 = value; } }
        public int Y2 { get; set; }
        public int Z2 { get; set; }

        public static void WriteInf()
        {
            Console.WriteLine("Const pi = {0}", pi);
            Console.WriteLine("count = {0}", count);
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (!(obj is Straight))
                return false;
            if (len == ((Straight)obj).len)
                return true;
            else
                return false;
        }
        public override int GetHashCode()
        {
            return (x1 + x2) / 2 + (Y1 - Y2) * 2;
        }       
    }

    static class MathObject
    {
        public static double Len(ref int px, ref int py, out int pz)
        {
            double rc;
            pz = 12;
            rc = px + py + pz;
            return rc;
        }
        
        public static int Length(Straight obj)
        {
            obj.len = (int)Math.Sqrt(Math.Pow((obj.X2 - obj.X1), 2) + Math.Pow((obj.Y2 - obj.Y1), 2));
            return 0;
        }
        public static bool InputBox(this int x, int y, int z, Straight obj)
        {
            if ((Math.Abs(obj.X2 - obj.X1) <= x) &&
                (Math.Abs(obj.Y2 - obj.Y1) <= y) &&
                (Math.Abs(obj.Z2 - obj.Z1) <= z)
                )
                return true;
            else
                return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int x = 10, y = 8, z;
            Console.Write(MathObject.Len(ref x,  ref y, out z));



            /*
            Straight Str = new Straight();
            Str.X1 = 1;
            Console.WriteLine(Str.X1);

            Straight Str1 = new Straight(10, 100, 20, 200, 10, 100);
            Console.WriteLine("Hash of element is {0}", Str1.ro);
            //Str1.ro = 10;
            Straight.WriteInf();

            Straight Str2 = new Straight(100, 10, 20, 200, 30, 300);
            MathObject.Length(Str1);
            MathObject.Length(Str2);

            if (Str1.Equals(Str1))
                Console.WriteLine("Equal");
            else
                Console.Write("Non-Equal");

            if (Str1.Equals(Str2))
                Console.WriteLine("Equal");
            else
                Console.WriteLine("Non-Equal");

            if (MathObject.InputBox(100, 200, 100, Str2))
                Console.WriteLine("Good");
            else
                Console.WriteLine("Bad");

            int a = 10;
            a.InputBox(100, 159, Str2);

            var student = new { Name = "Dima", age = 19 };
            Console.WriteLine("Name: {0}, Age: {1}", student.Name, student.age);
            */

            //Delay
            Console.ReadKey();
        }
    }

    class A
    {
        private int _num;
        public A(int num) { Num = num; }
        public int Num { get { return _num; } set { _num = value; } }
    }
}