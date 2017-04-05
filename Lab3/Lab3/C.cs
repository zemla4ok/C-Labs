using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab3
{
    class C : ProgLang, Operations
    {
        D del;
        public C(int pi, String ps, double pd)
        {
            this.integerType = pi;
            this.stringType = ps;
            this.doubleType = pd;
        }
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
    }

    sealed class Cpp : ProgLang, Operations
    {
        public Cpp() { }
        public Cpp(int pi, string ps, double pd)
        {
            this.integerType = pi;
            this.stringType = ps;
            this.doubleType = pd;
        }
        public void WriteToFile()
        {
            using (StreamWriter outf = new StreamWriter(new FileStream(@"F:\log.txt", FileMode.OpenOrCreate)))
            {
                if (outf == null)
                    throw new NullReferenceException();
                outf.WriteLine("int=" + integerType + ", str=" + stringType + ", bdl=" + doubleType + ";      ");
                Console.WriteLine("int=" + integerType + ", str=" + stringType + ", bdl=" + doubleType + ";      ");
            }
        }
        public Tuple<int, String, double> Cortage(int pInt, String pString, double pDouble)
        {
            int rcInt = pInt + integerType;
            String rcStr = pString + stringType;
            double rcDouble = pDouble + doubleType;
            return Tuple.Create<int, String, double>(rcInt, rcStr, rcDouble);
        }
        public static Cpp operator +(Cpp obj1, Cpp obj2)
        {
            Cpp rc = new Cpp();
            checked
            {
                rc.doubleType = obj1.doubleType + obj2.doubleType;
                rc.integerType = obj1.integerType + obj2.integerType;
                rc.stringType = obj2.stringType + obj1.stringType;
            }
            return rc;
        }
        public static Cpp operator -(Cpp obj1, Cpp obj2)
        {
            Cpp rc = new Cpp();
            checked
            {
                rc.doubleType = obj1.doubleType - obj2.doubleType;
                rc.integerType = obj1.integerType - obj2.integerType;
            }
            return rc;
        }
        public static Cpp operator /(Cpp obj1, Cpp obj2)
        {
            Cpp rc = new Cpp();
            checked
            {
                rc.doubleType = obj1.doubleType / obj2.doubleType;
                rc.integerType = obj1.integerType / obj2.integerType;
            }
            return rc;
        }
        public static Cpp operator *(Cpp obj1, Cpp obj2)
        {
            Cpp rc = new Cpp();
            checked
            {
                rc.doubleType = obj1.doubleType * obj2.doubleType;
                rc.integerType = obj1.integerType * obj2.integerType;
            }
            return rc;
        }

        public static bool operator <(Cpp obj1, Cpp obj2)
        {
            if (obj1.GetHashCode() < obj2.GetHashCode())
                return true;
            else return false;
        }
        public static bool operator >(Cpp obj1, Cpp obj2)
        {
            if (obj1.GetHashCode() > obj2.GetHashCode())
                return true;
            else return false;
        }
        public static bool operator ==(Cpp obj1, Cpp obj2)
        {
            if (obj1.GetHashCode() == obj1.GetHashCode())
                return true;
            else return false;
        }
        public static bool operator !=(Cpp obj1, Cpp obj2)
        {
            if (obj1.GetHashCode() != obj1.GetHashCode())
                return true;
            else return false;
        }
    }
}