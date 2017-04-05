using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Lab3
{
    class Java : ProgLang, Operations
    {
        public int zu;
        public Java() { }
        public Java(int pi, String ps, double pd, int pver)
        {
            this.version = pver;
            integerType = pi;
            stringType = ps;
            doubleType = pd;
        }

        public void Method(String str, String i)
        {
            Console.WriteLine(str + "  " + i);  
        }

        D del;
        public void WriteToFile()
        {
            using (StreamWriter outf = new StreamWriter(new FileStream(@"F:\log.txt", FileMode.OpenOrCreate)))
            {
                if (outf == null)
                    throw new NullReferenceException();
                outf.WriteLine("int=" + integerType + ", str=" + stringType + ", bdl=" + doubleType + ";      ");
            }
            Console.WriteLine("int=" + integerType + ", str=" + stringType + ", bdl=" + doubleType + ";      ");
        }
        public override string ToString()
        {
            del = () => { return integerType * 2; };
            return integerType.ToString();
        }
        public Tuple<int, String, double> Cortage(int pInt, String pString, double pDouble)
        {
            int rcInt = pInt + integerType;
            String rcStr = pString + stringType;
            double rcDouble = pDouble + doubleType;
            return Tuple.Create<int, String, double>(rcInt, rcStr, rcDouble);
        }

        ///Lab5
        public void NewVersion()
        {
            Console.WriteLine("Old version of " + this.GetType().Name + " is " + this.version);
            this.version++;
            Console.WriteLine("New version of " + this.GetType().Name + " is " + this.version);
        }
        public void DoReset()
        {
            Console.WriteLine("Before Reset");
            Console.WriteLine("int=" + integerType + ", str=" + stringType + ", bdl=" + doubleType + ";      ");
            this.integerType = 0;
            this.stringType = null;
            this.doubleType = 0.0;
            Console.WriteLine("Before Reset");
            Console.WriteLine("int=" + integerType + ", str=" + stringType + ", bdl=" + doubleType + ";      ");
        }
    }

    class Restorer
    {
        public Memento SaveState(Java obj)
        {
            obj.WriteToFile();
            return new Memento(obj.integerType, obj.stringType, obj.doubleType);
        }
        public void RestoreState(Java obj, Memento mem)
        {
            obj.doubleType = mem.dbl;
            obj.integerType = mem.integ;
            obj.stringType = mem.str;
        }
    }
    class Memento
    {
        public int integ;
        public string str;
        public double dbl;

        public Memento(int pi, string ps, double pd)
        {
            integ = pi;
            str = ps;
            dbl = pd;
        }
    }
    class History
    {
        public Stack<Memento> JavaHistory { get; private set; }
        public History()
        {
            JavaHistory = new Stack<Memento>();
        }
    }
}