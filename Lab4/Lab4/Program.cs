using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Program
    {
        delegate bool CountInt(MyClass mc, int num);
        delegate bool CountFromDiap(MyClass mc, int s, int e);

        static void Main(string[] args)
        {
            CountInt ci = (mc, num) =>
            {
                if (mc.myVal == num)
                    return true;
                else
                    return false;
            };
            CountFromDiap cfi = (mc, s, e) =>
            {
                if (mc.myVal >= s && mc.myVal <= e)
                    return true;
                else
                    return false;
            };

            try
            {
                Collection<MyClass> col = new Collection<MyClass>();
                col.SetElementToEnd(new MyClass(10));
                col.SetElementToEnd(new MyClass(5));
                col.SetElementToEnd(new MyClass(0));
                col.SetElementToEnd(new MyClass(32));
                col.SetElementToEnd(new MyClass(0));
                col.SetElementToEnd(new MyClass(8));
                col.SetElementToEnd(new MyClass(70));

                string path = "F:\\zu.txt";
                StreamWriter sw;
                FileInfo fi = new FileInfo(path);
                sw = fi.AppendText();
                for (int i = 0; i < col.GetMyQueue().Count(); i++)
                {
                    Console.WriteLine(col[i].myVal);//file
                }

                int counter = 0;
                for (int i = 0; i < col.GetMyQueue().Count(); i++)
                {
                    if (ci(col[i], 0))
                        counter++;
                }
                Console.WriteLine("Count of zeros: " + counter);

                counter = 0;
                for (int i = 0; i < col.GetMyQueue().Count(); i++)
                {
                    if (cfi(col[i], 5, 10))
                        counter++;
                }
                Console.WriteLine("Count from diap: " + counter);

                Queue<string> qs = new Queue<string>();
                qs.Enqueue("hello");
                qs.Enqueue("world");
                qs.Enqueue("sdfsdf");
                qs.Enqueue("dimasik");
                qs.Enqueue("good");

                for (int i = 0; i < qs.Count(); i++)
                {
                    Console.WriteLine(qs.ElementAt(i));
                }

                counter = 0;
                for (int i = 0; i < qs.Count(); i++)
                {
                    if (qs.ElementAt(i).Length == 5)
                        counter++;
                }
                Console.WriteLine("Elements with length 5: " + counter);

                var sq = from i in qs
                         where i.Length == 5
                         select i;
                Console.WriteLine("********" + sq.Count());


                Console.WriteLine("After sorting by length");
                var sortedQS = from i in qs
                               orderby i.Length
                               select i;
                foreach (String i in sortedQS)
                    Console.WriteLine(i);
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (MemberAccessException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Program ended");
            }
        }
    }
}