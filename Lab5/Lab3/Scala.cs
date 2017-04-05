using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab3
{
    class Scala : ProgLang, Operations
    {
        private static Scala instance;
        private Scala() { }
        public static Scala getInstance()
        {
            if (instance == null)
                instance = new Scala();
            return instance;
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

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
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
            Console.WriteLine("Old version " + this.version);
            this.version++;
            Console.WriteLine("Old version " + this.version);
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
}